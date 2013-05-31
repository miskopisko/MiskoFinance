using MPersist.Core;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Stored;

namespace MPFinance.Core.Message.Responses
{
    public class GetCategoriesRS : AbstractResponse
    {
        private static Logger Log = Logger.GetInstance(typeof(GetCategoriesRS));

        #region Parameters

        public Categories ExpenseCategories { get; set; }
        public Categories IncomeCategories { get; set; }
        public Categories TransferCategories { get; set; }
        public Categories AllCategories { get; set; }

        #endregion

        public GetCategoriesRS()
        {
            ExpenseCategories = new Categories();
            IncomeCategories = new Categories();
            TransferCategories = new Categories();
            AllCategories = new Categories();
        }
    }
}
