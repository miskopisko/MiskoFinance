using System;
using System.Data.Common;
using System.Data.SQLite;
using MPersist.Core.Resources;
using MPersist.Resources.Enums;
using MySql.Data.MySqlClient;
using Oracle.DataAccess.Client;

namespace MPersist.Core
{
    public class ServiceLocator
    {
        private static Logger Log = Logger.GetInstance(typeof(ServiceLocator));

        #region Public Methods

        public static DbConnection GetConnection()
        {
            if (ConnectionSettings.Instance.ConnectionType.Equals(ConnectionType.SQLite))
            {
                return GetSqliteConnection(ConnectionSettings.Instance.ConnectionString);
            }
            else if (ConnectionSettings.Instance.ConnectionType.Equals(ConnectionType.MySql))
            {
                return GetMysqlConnection(ConnectionSettings.Instance.ConnectionString);
            }
            else if (ConnectionSettings.Instance.ConnectionType.Equals(ConnectionType.Oracle))
            {
                return GetOracleConnection(ConnectionSettings.Instance.ConnectionString);
            }
            else if (ConnectionSettings.Instance.ConnectionType.Equals(ConnectionType.Postgres))
            {
                return GetPostgresConnection(ConnectionSettings.Instance.ConnectionString);
            }
            else if (ConnectionSettings.Instance.ConnectionType.Equals(ConnectionType.FoxPro))
            {
                return GetFoxProConnection(ConnectionSettings.Instance.ConnectionString);
            }
            else
            {
                throw new MPException(ErrorStrings.errInvalidConnectionString);
            }
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
            throw new NotImplementedException();
        }

        #endregion
    }
}
