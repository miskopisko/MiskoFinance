using MiskoPersist.Core;
using MiskoPersist.Message.Request;
using MiskoFinanceCore.Data.Viewed;

namespace MiskoFinanceCore.Message.Requests
{
    public class UpdateAccountsRQ : RequestMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(UpdateAccountsRQ));

        #region Parameters

        public VwBankAccounts BankAccounts { get; set; }

        #endregion

        public UpdateAccountsRQ()
        {
        }
    }
}
