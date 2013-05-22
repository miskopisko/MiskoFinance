using MPersist.Core;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Stored;

namespace MPFinance.Core.Message.Responses
{
    public class GetOperatorRS : AbstractResponse
    {
        private static Logger Log = Logger.GetInstance(typeof(GetOperatorRS));

        #region Parameters

        public Operator Operator { get; set; }

        #endregion

        public GetOperatorRS()
        {
            Operator = new Operator();
        }
    }
}
