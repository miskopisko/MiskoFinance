﻿using log4net;
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

		public Logon(LogonRQ request, LogonRS response) 
			: base(request, response)
		{
		}

		public override void Execute(Session session)
		{
			Operator mOperator_ = new Operator();
			mOperator_.FetchByUsername(session, Request.Username);
			
			if(mOperator_.IsSet)
			{
				mOperator_.Logon(session, Request.Password);
				
				Response.Operator = new VwOperator();
				Response.Operator.OperatorId = mOperator_.Id; 
				Response.Operator.Fetch(session, true);
			}
			else
			{
				session.Error(ErrorLevel.Error, "Invalid username or password.");
			}
		}
	}
}
