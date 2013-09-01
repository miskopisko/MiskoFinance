using MPersist.Core;
using MPersist.Message.Request;
using MPFinanceCore.Data.Viewed;

namespace MPFinanceCore.Message.Requests
{
    public class UpdateCategoriesRQ : RequestMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(UpdateCategoriesRQ));

        #region Parameters

        public VwCategories Categories { get; set; }

        #endregion

        public UpdateCategoriesRQ()
        {
        }
    }
}
