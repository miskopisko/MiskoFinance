using System;
using System.Globalization;
using System.Linq;
using System.Web.Configuration;
using MiskoPersist.Core;
using MiskoPersist.Enums;

namespace MiskoFinanceWeb
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ConnectionType[] allowableConnectionTypes = {ConnectionType.MySql, ConnectionType.SQLite};

            ConnectionType connectionType = ConnectionType.GetElement(WebConfigurationManager.AppSettings["ConnectionType"]);

            if(connectionType == null || !allowableConnectionTypes.Contains(connectionType))
            {
                throw new MiskoException("Invalid server location. Must be one of 'Online' or 'Local'");
            }
            else if(connectionType.Equals(ConnectionType.MySql))
            {
                String host = WebConfigurationManager.AppSettings["Hostname"];
                String database = WebConfigurationManager.AppSettings["Database"];
                String username = WebConfigurationManager.AppSettings["Username"];
                String password = WebConfigurationManager.AppSettings["Password"];

                ConnectionSettings.AddMySqlConnection(host, database, username, password);    
            }
            else if(connectionType.Equals(ConnectionType.SQLite))
            {
                ConnectionSettings.AddSqliteConnection(WebConfigurationManager.AppSettings["SqliteDB"]);
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