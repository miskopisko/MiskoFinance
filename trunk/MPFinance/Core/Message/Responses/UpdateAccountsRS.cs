using MPersist.Core;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Stored;

namespace MPFinance.Core.Message.Responses
{
    public class UpdateAccountsRS : AbstractResponse
    {
        private static Logger Log = Logger.GetInstance(typeof(UpdateAccountsRS));

        #region Parameters

        public BankAccounts Accounts { get; set; }

        #endregion

        public UpdateAccountsRS()
        {
            Accounts = new BankAccounts();
        }
    }
}
