using System;
using System.Windows.Forms;
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

        #region Private Methods

        private void LoginSuccess(ResponseMessage response)
        {
        	MiskoFinanceMain.Instance.Operator = ((LoginRS)response).Operator;
        	Settings.Default.DefaultUsername = MiskoFinanceMain.Instance.Operator.Username;
        	Settings.Default.Save();
            DialogResult = DialogResult.OK;
        }
        
        private void LoginError(ResponseMessage response)
        {
        	mNewUser_.Enabled = true;
        	mCancel_.Enabled = true;
        	mLogin_.Enabled = true;
        }

        #endregion

        #region Event Listenners

        private void mLogin__Click(object sender, EventArgs e)
        {
        	mNewUser_.Enabled = false;
        	mCancel_.Enabled = false;
        	mLogin_.Enabled = false;
        	
            LoginRQ request = new LoginRQ();
            request.Username = mUsername_.Text.Trim();
            request.Password = Utils.GenerateHash(mPassword_.Text.Trim());
            ServerConnection.SendRequest(request, LoginSuccess, LoginError);
        }

        private void mCancel__Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
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

        #endregion
    }
}
