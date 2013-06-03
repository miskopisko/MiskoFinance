using MPersist.Core;
using MPersist.Core.Message.Request;
using MPFinance.Core.Data.Viewed;

namespace MPFinance.Core.Message.Requests
{
    public class UpdateTxnRQ : AbstractRequest
    {
        private static Logger Log = Logger.GetInstance(typeof(UpdateTxnRQ));

        #region Parameters

        public VwTxn VwTxn { get; set; }

        #endregion

        public UpdateTxnRQ()
        {
        }
    }
}
