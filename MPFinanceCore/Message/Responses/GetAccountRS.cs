using MPersist.Core;
using MPersist.Message.Response;
using MPFinanceCore.Data.Viewed;

namespace MPFinanceCore.Message.Responses
{
    public class GetAccountRS : ResponseMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(GetAccountRS));

        #region Parameters

        public VwBankAccount BankAccount { get; set; }

        #endregion

        public GetAccountRS()
        {
            BankAccount = new VwBankAccount();
        }
    }
}
