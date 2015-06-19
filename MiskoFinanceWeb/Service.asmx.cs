using System;
using System.Diagnostics;
using System.IO;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using MiskoPersist.Core;
using MiskoPersist.Data;
using MiskoPersist.Enums;
using MiskoPersist.Message.Response;

namespace MiskoFinanceWeb
{
	[WebService(Namespace="http://miskofinance.piskuric.ca")]
	public class Service : System.Web.Services.WebService
	{
		[WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void ProcessRequest(String request)
		{
            ResponseMessage responseMessage;

			try
			{
                responseMessage = MessageProcessor.Process(request);

                #if DEBUG
                    String response1 = AbstractData.SerializeJson(responseMessage);
                    String response2 = AbstractData.SerializeJson((ResponseMessage)AbstractData.DeserializeJson(response1));
                    if(!response1.Equals(response2))
                    {
                        File.WriteAllText(@"D:\TEMP\Response1.txt", response1);
                        File.WriteAllText(@"D:\TEMP\Response2.txt", response2);
                        Process pr = new Process();
                        pr.StartInfo.FileName = @"C:\Program Files (x86)\Beyond Compare 4\BCompare.exe";
                        pr.StartInfo.Arguments = '\u0022' + @"D:\TEMP\Response1.txt" + '\u0022' + " " + '\u0022' + @"D:\TEMP\Response2.txt" + '\u0022';
                        pr.Start();
                    }
                #endif
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
	}
}