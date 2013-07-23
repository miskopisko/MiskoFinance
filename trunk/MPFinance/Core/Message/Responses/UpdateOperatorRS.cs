using MPersist.Core;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Stored;

namespace MPFinance.Core.Message.Responses
{
    public class UpdateOperatorRS : ResponseMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(UpdateOperatorRS));

        #region Parameters

        public Operator Operator { get; set; }

        #endregion

        #region Constructor

        public UpdateOperatorRS()
        {

        }

        #endregion
    }
}
