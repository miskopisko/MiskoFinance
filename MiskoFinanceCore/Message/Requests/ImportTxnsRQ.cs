using System;
using MiskoPersist.Core;
using MiskoPersist.Message.Request;
using MiskoFinanceCore.Data.Viewed;

namespace MiskoFinanceCore.Message.Requests
{
    public class ImportTxnsRQ : RequestMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(ImportTxnsRQ));

        #region Parameters

        public VwOperator Operator { get; set; }
        public VwBankAccount BankAccount { get; set; }
        public VwTxns VwTxns { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        #endregion

        public ImportTxnsRQ()
        {
        }
    }
}
