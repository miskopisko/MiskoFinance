using MPersist.Core;
using MPersist.Message.Response;
using MPFinanceCore.Data.Viewed;

namespace MPFinanceCore.Message.Responses
{
    public class AddAccountRS : ResponseMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(AddAccountRS));

        #region Parameters

        public VwBankAccount NewAccount { get; set; }

        #endregion

        public AddAccountRS()
        {
            NewAccount = new VwBankAccount();
        }
    }
}
