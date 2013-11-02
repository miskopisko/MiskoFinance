using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml;
using MPersist.Core;
using MPersist.Data;
using MPersist.Message.Request;

namespace MPFinanceWeb
{
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [ScriptService]
    public class Service : System.Web.Services.WebService
    {
        [WebMethod]
        public void Process()
        {
            String xmlResponse = "";
            StreamReader reader = new StreamReader(Context.Request.InputStream);
            String xmlRequest = reader.ReadToEnd();

            if(!String.IsNullOrEmpty(xmlRequest))
            {
                XmlDocument document = new XmlDocument();
                document.Load(XmlReader.Create(new StringReader(xmlRequest.Trim())));

                String className = document.DocumentElement.Name;
                Type type = Assembly.Load("MPFinanceCore").GetType("MPFinanceCore.Message.Requests." + className);

                if (type != null)
                {
                    RequestMessage request = (RequestMessage)AbstractData.Deserialize(xmlRequest, type);

                    Message message = new Message
                    {
                        ServerConnection = Global.ServerConnections.GetServerConnection(request.Connection),
                        Request = request
                    };

                    message.Process();
                    xmlResponse = AbstractData.Serialize(message.Response);
                }
            }

            Context.Response.Output.Write(xmlResponse);
        }
    }
}
