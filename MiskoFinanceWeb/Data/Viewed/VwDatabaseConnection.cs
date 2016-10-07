using System;
using System.Data;
using log4net;
using MiskoPersist.Attributes;
using MiskoPersist.Data.Viewed;

namespace MiskoFinanceWeb.Data.Viewed
{
	public class VwDatabaseConnection : ViewedData
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(VwDatabaseConnection));
		
		#region Viewed Properties
		
		[Viewed]
		public String Name { get; set; }
		[Viewed]
		public String DatabaseType { get; set; }
		[Viewed]
		public String ConnectionString { get; set; }
		[Viewed]
		public ConnectionState State { get; set; }
		[Viewed]
		public ErrorMessages Errors { get; set; }
		
		#endregion
		
		#region Constructor
		
		public VwDatabaseConnection()
		{
			Errors = new ErrorMessages();
		}
		
		#endregion
	}
}
