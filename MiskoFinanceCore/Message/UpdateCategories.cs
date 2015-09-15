using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;
using MiskoFinanceCore.Resources;
using MiskoPersist.Core;
using MiskoPersist.Enums;
using MiskoPersist.Message;

namespace MiskoFinanceCore.Message
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

            session.Error(ErrorLevel.Information, WarningStrings.warnCategoriesAddedUpdated);
        }
    }
}
