using System;
using MPersist.Core;
using MPersist.Core.Message.Request;
using MPFinance.Core.Data.Viewed;

namespace MPFinance.Core.Message.Requests
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
