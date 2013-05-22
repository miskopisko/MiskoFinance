using MPersist.Core;
using MPersist.Core.Message;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Data.Viewed;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;

namespace MPFinance.Core.Message
{
    public class CheckDuplicateTxns : AbstractMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(CheckDuplicateTxns));

        #region Properties

        public new CheckDuplicateTxnsRQ Request
        {
            get
            {
                return (CheckDuplicateTxnsRQ)base.Request;
            }
        }

        public new CheckDuplicateTxnsRS Response
        {
            get
            {
                return (CheckDuplicateTxnsRS)base.Response;
            }
        }

        #endregion

        public CheckDuplicateTxns(CheckDuplicateTxnsRQ request, CheckDuplicateTxnsRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
            foreach (VwTxn vwTxn in Request.OfxDucument.Transactions)
            {
                vwTxn.GenerateHashCode(Request.Account);

                Txn txn = Txn.FetchByHashCode(session, vwTxn.HashCode);
                vwTxn.IsDuplicate = txn != null && txn.IsSet;

                Response.Txns.Add(vwTxn);
            }
        }
    }
}
