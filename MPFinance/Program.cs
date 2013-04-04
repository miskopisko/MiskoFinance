using System;
using MPersist.Security;
using MPersist.Core;
using MPersist.Resources.Enums;
using System.Globalization;

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

            OperatorProfile profile = OperatorProfile.GetInstanceById(session, 2, true);

            //OperatorProfile tl = new OperatorProfile("Team Lead", "Test@test.com", new DateTime(1982, 05, 15), Gender.Male, 33, null);

            //profile.Age = profile.Age + 1;
            //profile.Gender = Gender.Female;
            //profile.Birthday = new DateTime(1982,05,15);
            //profile.Name = "Michael Piskuric";
            //profile.Email = "michael@piskuric.cs";
            //profile.TeamLead = tl;

            //tl.TeamLead = new OperatorProfile("XXXXX", "Test@test.com", new DateTime(1982, 05, 15), Gender.Female, 33, null);

            //tl.Save(session);
            //profile.Delete(session);

            //OperatorProfile pro = new OperatorProfile("Test", "Test@test.com", new DateTime(1982, 05, 15), Gender.Male, 33, null);
            //pro.Save(session);

            int i = 1;
        }
    }
}
