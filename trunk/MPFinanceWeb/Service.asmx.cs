using System;
using System.ComponentModel;
using System.IO;
using System.Web.Services;
using MPersist.Data;
using System.Xml;
using System.Reflection;
using MPersist.Core;
using MPersist.Message;
using MPersist.Message.Response;
using MPersist.Enums;
using MPersist.Message.Request;

namespace MPFinanceWeb
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {
        [WebMethod]
        public void Process()
        {
            String xmlResponse = "";
            StreamReader reader = new StreamReader(Context.Request.InputStream);
            String query = reader.ReadToEnd();

            if(!String.IsNullOrEmpty(query))
            {
                XmlDocument document = new XmlDocument();
                document.Load(XmlReader.Create(new StringReader(query.Trim())));

                String className = document.DocumentElement.Name;
                Type type = Assembly.Load("MPFinanceCore").GetType("MPFinanceCore.Message.Requests." + className);

                if (type != null)
                {
                    RequestMessage request = (RequestMessage)AbstractData.Deserialize(query, type);
                    ResponseMessage response = DoWork(request);
                    xmlResponse = AbstractData.Serialize(response);
                }
            }

            Context.Response.Output.Write(xmlResponse);
        }

        private ResponseMessage DoWork(RequestMessage request)
        {
            ResponseMessage response = null;
            Session session = new Session(ServiceLocator.GetConnection(Global.GetConnectionSettings(request.Connection)), request);

            if (request != null)
            {                
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

                    if (ActualException is MPException)
                    {
                        MPException ex = (MPException)ActualException;

                        // Ignore the generic exception thrown from session.Error
                        if (!(ex.Class.Name.Equals("Session") && ex.Method.Name.Equals("Error")))
                        {
                            session.ErrorMessages.Add(ex.ErrorMessage);
                        }
                    }
                    else
                    {
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
            }

            return response;
        }
    }
}
