using MiskoPersist.Core;
using MiskoPersist.Message.Request;
using MiskoFinanceCore.Data.Viewed;

namespace MiskoFinanceCore.Message.Requests
{
    public class AddAccountRQ : RequestMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(AddAccountRQ));

        #region Parameters

        public VwBankAccount BankAccount { get; set; }

        #endregion

        public AddAccountRQ()
        {
        }
    }
}
