using System;
using System.Windows.Forms;
using MiskoFinance.Panels;
using MiskoFinance.Properties;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;
using MiskoPersist.Core;
using MiskoPersist.Message.Response;
using MiskoPersist.Tools;

namespace MiskoFinance.Forms
{
    public partial class LoginDialog : Form
    {
        private static Logger Log = Logger.GetInstance(typeof(LoginDialog));

        public LoginDialog()
        {
            InitializeComponent();
        }

       	#region Override Methods
       	
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			
			Controls.Add(new LoginPanel(this));
		}
		
		protected override void OnControlAdded(ControlEventArgs e)
		{
			base.OnControlAdded(e);
			
			CenterToParent();
		}
		
		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			base.OnFormClosing(e);

        	if (this.DialogResult == DialogResult.Cancel)
        	{
        		Application.Exit();
        	}
		}
       	
       	#endregion        
    }
}
