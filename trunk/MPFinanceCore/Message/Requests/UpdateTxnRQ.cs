using System;
using MPersist.Core;
using MPersist.Data;
using MPersist.Message.Request;
using MPFinanceCore.Data.Viewed;

namespace MPFinanceCore.Message.Requests
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
