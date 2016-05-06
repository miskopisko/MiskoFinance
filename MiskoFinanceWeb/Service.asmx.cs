using System;
using System.IO;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using MiskoPersist.Serialization;
using MiskoFinanceWeb.Message.Requests;
using MiskoPersist.Core;
using MiskoPersist.Data;
using MiskoPersist.Enums;
using MiskoPersist.Message.Request;
using MiskoPersist.Message.Response;

namespace MiskoFinanceWeb
{
	[WebService(Namespace = "http://miskofinance.piskuric.ca", Description = "Service provides message processing for MiskoFinance application")]
	[WebServiceBinding(ConformsTo = WsiProfiles.None)]
	[ScriptService]
	public class Service : WebService
	{
		#region Public Methods
		
		[WebMethod(Description = "Accepts a RequestMessage, process it it on the server and returns a ResponseMessage")]
		public void Process(String message)
		{
			SerializationType serializationType = Serializer.GetSerializationType(message);
			ResponseMessage response = Process((RequestMessage)Serializer.Deserialize(message));
			
			HttpContext.Current.Response.Write(Serializer.Serialize(response, serializationType));
		}
		
		[WebMethod(Description = "Reads a request message from the POST body, process it it on the server and returns a response message")]
		public void ProcessRequest()
		{
			using (StreamReader sr = new StreamReader(HttpContext.Current.Request.InputStream))
			{
				Process(sr.ReadToEnd());
			}
		}

		[WebMethod(Description = "Tests the connection to the database and reports status")]
		public void TestDBConnection()
		{
			HttpContext.Current.Response.Write(Serializer.Serialize(Process(new TestDBConnectionRQ() { Connection = "NULL" }), SerializationType.Xml));
		}
		
		#endregion
		
		#region Private Methods
		
		private ResponseMessage Process(RequestMessage request)
		{
			try
			{
				return MessageProcessor.Process(request);
			}
			catch (Exception ex)
			{
				ResponseMessage response = new ResponseMessage();
				response.Status = ErrorLevel.Error;

				while (ex.InnerException != null)
				{
					response.Errors.Add(new ErrorMessage(ex));
					ex = ex.InnerException;
				}
				return response;
			}
		}
		
		#endregion
	}
}