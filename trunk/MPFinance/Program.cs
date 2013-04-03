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
            Session session = new Session(SessionType.Oracle, ServiceLocator.GetOracleConnection("devdb", 1521, "nbcdev02.world", "rpmprd", "open"));
            //Session session = new Session(SessionType.Sqlite, ServiceLocator.GetSqliteConnection(@"D:\TEMP\mpfinance\MPersistence\DBA\MPersist_DB"));

            OperatorProfile profile = OperatorProfile.GetInstance(session, 1);

            OperatorProfile pro = new OperatorProfile("Test", "Test@test.com", new DateTime(1982, 05, 15), Gender.Female, 30);
            pro.Save(session);

            int i = 1;
        }
    }
}
