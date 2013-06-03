using MPersist.Core;
using MPersist.Core.Message.Request;
using MPFinance.Core.Data.Stored;
using System;

namespace MPFinance.Core.Message.Requests
{
    public class GetAccountsRQ : AbstractRequest
    {
        private static Logger Log = Logger.GetInstance(typeof(GetAccountsRQ));

        #region Parameters

        public Operator Operator { get; set; }

        #endregion

        public GetAccountsRQ()
        {
        }
    }
}
