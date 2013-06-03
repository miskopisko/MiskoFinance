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

        public delegate void SuccessEventHandler(AbstractResponse Response);
        public delegate void ErrorEventHandler(AbstractResponse Response);

        #endregion

        #region Variable Declarations

        private readonly AbstractRequest mRequest_;
        private readonly SuccessEventHandler mSuccess_;
        private readonly ErrorEventHandler mError_;

        private static int active = 0;

        #endregion

        #region Properties

        public static IOController IOController { get; set; }
        public static Int32? RowsPerPage { get; set; }
        public static ConnectionSettings ConnectionSettings { get; set; }

        #endregion

        #region Constructors

        private MessageProcessor(AbstractRequest request, SuccessEventHandler successfulHandler, ErrorEventHandler errorHandler)
        {
            if(IOController == null)
            {
                throw new MPException(GetType(), MethodInfo.GetCurrentMethod(), ErrorStrings.errIOControllerIsNull);
            }

            if (String.IsNullOrEmpty(ConnectionSettings.ConnectionString))
            {
                throw new MPException(GetType(), MethodInfo.GetCurrentMethod(), ErrorStrings.errConnectionSettingsNotDefined);
            }

            if (!RowsPerPage.HasValue)
            {
                RowsPerPage = 15; // Default
            }

            mRequest_ = request;
            mSuccess_ = successfulHandler;
            mError_ = errorHandler;
        }

        #endregion

        #region Private Methods

        private void Done(AbstractResponse response)
        {
            active--;

            if (IOController is Control && ((Control)IOController).InvokeRequired)
            {
                ((Control)IOController).Invoke(new MethodInvoker(delegate { IOController.MessageReceived(Strings.strPorcessing); }));
            }
            else
            {
                IOController.MessageReceived(Strings.strPorcessing);
            }

            if (response != null)
            {
                if (mSuccess_ != null && !response.HasErrors)
                {
                    if (mSuccess_.Target is Control && ((Control)(mSuccess_.Target)).InvokeRequired)
                    {
                        try
                        {
                            ((Control)(mSuccess_.Target)).Invoke(mSuccess_, new Object[] { response });
                        }
                        catch (Exception e)
                        {
                            ErrorMessage message = new ErrorMessage(typeof(MessageProcessor), MethodInfo.GetCurrentMethod(), ErrorLevel.Error, ErrorStrings.errUnexpectedApplicationErrorLong, new Object[] { e.Message, e.StackTrace });
                            ((Control)IOController).Invoke(new MethodInvoker(delegate { IOController.Error(message); }));
                        }
                    }
                    else
                    {
                        mSuccess_(response);
                    }
                }
            }

            if (IOController is Control && ((Control)IOController).InvokeRequired)
            {
                ((Control)IOController).Invoke(new MethodInvoker(delegate { IOController.MessageReceived(active == 0 ? Strings.strSuccess : Strings.strPorcessing); }));
            }
            else
            {
                IOController.MessageReceived(active == 0 ? Strings.strSuccess : Strings.strPorcessing);
            }
        }

        private void SendRequest()
        {
            active++;

            if (IOController is Control && ((Control)IOController).InvokeRequired)
            {
                ((Control)IOController).Invoke(new MethodInvoker(delegate { IOController.MessageSent(Strings.strMessageSent); }));
            }
            else
            {
                IOController.MessageSent(Strings.strMessageSent);
            }

            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(Start);
            bw.RunWorkerAsync();

            if (IOController is Control && ((Control)IOController).InvokeRequired)
            {
                ((Control)IOController).Invoke(new MethodInvoker(delegate { IOController.MessageSent(Strings.strPorcessing); }));
            }
            else
            {
                IOController.MessageSent(Strings.strPorcessing);
            }
        }

        private void Start(object sender, DoWorkEventArgs e)
        {
            AbstractResponse response;
            Boolean ResendMessage = false;
            Session session = new Session(ServiceLocator.GetConnection(ConnectionSettings));
            session.MessageMode = mRequest_.MessageMode;
            session.RowPerPage = RowsPerPage.Value;

            do
            {
                ResendMessage = false;
                response = Process(session, mRequest_);
                response.MessageMode = mRequest_.MessageMode;

                if (response != null) // Now display warnings and error messages.
                {
                    for (int i = 0; i < session.ErrorMessages.Count; i++)
                    {
                        ErrorMessage Message = session.ErrorMessages[i];
                        if (Message.Level.Equals(ErrorLevel.Error))
                        {
                            if (IOController is Control)
                            {
                                ((Control)IOController).Invoke(new MethodInvoker(delegate { IOController.Error(Message); }));
                            }
                        }
                        else if (Message.Level.Equals(ErrorLevel.Warning))
                        {
                            if (IOController is Control)
                            {
                                ((Control)IOController).Invoke(new MethodInvoker(delegate { IOController.Warning(Message); }));
                            }
                            session.Warnings.Add(Message);
                        }
                        else if (Message.Level.Equals(ErrorLevel.Info))
                        {
                            if (IOController is Control)
                            {
                                ((Control)IOController).Invoke(new MethodInvoker(delegate { IOController.Info(Message); }));
                            }
                        }
                        else if (Message.Level.Equals(ErrorLevel.Confirmation))
                        {
                            if (!Message.Confirmed)
                            {
                                if (IOController is Control)
                                {
                                    Func<DialogResult> showMsg = () => IOController.Confirm(Message);
                                    DialogResult result = (DialogResult)((Control)IOController).Invoke(showMsg);

                                    if (result == DialogResult.Yes)
                                    {
                                        session.Status = ErrorLevel.Success;
                                        Message.Confirmed = true;
                                        session.Confirmations.Add(Message);
                                        ResendMessage = true;
                                    }
                                    else
                                    {
                                        response = null;
                                        session.Connection.Close();
                                        Done(response);
                                        return;
                                    }
                                }
                            }
                            else // Already confirmed.
                            {
                                session.Confirmations.Add(Message);
                            }
                        }
                    }
                }
            }
            while (response != null && ResendMessage);

            session.Connection.Close();
            Done(response);
        }

        private AbstractResponse Process(Session session, AbstractRequest Request)
        {
            AbstractResponse Response = null;
            AbstractMessage Wrapper = null;
            MessageTiming Timing = null;

            if (Request != null)
            {
                ErrorMessage errMessage = null;
                DateTime StartTime = DateTime.Now;

                try
                {
                    String msgName = Request.GetType().Name.Substring(0, Request.GetType().Name.Length - 2);
                    String msgPath = Request.GetType().FullName.Replace("Requests." + msgName + "RQ", "");

                    Response = (AbstractResponse)Assembly.GetEntryAssembly().CreateInstance(msgPath + "Responses." + msgName + "RS");                    
                    Wrapper = (AbstractMessage)Assembly.GetEntryAssembly().CreateInstance(msgPath + msgName, false, BindingFlags.CreateInstance, null, new object[] { Request, Response }, null, null);

                    Timing = new MessageTiming(Wrapper);

                    session.BeginTransaction();

                    Wrapper.GetType().InvokeMember(Request.Command, BindingFlags.Default | BindingFlags.InvokeMethod, null, Wrapper, new Object[] { session });
                }
                catch (Exception ex)
                {
                    Exception ActualException = ex;

                    while (ActualException.InnerException != null)
                    {
                        ActualException = ActualException.InnerException;
                    }

                    if (ActualException is MPException)
                    {
                        MPException ex1 = (MPException)ActualException;

                        // Ignore the generic exception thrown from session.Error
                        if(!(ex1.Class.Name.Equals("Session") && ex1.Method.Name.Equals("Error")))
                        {
                            if (ex1.ErrorMessage != null)
                            {
                                Log.Error("Unexpected Error: (" + ex1.Message + ")", ex1);
                                errMessage = ex1.ErrorMessage;                                
                                session.Status = ErrorLevel.Error;
                                session.ErrorMessages.Add(errMessage);
                            }
                            else
                            {
                                Log.Error("Unexpected Error: (" + ex1.Message + ")", ex1);
                                errMessage = new ErrorMessage(ex1.Class, ex1.Method, ErrorLevel.Error, ErrorStrings.errUnexpectedApplicationErrorShort, new Object[] { ex1.Message });
                                session.Status = ErrorLevel.Error;
                                session.ErrorMessages.Add(errMessage);
                            }
                        }
                    }
                    else
                    {
                        Log.Error("Unexpected Error: (" + ActualException.Message + ")", ActualException);
                        errMessage = new ErrorMessage(typeof(MessageProcessor), MethodInfo.GetCurrentMethod(), ErrorLevel.Error, ErrorStrings.errUnexpectedApplicationErrorLong, new Object[] { ActualException.Message, ActualException.StackTrace });
                        session.Status = ErrorLevel.Error;
                        session.ErrorMessages.Add(errMessage);
                    }                    
                }
                finally
                {
                    if (session != null)
                    {
                        Timing.EndTime = DateTime.Now;

                        session.EndTransaction();
                        session.FlushPersistence();

                        if (Response != null)
                        {
                            Response.HasErrors = session.HasErrors;
                            Response.HasWarnings = session.HasWarnings;
                            Response.HasConfirmations = session.HasConfirmations;
                            Response.Page = Request.Page;
                        }

                        Timing.SqlTimings = session.SqlTimings;
                    }

                    if (IOController is Control && ((Control)IOController).InvokeRequired)
                    {
                        ((Control)IOController).Invoke(new MethodInvoker(delegate { IOController.Debug(Timing); }));
                    }
                    else
                    {
                        IOController.Debug(Timing);
                    }                    
                }
            }

            return Response;
        }

        #endregion

        #region Public Methods

        public static void SendRequest(AbstractRequest request, SuccessEventHandler successfulHandler)
        {
            new MessageProcessor(request, successfulHandler, null).SendRequest();
        }

        #endregion
    }
}
