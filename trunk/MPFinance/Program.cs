using System;
using System.Windows.Forms;
using MPersist.Core;
using MPFinance.Forms;

namespace MPFinance
{
    static class Program
    {
        [STAThread]
        public static void Main()
        {
            //ConnectionSettings.AddOracleConnection("192.168.0.111", 1521, "xe", "MPersist", "MPersist");
            ConnectionSettings.AddSqliteConnection(@"..\..\DBA\MPersist_DB.sqlite3");
            //ConnectionSettings.AddMySqlConnection("piskuric.ca", "miskop_MPersistenceTest", "miskop_michael", "sarpatt06");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.Run(MPFinanceMain.Instance);
        }
    }
}
