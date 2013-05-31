using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using MPersist.Core;
using MPersist.Core.Enums;
using MPFinance.Core.Data.Stored;
using MPFinance.Forms;
using MPFinance.Resources;
using MPersist.Core.Tools;

namespace MPFinance
{
    static class Program
    {
        #region Variable Declarations

        private static MPFinanceMain mMAIN_;

        private static ConnectionSettings mConnectionSettings_ = ConnectionSettings.SqliteConnection(@"..\..\DBA\MPersist_DB.sqlite3");
        //private static ConnectionSettings mConnectionSettings_ = ConnectionSettings.MySqlConnection("rpm-cvl", "test", "cvl", "cvl");
        //private static ConnectionSettings mConnectionSettings_ = ConnectionSettings.MySqlConnection("piskuric.ca", "miskop_MPersistenceTest", "miskop_michael", "sarpatt06");
        //private static ConnectionSettings mConnectionSettings_ = ConnectionSettings.OracleConnection("192.168.0.111", 1521, "xe", "MPersist", "MPersist");

        #endregion

        [STAThread]
        public static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;

            mMAIN_ = new MPFinanceMain(mConnectionSettings_);            
            Application.Run(mMAIN_);
        }

        public static Operator GetOperator()
        {
            return mMAIN_.Operator;
        }

        public static Categories GetIncomeCategories()
        {
            return mMAIN_.IncomeCategories;
        }

        public static Categories GetExpenseCategories()
        {
            return mMAIN_.ExpenseCategories;
        }

        public static Categories GetTransferCategories()
        {
            return mMAIN_.TransferCategories;
        }

        public static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            if (e.Exception is MPException)
            {
                MessageBox.Show(mMAIN_, e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String message = Utils.ResolveTextParameters(ErrorStrings.errUnexpectedApplicationErrorLong, new Object[] { e.Exception.Message.ToString(), e.Exception.StackTrace });
                MessageBox.Show(mMAIN_, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                
        }
    }
}
