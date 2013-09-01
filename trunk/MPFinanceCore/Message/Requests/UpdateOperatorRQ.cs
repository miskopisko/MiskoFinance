using System;
using MPersist.Core;
using MPersist.Message.Request;
using MPFinanceCore.Data.Viewed;

namespace MPFinanceCore.Message.Requests
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
