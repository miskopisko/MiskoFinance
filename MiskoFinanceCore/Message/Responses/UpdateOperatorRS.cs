using MiskoPersist.Core;
using MiskoPersist.Message.Response;
using MiskoFinanceCore.Data.Viewed;

namespace MiskoFinanceCore.Message.Responses
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
