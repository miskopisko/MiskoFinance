using MPersist.Core;
using MPersist.Core.Enums;
using MPersist.Core.Message;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Data.Viewed;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;
using MPFinance.Resources;
using System.Reflection;

namespace MPFinance.Core.Message
{
    public class ImportTxns : MessageWrapper
    {
        private static Logger Log = Logger.GetInstance(typeof(ImportTxns));

        #region Properties

        public new ImportTxnsRQ Request { get { return (ImportTxnsRQ)base.Request; } }
        public new ImportTxnsRS Response { get { return (ImportTxnsRS)base.Response; } }

        #endregion

        public ImportTxns(ImportTxnsRQ request, ImportTxnsRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
            if (Request.Account != null)
            {
                Request.Account.Save(session);
            }
            else
            {
                session.Error(ErrorLevel.Error, ErrorStrings.errInvalidAccount);
            }

            foreach (VwTxn vwTxn in Request.VwTxns)
            {
                Txn txn = new Txn();
                txn.Account = Request.Account.Id;
                txn.Amount = vwTxn.Amount;
                txn.DatePosted = vwTxn.DatePosted;
                txn.Description = vwTxn.Description;
                txn.HashCode = vwTxn.HashCode;
                txn.TxnType = vwTxn.TxnType;
                txn.IsSet = true;
                txn.Save(session);
            }

        }
    }
}
