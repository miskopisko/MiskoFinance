using MPersist.Core.Debug;
using MPersist.Core.Enums;
using MPersist.Core.Interfaces;
using MPersist.Core.Message;
using MPersist.Core.Message.Request;
using MPersist.Core.Message.Response;
using MPersist.Core.Resources;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace MPersist.Core
{
    public class MessageProcessor
    {
        private static Logger Log = Logger.GetInstance(typeof(MessageProcessor));

        #region Delegates

        public delegate void MessageCompleteHandler(AbstractResponse Response);

        #endregion

        #region Variable Declarations

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

        private void SendRequest(AbstractRequest request)
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
            AbstractResponse response;
            AbstractRequest request = e.Argument as AbstractRequest;
            Boolean resendMessage = false;
            Session session = new Session(ServiceLocator.GetConnection());
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
                                ((Control)IOController).Invoke(new MethodInvoker(delegate { IOController.Error(errorMessage); }));
                            }
                        }
                        else if (errorMessage.Level.Equals(ErrorLevel.Warning))
                        {
                            if (IOController is Control)
                            {
                                ((Control)IOController).Invoke(new MethodInvoker(delegate { IOController.Warning(errorMessage); }));
                            }
                            session.Warnings.Add(errorMessage);
                        }
                        else if (errorMessage.Level.Equals(ErrorLevel.Info))
                        {
                            if (IOController is Control)
                            {
                                ((Control)IOController).Invoke(new MethodInvoker(delegate { IOController.Info(errorMessage); }));
                            }
                        }
                        else if (errorMessage.Level.Equals(ErrorLevel.Confirmation))
                        {
                            if (!errorMessage.Confirmed)
                            {
                                if (IOController is Control)
                                {
                                    Func<DialogResult> showMsg = () => IOController.Confirm(errorMessage);
                                    DialogResult result = (DialogResult)((Control)IOController).Invoke(showMsg);

                                    if (result == DialogResult.Yes)
                                    {
                                        session.Status = ErrorLevel.Success;
                                        errorMessage.Confirmed = true;
                                        resendMessage = true;
                                    }
                                    else
                                    {
                                        response.HasErrors = true;
                                        break;
                                    }
                                }
                            }
                            else // Already confirmed.
                            {
                                session.Confirmations.Add(errorMessage);
                            }
                        }
                    }
                }
            }
            while (response != null && resendMessage);

            session.Connection.Close();
            e.Result = response;
        }

        private AbstractResponse Process(Session session, AbstractRequest request)
        {
            if (request != null)
            {
                AbstractResponse response = null;
                AbstractMessage wrapper = null;
                DateTime startTime = DateTime.Now;

                try
                {
                    String msgName = request.GetType().Name.Substring(0, request.GetType().Name.Length - 2);
                    String msgPath = request.GetType().FullName.Replace("Requests." + msgName + "RQ", "");

                    response = (AbstractResponse)Assembly.GetEntryAssembly().CreateInstance(msgPath + "Responses." + msgName + "RS");
                    wrapper = (AbstractMessage)Assembly.GetEntryAssembly().CreateInstance(msgPath + msgName, false, BindingFlags.CreateInstance, null, new object[] { request, response }, null, null);

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
                            response.HasErrors = session.HasErrors;
                            response.HasWarnings = session.HasWarnings;
                            response.HasConfirmations = session.HasConfirmations;
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
            AbstractResponse response = e.Result as AbstractResponse;
            Boolean errorEncountered = e.Error != null || response.HasErrors;
            active--;

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

            HandleEvent(IOController, IOController.GetType().GetMethod("Debug"), new Object[] { response.MessageTiming });

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
                IOController.Error(new ErrorMessage(target.GetType(), method, ErrorLevel.Error, e.InnerException.Message));
                return false;
            }
        }

        #endregion

        #region Public Methods

        public static void SendRequest(AbstractRequest request, MessageCompleteHandler successHandler)
        {
            SendRequest(request, successHandler, null);
        }

        public static void SendRequest(AbstractRequest request, MessageCompleteHandler successHandler, MessageCompleteHandler errorHandler)
        {
            new MessageProcessor(successHandler, errorHandler).SendRequest(request);
        }

        #endregion
    }
}