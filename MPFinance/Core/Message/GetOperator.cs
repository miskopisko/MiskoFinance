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
            Operator o = Operator.FetchByUsername(session, Request.Username);

            if (!o.IsSet)
            {
                session.Error(GetType(), MethodInfo.GetCurrentMethod(), ErrorLevel.Confirmation, ConfirmStrings.conConfirmNewUser, new object[]{ Request.Username });

                o.Username = Request.Username;
                o.Password = Utils.GenerateHash("secret");
                o.Birthday = new DateTime(1982, 05, 15);
                o.Email = "michael@piskuric.ca";
                o.Gender = Gender.Male;
                o.FirstName = "Michael";
                o.LastName = "Piskuric";
                o.IsSet = true;
                o.Save(session);
            }

            Response.Operator = o;
            Response.Accounts.FetchByOperator(session, o);
            Response.ExpenseCategories.FetchByOperatorAndType(session, o, CategoryType.Expense, Status.Active);
            Response.IncomeCategories.FetchByOperatorAndType(session, o, CategoryType.Income, Status.Active);
            Response.TransferCategories.FetchByOperatorAndType(session, o, CategoryType.Transfer, Status.Active);

        }
    }
}
