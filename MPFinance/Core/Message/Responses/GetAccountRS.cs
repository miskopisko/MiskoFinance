using MPersist.Core;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Stored;

namespace MPFinance.Core.Message.Responses
{
    public class GetAccountRS : AbstractResponse
    {
        private static Logger Log = Logger.GetInstance(typeof(GetAccountRS));

        #region Parameters

        public Account Account { get; set; }

        #endregion

        public GetAccountRS()
        {
            Account = new Account();
        }
    }
}
