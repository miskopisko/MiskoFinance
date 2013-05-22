using MPersist.Core;
using MPersist.Core.Message;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;

namespace MPFinance.Core.Message
{
    public class GetAccounts : AbstractMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(GetAccounts));

        #region Properties

        public new GetAccountsRQ Request
        {
            get
            {
                return (GetAccountsRQ)base.Request;
            }
        }

        public new GetAccountsRS Response
        {
            get
            {
                return (GetAccountsRS)base.Response;
            }
        }

        #endregion

        public GetAccounts(GetAccountsRQ request, GetAccountsRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
            Response.Accounts.FetchByOperator(session, Request.Operator);
        }
    }
}
