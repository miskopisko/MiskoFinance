using MPersist.Core;
using MPersist.Core.Enums;
using MPersist.Core.Message;
using MPFinance.Core.Data.Viewed;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;
using MPFinance.Resources;

namespace MPFinance.Core.Message
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
