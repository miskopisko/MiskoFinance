using MPersist.Core;
using MPersist.Core.Message;
using MPFinance.Core.Enums;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;
using MPFinance.Core.Data.Stored;

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
            //Response.ExpenseCategories.FetchByComposite(session, Request.Operator, CategoryType.Expense, Request.Status);
            //Response.IncomeCategories.FetchByComposite(session, Request.Operator, CategoryType.Income, Request.Status);
            //Response.TransferCategories.FetchByComposite(session, Request.Operator, CategoryType.Transfer, Request.Status);

            //Response.AllCategories.Add(new Category(Request.Operator, "---", CategoryType.NULL, Request.Status));
            //Response.AllCategories.AddRange(Response.ExpenseCategories);
            //Response.AllCategories.AddRange(Response.IncomeCategories);
            //Response.AllCategories.AddRange(Response.TransferCategories);
        }
    }
}
