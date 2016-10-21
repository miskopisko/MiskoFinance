using System;
using System.Data;
using System.Data.Common;
using log4net;
using MiskoPersist.Core;
using MiskoPersist.Data.Viewed;

namespace MiskoFinanceWeb.Data.Viewed
{
	public class VwDatabaseConnections : ViewedDataList<VwDatabaseConnection>
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(VwDatabaseConnections));
		
		public VwDatabaseConnections()
		{
			foreach (DatabaseConnection databaseConnection in DatabaseConnections.GetConnections())
			{
				VwDatabaseConnection connection = new VwDatabaseConnection();
				connection.ConnectionString = databaseConnection.ConnectionString;
				connection.DatabaseType = databaseConnection.DatabaseType.Description;
				connection.Name = databaseConnection.Name;
				
				try
				{
					DbConnection conn = databaseConnection.Connect();
					connection.State = conn.State;
				}
				catch (Exception e)
				{
					connection.State = ConnectionState.Closed;
					
					do
		            {
		            	Log.Error("Unexpected Error: (" + e.Message + ")", e);
		                connection.Errors.Add(new ErrorMessage(e));
		                e = e.InnerException;
		            } 
		            while (e != null);
				}
				
				Add(connection);
			}
		}
	}
}
