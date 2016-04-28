using System;
using log4net;
using MiskoPersist.Attributes;
using MiskoPersist.Message.Request;

namespace MiskoFinanceCore.Message.Requests
{
	[Serializable]
	public class LoginRQ : RequestMessage
	{
		private static ILog Log = LogManager.GetLogger(typeof(LoginRQ));

		#region Parameters

		[Viewed]
		public String Username { get; set; }
		[Viewed]
		public String Password { get; set; }

		#endregion
	}
}
