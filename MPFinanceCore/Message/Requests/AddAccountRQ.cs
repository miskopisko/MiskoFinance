using MPersist.Core;
using MPersist.Message.Request;
using MPFinanceCore.Data.Viewed;

namespace MPFinanceCore.Message.Requests
{
    public class AddAccountRQ : RequestMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(AddAccountRQ));

        #region Parameters

        public VwOperator Operator { get; set; }
        public VwBankAccount BankAccount { get; set; }

        #endregion

        public AddAccountRQ()
        {
        }
    }
}
