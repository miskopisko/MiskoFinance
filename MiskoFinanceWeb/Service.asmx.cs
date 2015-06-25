using System;
using System.Web.Script.Services;
using System.Web.Services;
using MiskoPersist.Core;
using MiskoPersist.Data;
using MiskoPersist.Enums;
using MiskoPersist.Message.Response;

namespace MiskoFinanceWeb
{
	[WebService(Namespace="http://miskofinance.piskuric.ca")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
	public class Service : System.Web.Services.WebService
	{
        [WebMethod(Description = "Accepts a JSON RequestMessage, process it it on the server and returns a JSON ResponseMessage")]
        public void ProcessRequest(String request)
		{
            ResponseMessage responseMessage;

			try
			{
                responseMessage = MessageProcessor.Process(request);
			}
			catch(Exception ex)
			{
                while(ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }

				responseMessage = new ResponseMessage();
                responseMessage.Status = ErrorLevel.Error;
                responseMessage.Errors.Add(new ErrorMessage(ex));
			}

            Context.Response.Output.Write(AbstractData.SerializeJson(responseMessage));
		}

        [WebMethod]
        public string Info()
        {
            String result = "";
            foreach (var item in ConnectionSettings.Connections)
            {
                result += item.ConnectionString + Environment.NewLine;
                result += ServiceLocator.GetConnection(item.Name).State + Environment.NewLine;
            }

            return result;
        }
	}
}