using System;
using MPersist.Enums;
using System.Collections.Generic;
using MPersist.Resources;

namespace MPersist.Core
{
    public class ServerConnection
    {
        private static Logger Log = Logger.GetInstance(typeof(ServerConnection));

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

        public static ServerConnection GetMySqlConnection(String server, String datasource, String username, String password)
        {
            return GetMySqlConnection("Default", server, datasource, username, password);
        }

        public static ServerConnection GetMySqlConnection(String name, String server, String datasource, String username, String password)
        {
            ServerConnection item = new ServerConnection();
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

        public static ServerConnection GetOracleConnection(String host, Int32 port, String datasource, String username, String password)
        {
            return GetOracleConnection("Default", host, port, datasource, username, password);
        }

        public static ServerConnection GetOracleConnection(String name, String host, Int32 port, String datasource, String username, String password)
        {
            ServerConnection item = new ServerConnection();
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

        public static ServerConnection GetSqliteConnection(String datasource)
        {
            return GetSqliteConnection("Default", datasource);
        }

        public static ServerConnection GetSqliteConnection(String name, String datasource)
        {
            ServerConnection item = new ServerConnection();
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

        public static ServerConnection GetFoxProConnection(String datasource)
        {
            return GetFoxProConnection("Default", datasource);
        }

        public static ServerConnection GetFoxProConnection(String name, String datasource)
        {
            ServerConnection item = new ServerConnection();
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

        public static ServerConnection GetSvnConnection(String workingCopy)
        {
            return GetSvnConnection("Default", workingCopy);
        }

        public static ServerConnection GetSvnConnection(String name, String workingCopy)
        {
            ServerConnection item = new ServerConnection();
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

    public class ServerConnections
    {
        private static Logger Log = Logger.GetInstance(typeof(ServerConnection));

        #region Fields

        private List<ServerConnection> mConnections_ = new List<ServerConnection>();

        #endregion

        public void Add(ServerConnection serverConnection)
        {
            if (AlreadyExists(serverConnection.Name))
            {
                throw new MPException("Connection with name '{0}' already exists", new String[] { serverConnection.Name });
            }

            mConnections_.Add(serverConnection);
        }

        private Boolean AlreadyExists(String name)
        {
            foreach (ServerConnection item in mConnections_)
            {
                if (item.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public ServerConnection GetServerConnection(String name)
        {
            foreach (ServerConnection item in mConnections_)
            {
                if (item.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                {
                    return item;
                }
            }
            throw new MPException(ErrorStrings.errInvalidConnectionString, new String[] { name });
        }
    }
}
