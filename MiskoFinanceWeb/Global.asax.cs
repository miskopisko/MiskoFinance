using System;
using MPersist.Core;

namespace MPFinanceWeb
{
    public class Global : System.Web.HttpApplication
    {
        private static ServerConnections mServerConnections_ = new ServerConnections();

        public static ServerConnections ServerConnections { get { return mServerConnections_; } }

        protected void Application_Start(object sender, EventArgs e)
        {
            ServerConnections.Add(ServerConnection.GetSqliteConnection(@"D:\TEMP\mpfinance\MPersist_DB.sqlite3"));
            //IOController.Instance.AddConnection(ConnectionSettings.GetOracleConnection("192.168.0.111", 1521, "xe", "MPersist", "MPersist"));
            //IOController.Instance.AddConnection(ConnectionSettings.GetMySqlConnection("piskuric.ca", "miskop_mpfinance", "miskop_mpfinance", "B2FkUh4ct2OZ"));
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