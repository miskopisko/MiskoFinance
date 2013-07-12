using System;
using MPersist.Resources.Enums;

namespace MPersist.Core
{
    public class ConnectionSettings
    {
        private static Logger Log = Logger.GetInstance(typeof(ConnectionSettings));

        #region Variable Declarations

        private static ConnectionSettings mInstance_;

        #endregion

        #region Properties

        public ConnectionType ConnectionType { get; set; }
        public String Server { get; set; }
        public Int32? Port { get; set; }
        public String Datasource { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String ConnectionString { get; set; }

        public static ConnectionSettings Instance 
        {
            get
            {
                if (mInstance_ == null)
                {
                    mInstance_ = new ConnectionSettings();
                }
                return mInstance_;
            }
        }

        #endregion

        #region Public Static Methods

        public static void MySqlConnection(String server, String datasource, String username, String password)
        {
            Instance.ConnectionType = ConnectionType.MySql;
            Instance.Server = server;
            Instance.Port = null;
            Instance.Datasource = datasource;
            Instance.Username = username;
            Instance.Password = password;
            Instance.ConnectionString = "SERVER=" + server + ";DATABASE=" + datasource + ";UID=" + username + ";PASSWORD=" + password + ";Pooling=True;";
        }

        public static void OracleConnection(String host, Int32 port, String datasource, String username, String password)
        {
            Instance.ConnectionType = ConnectionType.Oracle;
            Instance.Server = host;
            Instance.Port = port;
            Instance.Datasource = datasource;
            Instance.Username = username;
            Instance.Password = password;
            Instance.ConnectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + host + ")(PORT=" + port + ")))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + datasource + ")));User Id=" + username + ";Password=" + password + ";Pooling=True;";
        }

        public static void SqliteConnection(String datasource)
        {
            Instance.ConnectionType = ConnectionType.SQLite;
            Instance.Server = null;
            Instance.Port = null;
            Instance.Datasource = datasource;
            Instance.Username = null;
            Instance.Password = null;
            Instance.ConnectionString = "Data Source=" + datasource + ";Version=3;Pooling=True;";
        }

        #endregion
    }
}
