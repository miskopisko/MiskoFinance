using System;
using log4net;
using MiskoPersist.Attributes;
using MiskoPersist.Data;
using MiskoPersist.Message.Request;

namespace MiskoFinanceCore.Message.Requests
{
	public class GetAccountRQ : RequestMessage
	{
		private static ILog Log = LogManager.GetLogger(typeof(GetAccountRQ));

		#region Parameters

		[Viewed]
		public PrimaryKey Operator { get; set;}
		[Viewed]
		public String AccountNo { get; set; }

		#endregion
	}
}
