using System;
using MiskoPersist.Core;
using MiskoPersist.Message.Request;
using MiskoFinanceCore.Data.Viewed;

namespace MiskoFinanceCore.Message.Requests
{
    public class UpdateOperatorRQ : RequestMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(UpdateOperatorRQ));

        #region Parameters

        public VwOperator Operator { get; set; }
        public String Password1 { get; set; }
        public String Password2 { get; set; }

        #endregion

        public UpdateOperatorRQ()
        {
        }
    }
}