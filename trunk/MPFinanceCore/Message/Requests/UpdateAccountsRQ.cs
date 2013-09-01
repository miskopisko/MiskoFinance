using MPersist.Core;
using MPersist.Message.Request;
using MPFinanceCore.Data.Viewed;

namespace MPFinanceCore.Message.Requests
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
