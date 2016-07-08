using System;
using System.Web.Script.Services;
using System.Web.Services;
using MiskoFinanceWeb.Message.Requests;
using MiskoPersist.Core;
using MiskoPersist.Enums;
using MiskoPersist.Message.Request;
using MiskoPersist.Message.Response;
using MiskoPersist.Serialization;

namespace MiskoFinanceWeb
{
    [WebService(Namespace = "http://miskofinance.piskuric.ca", Description = "Service provides message processing for MiskoFinance application")]
	[WebServiceBinding(ConformsTo = WsiProfiles.None)]
	[ScriptService]
    public class Service : WebService
	{
		[WebMethod(Description = "Accepts a request message as a string, process it it on the server and returns a response string")]
		public void ProcessRequestString(String message)
		{   
            RequestMessage request = (RequestMessage)Serializer.Deserialize(message);
            Process(request);
		}
		
		[WebMethod(Description = "Reads a request message from the POST body, process it it on the server and returns a response message")]
		public void ProcessRequest()
		{
            RequestMessage request = (RequestMessage)Serializer.Deserialize(Context.Request.InputStream);
            Process(request);
        }

		[WebMethod(Description = "Tests the connection to the database and reports status")]
		public void TestDBConnection()
		{
            TestDBConnectionRQ request = new TestDBConnectionRQ();
            request.SerializationType = SerializationType.Xml;
            Process(request);
		}

        private void Process(RequestMessage request)
        {
            ResponseMessage response = MessageProcessor.Process(request);
            Context.Response.ContentEncoding = Serializer.ENCODING;
            Context.Response.ContentType = response.SerializationType.ToHttpContentType();
            Context.Response.Write(Serializer.Serialize(response));
        }
	}
}