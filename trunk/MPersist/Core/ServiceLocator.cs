using System;
using System.Data.Common;
using System.Data.SQLite;
using MPersist.Resources.Enums;
using MySql.Data.MySqlClient;
using Oracle.DataAccess.Client;

namespace MPersist.Core
{
    public struct ConnectionSettings
    {
        #region Properties

        public ConnectionType ConnectionType { get; set; }
        public String Server { get; set; }
        public Int32? Port { get; set; }
        public String Datasource { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String ConnectionString { get; set; }

        #endregion

        public static ConnectionSettings MySqlConnection(String server, String datasource, String username, String password)
        {
            ConnectionSettings connectionSettings = new ConnectionSettings();

            connectionSettings.ConnectionType = ConnectionType.MySql;
            connectionSettings.Server = server;
            connectionSettings.Port = null;
            connectionSettings.Datasource = datasource;
            connectionSettings.Username = username;
            connectionSettings.Password = password;
            connectionSettings.ConnectionString = "SERVER=" + server + ";DATABASE=" + datasource + ";UID=" + username + ";PASSWORD=" + password + ";Pooling=True;";

            return connectionSettings;
        }

        public static ConnectionSettings OracleConnection(String host, Int32 port, String datasource, String username, String password)
        {
            ConnectionSettings connectionSettings = new ConnectionSettings();

            connectionSettings.ConnectionType = ConnectionType.Oracle;
            connectionSettings.Server = host;
            connectionSettings.Port = port;
            connectionSettings.Datasource = datasource;
            connectionSettings.Username = username;
            connectionSettings.Password = password;
            connectionSettings.ConnectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + host + ")(PORT=" + port + ")))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + datasource + ")));User Id=" + username + ";Password=" + password + ";Pooling=True;";
            
            return connectionSettings;
        }

        public static ConnectionSettings SqliteConnection(String datasource)
        {
            ConnectionSettings connectionSettings = new ConnectionSettings();

            connectionSettings.ConnectionType = ConnectionType.SQLite;
            connectionSettings.Server = null;
            connectionSettings.Port = null;
            connectionSettings.Datasource = datasource;
            connectionSettings.Username = null;
            connectionSettings.Password = null;
            connectionSettings.ConnectionString = "Data Source=" + datasource + ";Version=3;Pooling=True;";

            return connectionSettings;
        }
    }

    public class ServiceLocator
    {
        private static Logger Log = Logger.GetInstance(typeof(ServiceLocator));

        public static DbConnection GetConnection(ConnectionSettings connectionSettings)
        {
            if (connectionSettings.ConnectionType.Equals(ConnectionType.SQLite))
            {
                return GetSqliteConnection(connectionSettings);
            }
            else if (connectionSettings.ConnectionType.Equals(ConnectionType.MySql))
            {
                return GetMysqlConnection(connectionSettings);
            }
            else if (connectionSettings.ConnectionType.Equals(ConnectionType.Oracle))
            {
                return GetOracleConnection(connectionSettings);
            }

            return null;
        }

        private static DbConnection GetMysqlConnection(ConnectionSettings connectionSettings)
        {
            MySqlConnection connection = null;
            
            try
            {
                connection = new MySqlConnection(connectionSettings.ConnectionString);
                connection.Open();
            }
            catch (Exception e)
            {
                throw e;
            }

            return connection;
        }

        private static DbConnection GetOracleConnection(ConnectionSettings connectionSettings)
        {
            OracleConnection connection = null;

            try
            {
                connection = new OracleConnection(connectionSettings.ConnectionString);
                connection.Open();
            }
            catch (Exception e)
            {
                throw e;
            }

            return connection;
        }

        private static DbConnection GetSqliteConnection(ConnectionSettings connectionSettings)
        {
            SQLiteConnection connection = null;

            try
            {
                connection = new SQLiteConnection(connectionSettings.ConnectionString);
                connection.Open();
            }
            catch (Exception e)
            {
                throw e;
            }

            return connection;
        }
    }
}
