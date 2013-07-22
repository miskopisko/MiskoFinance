using System;
using MPersist.Core;
using MPersist.Core.Data;
using MPersist.Core.Message.Request;

namespace MPFinance.Core.Message.Requests
{
    public class GetAccountRQ : AbstractRequest
    {
        private static Logger Log = Logger.GetInstance(typeof(GetAccountRQ));

        #region Parameters

        public PrimaryKey Operator { get; set;}
        public String AccountNo { get; set; }

        #endregion

        public GetAccountRQ()
        {
        }
    }
}
