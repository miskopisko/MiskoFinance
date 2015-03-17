using MiskoPersist.Core;
using MiskoPersist.Message.Response;
using MiskoFinanceCore.Data.Viewed;

namespace MiskoFinanceCore.Message.Responses
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