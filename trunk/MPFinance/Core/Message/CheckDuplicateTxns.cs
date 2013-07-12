using System;
using System.Collections.Generic;
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
            txnsToChackAgainst.FetchByAccountAndDate(session, Request.Account.Id, Request.FromDate, Request.ToDate);
            
            // Build a dictionary hashtable to check against
            Dictionary<String, Txn> existingTxnHashes = new Dictionary<String, Txn>();            
            foreach (Txn txn in txnsToChackAgainst)
	        {
		        existingTxnHashes.Add(txn.HashCode, txn);
	        }

            // Generate a hash for each imported txn and compare to the hash table; add if non existant
            foreach (VwTxn vwTxn in Request.Transactions)
            {
                if (!existingTxnHashes.ContainsKey(vwTxn.GenerateHashCode(Request.Account)))
                {
                    Response.Txns.Add(vwTxn);
                }
            }
        }
    }
}
