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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            //ConnectionSettings.AddOracleConnection("192.168.0.111", 1521, "xe", "MPersist", "MPersist");
            //ConnectionSettings.AddSqliteConnection(@"C:\Users\Michael\Dev\C#\mpfinance\MPFinance\MPersist_DB.sqlite3");
            ConnectionSettings.AddMySqlConnection("piskuric.ca", "miskop_mpfinance", "miskop_mpfinance", "B2FkUh4ct2OZ");

            Application.Run(MPFinanceMain.Instance);
        }
    }
}
