using MPersist.Core;
using MPersist.Core.Message.Request;
using MPFinance.Core.Data.Stored;

namespace MPFinance.Core.Message.Requests
{
    public class UpdateAccountsRQ : AbstractRequest
    {
        private static Logger Log = Logger.GetInstance(typeof(UpdateAccountsRQ));

        #region Parameters

        public BankAccounts Accounts { get; set; }

        #endregion

        public UpdateAccountsRQ()
        {
        }
    }
}
