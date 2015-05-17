using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Reflection;
using System.Web.Services;
using System.Xml;
using MiskoPersist.Core;
using MiskoPersist.Data;
using MiskoPersist.Message.Request;

namespace MiskoFinanceWeb
{
    [WebServiceBindingAttribute(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItemAttribute(false)]
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
                Type type = Assembly.Load("MiskoFinanceCore").GetType("MiskoFinanceCore.Message.Requests." + className);

                if (type != null)
                {
                    //RequestMessage request = (RequestMessage)AbstractData.Deserialize(xmlRequest, type);

                    //MessageProcessor.
    
                    //xmlResponse = AbstractData.Serialize(message.Response);
                }
            }

            Context.Response.Output.Write(xmlResponse);
        }
    }
}
