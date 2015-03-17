using MiskoPersist.Core;
using MiskoPersist.Message.Response;
using MiskoFinanceCore.Data.Viewed;

namespace MiskoFinanceCore.Message.Responses
{
    public class AddAccountRS : ResponseMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(AddAccountRS));

        #region Parameters

        public VwBankAccount NewAccount { get; set; }

        #endregion

        public AddAccountRS()
        {
            NewAccount = new VwBankAccount();
        }
    }
}
