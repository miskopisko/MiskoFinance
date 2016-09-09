using System;
using System.Web.Configuration;
using MiskoPersist.Core;
using MiskoPersist.Enums;

namespace MiskoFinanceWeb
{
	public class Global : System.Web.HttpApplication
	{
		public static SerializationType DefaultSerializationType
		{
			get
			{
				return MiskoEnum.Parse<SerializationType>(WebConfigurationManager.AppSettings["DefaultSerializationType"]);
			}
		}
		
		protected void Application_Start(object sender, EventArgs e)
		{
			log4net.Config.XmlConfigurator.Configure();

			DatabaseType connectionType;
			if (!MiskoEnum.TryParse<DatabaseType>(WebConfigurationManager.AppSettings["ConnectionType"], out connectionType) || !connectionType.InArray(new[] { DatabaseType.MySql, DatabaseType.SQLite }))
			{
				throw new MiskoException("Invalid server location. Must be one of 'Online' or 'Local'");
			}
			
			if (connectionType.Equals(DatabaseType.MySql))
			{
				String host = WebConfigurationManager.AppSettings["Hostname"];
				String database = WebConfigurationManager.AppSettings["Database"];
				String username = WebConfigurationManager.AppSettings["Username"];
				String password = WebConfigurationManager.AppSettings["Password"];

				DatabaseConnections.AddMySqlConnection(host, database, username, password);
			}
			else if (connectionType.Equals(DatabaseType.SQLite))
			{
				DatabaseConnections.AddSqliteConnection(WebConfigurationManager.AppSettings["SqliteDB"]);
			}
		}
	}
}