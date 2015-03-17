using System;
using System.ComponentModel;
using System.Reflection;
using System.Threading;
using MiskoPersist.Data;
using MiskoPersist.Enums;
using MiskoPersist.Interfaces;
using MiskoPersist.Message;
using MiskoPersist.Message.Request;
using MiskoPersist.Message.Response;
using MiskoPersist.Resources;

namespace MiskoPersist.Core
{
    public class MessageProcessor
    {
        private static Logger Log = Logger.GetInstance(typeof(MessageProcessor));

        #region Delegates

        public delegate void MessageCompleteHandler(ResponseMessage Response);

        #endregion

        #region Fields

        private readonly MessageCompleteHandler mSuccessHandler_;
        private readonly MessageCompleteHandler mErrorHandler_;
        private readonly RequestMessage mRequest_;

        private static int active = 0;

        #endregion

        #region Properties

        public static IOController IOController { get; set; }

        #endregion

        #region Constructors

        private MessageProcessor(RequestMessage request, MessageCompleteHandler successHandler, MessageCompleteHandler errorHandler)
        {
            if (IOController == null)
            {
                throw new MiskoException(ErrorStrings.errIOControllerIsNull);
            }

            mSuccessHandler_ = successHandler;
            mErrorHandler_ = errorHandler;
            mRequest_ = request;
        }

        #endregion

        #region Private Methods

        private void SendRequest()
        {
            active++;

            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += DoWork;
            bw.RunWorkerCompleted += RunWorkerCompleted;
            bw.RunWorkerAsync();

            IOController.Status(Strings.strPorcessing);
            IOController.MessageSent();
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            ResponseMessage response;
            Boolean resendMessage = false;
            Session session = new Session(mRequest_.Connection);
            session.MessageMode = mRequest_.MessageMode;
            session.RowPerPage = IOController.RowsPerPage;

            try
            {
                IOController.Debug(mRequest_);
            }
            catch (Exception ex)
            {
                IOController.ExceptionHandler(mSuccessHandler_.Target, new ThreadExceptionEventArgs(ex));
            }

            do
            {
                resendMessage = false;
                response = Process(session, mRequest_);

                if (response != null) // Now display warnings and error messages.
                {
                    try
                    {
                        IOController.Debug(response);
                    }
                    catch (Exception ex)
                    {
                        IOController.ExceptionHandler(mSuccessHandler_.Target, new ThreadExceptionEventArgs(ex));
                    }

                    for (int i = 0; i < session.ErrorMessages.Count; i++)
                    {
                        ErrorMessage errorMessage = session.ErrorMessages[i];

                        if (errorMessage.Level.Equals(ErrorLevel.Error))
                        {
                        	IOController.Status(Strings.strError);
                            IOController.Error(errorMessage.Message);
                        }
                        else if (errorMessage.Level.Equals(ErrorLevel.Warning))
                        {
                            IOController.Warning(errorMessage.Message);
                        }
                        else if (errorMessage.Level.Equals(ErrorLevel.Info))
                        {
                            IOController.Info(errorMessage.Message);
                        }
                        else if (errorMessage.Level.Equals(ErrorLevel.Confirmation))
                        {
                            if (errorMessage.Confirmed.HasValue && !errorMessage.Confirmed.Value)
                            {
                                if (IOController.Confirm(errorMessage.Message))
                                {
                                    session.Status = ErrorLevel.Success;
                                    errorMessage.Confirmed = true;
                                    resendMessage = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            while (response != null && resendMessage);

            session.Connection.Close();
            e.Result = response;
        }

        private ResponseMessage Process(Session session, RequestMessage request)
        {
            if (request != null)
            {
                ResponseMessage response = null;
                MessageWrapper wrapper = null;
                DateTime startTime = DateTime.Now;

                try
                {
                    String msgName = request.GetType().Name.Substring(0, request.GetType().Name.Length - 2);
                    String msgPath = request.GetType().FullName.Replace("Requests." + msgName + "RQ", "");

                    response = (ResponseMessage)request.GetType().Assembly.CreateInstance(msgPath + "Responses." + msgName + "RS");
                    wrapper = (MessageWrapper)request.GetType().Assembly.CreateInstance(msgPath + msgName, false, BindingFlags.CreateInstance, null, new object[] { request, response }, null, null);

                    response.Page = new Page(request.Page);

                    session.BeginTransaction();

                    wrapper.GetType().InvokeMember(request.Command, BindingFlags.Default | BindingFlags.InvokeMethod, null, wrapper, new Object[] { session });
                }
                catch (Exception e)
                {
                    session.Status = ErrorLevel.Error;

                    Exception ActualException = e;

                    while (ActualException.InnerException != null)
                    {
                        ActualException = ActualException.InnerException;
                    }

                    if (ActualException is MiskoException)
                    {
                        MiskoException ex = (MiskoException)ActualException;

                        // Ignore the generic exception thrown from session.Error
                        if (!(ex.Class.Name.Equals("Session") && ex.Method.Name.Equals("Error")))
                        {
                            Log.Error("Unexpected Error: (" + ex.Message + ")", ex);
                            session.ErrorMessages.Add(ex.ErrorMessage);
                        }
                    }
                    else
                    {
                        Log.Error("Unexpected Error: (" + ActualException.Message + ")", ActualException);
                        session.ErrorMessages.Add(new ErrorMessage(ActualException));
                    }
                }
                finally
                {
                    if (session != null)
                    {
                        session.EndTransaction();
                        session.FlushPersistence();

                        if (response != null)
                        {
                            response.Status = session.Status;
                            response.Errors = session.ErrorMessages.ListOf(ErrorLevel.Error);
                            response.Infos = session.ErrorMessages.ListOf(ErrorLevel.Info);
                            response.Warnings = session.ErrorMessages.ListOf(ErrorLevel.Warning);
                            response.Confirmations = session.ErrorMessages.ListOf(ErrorLevel.Confirmation);
                        }
                    }
                }

                return response;
            }

            return null;
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            active--;
            Boolean errorEncountered = false;
            ResponseMessage response = null;

            if (e.Error != null)
            {
                errorEncountered = true;
                IOController.Error(e.Error.Message);
            }
            else
            {
                response = e.Result as ResponseMessage;
                errorEncountered = !response.Status.IsCommitable;
            }

            // No errors in the message; call the successfulHandler
            if (!errorEncountered && mSuccessHandler_ != null)
            {
                try
                {
                    mSuccessHandler_(response);
                }
                catch (Exception ex)
                {
                    errorEncountered = true;
                    IOController.ExceptionHandler(mSuccessHandler_.Target, new ThreadExceptionEventArgs(ex));
                }
            }
            // If errors in the message; call errorHandler
            else if (errorEncountered && mErrorHandler_ != null)
            {
                try
                {
                    mErrorHandler_(response);
                }
                catch (Exception ex)
                {
                    IOController.ExceptionHandler(mErrorHandler_.Target, new ThreadExceptionEventArgs(ex));
                }
            }

            IOController.Status(active == 0 ? errorEncountered ? Strings.strError : Strings.strSuccess : Strings.strPorcessing);
            IOController.MessageReceived();            
        }

        #endregion

        #region Public Methods

        public static void SendRequest(RequestMessage request, MessageCompleteHandler successHandler)
        {
            SendRequest(request, successHandler, null);
        }

        public static void SendRequest(RequestMessage request, MessageCompleteHandler successHandler, MessageCompleteHandler errorHandler)
        {
            new MessageProcessor(request, successHandler, errorHandler).SendRequest();
        }

        #endregion
    }
}