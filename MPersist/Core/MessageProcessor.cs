using MPersist.Core.Enums;
using MPersist.Core.Interfaces;
using MPersist.Core.Message;
using MPersist.Core.Message.Request;
using MPersist.Core.Message.Response;
using MPersist.Core.Resources;
using System;
using System.Data.Common;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace MPersist.Core
{
    public class MessageProcessor
    {
        private static Logger Log = Logger.GetInstance(typeof(MessageProcessor));

        #region Variable Declarations

        private readonly AbstractRequest mRequest_;
        private readonly IDataRequestor mDataRequestor_;

        private static int active = 0;

        #endregion

        #region Properties

        public static DbConnection Connection { get; set; }
        public static IOController IOController { get; set; }

        #endregion

        #region Constructors

        private MessageProcessor(AbstractRequest request, IDataRequestor requestor)
        {
            mRequest_ = request;
            mDataRequestor_ = requestor;
        }

        #endregion

        #region Private Methods

        private void Done(AbstractResponse response)
        {
            active--;

            if (IOController != null && IOController is Form)
            {
                ((Form)IOController).Invoke(new MethodInvoker(delegate { IOController.MessageReceived(Strings.strPorcessing); }));
            }

            if (response != null && mDataRequestor_ is Control)
            {
                ((Control)mDataRequestor_).Invoke(new MethodInvoker(delegate { mDataRequestor_.ResponseRecieved(response); }));
            }

            if (IOController != null && IOController is Form)
            {
                ((Form)IOController).Invoke(new MethodInvoker(delegate { IOController.MessageReceived(active == 0 ? Strings.strSuccess : Strings.strPorcessing); }));
            }
        }

        private static void SendRequest(MessageProcessor processor)
        {
            active++;

            if (IOController != null && IOController is Form)
            {
                ((Form)IOController).Invoke(new MethodInvoker(delegate { IOController.MessageSent(Strings.strMessageSent); }));
            }

            Thread ProcessMessage = new Thread(processor.Start);
            ProcessMessage.Start();

            if (IOController != null && IOController is Form)
            {
                ((Form)IOController).Invoke(new MethodInvoker(delegate { IOController.MessageSent(Strings.strPorcessing); }));
            }
        }

        private void Start()
        {
            AbstractResponse response;
            Boolean ResendMessage = false;
            Session session = new Session(Connection);
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
                        }
                    }
                }
            }

            return Response;
        }

        #endregion

        #region Public Methods

        [MethodImplAttribute(MethodImplOptions.Synchronized)]
        public static void SendRequest(AbstractRequest request, IDataRequestor requestor)
        {
            SendRequest(new MessageProcessor(request, requestor));
        }

        #endregion
    }
}
