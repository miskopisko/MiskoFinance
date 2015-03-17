using MiskoPersist.Core;
using MiskoPersist.Message;
using MiskoFinanceCore.Data.Stored;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;

namespace MiskoFinanceCore.Message
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
            // Save the bank account first
            Response.BankAccount = Request.BankAccount;
            Response.BankAccount.BankAccountId = Request.BankAccount.Update(session).Id;

            foreach (VwTxn vwTxn in Request.VwTxns)
            {
                Txn txn = new Txn();
                txn.Account = Response.BankAccount.BankAccountId;
                txn.Amount = vwTxn.Amount;
                txn.DatePosted = vwTxn.DatePosted;
                txn.Description = vwTxn.Description;
                txn.HashCode = vwTxn.HashCode;
                txn.TxnType = vwTxn.TxnType;
                txn.Save(session);
            }
        }
    }
}
