using System;
using MPersist.Core;
using MPersist.Message.Request;

namespace MPFinanceCore.Message.Requests
{
    public class LoginRQ : RequestMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(LoginRQ));

        #region Parameters

        public String Username { get; set; }
        public String Password { get; set; }

        #endregion

        public LoginRQ()
        {
        }
    }
}
