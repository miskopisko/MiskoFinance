using log4net;
using MiskoFinanceCore.Data.Viewed;
using MiskoPersist.Attributes;
using MiskoPersist.Message.Response;

namespace MiskoFinanceCore.Message.Responses
{
	public class UpdateAccountsRS : ResponseMessage
	{
		private static ILog Log = LogManager.GetLogger(typeof(UpdateAccountsRS));

		#region Parameters

		[Viewed]
		public VwBankAccounts BankAccounts { get; set; }

		#endregion
	}
}
