using System;
using MPersist.Enums;

namespace MPersist.Core
{
    public class ConnectionSettings
    {
        private static Logger Log = Logger.GetInstance(typeof(ConnectionSettings));

        #region Fields

        

        #endregion

        #region Properties

        public String Name { get; set; }
        public ConnectionType ConnectionType { get; set; }
        public String Server { get; set; }
        public Int32? Port { get; set; }
        public String Datasource { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String ConnectionString { get; set; }        

        #endregion

        #region Public Static Methods

        public static ConnectionSettings GetMySqlConnection(String server, String datasource, String username, String password)
        {
            return GetMySqlConnection("Default", server, datasource, username, password);
        }

        public static ConnectionSettings GetMySqlConnection(String name, String server, String datasource, String username, String password)
        {
            ConnectionSettings item = new ConnectionSettings();
            item.Name = name;
            item.ConnectionType = ConnectionType.MySql;
            item.Server = server;
            item.Port = null;
            item.Datasource = datasource;
            item.Username = username;
            item.Password = password;
            item.ConnectionString = "SERVER=" + server + ";DATABASE=" + datasource + ";UID=" + username + ";PASSWORD=" + password + ";Pooling=True;";

            return item;
        }

        public static ConnectionSettings GetOracleConnection(String host, Int32 port, String datasource, String username, String password)
        {
            return GetOracleConnection("Default", host, port, datasource, username, password);
        }

        public static ConnectionSettings GetOracleConnection(String name, String host, Int32 port, String datasource, String username, String password)
        {
            ConnectionSettings item = new ConnectionSettings();
            item.Name = name;
            item.ConnectionType = ConnectionType.Oracle;
            item.Server = host;
            item.Port = port;
            item.Datasource = datasource;
            item.Username = username;
            item.Password = password;
            item.ConnectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + host + ")(PORT=" + port + ")))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + datasource + ")));User Id=" + username + ";Password=" + password + ";Pooling=True;";

            return item;
        }

        public static ConnectionSettings GetSqliteConnection(String datasource)
        {
            return GetSqliteConnection("Default", datasource);
        }

        public static ConnectionSettings GetSqliteConnection(String name, String datasource)
        {
            ConnectionSettings item = new ConnectionSettings();
            item.Name = name;
            item.ConnectionType = ConnectionType.SQLite;
            item.Server = null;
            item.Port = null;
            item.Datasource = datasource;
            item.Username = null;
            item.Password = null;
            item.ConnectionString = "Data Source=" + datasource + ";Version=3;Pooling=True;";

            return item;
        }

        public static ConnectionSettings GetFoxProConnection(String datasource)
        {
            return GetFoxProConnection("Default", datasource);
        }

        public static ConnectionSettings GetFoxProConnection(String name, String datasource)
        {
            ConnectionSettings item = new ConnectionSettings();
            item.Name = name;
            item.ConnectionType = ConnectionType.FoxPro;
            item.Server = null;
            item.Port = null;
            item.Datasource = datasource;
            item.Username = null;
            item.Password = null;
            item.ConnectionString = "Provider=vfpoledb;Data Source=" + datasource + ";Collating Sequence=general;Exclusive=No;";

            return item;
        }

        public static ConnectionSettings GetSvnConnection(String workingCopy)
        {
            return GetSvnConnection("Default", workingCopy);
        }

        public static ConnectionSettings GetSvnConnection(String name, String workingCopy)
        {
            ConnectionSettings item = new ConnectionSettings();
            item.Name = name;
            item.ConnectionType = ConnectionType.SVN;
            item.Server = null;
            item.Port = null;
            item.Datasource = workingCopy;
            item.Username = null;
            item.Password = null;
            item.ConnectionString = workingCopy;

            return item;
        }

        #endregion
    }
}
