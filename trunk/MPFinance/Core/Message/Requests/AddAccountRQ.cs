using MPersist.Core;
using MPersist.Core.Message.Request;
using MPFinance.Core.Data.Stored;

namespace MPFinance.Core.Message.Requests
{
    public class AddAccountRQ : AbstractRequest
    {
        private static Logger Log = Logger.GetInstance(typeof(AddAccountRQ));

        #region Parameters

        public Account Account { get; set; }

        #endregion

        public AddAccountRQ()
        {

        }
    }
}
