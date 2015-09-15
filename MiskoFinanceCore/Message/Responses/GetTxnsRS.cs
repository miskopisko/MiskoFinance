using MiskoFinanceCore.Data.Viewed;
using MiskoPersist.Core;
using MiskoPersist.Message.Response;

namespace MiskoFinanceCore.Message.Responses
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
        }
    }
}
