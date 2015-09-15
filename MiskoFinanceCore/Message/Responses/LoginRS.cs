using MiskoFinanceCore.Data.Viewed;
using MiskoPersist.Core;
using MiskoPersist.Message.Response;

namespace MiskoFinanceCore.Message.Responses
{
    public class LoginRS : ResponseMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(LoginRS));

        #region Parameters

        public VwOperator Operator { get; set; }

        #endregion

        public LoginRS()
        {
        }
    }
}
