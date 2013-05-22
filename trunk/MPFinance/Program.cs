using MPersist.Core;
using MPersist.Core.Enums;
using MPFinance.Core.Data.Stored;
using MPFinance.Forms;
using MPFinance.Resources;
using System;
using System.Data.Common;
using System.Reflection;
using System.Windows.Forms;

namespace MPFinance
{
    static class Program
    {
        #region Variable Declarations

        private static DbConnection mConnection_ = ServiceLocator.GetOracleConnection("192.168.0.111", 1521, "xe", "MPersist", "MPersist");
        //private static DbConnection mConnection_ = ServiceLocator.GetSqliteConnection(@"..\..\DBA\MPersist_DB.sqlite3");
        //private static DbConnection mConnection_ = ServiceLocator.GetMysqlConnection("piskuric.ca", "miskop_MPersistenceTest", "miskop_michael", "sarpatt06");

        private static MPFinanceMain mMPFinance_ = null;
        private static Operator mOperator_ = null;

        #endregion

        #region Properties

        public static MPFinanceMain MPFinance { get { return mMPFinance_; } }
        public static Operator Operator { get { return mOperator_; } set { mOperator_ = value; } }

        #endregion

        [STAThread]
        public static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;

            mMPFinance_ = new MPFinanceMain();

            MessageProcessor.Connection = mConnection_;
            MessageProcessor.IOController = mMPFinance_;

            Application.Run(mMPFinance_);
        }

        public static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if (mMPFinance_ != null)
            {
                mMPFinance_.Error(new ErrorMessage(sender.GetType(), MethodBase.GetCurrentMethod(), ErrorLevel.Error, ErrorStrings.errUnexpectedApplicationErrorLong, new Object[] { e.Exception.Message.ToString(), e.Exception.StackTrace }));
            }
            else
            {
                MessageBox.Show(mMPFinance_, e.Exception.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
