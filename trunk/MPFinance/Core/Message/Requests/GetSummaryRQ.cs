using MPersist.Core;
using MPersist.Core.Message.Request;
using MPFinance.Core.Data.Stored;
using System;

namespace MPFinance.Core.Message.Requests
{
    public class GetSummaryRQ : AbstractRequest
    {
        private static Logger Log = Logger.GetInstance(typeof(GetSummaryRQ));

        #region Parameters

        public Operator Operator { get; set; }
        public Account Account { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        #endregion

        public GetSummaryRQ()
        {

        }
    }
}
