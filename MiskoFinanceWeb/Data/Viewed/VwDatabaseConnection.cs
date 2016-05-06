using System;
using System.Data;
using MiskoPersist.Attributes;
using MiskoPersist.Data;
using MiskoPersist.Enums;

namespace MiskoFinanceWeb.Data.Viewed
{
	public class VwDatabaseConnection : ViewedData
	{
		#region Viewed Properties
		
		[Viewed]
		public String Name { get; set; }
		[Viewed]
		public DatabaseType DatabaseType { get; set; }
		[Viewed]
		public String Server { get; set; }
		[Viewed]
		public Int32? Port { get; set; }
		[Viewed]
		public String Datasource { get; set; }
		[Viewed]
		public String Username { get; set; }
		[Viewed]
		public String Password { get; set; }
		[Viewed]
		public String ConnectionString { get; set; }
		[Viewed]
		public ConnectionState State { get; set; }
		[Viewed]
		public ErrorMessages Errors { get; set; }
		
		#endregion
	}
}
