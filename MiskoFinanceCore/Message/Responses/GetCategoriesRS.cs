using MiskoPersist.Core;
using MiskoPersist.Message.Response;
using MiskoFinanceCore.Data.Viewed;

namespace MiskoFinanceCore.Message.Responses
{
    public class GetCategoriesRS : ResponseMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(GetCategoriesRS));

        #region Parameters

        public VwCategories Categories { get; set; }

        #endregion

        public GetCategoriesRS()
        {
        }
    }
}
