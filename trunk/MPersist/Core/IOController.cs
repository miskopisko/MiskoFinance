using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MPersist.Data;
using MPersist.Enums;
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

        public ServerConnection ServerConnection { get; set; }
        public RequestMessage Request { get; set; }
        public ResponseMessage Response { get; set; }
        public MessageCompleteHandler SuccessHandler { get; set; }
        public MessageCompleteHandler ErrorHandler { get; set; }

        public void Process()
        {
            this = MessageProcessor.ProcessRequest(this);
        }
    }

    public class IOController
    {
        private static Logger Log = Logger.GetInstance(typeof(IOController));
        
        #region Fields

        private static IOController mInstance_;
        private static Int16 mActive_ = 0;

        private ServerConnections mServerConnections_ = new ServerConnections();
        private ServerType mServerType_ = ServerType.Local;
        private String mHost_ = "";
        private Int32 mPort_ = 80;
        private Boolean mUseSsl_ = false;
        private String mScript_ = "";

        #endregion

        #region Properties

        public static IOController Instance { get { return mInstance_; } set { mInstance_ = value; } }

        public ServerConnections ServerConnections { get { return mServerConnections_; } }
        public ServerType ServerType { get { return mServerType_; } set { mServerType_ = value; } }
        public String Host { get { return mHost_; } set { mHost_ = value; } }
        public Int32 Port { get { return mPort_; } set { mPort_ = value; } }
        public Boolean UseSsl { get { return mUseSsl_; } set { mUseSsl_ = value; } }
        public String Script { get { return mScript_; } set { mScript_ = value; } }
        public String URL
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
            IOController.Instance = this;
            Application.ThreadException += ExceptionHandler;
        }

        #region Private Methods

        private static void ProcessResponse(Message message)
        {
            mActive_--;

            ResponseMessage response = message.Response;
            Boolean errorEncountered = response == null || !response.Status.IsCommitable;

            Instance.Debug(message.Response);
            Instance.MessageReceived();            

            if (response != null && response.HasErrors)
            {
                foreach (ErrorMessage errorMessage in response.Errors)
                {
                    Instance.Error(errorMessage.Message);
                }
            }

            if (response != null && response.HasConfirmations)
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

            if (response != null && response.HasWarnings)
            {
                foreach (ErrorMessage errorMessage in response.Warnings)
                {
                    Instance.Warning(errorMessage.Message);
                }
            }

            if (response != null && response.HasInfos)
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

        public static void SendRequest(RequestMessage request, Message.MessageCompleteHandler successHandler)
        {
            SendRequest(request, successHandler, null);
        }

        public static void SendRequest(RequestMessage request, Message.MessageCompleteHandler successHandler, Message.MessageCompleteHandler errorHandler)
        {
            mActive_++;

            Message message = new Message
            {
                Request = request,
                SuccessHandler = successHandler,
                ErrorHandler = errorHandler
            };
            
            Instance.Debug(request);

            if(Instance.ServerType.Equals(ServerType.Local))
            {
                message.ServerConnection = Instance.ServerConnections.GetServerConnection(request.Connection);

                message.Process();

                ProcessResponse(message);
            }
            else if (Instance.ServerType.Equals(ServerType.Online))
            {
                String xmlRequest = AbstractData.Serialize(request);
                String xmlResponse = "";

                try
                {
                    WebRequest webRequest = WebRequest.Create(Instance.URL);
                    webRequest.Method = "POST";
                    webRequest.ContentType = "text/plain";
                    webRequest.Timeout = 180 * 1000;
                    webRequest.ContentLength = xmlRequest.Length;

                    StreamWriter rqWriter = new StreamWriter(webRequest.GetRequestStream(), Encoding.GetEncoding("ISO-8859-1"));
                    rqWriter.Write(xmlRequest);
                    rqWriter.Close();

                    WebResponse webResponse = webRequest.GetResponse();
                    StreamReader rsReader = new StreamReader(webResponse.GetResponseStream(), Encoding.GetEncoding(AbstractData.ENCODING));
                    xmlResponse = rsReader.ReadToEnd();
                }
                catch (Exception e)
                {
                    throw new MPException("Error communicating with server", e);
                }
                finally
                {
                    String msgName = request.GetType().Name.Substring(0, request.GetType().Name.Length - 2);
                    String msgPath = request.GetType().FullName.Replace("Requests." + msgName + "RQ", "");
                    Type type = request.GetType().Assembly.GetType(msgPath + "Responses." + msgName + "RS");
                    message.Response = (ResponseMessage)AbstractData.Deserialize(xmlResponse, type);
                    ProcessResponse(message);
                }
            }
        }

        #endregion

        #region Virtual Methods

        public virtual void ExceptionHandler(Object sender, ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            Error(ex.Message);
        }

        public virtual void Debug(Object obj) 
        { 
        }

        public virtual void MessageStatus(String status) 
        { 
        }

        public virtual void MessageReceived() 
        { 
        }

        public virtual void MessageSent()
        {
        }

        public virtual void Error(String message) 
        {
        }

        public virtual void Warning(String message)
        {
        }

        public virtual void Info(String message)
        {
        }

        public virtual Boolean Confirm(String message)
        {
            return false;
        }

        #endregion
    }
}
