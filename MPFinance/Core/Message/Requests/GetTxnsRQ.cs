using System;
using MPersist.Core;
using MPersist.Core.Data;
using MPersist.Core.Message.Request;

namespace MPFinance.Core.Message.Requests
{
    public class GetTxnsRQ : RequestMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(GetTxnsRQ));

        #region Parameters

        public PrimaryKey Operator { get; set; }
        public PrimaryKey Account { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public PrimaryKey Category { get; set; }

        #endregion

        public GetTxnsRQ()
        {
        }
    }
}
