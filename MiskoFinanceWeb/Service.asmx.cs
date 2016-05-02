using System;
using System.Reflection;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using MiskoPersist.Serialization;
using MiskoFinanceWeb.Message.Requests;
using MiskoFinanceWeb.Message.Responses;
using MiskoPersist.Core;
using MiskoPersist.Data;
using MiskoPersist.Enums;
using MiskoPersist.Message.Request;
using MiskoPersist.Message.Response;

namespace MiskoFinanceWeb
{
	[WebService(Namespace="http://miskofinance.piskuric.ca", Description = "Service provides message processing for MiskoFinance application")]
	[WebServiceBinding(ConformsTo = WsiProfiles.None)]
	[ScriptService]
	public class Service : WebService
	{
		[WebMethod(Description = "Accepts a RequestMessage, process it it on the server and returns a ResponseMessage")]
		public void ProcessRequest()
		{
			ResponseMessage response = null;
			SerializationType serializationType = SerializationType.FromHttpContentType(HttpContext.Current.Request.ContentType);
			try
			{
				RequestMessage request = (RequestMessage)Serializer.Deserialize(HttpContext.Current.Request.InputStream, serializationType);
				response = MessageProcessor.Process(request);
			}
			catch(Exception ex)
			{
				response = new ResponseMessage();
				response.Status = ErrorLevel.Error;
				response.Errors.Add(new ErrorMessage(ex));

				while(ex.InnerException != null)
				{
					ex = ex.InnerException;
					response.Errors.Add(new ErrorMessage(ex));
				}
			}
			finally
			{
				HttpContext.Current.Response.Write(Serializer.Serialize(response, serializationType));
			}
		}

		[WebMethod(Description = "Tests the connection to the database and reports status")]
		public void TestDBConnection()
		{
			SerializationType serializationType = SerializationType.Json;
			TestDBConnectionRS response = new TestDBConnectionRS();

			try
			{
				TestDBConnectionRQ request = new TestDBConnectionRQ();
				request.Connections = DatabaseConnections.Connections;
				response = (TestDBConnectionRS)MessageProcessor.Process(request);
			}
			catch(Exception ex)
			{
				response = new TestDBConnectionRS();
				response.Status = ErrorLevel.Error;
				response.Errors.Add(new ErrorMessage(ex));

				while(ex.InnerException != null)
				{
					ex = ex.InnerException;
					response.Errors.Add(new ErrorMessage(ex));
				}
			}
			finally
			{
				HttpContext.Current.Response.Write(Serializer.Serialize(response, serializationType));
			}
		}
	}
}