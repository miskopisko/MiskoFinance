using System;
using System.Diagnostics;
using System.Windows.Forms;
using MiskoFinanceCore.Resources;
using MiskoPersist.Core;
using MiskoPersist.Data;
using MiskoPersist.Enums;
using MiskoPersist.Interfaces;
using MiskoFinance.Forms;
using MiskoFinance.Properties;

namespace MiskoFinance
{
	public class MiskoFinance_IOController_Impl : IOController
	{
		#region Fields
		
		private static MiskoFinance_IOController_Impl mInstance_;
		
		#endregion
		
		#region Properties
		
		public static MiskoFinance_IOController_Impl Instance 
		{
			get 
			{
				if(mInstance_ == null)
				{
					mInstance_ = new MiskoFinance_IOController_Impl();
				}
				return mInstance_;
			}
		}
		
		public int RowsPerPage 
		{
			get 
			{
				return Settings.Default.RowsPerPage;
			}
		}

		public DataSource DataSource 
		{
			get 
			{
				return DataSource.Local;
			}
		}
		
		#endregion
		
		public MiskoFinance_IOController_Impl()
		{
		}

		#region IOController implementation

		public ConnectionProvider GetConnectionProvider()
		{
			if(DataSource.Equals(DataSource.Local))
			{
			   	return new LocalConnectionProvider();
			}
		   	return null;
		}

		public void Debug(object obj)
		{
			Trace.Write(AbstractData.SerializeJson(obj));
		}

		public void Status(string message)
		{
			MiskoFinanceMain.Instance.Invoke(new MethodInvoker(delegate { MiskoFinanceMain.Instance.StatusLabel.Text = message; }));
        	Application.DoEvents();
		}

		public void MessageReceived()
		{
			MiskoFinanceMain.Instance.Invoke(new MethodInvoker(delegate { MiskoFinanceMain.Instance.MessageStatusBar.Increment(-10); }));
            Application.DoEvents();
		}

		public void MessageSent()
		{
			MiskoFinanceMain.Instance.Invoke(new MethodInvoker(delegate { MiskoFinanceMain.Instance.MessageStatusBar.Increment(10); }));
            Application.DoEvents();
		}

		public void ExceptionHandler(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			Exception ex = e.Exception;
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            
            #if DEBUG
				Trace.TraceError(ex.StackTrace);
			#endif
            
            Error(ex.Message);
		}

		public void Error(string message)
		{			
			MiskoFinanceMain.Instance.Invoke(new MethodInvoker(delegate { MessageBox.Show(MiskoFinanceMain.Instance, message, ErrorStrings.errError, MessageBoxButtons.OK, MessageBoxIcon.Error); }));
		}

		public void Warning(string message)
		{
			MiskoFinanceMain.Instance.Invoke(new MethodInvoker(delegate { MessageBox.Show(MiskoFinanceMain.Instance, message, WarningStrings.warnWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning); }));
		}

		public void Info(string message)
		{
			MiskoFinanceMain.Instance.Invoke(new MethodInvoker(delegate { MessageBox.Show(MiskoFinanceMain.Instance, message, Strings.strInfo, MessageBoxButtons.OK, MessageBoxIcon.Information); }));
		}

		public bool Confirm(string message)
		{
			DialogResult result = DialogResult.None;
            MiskoFinanceMain.Instance.Invoke(new MethodInvoker(delegate { result = MessageBox.Show(MiskoFinanceMain.Instance, message, ConfirmStrings.conConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question); }));
            return result.Equals(DialogResult.Yes);
		}

		#endregion
	}
}
