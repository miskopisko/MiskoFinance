using System;
using log4net;
using MiskoFinanceCore.Data.Viewed;
using MiskoPersist.Attributes;
using MiskoPersist.Data;
using MiskoPersist.Message.Request;

namespace MiskoFinanceCore.Message.Requests
{
	public class UpdateTxnRQ : RequestMessage
	{
		private static ILog Log = LogManager.GetLogger(typeof(UpdateTxnRQ));

		#region Parameters

		[Viewed]
		public VwTxn Txn { get; set; }
		[Viewed]
		public PrimaryKey Operator { get; set; }
		[Viewed]
		public PrimaryKey Account { get; set; }
		[Viewed]
		public DateTime FromDate { get; set; }
		[Viewed]
		public DateTime ToDate { get; set; }
		[Viewed]
		public PrimaryKey Category { get; set; }
		[Viewed]
		public String Description { get; set; }
		
		#endregion
	}
}
