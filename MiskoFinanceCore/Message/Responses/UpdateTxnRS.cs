using MiskoPersist.Core;
using MiskoPersist.Message.Response;
using MiskoFinanceCore.Data.Viewed;

namespace MiskoFinanceCore.Message.Responses
{
    public class UpdateTxnRS : ResponseMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(UpdateTxnRS));

        #region Parameters

        public VwSummary Summary { get; set; }

        #endregion

        public UpdateTxnRS()
        {
        }
    }
}
