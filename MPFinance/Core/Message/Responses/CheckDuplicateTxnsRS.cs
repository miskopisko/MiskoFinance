using MPersist.Core;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Viewed;

namespace MPFinance.Core.Message.Responses
{
    public class CheckDuplicateTxnsRS : AbstractResponse
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
