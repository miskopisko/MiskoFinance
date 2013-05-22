using MPersist.Core;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Viewed;

namespace MPFinance.Core.Message.Responses
{
    public class UpdateTxnRS : AbstractResponse
    {
        private static Logger Log = Logger.GetInstance(typeof(UpdateTxnRS));

        #region Parameters

        public VwTxn VwTxn { get; set; }

        #endregion

        public UpdateTxnRS()
        {
            VwTxn = new VwTxn();
        }
    }
}
