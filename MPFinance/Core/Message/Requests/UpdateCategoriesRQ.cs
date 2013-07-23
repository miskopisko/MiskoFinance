using MPersist.Core;
using MPersist.Core.Message.Request;
using MPFinance.Core.Data.Stored;

namespace MPFinance.Core.Message.Requests
{
    public class UpdateCategoriesRQ : RequestMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(UpdateCategoriesRQ));

        #region Parameters

        public Categories Categories { get; set; }

        #endregion

        public UpdateCategoriesRQ()
        {
        }
    }
}