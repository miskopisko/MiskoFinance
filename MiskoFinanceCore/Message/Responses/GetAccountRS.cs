using log4net;
using MiskoFinanceCore.Data.Viewed;
using MiskoPersist.Attributes;
using MiskoPersist.Message.Response;

namespace MiskoFinanceCore.Message.Responses
{
	public class GetAccountRS : ResponseMessage
	{
		private static ILog Log = LogManager.GetLogger(typeof(GetAccountRS));

		#region Parameters

		[Viewed]
		public VwBankAccount BankAccount { get; set; }

		#endregion
	}
}
