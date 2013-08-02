using MPersist.Core;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Viewed;

namespace MPFinance.Core.Message.Responses
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
