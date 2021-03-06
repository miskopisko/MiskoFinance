using log4net;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;
using MiskoPersist.Core;
using MiskoPersist.Message;

namespace MiskoFinanceCore.Message
{
	public class UpdateCategories : MessageWrapper
    {
        private static ILog Log = LogManager.GetLogger(typeof(UpdateCategories));

        #region Properties

        public new UpdateCategoriesRQ Request { get { return (UpdateCategoriesRQ)base.Request; } }
        public new UpdateCategoriesRS Response { get { return (UpdateCategoriesRS)base.Response; } }

        #endregion

        public UpdateCategories(UpdateCategoriesRQ request, UpdateCategoriesRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
			Response.Categories = new VwCategories();
        	
            foreach (VwCategory category in Request.Categories)
            {
				category.Update(session);
                if (category.CategoryId > 0)
                {
                    Response.Categories.Add(category);
                }
            }
        }
    }
}
