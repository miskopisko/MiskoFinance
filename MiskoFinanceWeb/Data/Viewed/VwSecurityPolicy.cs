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
				return SecurityPolicy.Instance.LoginRequired;
			}
			set { }
		}
		
		[Viewed]
		public Int16 MinimumPasswordAge
		{
			get
			{
				return SecurityPolicy.Instance.MinimumPasswordAge;
			}
			set { }
		}

		[Viewed]
		public Int16 MaximumPasswordAge
		{
			get
			{
				return SecurityPolicy.Instance.MaximumPasswordAge;
			}
			set { }
		}
		
		[Viewed]
		public Int16 MinimumPasswordLength
		{
			get
			{
				return SecurityPolicy.Instance.MinimumPasswordLength;
			}
			set { }
		}
		
		[Viewed]
		public Int16 LockOutAttempts
		{
			get
			{
				return SecurityPolicy.Instance.LockOutAttempts;
			}
			set { }
		}
		
		[Viewed]
		public Int16 LockOutDuration
		{
			get
			{
				return SecurityPolicy.Instance.LockOutDuration;
			}
			set { }
		}
		
		[Viewed]
		public Int16 ResetLoginCount
		{
			get
			{
				return SecurityPolicy.Instance.ResetLoginCount;
			}
			set { }
		}
		
		[Viewed]
		public Int16 SessionTokenExpiry
		{
			get
			{
				return SecurityPolicy.Instance.SessionTokenExpiry;
			}
			set { }
		}
		
		#endregion
	}
}
