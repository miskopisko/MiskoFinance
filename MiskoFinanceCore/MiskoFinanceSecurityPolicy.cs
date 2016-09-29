using System;
using log4net;
using MiskoPersist.Core;

namespace MiskoFinanceCore
{
	public static class MiskoFinanceSecurityPolicy
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(MiskoFinanceSecurityPolicy));
		
		public static void Load()
		{
			// Configure security policy
			SecurityPolicy.LoginRequired = true;
			SecurityPolicy.LockOutAttempts = 5;
			SecurityPolicy.SessionTokenExpiry = 30;
			SecurityPolicy.ResetLoginCount = 5;
			SecurityPolicy.LockOutDuration = 5;
		}
	}
}
