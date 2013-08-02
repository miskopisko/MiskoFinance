using MPersist.Core;
using MPersist.Core.Message.Request;
using MPFinance.Core.Data.Viewed;

namespace MPFinance.Core.Message.Requests
{
    public class ImportTxnsRQ : RequestMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(ImportTxnsRQ));

        #region Parameters

        public VwOperator Operator { get; set; }
        public VwBankAccount BankAccount { get; set; }
        public VwTxns VwTxns { get; set; }

        #endregion

        public ImportTxnsRQ()
        {
        }
    }
}
