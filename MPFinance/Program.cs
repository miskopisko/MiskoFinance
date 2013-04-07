using System;
using MPersist.Core;
using MPersist.Resources.Enums;
using MPFinance.Security;
using System.Windows.Forms;
using MPersist.Security;
using System.Reflection;

namespace MPersist
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;

            Session session = new Session(SqlSessionType.MySql, ServiceLocator.GetMysqlConnection("piskuric.ca", "miskop_MPersistenceTest", "miskop_mpersist", "mpersist"));
            //Session session = new Session(SessionType.Oracle, ServiceLocator.GetOracleConnection("devdb", 1521, "nbcdev02.world", "rpmprd", "open"));
            //Session session = new Session(SessionType.Sqlite, ServiceLocator.GetSqliteConnection(@"..\..\DBA\MPersist_DB.sqlite3"));

            //Users u = new Users();
            //u.fetchAll(session);



            Operator profile = Operator.GetInstanceById(session, 4, true);

            Object[] items = typeof(Gender).GetProperties(BindingFlags.Static | BindingFlags.Public);

            int i = 1;

            //Operator tl = new Operator("miskop", "secret", "TeamLead", "Test@test.com", new DateTime(1982, 05, 15), Gender.Male, 33, null);

            //profile.Age = 30;
            //profile.Gender = Gender.Male;
            //profile.Birthday = new DateTime(1982,05,15);
            //profile.Name = "Michael Piskuric";
            //profile.Email = "michael@piskuric.cs";
            //profile.TeamLead = tl;

            //profile.Save(session);

            //tl.TeamLead = new Operator("user", "pass", "XXXXX", "Test@test.com", new DateTime(1982, 05, 15), Gender.Female, 33, null);
                      
            //profile.Delete(session);
            //Operator pro = new Operator("miskooop","more","Follower", "Test@test.com", new DateTime(1982, 05, 15), Gender.Female, 33, tl);
            //pro.Save(session);

            //Operators profiles = new Operators();
            //profiles.fetchTest(session);            


            
        }

        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.ExceptionObject.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(1);
        }
    }
}
