using MPersist.Core;
using MPersist.Enums;
using MPersist.Message;
using MPFinanceCore.Data.Viewed;
using MPFinanceCore.Message.Requests;
using MPFinanceCore.Message.Responses;
using MPFinanceCore.Resources;

namespace MPFinanceCore.Message
{
    public class UpdateCategories : MessageWrapper
    {
        private static Logger Log = Logger.GetInstance(typeof(UpdateCategories));

        #region Properties

        public new UpdateCategoriesRQ Request { get { return (UpdateCategoriesRQ)base.Request; } }
        public new UpdateCategoriesRS Response { get { return (UpdateCategoriesRS)base.Response; } }

        #endregion

        public UpdateCategories(UpdateCategoriesRQ request, UpdateCategoriesRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
            foreach (VwCategory category in Request.Categories)
            {
                category.Update(session);
            }

            Response.Categories = Request.Categories;

            session.Error(ErrorLevel.Info, WarningStrings.warnCategoriesAddedUpdated);
        }
    }
}
