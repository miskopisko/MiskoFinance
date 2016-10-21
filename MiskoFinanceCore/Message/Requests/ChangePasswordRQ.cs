using System;
using log4net;
using MiskoPersist.Attributes;
using MiskoPersist.Message.Requests;

namespace MiskoFinanceCore.Message.Requests
{
	public class ChangePasswordRQ : RequestMessage
	{
		private static ILog Log = LogManager.GetLogger(typeof(ChangePasswordRQ));

		#region Parameters

		[Viewed]
		public String Username { get; set; }
		[Viewed]
		public String OldPassword { get; set; }
		[Viewed]
		public String NewPassword { get; set; }
		[Viewed]
		public String ConfirmPassword { get; set; }

		#endregion
		
		#region Other Properties
		
		public override Boolean SecurityExempt
		{
			get
			{
				return true;
			}
		}
		
		#endregion
	}
}