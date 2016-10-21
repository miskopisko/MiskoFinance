using System;
using System.Windows.Forms;
using MiskoFinance.Forms;
using MiskoFinanceCore.Message.Requests;
using MiskoPersist.Core;
using MiskoPersist.Message.Responses;

namespace MiskoFinance.Panels
{
	public partial class ChangePasswordPanel : UserControl
	{
		private new LoginDialog Parent 
		{
			get;
			set;
		}
		
		private String mUsername_;
		
		public ChangePasswordPanel(LoginDialog loginDialog, String username)
		{
			Parent = loginDialog;
			mUsername_ = username;
			
			InitializeComponent();
			
			Parent.Text = "Change password";
		}
		
		private void mCancel__Click(object sender, EventArgs e)
		{
			Parent.Controls.Clear();
			Parent.Controls.Add(new LoginPanel(Parent));
		}
		
		private void mOKBtn__Click(object sender, EventArgs e)
		{
			Parent.Enabled = false;
			
			ChangePasswordRQ request = new ChangePasswordRQ();
			request.Username = mUsername_;
			request.OldPassword = mCurrentPassword_.Text.Trim();
			request.NewPassword = mNewPassword_.Text.Trim();
			request.ConfirmPassword = mConfirmPassword_.Text.Trim();
			Server.SendRequest(request, ChangePasswordSuccess, ChangePasswordError);
		}
		
		private void ChangePasswordSuccess(ResponseMessage response)
		{
			Parent.Enabled = true;
			Parent.Controls.Clear();
			Parent.Controls.Add(new LoginPanel(Parent));
		}
		
		private void ChangePasswordError(ResponseMessage response)
		{
			Parent.Enabled = true;
		}
	}
}
