using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using MPersist.Core;
using MPersist.Core.Enums;
using MPFinance.Core.Data.Stored;
using MPFinance.Forms;
using MPFinance.Resources;

namespace MPFinance
{
    static class Program
    {
        #region Variable Declarations

        private static ConnectionSettings mConnectionSettings_ = ConnectionSettings.SqliteConnection(@"..\..\DBA\MPersist_DB.sqlite3");
        //private static ConnectionSettings mConnectionSettings_ = ConnectionSettings.MySqlConnection("rpm-cvl", "test", "cvl", "cvl");
        //private static ConnectionSettings mConnectionSettings_ = ConnectionSettings.MySqlConnection("piskuric.ca", "miskop_MPersistenceTest", "miskop_michael", "sarpatt06");
        //private static ConnectionSettings mConnectionSettings_ = ConnectionSettings.OracleConnection("192.168.0.111", 1521, "xe", "MPersist", "MPersist");

        #endregion

        #region Properties

        public static Operator Operator { get; set; }
        public static Categories ExpenseCategories { get; set; }
        public static Categories IncomeCategories { get; set; }

        #endregion

        [STAThread]
        public static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;

            MessageProcessor.ConnectionSettings = mConnectionSettings_;
            MessageProcessor.IOController = new MPFinanceMain();

            Application.Run((Form)MessageProcessor.IOController);
        }

        public static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            if (MessageProcessor.IOController != null)
            {
                MessageProcessor.IOController.Error(new ErrorMessage(sender.GetType(), MethodBase.GetCurrentMethod(), ErrorLevel.Error, ErrorStrings.errUnexpectedApplicationErrorLong, new Object[] { e.Exception.Message.ToString(), e.Exception.StackTrace }));
            }
            else
            {
                MessageBox.Show((Control)MessageProcessor.IOController, e.Exception.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
