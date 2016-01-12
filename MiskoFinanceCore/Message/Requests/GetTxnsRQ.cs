using System;
using MiskoPersist.Core;
using MiskoPersist.Data;
using MiskoPersist.Message.Request;

namespace MiskoFinanceCore.Message.Requests
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
