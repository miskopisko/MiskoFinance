using MPersist.Core;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Stored;

namespace MPFinance.Core.Message.Responses
{
    public class AddAccountRS : AbstractResponse
    {
        private static Logger Log = Logger.GetInstance(typeof(AddAccountRS));

        #region Parameters

        public Account NewAccount { get; set; }

        #endregion

        public AddAccountRS()
        {
            NewAccount = new Account();
        }
    }
}