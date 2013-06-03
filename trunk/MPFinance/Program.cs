using System;
using System.Threading;
using System.Windows.Forms;
using MPersist.Core;
using MPersist.Core.Tools;
using MPFinance.Forms;
using MPFinance.Resources;

namespace MPFinance
{
    static class Program
    {
        #region Variable Declarations

        public static ConnectionSettings mConnectionSettings_ = ConnectionSettings.SqliteConnection(@"..\..\DBA\MPersist_DB.sqlite3");
        //public static ConnectionSettings mConnectionSettings_ = ConnectionSettings.MySqlConnection("rpm-cvl", "test", "cvl", "cvl");
        //public static ConnectionSettings mConnectionSettings_ = ConnectionSettings.MySqlConnection("piskuric.ca", "miskop_MPersistenceTest", "miskop_michael", "sarpatt06");
        //public static ConnectionSettings mConnectionSettings_ = ConnectionSettings.OracleConnection("192.168.0.111", 1521, "xe", "MPersist", "MPersist");

        #endregion

        [STAThread]
        public static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;

            Application.Run(MPFinanceMain.Instance);
        }

        public static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            if (e.Exception is MPException)
            {
                MessageBox.Show(MPFinanceMain.Instance, e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String message = Utils.ResolveTextParameters(ErrorStrings.errUnexpectedApplicationErrorLong, new Object[] { e.Exception.Message.ToString(), e.Exception.StackTrace });
                MessageBox.Show(MPFinanceMain.Instance, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                
        }
    }
}
