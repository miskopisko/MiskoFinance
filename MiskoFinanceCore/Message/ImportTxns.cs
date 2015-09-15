using System;
using System.Collections.Generic;
using MiskoFinanceCore.Data.Stored;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;
using MiskoPersist.Core;
using MiskoPersist.Enums;
using MiskoPersist.Message;

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
            
            // Get all existing txns with the same timeframe
            Txns txnsToChackAgainst = new Txns();
            txnsToChackAgainst.FetchByAccountAndDate(session, Request.BankAccount.BankAccountId, Request.FromDate, Request.ToDate);
            
            // Build a dictionary hashtable to check against
            Dictionary<String, Txn> existingTxnHashes = new Dictionary<String, Txn>();            
            foreach (Txn txn in txnsToChackAgainst)
	        {
                existingTxnHashes.Add(txn.HashCode, txn);
	        }
            
            Int32 noTxnsAdded = 0;

            // Save each txn
            foreach (VwTxn vwTxn in Request.VwTxns)
            {
            	if (!existingTxnHashes.ContainsKey(vwTxn.HashCode))
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
	            	noTxnsAdded ++;
            	}
            }
            
            session.Error(ErrorLevel.Information, "Added {0} transactions to account {1}.", new Object[] { noTxnsAdded, Response.BankAccount.AccountNumber });
        }
    }
}
