using System;
using System.Windows.Forms;
using MPersist.Core;
using MPFinance.Forms;

namespace MPFinance
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            ConnectionSettings.AddSqliteConnection(@"..\..\..\MPersist_DB.sqlite3");
        	
        	Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.Run(MPFinanceMain.Instance);
        }        
    }
}
