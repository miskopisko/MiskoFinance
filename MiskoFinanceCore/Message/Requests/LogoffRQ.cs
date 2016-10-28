using System;
using log4net;
using MiskoPersist.Message.Requests;

namespace MiskoFinanceCore.Message.Requests
{
	public class LogoffRQ : RequestMessage
	{
		private static ILog Log = LogManager.GetLogger(typeof(LogoffRQ));
		
		#region Override Properties
		
		public override Boolean SecurityExempt
		{
			get
			{
				return true;
			}
		}
		
		#endregion
	}
}
