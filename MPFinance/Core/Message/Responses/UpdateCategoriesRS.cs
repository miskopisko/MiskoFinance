using MPersist.Core;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Stored;

namespace MPFinance.Core.Message.Responses
{
    public class UpdateCategoriesRS : AbstractResponse
    {
        private static Logger Log = Logger.GetInstance(typeof(UpdateCategoriesRS));

        #region Parameters

        public Categories Categories { get; set; }

        #endregion

        public UpdateCategoriesRS()
        {
            Categories = new Categories();
        }
    }
}
