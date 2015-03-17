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
            ConnectionSettings.AddSqliteConnection(@"..\..\..\MiskoFinance_DB.sqlite3");
        	
        	Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.Run(MiskoFinanceMain.Instance);
        }        
    }
}
