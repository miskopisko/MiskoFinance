using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;
using MiskoPersist.Core;
using MiskoPersist.Message.Response;
using MiskoPersist.Tools;
using MiskoFinance.Forms;
using MiskoFinance.Properties;

namespace MiskoFinance.Panels
{
	public partial class LoginPanel : UserControl
	{
		private new LoginDialog Parent 
		{
			get;
			set;
		}
		
		public LoginPanel(LoginDialog loginDialog)
		{
			Parent = loginDialog;
			
			InitializeComponent();
			
			Parent.Text = "Login";
            
            mUsername_.TextChanged += mUsername_TextChanged;
		}
		
		#region Override Methods

        protected override void OnLoad(EventArgs e)
        {
        	if (!String.IsNullOrEmpty(Settings.Default.DefaultUsername.Trim()))
            {
                mUsername_.Text = Settings.Default.DefaultUsername.Trim();
                mPassword_.Text = "";
                mPassword_.Select();
            }
        	
        	Parent.AcceptButton = mLogin_;
        	Parent.CancelButton = mCancel_;
        }

        #endregion

        #region Private Methods

        private void LoginSuccess(ResponseMessage response)
        {
        	MiskoFinanceMain.Instance.Operator = ((LoginRS)response).Operator;
        	Settings.Default.DefaultUsername = MiskoFinanceMain.Instance.Operator.Username;
        	Settings.Default.Save();
        	Parent.DialogResult = DialogResult.OK;
        }
        
        private void LoginError(ResponseMessage response)
        {
        	mNewUser_.Enabled = true;
        	mCancel_.Enabled = true;
        	mLogin_.Enabled = true;
        	mDatasource_.Enabled = true;
        }

        #endregion

        #region Event Listenners

        private void mLogin__Click(object sender, EventArgs e)
        {
        	mNewUser_.Enabled = false;
        	mCancel_.Enabled = false;
        	mLogin_.Enabled = false;
        	mDatasource_.Enabled = false;
        	
            LoginRQ request = new LoginRQ();
            request.Username = mUsername_.Text.Trim();
            request.Password = Utils.GenerateHash(mPassword_.Text.Trim());
            ServerConnection.SendRequest(request, LoginSuccess, LoginError);
        }

        private void mCancel__Click(object sender, EventArgs e)
        {
            Parent.DialogResult = DialogResult.Cancel;
        }

		private void mUsername_TextChanged(object sender, EventArgs e)
		{
			mPassword_.Text = "";
		}
		
        private void mNewUser__Click(object sender, EventArgs e)
        {
            SettingsDialog settings = new SettingsDialog(new VwOperator());

            if (settings.ShowDialog(this) == DialogResult.OK)
            {
                VwOperator o = settings.Operator;

                mUsername_.Text = o.Username;
                mPassword_.Text = "";
                mPassword_.Focus();
            }
        }
        
		private void mDatasource__Click(object sender, EventArgs e)
		{
			Parent.Controls.Clear();
			Parent.Controls.Add(new DatasourcePanel(Parent));
		}

        #endregion
	}
}
