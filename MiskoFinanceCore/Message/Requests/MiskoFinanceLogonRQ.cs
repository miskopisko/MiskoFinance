using System;
using log4net;
using MiskoPersist.Message.Requests;

namespace MiskoFinanceCore.Message.Requests
{
	public class MiskoFinanceLogonRQ : LogonRQ
	{
		private static ILog Log = LogManager.GetLogger(typeof(MiskoFinanceLogonRQ));		
	}
}
