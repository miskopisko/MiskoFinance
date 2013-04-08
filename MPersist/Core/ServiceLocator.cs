using System;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.Data.SQLite;
using System.Data.OracleClient;

namespace MPersist.Core
{
    public class ServiceLocator
    {
        private static Logger Log = Logger.GetInstance(typeof(ServiceLocator));

        public static DbConnection GetMysqlConnection(String server, String datasource, String username, String password)
        {
            MySqlConnection connection = null;
            
            try
            {
                connection = new MySqlConnection("SERVER=" + server + ";DATABASE=" + datasource + ";UID=" + username + ";PASSWORD=" + password + ";");
                connection.Open();
            }
            catch (Exception)
            {
            }

            return connection;
        }

        public static DbConnection GetOracleConnection(String host, Int32 port, String datasource, String username, String password)
        {
            OracleConnection connection = null;

            try
            {
                connection = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + host + ")(PORT=" + port + ")))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + datasource + ")));User Id=" + username + ";Password=" + password + ";");
                connection.Open();
            }
            catch (Exception)
            {
            }

            return connection;
        }

        public static DbConnection GetSqliteConnection(String dataSource)
        {
            SQLiteConnection connection = null;

            try
            {
                connection = new SQLiteConnection("Data Source=" + dataSource + ";Version=3;");
                connection.Open();
            }
            catch (Exception)
            {
                throw new Exception("Could not open Sqlite database at " + dataSource);
            }

            return connection;
        }
    }
}
