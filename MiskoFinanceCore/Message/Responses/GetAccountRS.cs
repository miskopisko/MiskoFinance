using MiskoFinanceCore.Data.Viewed;
using MiskoPersist.Core;
using MiskoPersist.Message.Response;

namespace MiskoFinanceCore.Message.Responses
{
	public class GetAccountRS : ResponseMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(GetAccountRS));

        #region Parameters

        public VwBankAccount BankAccount { get; set; }

        #endregion

        public GetAccountRS()
        {
        }
    }
}
