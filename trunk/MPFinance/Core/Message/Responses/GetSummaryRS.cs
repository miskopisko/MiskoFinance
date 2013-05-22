using MPersist.Core;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Viewed;

namespace MPFinance.Core.Message.Responses
{
    public class GetSummaryRS : AbstractResponse
    {
        private static Logger Log = Logger.GetInstance(typeof(GetSummaryRS));

        #region Parameters

        public VwSummary Summary { get; set; }

        #endregion

        public GetSummaryRS()
        {
            Summary = new VwSummary();
        }
    }
}
