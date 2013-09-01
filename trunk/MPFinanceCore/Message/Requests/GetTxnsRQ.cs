using System;
using MPersist.Core;
using MPersist.Data;
using MPersist.Message.Request;

namespace MPFinanceCore.Message.Requests
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
        public String Description { get; set; }

        #endregion

        public GetTxnsRQ()
        {
        }
    }
}
