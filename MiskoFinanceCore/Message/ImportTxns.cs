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
            Request.BankAccount.Update(session);

            // Save each txn
            foreach (VwTxn vwTxn in Request.VwTxns)
            {
            	Txn txn = new Txn
            	{
            		Account = Response.BankAccount.BankAccountId,
            		DrCr = vwTxn.DrCr,
            	 	Amount = vwTxn.Amount,
            	 	Category = vwTxn.Category,
            	 	DatePosted = vwTxn.DatePosted,
            	 	Description = vwTxn.Description,
            	 	HashCode = vwTxn.HashCode,
            	 	OneTime = vwTxn.OneTime,
            	 	Transfer = vwTxn.Transfer
            	};            	
            	txn.Save(session);
            }
        }
    }
}
