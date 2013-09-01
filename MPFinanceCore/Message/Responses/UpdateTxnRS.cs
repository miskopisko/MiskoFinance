using MPersist.Core;
using MPersist.Message.Response;
using MPFinanceCore.Data.Viewed;

namespace MPFinanceCore.Message.Responses
{
    public class UpdateTxnRS : ResponseMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(UpdateTxnRS));

        #region Parameters

        public VwSummary Summary { get; set; }

        #endregion

        public UpdateTxnRS()
        {
            Summary = new VwSummary();
        }
    }
}
