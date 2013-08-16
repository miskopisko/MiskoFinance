using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using MPersist.Core.Debug;
using MPersist.Core.Enums;
using MPersist.Core.Interfaces;
using MPersist.Core.Message;
using MPersist.Core.Message.Request;
using MPersist.Core.Message.Response;
using MPersist.Core.Resources;

namespace MPersist.Core
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

        private static int active = 0;

        #endregion

        #region Properties

        public static IOController IOController { get; set; }        

        #endregion

        #region Constructors

        private MessageProcessor(MessageCompleteHandler successHandler, MessageCompleteHandler errorHandler)
        {
            if (IOController == null)
            {
                throw new MPException(ErrorStrings.errIOControllerIsNull);
            }

            mSuccessHandler_ = successHandler;
            mErrorHandler_ = errorHandler;
        }

        #endregion

        #region Private Methods

        private void SendRequest(RequestMessage request)
        {
            active++;

            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += DoWork;
            bw.RunWorkerCompleted += RunWorkerCompleted;
            bw.RunWorkerAsync(request);

            HandleEvent(IOController, IOController.GetType().GetMethod("MessageSent"), new Object[] { Strings.strPorcessing });
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            ResponseMessage response;
            RequestMessage request = e.Argument as RequestMessage;
            Boolean resendMessage = false;
            Session session = new Session(request.Connection, ServiceLocator.GetConnection(request.Connection));
            session.MessageMode = request.MessageMode;
            session.RowPerPage = IOController.RowsPerPage;

            do
            {
                resendMessage = false;
                response = Process(session, request);
                response.MessageMode = request.MessageMode;

                if (response != null) // Now display warnings and error messages.
                {
                    for (int i = 0; i < session.ErrorMessages.Count; i++)
                    {
                        ErrorMessage errorMessage = session.ErrorMessages[i];

                        if (errorMessage.Level.Equals(ErrorLevel.Error))
                        {
                            if (IOController is Control)
                            {
                                ((Control)IOController).Invoke(new MethodInvoker(delegate { IOController.Error(errorMessage.Message); }));
                            }
                        }
                        else if (errorMessage.Level.Equals(ErrorLevel.Warning))
                        {
                            if (IOController is Control)
                            {
                                ((Control)IOController).Invoke(new MethodInvoker(delegate { IOController.Warning(errorMessage.Message); }));
                            }
                        }
                        else if (errorMessage.Level.Equals(ErrorLevel.Info))
                        {
                            if (IOController is Control)
                            {
                                ((Control)IOController).Invoke(new MethodInvoker(delegate { IOController.Info(errorMessage.Message); }));
                            }
                        }
                        else if (errorMessage.Level.Equals(ErrorLevel.Confirmation))
                        {
                            if (!errorMessage.Confirmed)
                            {
                                if (IOController is Control)
                                {
                                    Func<DialogResult> showMsg = () => IOController.Confirm(errorMessage.Message);
                                    DialogResult result = (DialogResult)((Control)IOController).Invoke(showMsg);

                                    if (result == DialogResult.Yes)
                                    {
                                        session.Status = ErrorLevel.Success;
                                        errorMessage.Confirmed = true;
                                        resendMessage = true;
                                    }
                                    else
                                    {
                                        response.Errors.Add(new MPException(ErrorStrings.errUserDeclinedConfirmation).ErrorMessage);
                                        break;
                                    }
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

                    response = (ResponseMessage)Assembly.GetEntryAssembly().CreateInstance(msgPath + "Responses." + msgName + "RS");
                    wrapper = (MessageWrapper)Assembly.GetEntryAssembly().CreateInstance(msgPath + msgName, false, BindingFlags.CreateInstance, null, new object[] { request, response }, null, null);

                    response.MessageTiming = new MessageTiming(wrapper);

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

                    if (ActualException is MPException)
                    {
                        MPException ex = (MPException)ActualException;

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
                            response.Errors = session.ErrorMessages.ListOf(ErrorLevel.Error);
                            response.Warnings = session.ErrorMessages.ListOf(ErrorLevel.Warning);
                            response.Confirmations = session.ErrorMessages.ListOf(ErrorLevel.Confirmation);
                            response.MessageTiming.EndTime = DateTime.Now;
                            response.MessageTiming.SqlTimings = session.SqlTimings;
                            response.Page = request.Page;
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

                if (IOController is Control)
                {
                    ((Control)IOController).Invoke(new MethodInvoker(delegate { IOController.Error(e.Error.Message); }));
                }
            }
            else
            {
                response = e.Result as ResponseMessage;
                errorEncountered = response.HasErrors;
            }

            // No errors in the message; call the successfulHandler
            if (!errorEncountered && mSuccessHandler_ != null)
            {
                errorEncountered = errorEncountered | !HandleEvent(mSuccessHandler_.Target, mSuccessHandler_.Method, new Object[] { response });
            }

            // If errors in the message OR errors on the successfulHandler then call errorHandler
            if (errorEncountered && mErrorHandler_ != null)
            {
                errorEncountered = errorEncountered | !HandleEvent(mErrorHandler_.Target, mErrorHandler_.Method, new Object[] { response });
            }

            if(response != null)
            {
                HandleEvent(IOController, IOController.GetType().GetMethod("Debug"), new Object[] { response.MessageTiming });
            }

            HandleEvent(IOController, IOController.GetType().GetMethod("MessageReceived"), new Object[] { active == 0 ? errorEncountered ? Strings.strError : Strings.strSuccess : Strings.strPorcessing });
        }

        private Boolean HandleEvent(Object target, MethodInfo method, Object[] args)
        {
            try
            {
                method.Invoke(target, args);
                return true;
            }
            catch (Exception e)
            {
                IOController.Error(new ErrorMessage(target.GetType(), method, ErrorLevel.Error, e.InnerException.Message).Message);
                return false;
            }
        }

        #endregion

        #region Public Methods

        public static void SendRequest(RequestMessage request, MessageCompleteHandler successHandler)
        {
            SendRequest(request, successHandler, null);
        }

        public static void SendRequest(RequestMessage request, MessageCompleteHandler successHandler, MessageCompleteHandler errorHandler)
        {
            new MessageProcessor(successHandler, errorHandler).SendRequest(request);
        }

        #endregion
    }
}