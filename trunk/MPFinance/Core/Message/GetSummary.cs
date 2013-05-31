using MPersist.Core;
using MPersist.Core.Message;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;

namespace MPFinance.Core.Message
{
    public class GetSummary : AbstractMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(GetSummary));

        #region Properties

        public new GetSummaryRQ Request
        {
            get
            {
                return (GetSummaryRQ)base.Request;
            }
        }

        public new GetSummaryRS Response
        {
            get
            {
                return (GetSummaryRS)base.Response;
            }
        }

        #endregion

        public GetSummary(GetSummaryRQ request, GetSummaryRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
            Response.Summary.Fetch(session, Request.Operator, Request.Account, Request.FromDate, Request.ToDate, Request.Category);
        }
    }
}
