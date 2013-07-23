using MPersist.Core;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Viewed;

namespace MPFinance.Core.Message.Responses
{
    public class GetTxnsRS : ResponseMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(GetTxnsRS));

        #region Parameters

        public VwTxns Txns { get; set; }
        public VwSummary Summary { get; set; }

        #endregion

        public GetTxnsRS()
        {
            Txns = new VwTxns();
            Summary = new VwSummary();
        }
    }
}
