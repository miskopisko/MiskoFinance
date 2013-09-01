using System;
using MPersist.Core;
using MPersist.Data;
using MPersist.Message.Request;

namespace MPFinanceCore.Message.Requests
{
    public class GetAccountRQ : RequestMessage
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
