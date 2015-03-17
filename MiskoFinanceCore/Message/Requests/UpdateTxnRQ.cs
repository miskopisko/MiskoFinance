using System;
using MiskoPersist.Core;
using MiskoPersist.Data;
using MiskoPersist.Message.Request;
using MiskoFinanceCore.Data.Viewed;

namespace MiskoFinanceCore.Message.Requests
{
    public class UpdateTxnRQ : RequestMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(UpdateTxnRQ));

        #region Parameters

        public VwTxn Txn { get; set; }
        public VwSummary Summary { get; set; } 
        
        #endregion

        public UpdateTxnRQ()
        {
        }
    }
}
