using log4net;
using MiskoFinanceCore.Data.Viewed;
using MiskoPersist.Attributes;
using MiskoPersist.Message.Response;

namespace MiskoFinanceCore.Message.Responses
{
	public class LoginRS : ResponseMessage
	{
		private static ILog Log = LogManager.GetLogger(typeof(LoginRS));

		#region Parameters

		[Viewed]
		public VwOperator Operator { get; set; }

		#endregion
	}
}
