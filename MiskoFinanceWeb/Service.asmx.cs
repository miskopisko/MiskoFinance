using System;
using System.Web.Script.Services;
using System.Web.Services;
using log4net;
using MiskoFinanceWeb.Data.Viewed;
using MiskoPersist.Core;
using MiskoPersist.Data.Viewed;
using MiskoPersist.Enums;
using MiskoPersist.Message.Requests;
using MiskoPersist.Message.Responses;
using MiskoPersist.Serialization;

namespace MiskoFinanceWeb
{
    [WebService(Namespace = "http://miskofinance.piskuric.ca", Description = "Service provides message processing for MiskoFinance application")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[ScriptService]
    public class Service : WebService
	{
    	private static ILog Log = LogManager.GetLogger(typeof(Service));

		[WebMethod(Description = "Accepts a request message as a string, process it it on the server and returns a response string")]
		public void ProcessRequestString(String message)
        {   
            try
            {
            	RequestMessage request = Serializer.Deserialize(message) as RequestMessage;
                ResponseMessage response = MessageProcessor.Process(request);
                SendResponse(response, message.GetSerializationType(), true);
            }
            catch(Exception e)
            {
                SendResponse(HandleException(e), Global.DefaultSerializationType, true);
            }
        }
		
		[WebMethod(Description = "Reads a request message from the POST body, process it it on the server and returns a response message")]
		public void ProcessRequest()
		{
            try
            {
                RequestMessage request = Serializer.Deserialize(Context.Request.InputStream) as RequestMessage;
                ResponseMessage response = MessageProcessor.Process(request);
                SendResponse(response, SerializationType.FromHttpContentType(Context.Request.ContentType), false);
            }
            catch (Exception e)
            {
                SendResponse(HandleException(e), SerializationType.FromHttpContentType(Context.Request.ContentType), false);
            }
        }

		[WebMethod(Description = "Gets all the database connections reports status")]
		public void DatabaseConnections()
		{
            try
            {
				VwDatabaseConnections databaseConnections = new VwDatabaseConnections();
				SendResponse(databaseConnections, Global.DefaultSerializationType, true);
            }
            catch (Exception e)
            {
                SendResponse(HandleException(e), Global.DefaultSerializationType, true);
            }
		}
		
		[WebMethod(Description = "Outputs the current server security policy configuration")]
		public void CurrentSecurityPolicy()
		{
            try
            {
				VwSecurityPolicy securityPolicy = new VwSecurityPolicy();
				SendResponse(securityPolicy, Global.DefaultSerializationType, true);
            }
            catch (Exception e)
            {
                SendResponse(HandleException(e), Global.DefaultSerializationType, true);
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

        private void SendResponse(Object response, SerializationType serializationType, Boolean indent)
        {
            Context.Response.ContentEncoding = Serializer.Encoding;
            Context.Response.ContentType = serializationType.ToHttpContentType();
            Context.Response.Write(Serializer.Serialize(response, serializationType, indent));	
        }
	}
}