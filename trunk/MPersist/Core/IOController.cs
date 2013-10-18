using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MPersist.Data;
using MPersist.Enums;
using MPersist.Message;
using MPersist.Message.Request;
using MPersist.Message.Response;
using MPersist.Resources;

namespace MPersist.Core
{
    public struct Message
    {
        #region Delegates

        public delegate void MessageCompleteHandler(ResponseMessage Response);

        #endregion

        public RequestMessage Request { get; set; }
        public ResponseMessage Response { get; set; }
        public MessageCompleteHandler SuccessHandler { get; set; }
        public MessageCompleteHandler ErrorHandler { get; set; }
    }

    public abstract class IOController
    {
        private static Logger Log = Logger.GetInstance(typeof(IOController));
        
        #region Fields

        private static IOController mInstance_;
        private static Int16 mActive_ = 0;

        private List<ConnectionSettings> mConnections_ = new List<ConnectionSettings>();
        private Int32 mRowsPerPage_ = 20;
        private ServerType mServerType_ = ServerType.Direct;
        private String mHost_ = "";
        private Int32 mPort_ = 80;
        private Boolean mUseSsl_ = false;
        private String mScript_ = "";

        #endregion

        #region Properties

        public static IOController Instance { get { return mInstance_; } set { mInstance_ = value; } }

        public List<ConnectionSettings> Connections { get { return mConnections_; } set { mConnections_ = value; } }
        public Int32 RowsPerPage { get { return mRowsPerPage_; } set { mRowsPerPage_ = value; } }
        public ServerType ServerType { get { return mServerType_; } set { mServerType_ = value; } }
        public String Host { get { return mHost_; } set { mHost_ = value; } }
        public Int32 Port { get { return mPort_; } set { mPort_ = value; } }
        public Boolean UseSsl { get { return mUseSsl_; } set { mUseSsl_ = value; } }
        public String Script { get { return mScript_; } set { mScript_ = value; } }

        private static String URL
        {
            get
            {
                String protocol = "http";

                if (IOController.Instance.UseSsl)
                {
                    protocol = "https";
                }

                return protocol + "://" + IOController.Instance.Host + ":" + IOController.Instance.Port + IOController.Instance.Script;
            }
        }

        #endregion

        public IOController()
        {
            Application.ThreadException += ExceptionHandler;
        }

        #region Private Methods

