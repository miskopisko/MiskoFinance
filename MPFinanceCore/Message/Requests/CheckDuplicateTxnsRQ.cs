using System;
using MPersist.Core;
using MPersist.Data;
using MPersist.Message.Request;
using MPFinanceCore.Data.Viewed;

namespace MPFinanceCore.Message.Requests
{
    public class CheckDuplicateTxnsRQ : RequestMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(CheckDuplicateTxnsRQ));

        #region Parameters

        public PrimaryKey Operator { get; set; }
        public VwBankAccount BankAccount { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public VwTxns Transactions { get; set; }

        #endregion

        public CheckDuplicateTxnsRQ()
        {
        }
    }
}
