using System;
using System.Data;
using System.Data.Common;
using MiskoFinanceWeb.Data.Viewed;
using MiskoFinanceWeb.Message.Requests;
using MiskoFinanceWeb.Message.Responses;
using MiskoPersist.Core;
using MiskoPersist.Data.Viewed;
using MiskoPersist.Message;

namespace MiskoFinanceWeb.Message
{
	public class TestDBConnection : MessageWrapper
	{
		#region Properties

		public new TestDBConnectionRQ Request { get { return (TestDBConnectionRQ)base.Request; } }
		public new TestDBConnectionRS Response  { get { return (TestDBConnectionRS)base.Response; } }

		#endregion

		public TestDBConnection(TestDBConnectionRQ request, TestDBConnectionRS response)
			: base(request, response)
		{
		}

		public override void Execute(Session session)
		{
			Response.Connections = new VwDatabaseConnections();
			foreach (DatabaseConnection databaseConnection in DatabaseConnections.Connections.Values)
			{
				VwDatabaseConnection connection = new VwDatabaseConnection();
				connection.ConnectionString = databaseConnection.ConnectionString;
				connection.DatabaseType = databaseConnection.DatabaseType;
				connection.Datasource = databaseConnection.Datasource;
				connection.Name = databaseConnection.Name;
				connection.Password = databaseConnection.Password;
				connection.Port = databaseConnection.Port;
				connection.Server = databaseConnection.Server;
				connection.Username = databaseConnection.Username;
				
				try
				{
					DbConnection dbConn = DatabaseConnections.GetConnection(connection.Name);
					dbConn.Open();
					connection.State = dbConn.State;
				}
				catch (Exception e)
				{
					connection.State = ConnectionState.Closed;
					connection.Errors = new ErrorMessages();
					connection.Errors.Add(new ErrorMessage(e));
					
					while (e.InnerException != null)
					{
						e = e.InnerException;
						connection.Errors.Add(new ErrorMessage(e));
					}
				}
				
				Response.Connections.Add(connection);
			}
		}
	}
}

