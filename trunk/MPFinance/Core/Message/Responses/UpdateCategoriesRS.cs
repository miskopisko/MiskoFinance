using MPersist.Core;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Stored;

namespace MPFinance.Core.Message.Responses
{
    public class UpdateCategoriesRS : AbstractResponse
    {
        private static Logger Log = Logger.GetInstance(typeof(UpdateCategoriesRS));

        #region Parameters

        public Categories ExpenseCategories { get; set; }
        public Categories IncomeCategories { get; set; }

        #endregion

        public UpdateCategoriesRS()
        {

        }
    }
}
