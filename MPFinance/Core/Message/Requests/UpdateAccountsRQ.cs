using MPersist.Core;
using MPersist.Core.Message.Request;
using MPFinance.Core.Data.Viewed;

namespace MPFinance.Core.Message.Requests
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
