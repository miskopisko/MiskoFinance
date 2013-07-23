using MPersist.Core;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Stored;

namespace MPFinance.Core.Message.Responses
{
    public class GetCategoriesRS : ResponseMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(GetCategoriesRS));

        #region Parameters

        public Categories Categories { get; set; }

        #endregion

        public GetCategoriesRS()
        {
            Categories = new Categories();
        }
    }
}
