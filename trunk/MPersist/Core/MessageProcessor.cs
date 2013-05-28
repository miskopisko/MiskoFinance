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

        [Browsable(false)]
        public delegate void SuccessEventHandler(AbstractResponse Response);
        [Browsable(false)]
        public delegate void ErrorEventHandler(AbstractResponse Response);

        #endregion

        #region Variable Declarations

        private readonly AbstractRequest mRequest_;
        private readonly SuccessEventHandler mSuccess_;
        private readonly ErrorEventHandler mError_;

        private static int active = 0;

        #endregion

        #region Properties

        [Browsable(false)]
        public static ConnectionSettings ConnectionSettings { get; set; }
        [Browsable(false)]
        public static IOController IOController { get; set; }

        #endregion

        #region Constructors

        private MessageProcessor(AbstractRequest request, SuccessEventHandler successfulHandler, ErrorEventHandler errorHandler)
        {
            mRequest_ = request;
            mSuccess_ = successfulHandler;
            mError_ = errorHandler;
        }

        #endregion

        #region Private Methods

        private void Done(AbstractResponse response)
        {
            active--;

            if (IOController != null && IOController is Control)
            {
                if (((Control)IOController).InvokeRequired)
                {
                    ((Control)IOController).Invoke(new MethodInvoker(delegate { IOController.MessageReceived(Strings.strPorcessing); }));
                }
                else
                {
                    IOController.MessageReceived(Strings.strPorcessing);
                }
            }

            if (response != null)
            {
                if (mSuccess_ != null && !response.HasErrors)
                {
                    if (mSuccess_.Target is Control && ((Control)(mSuccess_.Target)).InvokeRequired)
                    {
                        ((Control)(mSuccess_.Target)).Invoke(mSuccess_, new Object[] { response });
                    }
                    else
                    {
                        mSuccess_(response);
                    }
                }
            }

            if (IOController != null && IOController is Control)
            {
                if (((Control)IOController).InvokeRequired)
                {
                    ((Control)IOController).Invoke(new MethodInvoker(delegate { IOController.MessageReceived(active == 0 ? Strings.strSuccess : Strings.strPorcessing); }));
                }
                else
                {
                    IOController.MessageReceived(active == 0 ? Strings.strSuccess : Strings.strPorcessing);
                }
            }
        }

        private void SendRequest()
        {
            active++;

            if (IOController != null && IOController is Control)
            {
                if (((Control)IOController).InvokeRequired)
                {
                    ((Control)IOController).Invoke(new MethodInvoker(delegate { IOController.MessageSent(Strings.strMessageSent); }));
                }
                else
                {
                    IOController.MessageSent(Strings.strMessageSent);
                }
            }

            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(Start);
            bw.RunWorkerAsync();

            if (IOController != null && IOController is Control)
            {
                if (((Control)IOController).InvokeRequired)
                {
                    ((Control)IOController).Invoke(new MethodInvoker(delegate { IOController.MessageSent(Strings.strPorcessing); }));
                }
                else
                {
                    IOController.MessageSent(Strings.strPorcessing);
                }                
            }
        }

        private void Start(object sender, DoWorkEventArgs e)
        {
            AbstractResponse response;
            Boolean ResendMessage = false;
            Session session = new Session(ServiceLocator.GetConnection(ConnectionSettings));
            session.MessageMode = mRequest_.MessageMode;

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
                            if (IOController != null && IOController is Form)
                            {
                                ((Form)IOController).Invoke(new MethodInvoker(delegate { IOController.Error(Message); }));
                            }
                        }
                        else if (Message.Level.Equals(ErrorLevel.Warning))
                        {
                            if (IOController != null && IOController is Form)
                            {
                                ((Form)IOController).Invoke(new MethodInvoker(delegate { IOController.Warning(Message); }));
                            }
                            session.Warnings.Add(Message);
                        }
                        else if (Message.Level.Equals(ErrorLevel.Info))
                        {
                            if (IOController != null && IOController is Form)
                            {
                                ((Form)IOController).Invoke(new MethodInvoker(delegate { IOController.Info(Message); }));
                            }
                        }
                        else if (Message.Level.Equals(ErrorLevel.Confirmation))
                        {
                            if (!Message.Confirmed)
                            {
                                if (IOController != null && IOController is Form)
                                {
                                    Func<DialogResult> showMsg = () => IOController.Confirm(Message);
                                    DialogResult result = (DialogResult)((Form)IOController).Invoke(showMsg);

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

            if (Request != null)
            {
                ErrorMessage errMessage = null;
                DateTime StartTime = DateTime.Now;

                try
                {
                    String msgName = Request.GetType().Name.Substring(0, Request.GetType().Name.Length - 2);
                    String msgPath = Request.GetType().FullName.Replace("Requests." + msgName + "RQ", "");

                    Response = (AbstractResponse)Assembly.GetEntryAssembly().CreateInstance(msgPath + "Responses." + msgName + "RS");                    

                    AbstractMessage wrapper = (AbstractMessage)Assembly.GetEntryAssembly().CreateInstance(msgPath + msgName, false, BindingFlags.CreateInstance, null, new object[] { Request, Response }, null, null);

                    session.BeginTransaction();

                    StartTime = DateTime.Now;
                    wrapper.GetType().InvokeMember(Request.Command, BindingFlags.Default | BindingFlags.InvokeMethod, null, wrapper, new Object[] { session });
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

                        if (ex1.ErrorMessage != null)
                        {
                            errMessage = ex1.ErrorMessage;
                            Log.Error("Unexpected Error: (" + ex1.Message + ")", ex1);
                        }
                        else
                        {
                            Log.Error("Unexpected Error: (" + ex1.Message + ")", ex1);
                            errMessage = new ErrorMessage(ex1.Class, ex1.Method, ErrorLevel.Error, ErrorStrings.errUnexpectedApplicationErrorShort, new Object[] { ex1.Message });
                        }
                    }
                    else
                    {
                        Log.Error("Unexpected Error: (" + ActualException.Message + ")", ActualException);
                        session.ErrorMessages.Add(new ErrorMessage(typeof(MessageProcessor), MethodInfo.GetCurrentMethod(), ErrorLevel.Error, ErrorStrings.errUnexpectedApplicationErrorLong, new Object[] { ActualException.Message, ActualException.StackTrace }));
                        session.Status = ErrorLevel.Error;
                    }
                }
                finally
                {
                    if (session != null)
                    {
                        DateTime EndTime = DateTime.Now;

                        session.EndTransaction();
                        session.FlushPersistence();

                        if (Response != null)
                        {
                            Response.ExecutionTime = EndTime.Subtract(StartTime);
                            Response.HasErrors = session.HasErrors;
                            Response.HasWarnings = session.HasWarnings;
                            Response.HasConfirmations = session.HasConfirmations;
                            Response.Page = Request.Page;
                        }
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
