using log4net;
using MiskoFinanceCore.Data.Viewed;
using MiskoPersist.Attributes;
using MiskoPersist.Message.Responses;

namespace MiskoFinanceCore.Message.Responses
{
	public class UpdateTxnRS : ResponseMessage
	{
		private static ILog Log = LogManager.GetLogger(typeof(UpdateTxnRS));

		#region Parameters

		[Viewed]
		public VwSummary Summary { get; set; }

		#endregion
	}
}
