using MPersist.Core.Resources;
using MPersist.Resources.Enums;
using MySql.Data.MySqlClient;
using Oracle.DataAccess.Client;
using System;
using System.Data.Common;
using System.Data.SQLite;

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
            else
            {
                throw new MPException(ErrorStrings.errInvalidConnectionString);
            }
        }

        #endregion

        #region Private Methods

        private static DbConnection GetMysqlConnection(String connectionString)
        {
            MySqlConnection connection = null;
            
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            catch (Exception e)
            {
                throw e;
            }

            return connection;
        }

        private static DbConnection GetOracleConnection(String connectionString)
        {
            OracleConnection connection = null;

            try
            {
                connection = new OracleConnection(connectionString);
                connection.Open();
            }
            catch (Exception e)
            {
                throw e;
            }

            return connection;
        }

        private static DbConnection GetSqliteConnection(String connectionString)
        {
            SQLiteConnection connection = null;

            try
            {
                connection = new SQLiteConnection(connectionString);
                connection.Open();
            }
            catch (Exception e)
            {
                throw e;
            }

            return connection;
        }

        #endregion
    }
}
