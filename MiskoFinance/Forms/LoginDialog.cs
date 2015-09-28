using System;
using System.Windows.Forms;
using MiskoPersist.Core;
using MiskoFinance.Panels;

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
