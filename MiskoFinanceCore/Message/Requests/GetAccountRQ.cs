using System;
using MiskoPersist.Core;
using MiskoPersist.Data;
using MiskoPersist.Message.Request;

namespace MiskoFinanceCore.Message.Requests
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
