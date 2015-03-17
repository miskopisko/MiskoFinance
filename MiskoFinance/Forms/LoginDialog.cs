using System;
using System.Windows.Forms;
using MiskoPersist.Core;
using MiskoPersist.Enums;
using MiskoPersist.Message.Response;
using MiskoPersist.Tools;
using MiskoFinance.Properties;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;

namespace MiskoFinance.Forms
{
    public partial class LoginDialog : Form
    {
        private static Logger Log = Logger.GetInstance(typeof(LoginDialog));

        public LoginDialog()
        {
            InitializeComponent();

            mDatasource_.DataSource = new ConnectionType[] { ConnectionType.NULL, ConnectionType.SQLite, ConnectionType.MySql, ConnectionType.Oracle };
        }

        #region Override Methods

        protected override void OnLoad(EventArgs e)
        {
            if (!String.IsNullOrEmpty(Settings.Default.DefaultUsername.Trim()))
            {
                mUsername_.Text = Settings.Default.DefaultUsername.Trim();
                mPassword_.Text = "";
                mPassword_.Select();

                mDatasource_.SelectedItem = ConnectionType.GetElement(Settings.Default.DefaultDatasource);
            }

            #if (DEBUG)
                mPassword_.Text = "secret";
                //AcceptButton.PerformClick();
            #endif
        }

        #endregion

        #region Private Methods

        private void LoginSuccess(ResponseMessage response)
        {
            //MiskoFinanceMain.Operator = ((LoginRS)response).Operator;
            DialogResult = DialogResult.OK;
            Dispose();
        }

        #endregion

        #region Event Listenners

        private void mLogin__Click(object sender, EventArgs e)
        {
            LoginRQ request = new LoginRQ();
            request.Username = mUsername_.Text.Trim();
            request.Password = Utils.GenerateHash(mPassword_.Text.Trim());
            MessageProcessor.SendRequest(request, LoginSuccess);
        }

        private void mCancel__Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Dispose();
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
