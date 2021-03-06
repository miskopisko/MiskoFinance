﻿using System;
using System.IO;
using System.Web.Configuration;
using log4net;
using log4net.Config;
using MiskoPersist.Core;
using MiskoPersist.Enums;

namespace MiskoFinanceWeb
{
	public class Global : System.Web.HttpApplication
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(Global));
		
		public static SerializationType DefaultSerializationType
		{
			get
			{
				return MiskoEnum.Parse<SerializationType>(WebConfigurationManager.AppSettings["DefaultSerializationType"]);
			}
		}
		
		protected void Application_Start(object sender, EventArgs e)
		{
			// Configure the logger
			XmlConfigurator.Configure();

			// Get a database connection
			DatabaseType connectionType;
			if (!MiskoEnum.TryParse<DatabaseType>(WebConfigurationManager.AppSettings["ConnectionType"], out connectionType) || !connectionType.InArray(new[] { DatabaseType.MySql, DatabaseType.SQLite }))
			{
				throw new MiskoException("Invalid connection type. Must be one of 'MySql' or 'Sqlite'");
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
			
			String path = Environment.GetEnvironmentVariable("PATH");
			String binDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Bin");
			Environment.SetEnvironmentVariable("PATH", path + ";" + binDir);
		}
	}
}