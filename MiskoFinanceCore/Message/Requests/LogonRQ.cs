using System;
using log4net;
using MiskoPersist.Attributes;
using MiskoPersist.Message.Requests;

namespace MiskoFinanceCore.Message.Requests
{
	public class LogonRQ : RequestMessage
	{
		private static ILog Log = LogManager.GetLogger(typeof(LogonRQ));
		
		#region Parameters

		[Viewed]
		public String Username { get; set; }
		[Viewed]
		public String Password { get; set; }

		#endregion

		#region Other Properties

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
