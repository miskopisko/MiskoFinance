using MPersist.Core;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Stored;

namespace MPFinance.Core.Message.Responses
{
    public class GetAccountsRS : AbstractResponse
    {
        private static Logger Log = Logger.GetInstance(typeof(GetAccountsRS));

        #region Parameters

        public Accounts Accounts { get; set; }

        #endregion

        public GetAccountsRS()
        {
            Accounts = new Accounts();
        }
    }
}
