using MPersist.Core;
using MPersist.Core.Message.Request;
using MPFinance.Core.Data.Viewed;
using MPersist.Core.Data;

namespace MPFinance.Core.Message.Requests
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
