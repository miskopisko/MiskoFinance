using log4net;
using MiskoFinanceCore.Data.Viewed;
using MiskoPersist.Attributes;
using MiskoPersist.Message.Responses;

namespace MiskoFinanceCore.Message.Responses
{
	public class LogonRS : ResponseMessage
	{
		private static ILog Log = LogManager.GetLogger(typeof(LogonRS));

		#region Parameters

		[Viewed]
		public VwOperator Operator { get; set; }

		#endregion
	}
}
