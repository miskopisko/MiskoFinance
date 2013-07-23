using MPersist.Core;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Data.Viewed;

namespace MPFinance.Core.Message.Responses
{
    public class GetOperatorRS : ResponseMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(GetOperatorRS));

        #region Parameters

        public Operator Operator { get; set; }
        public VwTxns Txns { get; set; }
        public VwSummary Summary { get; set; }

        #endregion

        public GetOperatorRS()
        {
            Operator = new Operator();
            Txns = new VwTxns();
            Summary = new VwSummary();
        }
    }
}
