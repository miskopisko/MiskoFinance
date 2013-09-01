using MPersist.Core;
using MPersist.Message.Response;
using MPFinanceCore.Data.Viewed;

namespace MPFinanceCore.Message.Responses
{
    public class LoginRS : ResponseMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(LoginRS));

        #region Parameters

        public VwOperator Operator { get; set; }

        #endregion

        public LoginRS()
        {
            Operator = new VwOperator();
        }
    }
}
