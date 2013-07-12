using MPersist.Core;
using MPFinance.Forms;
using System;
using System.Windows.Forms;

namespace MPFinance
{
    static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            //ConnectionSettings.OracleConnection("192.168.0.111", 1521, "xe", "MPersist", "MPersist");
            ConnectionSettings.SqliteConnection(@"..\..\DBA\MPersist_DB.sqlite3");
            //ConnectionSettings.MySqlConnection("rpm-cvl", "test", "cvl", "cvl");
            //ConnectionSettings.MySqlConnection("piskuric.ca", "miskop_MPersistenceTest", "miskop_michael", "sarpatt06");
            //ConnectionSettings.SqliteConnection(@"C:\Users\Michael\Dev\mpersist_test");

            Application.ThreadException += MPFinanceMain.Instance.ExceptionHandler;
            MessageProcessor.IOController = MPFinanceMain.Instance;
            Application.Run(MPFinanceMain.Instance);
        }
    }
}
