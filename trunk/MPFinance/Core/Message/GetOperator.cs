using System;
using MPersist.Core;
using MPersist.Core.Enums;
using MPersist.Core.Message;
using MPersist.Core.Tools;
using MPFinance.Core.Data.Viewed;
using MPFinance.Core.Enums;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;
using MPFinance.Resources;

namespace MPFinance.Core.Message
{
    public class GetOperator : MessageWrapper
    {
        private static Logger Log = Logger.GetInstance(typeof(GetOperator));

        #region Properties

        public new GetOperatorRQ Request { get { return (GetOperatorRQ)base.Request; } }
        public new GetOperatorRS Response  { get { return (GetOperatorRS)base.Response; } }

        #endregion

        public GetOperator(GetOperatorRQ request, GetOperatorRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
            Response.Operator = VwOperator.GetInstanceByUsername(session, Request.Username);

            if (Response.Operator.OperatorId == null || Response.Operator.OperatorId.IsNotSet)
            {
                session.Error(ErrorLevel.Confirmation, ConfirmStrings.conConfirmNewUser, new Object[]{ Request.Username });

                Response.Operator.Username = Request.Username;
                Response.Operator.Password = Utils.GenerateHash("secret");
                Response.Operator.Birthday = new DateTime(1982, 05, 15);
                Response.Operator.Email = "michael@piskuric.ca";
                Response.Operator.Gender = Gender.Male;
                Response.Operator.FirstName = "Michael";
                Response.Operator.LastName = "Piskuric";

                Response.Operator.Update(session);
                Response.Operator = VwOperator.GetInstanceByUsername(session, Request.Username);
            }

            if (Response.Operator != null && Response.Operator.OperatorId.IsSet)
            {
                Response.Operator.BankAccounts.FetchByOperator(session, Response.Operator.OperatorId);
                Response.Operator.Categories.FetchByComposite(session, Response.Operator.OperatorId, Status.Active);
                Response.Txns.Fetch(session, Request.Page, Response.Operator.OperatorId, null, Request.FromDate, Request.ToDate, null, null);
                Response.Summary.Fetch(session, Response.Operator.OperatorId, null, Request.FromDate, Request.ToDate, null, null);
            }
            else
            {
                session.Error(ErrorLevel.Error, ErrorStrings.errOperatorNotFound, new Object[] { Request.Username });
            }
        }
    }
}