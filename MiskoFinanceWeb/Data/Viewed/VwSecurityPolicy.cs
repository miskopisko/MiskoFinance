using System;
using log4net;
using MiskoPersist.Attributes;
using MiskoPersist.Core;
using MiskoPersist.Data.Viewed;

namespace MiskoFinanceWeb.Data.Viewed
{
	public class VwSecurityPolicy : ViewedData
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(VwSecurityPolicy));
		
		#region Properties
		
		[Viewed]
		public Boolean LoginRequired
		{
			get
			{
				return SecurityPolicy.LoginRequired;
			}
			set { }
		}
		
		[Viewed]
		public Int16 MinimumPasswordAge
		{
			get
			{
				return SecurityPolicy.MinimumPasswordAge;
			}
			set { }
		}

		[Viewed]
		public Int16 MaximumPasswordAge
		{
			get
			{
				return SecurityPolicy.MaximumPasswordAge;
			}
			set { }
		}
		
		[Viewed]
		public Int16 MinimumPasswordLength
		{
			get
			{
				return SecurityPolicy.MinimumPasswordLength;
			}
			set { }
		}
		
		[Viewed]
		public Int16 LockOutAttempts
		{
			get
			{
				return SecurityPolicy.LockOutAttempts;
			}
			set { }
		}
		
		[Viewed]
		public Int16 LockOutDuration
		{
			get
			{
				return SecurityPolicy.LockOutDuration;
			}
			set { }
		}
		
		[Viewed]
		public Int16 ResetLoginCount
		{
			get
			{
				return SecurityPolicy.ResetLoginCount;
			}
			set { }
		}
		
		[Viewed]
		public Int16 SessionTokenExpiry
		{
			get
			{
				return SecurityPolicy.SessionTokenExpiry;
			}
			set { }
		}
		
		#endregion
	}
}
