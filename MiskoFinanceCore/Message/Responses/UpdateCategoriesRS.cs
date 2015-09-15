using MiskoFinanceCore.Data.Viewed;
using MiskoPersist.Core;
using MiskoPersist.Message.Response;

namespace MiskoFinanceCore.Message.Responses
{
    public class UpdateCategoriesRS : ResponseMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(UpdateCategoriesRS));

        #region Parameters

        public VwCategories Categories { get; set; }

        #endregion

        public UpdateCategoriesRS()
        {
        }
    }
}
