using MPersist.Core;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Viewed;

namespace MPFinance.Core.Message.Responses
{
    public class UpdateOperatorRS : ResponseMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(UpdateOperatorRS));

        #region Parameters

        public VwOperator Operator { get; set; }

        #endregion

        public UpdateOperatorRS()
        {
            Operator = new VwOperator();
        }
    }
}
