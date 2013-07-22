using System;
using MPersist.Core;
using MPersist.Core.Message.Request;
using MPFinance.Core.Data.Stored;

namespace MPFinance.Core.Message.Requests
{
    public class UpdateOperatorRQ : AbstractRequest
    {
        private static Logger Log = Logger.GetInstance(typeof(UpdateOperatorRQ));

        #region Parameters

        public Operator Operator { get; set; }
        public String Password1 { get; set; }
        public String Password2 { get; set; }

        #endregion

        #region Constructor

        public UpdateOperatorRQ()
        {
        }

        #endregion
    }
}
