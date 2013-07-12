using System;
using MPersist.Core;
using MPersist.Core.Data;
using MPersist.Core.Message.Request;
using MPFinance.Core.Enums;

namespace MPFinance.Core.Message.Requests
{
    public class GetAccountRQ : AbstractRequest
    {
        private static Logger Log = Logger.GetInstance(typeof(GetAccountRQ));

        #region Parameters

        public PrimaryKey Operator { get; set;}
        public AccountType AccountType { get; set;}
        public String BankNo { get; set;}
        public String AccountNo { get; set; }

        #endregion

        public GetAccountRQ()
        {
        }
    }
}
