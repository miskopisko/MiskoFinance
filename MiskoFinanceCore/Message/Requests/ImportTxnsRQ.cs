using System;
using log4net;
using MiskoFinanceCore.Data.Viewed;
using MiskoPersist.Attributes;
using MiskoPersist.Message.Request;

namespace MiskoFinanceCore.Message.Requests
{
	public class ImportTxnsRQ : RequestMessage
	{
		private static ILog Log = LogManager.GetLogger(typeof(ImportTxnsRQ));

		#region Parameters

		[Viewed]
		public VwOperator Operator { get; set; }
		[Viewed]
		public VwBankAccount BankAccount { get; set; }
		[Viewed]
		public VwTxns Txns { get; set; }
		[Viewed]
		public DateTime FromDate { get; set; }
		[Viewed]
		public DateTime ToDate { get; set; }

		#endregion
	}
}
