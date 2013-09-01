using MPersist.Core;
using MPersist.Message.Response;
using MPFinanceCore.Data.Viewed;

namespace MPFinanceCore.Message.Responses
{
    public class GetCategoriesRS : ResponseMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(GetCategoriesRS));

        #region Parameters

        public VwCategories Categories { get; set; }

        #endregion

        public GetCategoriesRS()
        {
            Categories = new VwCategories();
        }
    }
}
