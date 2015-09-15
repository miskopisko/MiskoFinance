using System;
using System.Windows.Forms;
using MiskoFinance.Forms;

namespace MiskoFinance
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
			Application.Run(MiskoFinanceMain.Instance);            
        }        
    }
}
