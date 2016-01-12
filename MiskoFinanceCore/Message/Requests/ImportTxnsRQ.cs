using System;
using MiskoFinanceCore.Data.Viewed;
using MiskoPersist.Core;
using MiskoPersist.Message.Request;

namespace MiskoFinanceCore.Message.Requests
{
	public class ImportTxnsRQ : RequestMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(ImportTxnsRQ));

        #region Parameters

        public VwOperator Operator { get; set; }
        public VwBankAccount BankAccount { get; set; }
        public VwTxns Txns { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        #endregion

        public ImportTxnsRQ()
        {
        }
    }
}
