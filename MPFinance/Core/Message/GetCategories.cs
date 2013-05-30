using MPersist.Core;
using MPersist.Core.Message;
using MPFinance.Core.Enums;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;

namespace MPFinance.Core.Message
{
    public class GetCategories : AbstractMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(GetCategories));

        #region Properties

        public new GetCategoriesRQ Request
        {
            get
            {
                return (GetCategoriesRQ)base.Request;
            }
        }

        public new GetCategoriesRS Response
        {
            get
            {
                return (GetCategoriesRS)base.Response;
            }
        }

        #endregion

        public GetCategories(GetCategoriesRQ request, GetCategoriesRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
            Response.ExpenseCategories.FetchByOperatorAndType(session, Request.Operator, CategoryType.Expense, Request.Status);
            Response.IncomeCategories.FetchByOperatorAndType(session, Request.Operator, CategoryType.Income, Request.Status);
            Response.TransferCategories.FetchByOperatorAndType(session, Request.Operator, CategoryType.Transfer, Request.Status);
        }
    }
}
