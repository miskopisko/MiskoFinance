using System;
using System.Reflection;
using System.Threading;
using MPersist.Enums;
using MPersist.Message;
using MPersist.Message.Response;
using MPersist.Message.Request;

namespace MPersist.Core
{
    public class MessageProcessor
    {
        private static Logger Log = Logger.GetInstance(typeof(MessageProcessor));

        #region Fields



        #endregion

        #region Properties

        

        #endregion

        #region Private Methods

        private static Message DoWork(Message message)
        {
            Session session = new Session(ServiceLocator.GetConnection(message.ServerConnection), message.Request); // new Session(ServiceLocator.GetConnection(GetConnectionSettings(message.Request.Connection)), message.Request);

            if (message.Request != null)
            {
                MessageWrapper wrapper = null;
                DateTime startTime = DateTime.Now;

                try
                {
                    String msgName = message.Request.GetType().Name.Substring(0, message.Request.GetType().Name.Length - 2);
                    String msgPath = message.Request.GetType().FullName.Replace("Requests." + msgName + "RQ", "");

                    message.Response = (ResponseMessage)message.Request.GetType().Assembly.CreateInstance(msgPath + "Responses." + msgName + "RS");
                    wrapper = (MessageWrapper)message.Request.GetType().Assembly.CreateInstance(msgPath + msgName, false, BindingFlags.CreateInstance, null, new object[] { message.Request, message.Response }, null, null);

                    message.Response.Page = message.Request.Page;

                    session.BeginTransaction();

                    wrapper.GetType().InvokeMember(message.Request.Command, BindingFlags.Default | BindingFlags.InvokeMethod, null, wrapper, new Object[] { session });
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

                        if (message.Response != null)
                        {
                            message.Response.Status = session.Status;
                            message.Response.Errors = session.ErrorMessages.ListOf(ErrorLevel.Error);
                            message.Response.Infos = session.ErrorMessages.ListOf(ErrorLevel.Info);
                            message.Response.Warnings = session.ErrorMessages.ListOf(ErrorLevel.Warning);
                            message.Response.Confirmations = session.ErrorMessages.ListOf(ErrorLevel.Confirmation);
                        }
                    }
                }
            }

            return message;
        }

        #endregion

        #region Public Methods

        public static Message ProcessRequest(Message message)
        {
            Message result = message;
            Thread thread = new Thread(
              () =>
              {
                  result = DoWork(message);
              });
            thread.Start();
            thread.Join();

            return result;
        }

        #endregion
    }
}