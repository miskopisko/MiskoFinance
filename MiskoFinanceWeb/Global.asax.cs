using System;
using System.Linq;
using System.Web.Configuration;
using MiskoPersist.Core;
using MiskoPersist.Data;
using MiskoPersist.Enums;

namespace MiskoFinanceWeb
{
	public class Global : System.Web.HttpApplication
	{
		protected void Application_Start(object sender, EventArgs e)
		{
			log4net.Config.XmlConfigurator.Configure();

			DatabaseType[] allowableConnectionTypes = { DatabaseType.MySql, DatabaseType.SQLite };

			DatabaseType connectionType = DatabaseType.GetElement(WebConfigurationManager.AppSettings["ConnectionType"]);

			if(connectionType == null || !allowableConnectionTypes.Contains(connectionType))
			{
				throw new MiskoException("Invalid server location. Must be one of 'Online' or 'Local'");
			}
			else if(connectionType.Equals(DatabaseType.MySql))
			{
				String host = WebConfigurationManager.AppSettings["Hostname"];
				String database = WebConfigurationManager.AppSettings["Database"];
				String username = WebConfigurationManager.AppSettings["Username"];
				String password = WebConfigurationManager.AppSettings["Password"];

				DatabaseConnections.AddMySqlConnection(host, database, username, password);    
			}
			else if(connectionType.Equals(DatabaseType.SQLite))
			{
				DatabaseConnections.AddSqliteConnection(WebConfigurationManager.AppSettings["SqliteDB"]);
			}
		}

		protected void Session_Start(object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{

		}

		protected void Application_Error(object sender, EventArgs e)
		{

		}

		protected void Session_End(object sender, EventArgs e)
		{

		}

		protected void Application_End(object sender, EventArgs e)
		{

		}
	}
}