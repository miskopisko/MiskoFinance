using System;
using MPersist.Core;
using MPersist.Core.Data;
using MPersist.Core.Message.Request;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Data.Viewed;

namespace MPFinance.Core.Message.Requests
{
    public class CheckDuplicateTxnsRQ : RequestMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(CheckDuplicateTxnsRQ));

        #region Parameters

        public PrimaryKey Operator { get; set; }
        public BankAccount Account { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public VwTxns Transactions { get; set; }

        #endregion

        public CheckDuplicateTxnsRQ()
        {
        }
    }
}
