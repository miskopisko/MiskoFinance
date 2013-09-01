using MPersist.Core;
using MPersist.Message.Response;
using MPFinanceCore.Data.Viewed;

namespace MPFinanceCore.Message.Responses
{
    public class UpdateCategoriesRS : ResponseMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(UpdateCategoriesRS));

        #region Parameters

        public VwCategories Categories { get; set; }

        #endregion

        public UpdateCategoriesRS()
        {
            Categories = new VwCategories();
        }
    }
}
