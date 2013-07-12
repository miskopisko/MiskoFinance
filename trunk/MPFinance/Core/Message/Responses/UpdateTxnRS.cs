using MPersist.Core;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Viewed;

namespace MPFinance.Core.Message.Responses
{
    public class UpdateTxnRS : AbstractResponse
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
