using System;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SQLite;
using MPersist.Enums;
using MPersist.SVN;
using MySql.Data.MySqlClient;
using Oracle.DataAccess.Client;

namespace MPersist.Core
{
    public class ServiceLocator
    {
        private static Logger Log = Logger.GetInstance(typeof(ServiceLocator));

        #region Public Methods

        public static DbConnection GetConnection(ServerConnection serverConnection)
        {
            if (serverConnection != null && serverConnection.ConnectionType.Equals(ConnectionType.SQLite))
            {
                return GetSqliteConnection(serverConnection.ConnectionString);
            }
            else if (serverConnection != null && serverConnection.ConnectionType.Equals(ConnectionType.MySql))
            {
                return GetMysqlConnection(serverConnection.ConnectionString);
            }
            else if (serverConnection != null && serverConnection.ConnectionType.Equals(ConnectionType.Oracle))
            {
                return GetOracleConnection(serverConnection.ConnectionString);
            }
            else if (serverConnection != null && serverConnection.ConnectionType.Equals(ConnectionType.Postgres))
            {
                return GetPostgresConnection(serverConnection.ConnectionString);
            }
            else if (serverConnection != null && serverConnection.ConnectionType.Equals(ConnectionType.FoxPro))
            {
                return GetFoxProConnection(serverConnection.ConnectionString);
            }
            else if (serverConnection != null && serverConnection.ConnectionType.Equals(ConnectionType.SVN))
            {
                return GetSvnConnection(serverConnection.ConnectionString);
            }
            return null;
        }

        #endregion

        #region Private Methods

        private static DbConnection GetMysqlConnection(String connectionString)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            return connection;
        }

        private static DbConnection GetOracleConnection(String connectionString)
        {
            OracleConnection connection = new OracleConnection(connectionString);
            connection.Open();

            return connection;
        }

        private static DbConnection GetSqliteConnection(String connectionString)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            return connection;
        }

        private static DbConnection GetPostgresConnection(String connectionString)
        {
            throw new NotImplementedException();
        }

        private static DbConnection GetFoxProConnection(String connectionString)
        {
            DbConnection connection = new OleDbConnection(connectionString);
            connection.Open();

            return connection;
        }

        private static DbConnection GetSvnConnection(String connectionString)
        {
            DbConnection connection = SvnConnectionPool.GetByConnectionString(connectionString);

            if(connection == null)
            {
                connection = new SvnConnection(connectionString);
                connection.Open();
                SvnConnectionPool.AddConnection((SvnConnection)connection);
            }

            return connection;
        }

        #endregion
    }
}
