using MPersist.Core;
using MPersist.Core.Message.Request;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.OFX;
using System;

namespace MPFinance.Core.Message.Requests
{
    public class CheckDuplicateTxnsRQ : AbstractRequest
    {
        private static Logger Log = Logger.GetInstance(typeof(CheckDuplicateTxnsRQ));

        #region Parameters

        public Operator Operator { get; set; }
        public Account Account { get; set; }
        public OfxDocument OfxDucument { get; set; }

        #endregion

        public CheckDuplicateTxnsRQ()
        {
        }
    }
}
