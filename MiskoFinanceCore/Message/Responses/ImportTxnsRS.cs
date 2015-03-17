using MiskoPersist.Core;
using MiskoPersist.Message.Response;
using MiskoFinanceCore.Data.Viewed;

namespace MiskoFinanceCore.Message.Responses
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