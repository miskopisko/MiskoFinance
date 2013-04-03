using System;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.Data.OracleClient;
using System.Data.SQLite;

namespace MPersist.Core
{
    public class ServiceLocator
    {
        private static Logger Log = Logger.GetInstance(typeof(ServiceLocator));

        public static DbConnection GetMysqlConnection(String server, String datasource, String username, String password)
        {
            MySqlConnection connection = new MySqlConnection("SERVER=" + server + ";DATABASE=" + datasource + ";UID=" + username + ";PASSWORD=" + password + ";");
            
            try
            {
                connection.Open();
            }
            catch (Exception)
            {
            }

            return connection;
        }

        public static DbConnection GetOracleConnection(String host, Int32 port, String datasource, String username, String password)
        {
            OracleConnection connection = new OracleConnection();
            connection.ConnectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + host + ")(PORT=" + port + ")))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + datasource + ")));User Id=" + username + ";Password=" + password + ";";

            try
            {
                connection.Open();
            }
            catch (Exception)
            {                
            }

            return connection;
        }

        public static DbConnection GetSqliteConnection(String dataSource)
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source=" + dataSource + ";Version=3;");

            try
            {
                connection.Open();
            }
            catch (Exception)
            {
            }

            return connection;
        }
    }
}
