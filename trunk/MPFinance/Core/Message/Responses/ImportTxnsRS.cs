using MPersist.Core;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Viewed;

namespace MPFinance.Core.Message.Responses
{
    public class ImportTxnsRS : ResponseMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(ImportTxnsRS));

        #region Parameters

        public VwBankAccount BankAccount { get; set; }

        #endregion

        public ImportTxnsRS()
        {
        }
    }
}
