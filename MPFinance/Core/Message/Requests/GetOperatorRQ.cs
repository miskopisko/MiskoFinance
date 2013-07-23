using System;
using MPersist.Core;
using MPersist.Core.Message.Request;

namespace MPFinance.Core.Message.Requests
{
    public class GetOperatorRQ : RequestMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(GetOperatorRQ));

        #region Parameters

        public String Username { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        #endregion

        public GetOperatorRQ()
        {
        }
    }
}
