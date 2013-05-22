using MPersist.Core;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Stored;

namespace MPFinance.Core.Message.Responses
{
    public class UpdateAccountRS : AbstractResponse
    {
        private static Logger Log = Logger.GetInstance(typeof(UpdateAccountRS));

        #region Parameters

        public Account Account { get; set; }

        #endregion

        public UpdateAccountRS()
        {
            Account = new Account();
        }
    }
}
