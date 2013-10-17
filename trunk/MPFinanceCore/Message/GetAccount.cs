using MPersist.Core;
using MPersist.Message;
using MPFinanceCore.Message.Requests;
using MPFinanceCore.Message.Responses;

namespace MPFinanceCore.Message
{
    public class GetAccount : MessageWrapper
    {
        private static Logger Log = Logger.GetInstance(typeof(GetAccount));

        #region Properties

        public new GetAccountRQ Request { get { return (GetAccountRQ)base.Request; } }
        public new GetAccountRS Response { get { return (GetAccountRS)base.Response; } }

        #endregion

        public GetAccount(GetAccountRQ request, GetAccountRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
            Response.BankAccount.FetchByAccountNo(session, Request.AccountNo);
        }
    }
}