        private Boolean AlreadyExists(String name)
        {
            foreach (ConnectionSettings item in mConnections_)
            {
                if (item.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        private static ConnectionSettings GetConnectionSettings(String name)
        {
            foreach (ConnectionSettings item in Instance.Connections)
            {
                if (item.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                {
                    return item;
                }
            }
            throw new MPException(ErrorStrings.errInvalidConnectionString, new String[] { name });
        }

        private static void ProcessRequest(Message message)
        {
            mActive_++;

            Instance.Debug(message.Request);
            Instance.MessageSent();
            Instance.MessageStatus(Strings.strPorcessing);

            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += DoWork;
            bw.RunWorkerCompleted += DoWorkCompleted;
            bw.RunWorkerAsync(message);
        }

        private static void DoWork(object sender, DoWorkEventArgs arg)
        {
            Message message = (Message)arg.Argument;            
            Session session = new Session(ServiceLocator.GetConnection(GetConnectionSettings(message.Request.Connection)), message.Request);

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

                    message.Response.Page = new Page(message.Request.Page);

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

            arg.Result = message;
        }

        private static void DoWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            mActive_--;
            Message message = (Message)e.Result;

            if (e.Error != null)
            {
                Instance.Error(e.Error.Message);
            }

            if (Instance.ServerType.Equals(ServerType.Direct))
            {
                ProcessResponse(message);
            }
        }

        private static void ProcessResponse(Message message)
        {
            ResponseMessage response = message.Response;
            Boolean errorEncountered = !response.Status.IsCommitable;

            Instance.Debug(message.Response);
            Instance.MessageReceived();            

            if (response.HasErrors)
            {
                foreach (ErrorMessage errorMessage in response.Errors)
                {
                    Instance.Error(errorMessage.Message);
                }
            }

            if (response.HasConfirmations)
            {
                Boolean resendMessage = false;
                foreach (ErrorMessage errorMessage in response.Confirmations)
                {
                    if (errorMessage.Confirmed.HasValue && !errorMessage.Confirmed.Value)
                    {
                        if (Instance.Confirm(errorMessage.Message))
                        {
                            errorMessage.Confirmed = true;
                            resendMessage = true;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (resendMessage)
                {
                    message.Request.Confirmations = response.Confirmations;
                    message.Response = null;
                    SendRequest(message.Request, message.SuccessHandler, message.ErrorHandler);
                    return;
                }
            }

            if (response.HasWarnings)
            {
                foreach (ErrorMessage errorMessage in response.Warnings)
                {
                    Instance.Warning(errorMessage.Message);
                }
            }

            if (response.HasInfos)
            {
                foreach (ErrorMessage errorMessage in response.Infos)
                {
                    Instance.Info(errorMessage.Message);
                }
            }

            if (!errorEncountered && message.SuccessHandler != null)
            {
                message.SuccessHandler(response);
            }
            else if (errorEncountered && message.ErrorHandler != null)
            {
                message.ErrorHandler(response);
            }

            Instance.MessageStatus(mActive_ == 0 ? errorEncountered ? Strings.strError : Strings.strSuccess : Strings.strPorcessing);
        }

        #endregion

        #region Public Methods

        public void AddConnection(ConnectionSettings connectionSettings)
        {
            if(AlreadyExists(connectionSettings.Name))
            {
                throw new MPException("Connection with name '{0}' already exists", new String[]{ connectionSettings.Name });
            }

            Instance.Connections.Add(connectionSettings);
        }

        public static void SendRequest(RequestMessage request, Message.MessageCompleteHandler successHandler)
        {
            SendRequest(request, successHandler, null);
        }

        public static void SendRequest(RequestMessage request, Message.MessageCompleteHandler successHandler, Message.MessageCompleteHandler errorHandler)
        {
            if (Instance == null)
            {
                throw new MPException("IO Conroller is not correctly set");
            }

            request.RowsPerPage = Instance.RowsPerPage;
            Message message = new Message { Request = request, SuccessHandler = successHandler, ErrorHandler = errorHandler };

            if (Instance.ServerType.Equals(ServerType.Direct))
            {
                ProcessRequest(message);
            }
            else
            {
                String xmlRequest = AbstractData.Serialize(request);

                WebRequest webRequest = WebRequest.Create(URL);
                webRequest.Method = "POST";
                webRequest.ContentType = "text/plain";
                webRequest.Timeout = 180 * 1000;
                webRequest.ContentLength = xmlRequest.Length;

                StreamWriter rqWriter = new StreamWriter(webRequest.GetRequestStream(), Encoding.GetEncoding("ISO-8859-1"));
                rqWriter.Write(xmlRequest);
                rqWriter.Close();

                try
                {
                    WebResponse webResponse = webRequest.GetResponse();
                    StreamReader rsReader = new StreamReader(webResponse.GetResponseStream(), Encoding.GetEncoding(AbstractData.ENCODING));
                    String xmlResponse = rsReader.ReadToEnd();

                    String msgName = request.GetType().Name.Substring(0, request.GetType().Name.Length - 2);
                    String msgPath = request.GetType().FullName.Replace("Requests." + msgName + "RQ", "");
                    Type type = request.GetType().Assembly.GetType(msgPath + "Responses." + msgName + "RS");
                    message.Response = (ResponseMessage)AbstractData.Deserialize(xmlResponse, type);
                    ProcessResponse(message);
                }
                catch(Exception exxx)
                {
                    int i = 0;
                }
                
                
            }
        }

        #endregion

        #region Abstract Methods

        public abstract void Debug(Object obj);
        public abstract void MessageStatus(String status);
        public abstract void MessageReceived();
        public abstract void MessageSent();
        public abstract void ExceptionHandler(Object sender, ThreadExceptionEventArgs e);
        public abstract void Error(String message);
        public abstract void Warning(String message);
        public abstract void Info(String message);
        public abstract Boolean Confirm(String message);

        #endregion
    }
}
