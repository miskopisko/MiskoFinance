using System;
using System.Web.Script.Services;
using System.Web.Services;
using log4net;
using MiskoFinanceWeb.Message.Requests;
using MiskoPersist.Core;
using MiskoPersist.Data.Viewed;
using MiskoPersist.Enums;
using MiskoPersist.Message.Request;
using MiskoPersist.Message.Response;
using MiskoPersist.Serialization;

namespace MiskoFinanceWeb
{
    [WebService(Namespace = "http://miskofinance.piskuric.ca", Description = "Service provides message processing for MiskoFinance application")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[ScriptService]
    public class Service : WebService
	{
    	private static ILog Log = LogManager.GetLogger(typeof(Service));
    	
        private static readonly SerializationType DEFAULTSERIALIZATIONTYPE = SerializationType.Xml;

		[WebMethod(Description = "Accepts a request message as a string, process it it on the server and returns a response string")]
		public void ProcessRequestString(String message)
        {   
            SerializationType serializationType = DEFAULTSERIALIZATIONTYPE;
            try
            {
                if (message.StartsWith("<", StringComparison.OrdinalIgnoreCase))
                {
                    serializationType = SerializationType.Xml;
                }
                else if (message.StartsWith("{", StringComparison.OrdinalIgnoreCase))
                {
                    serializationType = SerializationType.Json;
                }
                else
                {
                    throw new MiskoException("Unrecognized string format");
                }    
                RequestMessage request = (RequestMessage)Serializer.Deserialize(message);
                ResponseMessage response = MessageProcessor.Process(request);
                SendResponse(response, serializationType);
            }
            catch(Exception e)
            {
                SendResponse(HandleException(e), serializationType);
            }
        }
		
		[WebMethod(Description = "Reads a request message from the POST body, process it it on the server and returns a response message")]
		public void ProcessRequest()
		{
            try
            {
                RequestMessage request = (RequestMessage)Serializer.Deserialize(Context.Request.InputStream);
                ResponseMessage response = MessageProcessor.Process(request);
                SendResponse(response, SerializationType.FromHttpContentType(Context.Request.ContentType));
            }
            catch (Exception e)
            {
                SendResponse(HandleException(e), SerializationType.FromHttpContentType(Context.Request.ContentType));
            }
        }

		[WebMethod(Description = "Tests the connection to the database and reports status")]
		public void TestDBConnection()
		{
            try
            {
				SendResponse(MessageProcessor.Process(new TestDBConnectionRQ()), DEFAULTSERIALIZATIONTYPE);
            }
            catch (Exception e)
            {
                SendResponse(HandleException(e), DEFAULTSERIALIZATIONTYPE);
            }
		}

        private ResponseMessage HandleException(Exception e)
        {
            ResponseMessage response = new ResponseMessage();
            response.Status = ErrorLevel.Error;

            do
            {
            	Log.Error("Unexpected Error: (" + e.Message + ")", e);
                response.Errors.Add(new ErrorMessage(e));
                e = e.InnerException;
            } 
            while (e != null);

            return response;
        }

        private void SendResponse(ResponseMessage response, SerializationType serializationType)
        {
            Context.Response.ContentEncoding = Serializer.Encoding;
            Context.Response.ContentType = serializationType.ToHttpContentType();
            Context.Response.Write(Serializer.Serialize(response, serializationType));	
        }
	}
}