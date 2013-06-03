using MPersist.Core;
using MPersist.Core.Message.Request;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Data.Viewed;
using System;

namespace MPFinance.Core.Message.Requests
{
    public class ImportTxnsRQ : AbstractRequest
    {
        private static Logger Log = Logger.GetInstance(typeof(ImportTxnsRQ));

        #region Parameters

        public Account Account { get; set; }
        public VwTxns VwTxns { get; set; }

        #endregion

        public ImportTxnsRQ()
        {
        }
    }
}
