using System;
using MPersist.Core;
using MPersist.Resources.Enums;
using MPFinance.Security;
using System.Windows.Forms;

namespace MPersist
{
    static class Program
    {
        static Session session = new Session(SqlSessionType.MySql, ServiceLocator.GetMysqlConnection("rpm-cvl", "test", "cvl", "cvl"));
        //Session session = new Session(SqlSessionType.Oracle, ServiceLocator.GetOracleConnection("devdb", 1521, "nbcdev02.world", "rpmprd", "open"));
        //Session session = new Session(SqlSessionType.Sqlite, ServiceLocator.GetSqliteConnection(@"..\..\DBA\MPersist_DB.sqlite3"));

        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;            

            session.BeginTransaction();
            OperatorProfile tl = new OperatorProfile("miskop", "secret", "TeamLead", "Test@test.com", new DateTime(1982, 05, 15), Gender.Male, 33, null);
            OperatorProfile pro = new OperatorProfile("Follower", "xxxx", "minion", "Test@test.com", null, Gender.NULL, 33, tl);

            session.BeginTransaction();
            session.EndTransaction();

            pro.Save(session);

            //Operators profiles = new Operators();
            //profiles.fetchTest(session);

            //OperatorProfile o = OperatorProfile.GetInstanceById(session, 1000005, true);
            //o.Age = o.Age + 1;
            //o.Gender = Gender.Male;
            //o.Email = "changed email again";
            //o.Save(session);

            int j = 0;
            int i = 1/j;            
        }

        static void UnhandledExceptionTrapper(Object sender, UnhandledExceptionEventArgs e)
        {
            session.Error(e.ExceptionObject.GetType(), null, ErrorLevel.Critical, "Unknown error");
        }
    }
}
