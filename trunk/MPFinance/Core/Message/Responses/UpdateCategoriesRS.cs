using MPersist.Core;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Viewed;

namespace MPFinance.Core.Message.Responses
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
