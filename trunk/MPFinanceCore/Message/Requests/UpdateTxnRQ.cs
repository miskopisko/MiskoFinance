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
        public PrimaryKey Operator { get; set; }
        public PrimaryKey BankAccount { get; set; }
        public PrimaryKey Category { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public String Description { get; set; }

        #endregion

        public UpdateTxnRQ()
        {
        }
    }
}
