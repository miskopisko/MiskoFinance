using System;
using System.Reflection;
using MPersist.Core;
using MPersist.Core.Enums;
using MPersist.Core.Message;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Enums;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;
using MPFinance.Resources;
using MPersist.Core.Tools;

namespace MPFinance.Core.Message
{
    public class GetOperator : AbstractMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(GetOperator));

        #region Properties

        public new GetOperatorRQ Request
        {
            get
            {
                return (GetOperatorRQ)base.Request;
            }
        }

        public new GetOperatorRS Response
        {
            get
            {
                return (GetOperatorRS)base.Response;
            }
        }

        #endregion

        public GetOperator(GetOperatorRQ request, GetOperatorRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
            Response.Operator = Operator.FetchByUsername(session, Request.Username);

            if (Response.Operator == null || Response.Operator.IsNotSet)
            {
                session.Error(GetType(), MethodInfo.GetCurrentMethod(), ErrorLevel.Confirmation, ConfirmStrings.conConfirmNewUser, new object[]{ Request.Username });

                Response.Operator = new Operator();
                Response.Operator.Username = Request.Username;
                Response.Operator.Password = Utils.GenerateHash("secret");
                Response.Operator.Birthday = new DateTime(1982, 05, 15);
                Response.Operator.Email = "michael@piskuric.ca";
                Response.Operator.Gender = Gender.Male;
                Response.Operator.FirstName = "Michael";
                Response.Operator.LastName = "Piskuric";
                Response.Operator.IsSet = true;
                Response.Operator.Save(session);
            }

            Response.Accounts.FetchByOperator(session, Response.Operator);
            Response.ExpenseCategories.FetchByComposite(session, Response.Operator, CategoryType.Expense, Status.Active);
            Response.IncomeCategories.FetchByComposite(session, Response.Operator, CategoryType.Income, Status.Active);
            Response.TransferCategories.FetchByComposite(session, Response.Operator, CategoryType.Transfer, Status.Active);

            Response.AllCategories.Add(new Category(Response.Operator, "ALL", CategoryType.NULL, Status.Active));
            Response.AllCategories.AddRange(Response.ExpenseCategories);
            Response.AllCategories.AddRange(Response.IncomeCategories);
            Response.AllCategories.AddRange(Response.TransferCategories);
        }
    }
}
