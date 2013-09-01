using MPersist.Core;
using MPersist.Message.Request;
using MPFinanceCore.Data.Viewed;

namespace MPFinanceCore.Message.Requests
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
