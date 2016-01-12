using MiskoFinanceCore.Data.Viewed;
using MiskoPersist.Core;
using MiskoPersist.Message.Request;

namespace MiskoFinanceCore.Message.Requests
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
