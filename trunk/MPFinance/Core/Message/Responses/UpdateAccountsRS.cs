using MPersist.Core;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Viewed;

namespace MPFinance.Core.Message.Responses
{
    public class UpdateAccountsRS : ResponseMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(UpdateAccountsRS));

        #region Parameters

        public VwBankAccounts BankAccounts { get; set; }

        #endregion
        
        public UpdateAccountsRS()
        {
            BankAccounts = new VwBankAccounts();
        }
    }
}
