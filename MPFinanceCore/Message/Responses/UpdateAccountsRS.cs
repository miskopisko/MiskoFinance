using MPersist.Core;
using MPersist.Message.Response;
using MPFinanceCore.Data.Viewed;

namespace MPFinanceCore.Message.Responses
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
