using MPersist.Core;
using MPersist.Message;
using MPFinanceCore.Message.Requests;
using MPFinanceCore.Message.Responses;

namespace MPFinanceCore.Message
{
    public class GetTxns : MessageWrapper
    {
        private static Logger Log = Logger.GetInstance(typeof(GetTxns));

        #region Properties

        public new GetTxnsRQ Request { get { return (GetTxnsRQ)base.Request; } }
        public new GetTxnsRS Response { get { return (GetTxnsRS)base.Response; } }

        #endregion

        public GetTxns(GetTxnsRQ request, GetTxnsRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
            Response.Txns.Fetch(session, Request.Page, Request.Operator, Request.Account, Request.FromDate, Request.ToDate, Request.Category, Request.Description);
            Response.Summary.Fetch(session, Request.Operator, Request.Account, Request.FromDate, Request.ToDate, Request.Category, Request.Description);
        }
    }
}
