using System;
using System.Windows.Forms;
using MiskoPersist.Core;
using MiskoFinance.Forms;

namespace MiskoFinance
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            //ConnectionSettings.AddSqliteConnection(@"..\..\..\MiskoFinance_DB.sqlite3");
            ConnectionSettings.AddMySqlConnection("piskuric.ca", "mpfinance", "mpfinance", "mpfinance");

            ServerConnection.IOController = MiskoFinance_IOController_Impl.Instance;
        	
        	Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
			Application.ThreadException += MiskoFinance_IOController_Impl.Instance.ExceptionHandler;
			Application.Run(MiskoFinanceMain.Instance);
            Application.DoEvents();
        }        
    }
}
