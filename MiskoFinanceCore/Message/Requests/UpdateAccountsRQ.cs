using log4net;
using MiskoFinanceCore.Data.Viewed;
using MiskoPersist.Attributes;
using MiskoPersist.Message.Requests;

namespace MiskoFinanceCore.Message.Requests
{
	public class UpdateAccountsRQ : RequestMessage
	{
		private static ILog Log = LogManager.GetLogger(typeof(UpdateAccountsRQ));

		#region Parameters

		[Viewed]
		public VwBankAccounts BankAccounts { get; set; }

		#endregion
	}
}
