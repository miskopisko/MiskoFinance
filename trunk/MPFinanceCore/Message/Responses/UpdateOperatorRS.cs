using MPersist.Core;
using MPersist.Message.Response;
using MPFinanceCore.Data.Viewed;

namespace MPFinanceCore.Message.Responses
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
