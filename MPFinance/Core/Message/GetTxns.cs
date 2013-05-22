using MPersist.Core;
using MPersist.Core.Message;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;

namespace MPFinance.Core.Message
{
    public class GetTxns : AbstractMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(GetTxns));

        #region Properties

        public new GetTxnsRQ Request
        {
            get
            {
                return (GetTxnsRQ)base.Request;
            }
        }

        public new GetTxnsRS Response
        {
            get
            {
                return (GetTxnsRS)base.Response;
            }
        }

        #endregion

        public GetTxns(GetTxnsRQ request, GetTxnsRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
            Response.Txns.Fetch(session, Request.PageNo, Request.NoRows, Request.Operator, Request.Account, Request.FromDate, Request.ToDate);
            Response.Summary.Fetch(session, Request.Operator, Request.Account, Request.FromDate, Request.ToDate);
        }
    }
}
