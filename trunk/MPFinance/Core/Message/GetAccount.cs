using MPersist.Core;
using MPersist.Core.Message;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;

namespace MPFinance.Core.Message
{
    public class GetAccount : AbstractMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(GetAccount));

        #region Properties

        public new GetAccountRQ Request
        {
            get
            {
                return (GetAccountRQ)base.Request;
            }
        }

        public new GetAccountRS Response
        {
            get
            {
                return (GetAccountRS)base.Response;
            }
        }

        #endregion

        public GetAccount(GetAccountRQ request, GetAccountRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
            Response.Account = BankAccount.GetInstanceByComposite(session, Request.Operator, Request.AccountType, Request.BankNo, Request.AccountNo);
        }
    }
}
