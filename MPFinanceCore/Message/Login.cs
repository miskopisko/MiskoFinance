using System;
using MPersist.Core;
using MPersist.Enums;
using MPersist.Message;
using MPersist.Tools;
using MPFinanceCore.Data.Viewed;
using MPFinanceCore.Enums;
using MPFinanceCore.Message.Requests;
using MPFinanceCore.Message.Responses;

namespace MPFinanceCore.Message
{
    public class Login : MessageWrapper
    {
        private static Logger Log = Logger.GetInstance(typeof(Login));

        #region Properties

        public new LoginRQ Request { get { return (LoginRQ)base.Request; } }
        public new LoginRS Response  { get { return (LoginRS)base.Response; } }

        #endregion

        public Login(LoginRQ request, LoginRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
            if (String.IsNullOrEmpty(Request.Username))
            {
                session.Error(ErrorLevel.Error, "Invalid username.");
            }

            Response.Operator = VwOperator.GetInstanceByUsername(session, Request.Username);

            if (Response.Operator.OperatorId != null && Response.Operator.OperatorId.IsSet)
            {
                if (!Response.Operator.Password.Equals(Utils.GenerateHash(Request.Password)))
                {
                    session.Error(ErrorLevel.Error, "Incorrect password.");
                }

                Response.Operator.BankAccounts.FetchByOperator(session, Response.Operator.OperatorId);
                Response.Operator.Categories.FetchByComposite(session, Response.Operator.OperatorId, Status.Active);
            }
            else
            {
                session.Error(ErrorLevel.Error, "User {0} does not exist. Please try again.", new String[] { Request.Username });
            }
        }
    }
}
