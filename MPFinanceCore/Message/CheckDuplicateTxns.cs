using System;
using System.Collections.Generic;
using MPersist.Core;
using MPersist.Message;
using MPFinanceCore.Data.Stored;
using MPFinanceCore.Data.Viewed;
using MPFinanceCore.Message.Requests;
using MPFinanceCore.Message.Responses;

namespace MPFinanceCore.Message
{
    public class CheckDuplicateTxns : MessageWrapper
    {
        private static Logger Log = Logger.GetInstance(typeof(CheckDuplicateTxns));

        #region Properties

        public new CheckDuplicateTxnsRQ Request { get { return (CheckDuplicateTxnsRQ)base.Request; } }
        public new CheckDuplicateTxnsRS Response { get { return (CheckDuplicateTxnsRS)base.Response; } }

        #endregion

        public CheckDuplicateTxns(CheckDuplicateTxnsRQ request, CheckDuplicateTxnsRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
            // Get all existing txns with the same timeframe
            Txns txnsToChackAgainst = new Txns();
            txnsToChackAgainst.FetchByAccountAndDate(session, Request.BankAccount.BankAccountId, Request.FromDate, Request.ToDate);
            
            // Build a dictionary hashtable to check against
            Dictionary<String, Txn> existingTxnHashes = new Dictionary<String, Txn>();            
            foreach (Txn txn in txnsToChackAgainst)
	        {
                existingTxnHashes.Add(txn.HashCode, txn);
	        }

            // Generate a hash for each imported txn and compare to the hash table; add if non existant
            foreach (VwTxn vwTxn in Request.Transactions)
            {
                if (!existingTxnHashes.ContainsKey(vwTxn.HashCode))
                {
                    Response.Txns.Add(vwTxn);
                }
            }
        }
    }
}
