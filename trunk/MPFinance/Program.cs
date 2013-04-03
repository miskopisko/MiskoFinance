using System;
using MPersist.Security;
using MPersist.Core;
using MPersist.Resources.Enums;

namespace MPFinance
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            //Session session = new Session(SessionType.MySql, ServiceLocator.GetMysqlConnection("rpm-cvl", "test", "cvl", "cvl"));
            //Session session = new Session(SessionType.Oracle, ServiceLocator.GetOracleConnection("rpm-cvl", "test", "cvl", "cvl"));
            Session session = new Session(SessionType.Sqlite, ServiceLocator.GetSqliteConnection(@"D:\TEMP\mpfinance\MPersistence\DBA\MPersist_DB"));

            OperatorProfile profile = OperatorProfile.GetInstance(session, 1);
            int i = 1;
        }
    }
}
