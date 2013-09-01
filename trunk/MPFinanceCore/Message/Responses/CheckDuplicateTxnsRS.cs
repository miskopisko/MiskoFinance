using MPersist.Core;
using MPersist.Message.Response;
using MPFinanceCore.Data.Viewed;

namespace MPFinanceCore.Message.Responses
{
    public class CheckDuplicateTxnsRS : ResponseMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(CheckDuplicateTxnsRS));

        #region Parameters

        public VwTxns Txns { get; set; }

        #endregion

        public CheckDuplicateTxnsRS()
        {
            Txns = new VwTxns();
        }
    }
}
