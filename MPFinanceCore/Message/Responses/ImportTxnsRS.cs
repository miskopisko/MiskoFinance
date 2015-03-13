using MPersist.Core;
using MPersist.Message.Response;
using MPFinanceCore.Data.Viewed;

namespace MPFinanceCore.Message.Responses
{
    public class ImportTxnsRS : ResponseMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(ImportTxnsRS));

        #region Parameters

        public VwBankAccount BankAccount { get; set; }

        #endregion

        public ImportTxnsRS()
        {
        	BankAccount = new VwBankAccount();
        }
    }
}
