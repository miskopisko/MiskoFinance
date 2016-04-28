using log4net;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;
using MiskoPersist.Core;
using MiskoPersist.Message;

namespace MiskoFinanceCore.Message
{
	public class UpdateTxn : MessageWrapper
    {
        private static ILog Log = LogManager.GetLogger(typeof(UpdateTxn));

        #region Properties

        public new UpdateTxnRQ Request { get { return (UpdateTxnRQ)base.Request; } }
        public new UpdateTxnRS Response { get { return (UpdateTxnRS)base.Response; }}

        #endregion

        public UpdateTxn(UpdateTxnRQ request, UpdateTxnRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
            Request.Txn.Update(session);
            
            Response.Summary = new VwSummary();
            Response.Summary.Fetch(session, Request.Operator, Request.Account, Request.FromDate, Request.ToDate, Request.Category, Request.Description);
        }
    }
}
