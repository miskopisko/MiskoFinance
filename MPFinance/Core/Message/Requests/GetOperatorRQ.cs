using MPersist.Core;
using MPersist.Core.Message.Request;
using System;

namespace MPFinance.Core.Message.Requests
{
    public class GetOperatorRQ : AbstractRequest
    {
        private static Logger Log = Logger.GetInstance(typeof(GetOperatorRQ));

        #region Parameters

        public String Username { get; set; }

        #endregion

        public GetOperatorRQ()
        {

        }
    }
}