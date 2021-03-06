﻿using System;
using System.Windows.Forms;
using MiskoFinance.Forms;
using MiskoFinance.Properties;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Message.Requests;
using MiskoPersist.Core;
using MiskoPersist.Data.Viewed;
using MiskoPersist.Message.Responses;

namespace MiskoFinance.Panels
{
	public partial class LoginPanel : UserControl
	{
		#region Fields
		
		private readonly ToolStripDropDownMenu mMenu_ = new ToolStripDropDownMenu();
		private ToolStripMenuItem mDatasource_ = new ToolStripMenuItem();
		private ToolStripMenuItem mNewUser_ = new ToolStripMenuItem();

		#endregion

		#region Properties

		private new LoginDialog Parent 
		{
			get;
			set;
		}
		
		#endregion
		
		public LoginPanel(LoginDialog loginDialog)
		{
			Parent = loginDialog;
			
			InitializeComponent();
			
			Parent.Text = "Login";
			
			mUsername_.TextChanged += mUsername_TextChanged;

			mDatasource_.Text = "Datasource";
			mDatasource_.Click += mDatasource__Click;
			mMenu_.Items.Add(mDatasource_);
			
			mNewUser_.Text = "New User";
			mNewUser_.Click += mNewUser__Click;
			mMenu_.Items.Add(mNewUser_);			
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
			MiskoFinanceMain.Instance.LoginSuccess(response);
			
			Settings.Default.DefaultUsername = MiskoFinanceMain.Instance.Operator.Username;
			Settings.Default.Save();
			Parent.DialogResult = DialogResult.OK;
		}
		
		private void LoginError(ResponseMessage response)
		{
			Parent.Enabled = true;
			
			foreach (ErrorMessage errorMessage in response.Errors) 
			{
				if (errorMessage.Message.Equals("Password has expired."))
				{
					Parent.Controls.Clear();
					Parent.Controls.Add(new ChangePasswordPanel(Parent, mUsername_.Text.Trim()));
				}
			}
		}

		#endregion

		#region Event Listenners

		private void mLogin__Click(Object sender, EventArgs e)
		{        	
			Parent.Enabled = false;
			
			LogonRQ request = new LogonRQ();
			request.Username = mUsername_.Text.Trim();
			request.Password = mPassword_.Text.Trim();
			Server.SendRequest(request, LoginSuccess, LoginError);
		}

		private void mCancel__Click(Object sender, EventArgs e)
		{
			Parent.DialogResult = DialogResult.Cancel;
		}

		private void mUsername_TextChanged(Object sender, EventArgs e)
		{
			mPassword_.Text = "";
		}
		
		private void mNewUser__Click(Object sender, EventArgs e)
		{
			SettingsDialog settings = new SettingsDialog(new VwOperator());

			if(settings.ShowDialog(this) == DialogResult.OK)
			{
				mUsername_.Text = settings.Operator.Username;
				mPassword_.Text = "";
				mPassword_.Focus();
			}
		}
		
		private void mDatasource__Click(Object sender, EventArgs e)
		{
			Parent.Controls.Clear();
			Parent.Controls.Add(new DatasourcePanel(Parent));
		}
		
		private void mMore__Click(Object sender, EventArgs e)
		{
			mMenu_.Show(mMore_, 0, mMore_.Height);
		}

		#endregion
	}
}
