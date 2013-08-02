using MPersist.Core;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Viewed;

namespace MPFinance.Core.Message.Responses
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
