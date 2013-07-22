using MPersist.Core;
using MPersist.Core.Message;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;

namespace MPFinance.Core.Message
{
    public class UpdateTxn : AbstractMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(UpdateTxn));

        #region Properties

        public new UpdateTxnRQ Request { get { return (UpdateTxnRQ)base.Request; } }
        public new UpdateTxnRS Response { get { return (UpdateTxnRS)base.Response; }}

        #endregion

        public UpdateTxn(UpdateTxnRQ request, UpdateTxnRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
            Txn txn = (Txn)Txn.GetInstanceById(session, typeof(Txn), Request.VwTxn.TxnId, true);
            txn.TxnType = Request.VwTxn.TxnType;
            txn.Category = Request.VwTxn.Category;
            txn.Save(session);

            Response.Summary.Fetch(session, Request.Operator, Request.Account, Request.FromDate, Request.ToDate, Request.Category);
        }
    }
}
