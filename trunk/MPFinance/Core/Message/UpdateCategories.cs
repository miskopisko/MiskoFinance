using MPersist.Core;
using MPersist.Core.Message;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;

namespace MPFinance.Core.Message
{
    public class UpdateCategories : AbstractMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(UpdateCategories));

        #region Properties

        public new UpdateCategoriesRQ Request
        {
            get
            {
                return (UpdateCategoriesRQ)base.Request;
            }
        }

        public new UpdateCategoriesRS Response
        {
            get
            {
                return (UpdateCategoriesRS)base.Response;
            }
        }

        #endregion

        public UpdateCategories(UpdateCategoriesRQ request, UpdateCategoriesRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
            Response.ExpenseCategories = (Categories)Request.ExpenseCategories.Save(session);
            Response.IncomeCategories = (Categories)Request.IncomeCategories.Save(session);
            Response.TransferCategories = (Categories)Request.TransferCategories.Save(session);
        }
    }
}
