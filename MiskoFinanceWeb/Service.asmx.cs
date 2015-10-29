using System;
using System.Reflection;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using Message;
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
	public class Service : System.Web.Services.WebService
	{
        private static readonly Logger Log = Logger.GetInstance(typeof(Service));

        [WebMethod(Description = "Accepts a RequestMessage, process it it on the server and returns a ResponseMessage")]
        public void ProcessRequest(String message, Int64 serializationType)
		{
            SerializationType serialization = SerializationType.GetElement(serializationType);
            ResponseMessage response = new ResponseMessage();

			try
			{
                RequestMessage request = (RequestMessage)CoreMessage.Read(message, serialization);
                response = MessageProcessor.Process(request);
			}
			catch(Exception ex)
			{
                Log.Error("Error processing message", ex);

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
                HttpContext.Current.Response.Write(response.Write(serialization));
            }
		}

        [WebMethod(Description = "Tests the connection to the database and reports status")]
        public void TestDBConnection()
        {
            SerializationType serializationType = SerializationType.Xml;
            TestDBConnectionRS response = new TestDBConnectionRS();

            try
            {
                TestDBConnectionRQ request = new TestDBConnectionRQ();
                request.Connections = DatabaseConnections.Connections;

                response = (TestDBConnectionRS)MessageProcessor.Process(request);
            }
            catch(Exception ex)
            {
                if(ex is TargetInvocationException)
                {
                    ex = ex.InnerException;
                }

                Log.Error("Error testing DB connection", ex);

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
                HttpContext.Current.Response.Write(response.Write(serializationType));    
            }
        }
	}
}