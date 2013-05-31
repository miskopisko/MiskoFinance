using System;
using MPersist.Core;
using MPersist.Core.Message.Request;
using MPFinance.Core.Data.Stored;

namespace MPFinance.Core.Message.Requests
{
    public class GetTxnsRQ : AbstractRequest
    {
        private static Logger Log = Logger.GetInstance(typeof(GetTxnsRQ));

        #region Parameters

        public Operator Operator { get; set; }
        public Account Account { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public Category Category { get; set; }

        #endregion
    }
}
