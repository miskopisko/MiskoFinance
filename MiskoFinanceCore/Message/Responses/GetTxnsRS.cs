using MiskoPersist.Data;
using log4net;
using MiskoFinanceCore.Data.Viewed;
using MiskoPersist.Attributes;
using MiskoPersist.Message.Response;

namespace MiskoFinanceCore.Message.Responses
{
	public class GetTxnsRS : ResponseMessage
	{
		private static ILog Log = LogManager.GetLogger(typeof(GetTxnsRS));

		#region Viewed Parameters

		[Viewed]
		public VwTxns Txns { get; set; }
		[Viewed]
		public VwSummary Summary { get; set; }
		[Viewed]
		public Page Page { get; set; }

		#endregion
	}
}
