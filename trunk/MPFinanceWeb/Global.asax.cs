using System;
using System.Collections.Generic;
using MPersist.Core;
using MPFinanceCore.Resources;

namespace MPFinanceWeb
{
    public class Global : System.Web.HttpApplication
    {
        #region Fields

        private static List<ConnectionSettings> mConnections_ = new List<ConnectionSettings>();

        #endregion

        #region Properties

        public static List<ConnectionSettings> Connections { get { return mConnections_; } set { mConnections_ = value; } }

        #endregion

        protected void Application_Start(object sender, EventArgs e)
        {
            Connections.Add(ConnectionSettings.GetSqliteConnection(@"D:\TEMP\mpfinance\MPersist_DB.sqlite3"));
            //Connections.Add(ConnectionSettings.GetOracleConnection("192.168.0.111", 1521, "xe", "MPersist", "MPersist"));
            //Connections.Add(ConnectionSettings.GetMySqlConnection("piskuric.ca", "miskop_mpfinance", "miskop_mpfinance", "B2FkUh4ct2OZ"));
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

        public static ConnectionSettings GetConnectionSettings(String name)
        {
            foreach (ConnectionSettings item in Connections)
            {
                if (item.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                {
                    return item;
                }
            }
            throw new MPException("Invalid connection name {0}", new String[] { name });
        }
    }
}