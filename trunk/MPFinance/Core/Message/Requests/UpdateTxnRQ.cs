using MPersist.Core;
using MPersist.Core.Message.Request;
using MPFinance.Core.Data.Viewed;
using System;

namespace MPFinance.Core.Message.Requests
{
    public class UpdateTxnRQ : AbstractRequest
    {
        private static Logger Log = Logger.GetInstance(typeof(UpdateTxnRQ));

        #region Parameters

        public VwTxn VwTxn { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        #endregion

        public UpdateTxnRQ()
        {
        }
    }
}
