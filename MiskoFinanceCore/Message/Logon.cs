using System;
using log4net;
using MiskoFinanceCore.Data.Stored;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;
using MiskoPersist.Core;
using MiskoPersist.Data.Stored;
using MiskoPersist.Enums;
using MiskoPersist.Message;

namespace MiskoFinanceCore.Message
{
	public class Logon : MessageWrapper
    {
        private static ILog Log = LogManager.GetLogger(typeof(Logon));

        #region Properties

        public new LogonRQ Request { get { return (LogonRQ)base.Request; } }
        public new LogonRS Response  { get { return (LogonRS)base.Response; } }

        #endregion

        public Logon(LogonRQ request, LogonRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
        	if(String.IsNullOrEmpty(Request.Username))
            {
                session.Error(ErrorLevel.Error, "Invalid username.");
            }
        	
        	Operator o = new Operator();
        	o.FetchByUsername(session, Request.Username);
        	
        	if(o.IsSet)
        	{
        		Response.SessionToken = o.Logon(session, Request.Password);
        		
				Response.Operator = new VwOperator();
				Response.Operator.OperatorId = o.Id;
				Response.Operator.Fetch(session, true);
        	}
 			else
            {
                session.Error(ErrorLevel.Error, "Invalid username or password. Please try again.");
            }
        }
    }
}
