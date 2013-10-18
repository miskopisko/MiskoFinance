using System;
using System.Windows.Forms;
using MPersist.Core;
using MPFinance.Forms;
using MPFinance.Properties;
using MPersist.Enums;

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

            IOController.Instance = new IOController_Impl();
            IOController.Instance.RowsPerPage = Settings.Default.RowsPerPage;

            IOController.Instance.ServerType = ServerType.Online;
            IOController.Instance.Host = "localhost";
            IOController.Instance.Port = 33333;
            IOController.Instance.Script = "/Service.asmx/Process";

            //IOController.Instance.AddConnection(ConnectionSettings.GetSqliteConnection(@"..\..\MPersist_DB.sqlite3"));
            //IOController.Instance.AddConnection(ConnectionSettings.GetOracleConnection("192.168.0.111", 1521, "xe", "MPersist", "MPersist"));
            //IOController.Instance.AddConnection(ConnectionSettings.GetMySqlConnection("piskuric.ca", "miskop_mpfinance", "miskop_mpfinance", "B2FkUh4ct2OZ"));

            Application.Run(MPFinanceMain.Instance);
        }
    }
}
