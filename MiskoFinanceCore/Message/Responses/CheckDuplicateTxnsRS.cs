using MiskoPersist.Core;
using MiskoPersist.Message.Response;
using MiskoFinanceCore.Data.Viewed;

namespace MiskoFinanceCore.Message.Responses
{
    public class CheckDuplicateTxnsRS : ResponseMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(CheckDuplicateTxnsRS));

        #region Parameters

        public VwTxns Txns { get; set; }

        #endregion

        public CheckDuplicateTxnsRS()
        {
            Txns = new VwTxns();
        }
    }
}
