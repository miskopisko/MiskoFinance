using System;
using MiskoPersist.Core;
using MiskoPersist.Message.Request;

namespace MiskoFinanceCore.Message.Requests
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
