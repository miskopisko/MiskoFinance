using System;
using log4net;
using MiskoFinanceCore.Data.Viewed;
using MiskoPersist.Attributes;
using MiskoPersist.Message.Request;

namespace MiskoFinanceCore.Message.Requests
{
	public class UpdateOperatorRQ : RequestMessage
	{
		private static ILog Log = LogManager.GetLogger(typeof(UpdateOperatorRQ));

		#region Parameters

		[Viewed]
		public VwOperator Operator { get; set; }
		[Viewed]
		public String Password1 { get; set; }
		[Viewed]
		public String Password2 { get; set; }

		#endregion
	}
}
