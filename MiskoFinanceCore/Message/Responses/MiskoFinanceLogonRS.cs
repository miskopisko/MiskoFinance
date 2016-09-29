using log4net;
using MiskoFinanceCore.Data.Viewed;
using MiskoPersist.Attributes;
using MiskoPersist.Message.Responses;

namespace MiskoFinanceCore.Message.Responses
{
	public class MiskoFinanceLogonRS : LogonRS
	{
		private static ILog Log = LogManager.GetLogger(typeof(MiskoFinanceLogonRS));

		#region Parameters

		[Viewed]
		public VwOperator Operator { get; set; }

		#endregion
	}
}
