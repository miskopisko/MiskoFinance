using log4net;
using MiskoFinanceCore.Data.Viewed;
using MiskoPersist.Attributes;
using MiskoPersist.Message.Response;

namespace MiskoFinanceCore.Message.Responses
{
	public class UpdateOperatorRS : ResponseMessage
	{
		private static ILog Log = LogManager.GetLogger(typeof(UpdateOperatorRS));

		#region Parameters

		[Viewed]
		public VwOperator Operator { get; set; }

		#endregion
	}
}
