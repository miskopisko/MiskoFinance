﻿using System;
using System.Windows.Forms;
using MiskoFinance.Forms;
using MiskoFinance.Properties;
using MiskoPersist.Enums;

namespace MiskoFinance.Panels
{
    public partial class DatasourcePanel : UserControl
	{
		private new LoginDialog Parent 
		{
			get;
			set;
		}
		
		public DatasourcePanel(LoginDialog loginDialog)
		{
			Parent = loginDialog;
			
			InitializeComponent();
			
			Parent.Text = "Datasource";
			
			mServerLocation_.DataSource = new ServerLocation[] {ServerLocation.Online, ServerLocation.Local};
			mServerLocation_.SelectedValueChanged += mServerLocation_SelectedValueChanged;
		}
		
		#region Override Methods
		
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			
			mServerLocation_.SelectedItem = ServerLocation.GetElement(Settings.Default.ServerLocation);
			mHostname_.Text = Settings.Default.Hostname;
			mPort_.Value = Settings.Default.Port;
			mScript_.Text = Settings.Default.Script;
			mUseSSL_.Checked = Settings.Default.UseSSL;
			mLocalDatabase_.Text = Settings.Default.LocalDatabase;
			
			Parent.AcceptButton = mSave_;
		}
		
		private void mSave__Click(Object sender, EventArgs e)
		{
			Settings.Default.ServerLocation = ((ServerLocation)mServerLocation_.SelectedItem).ToString();
			Settings.Default.Hostname = mHostname_.Text.Trim();
			Settings.Default.Port = (short)mPort_.Value;
			Settings.Default.Script = mScript_.Text.Trim();
			Settings.Default.UseSSL = mUseSSL_.Checked;			
			Settings.Default.LocalDatabase = mLocalDatabase_.Text.Trim();
			Settings.Default.Save();
			
			Parent.Controls.Clear();
			Parent.Controls.Add(new LoginPanel(Parent));
		}		
		
		#endregion

		private void mServerLocation_SelectedValueChanged(Object sender, EventArgs e)
		{
			mHostname_.Enabled = ((ServerLocation)mServerLocation_.SelectedItem).Equals(ServerLocation.Online);
			mPort_.Enabled = ((ServerLocation)mServerLocation_.SelectedItem).Equals(ServerLocation.Online);
			mScript_.Enabled = ((ServerLocation)mServerLocation_.SelectedItem).Equals(ServerLocation.Online);
			mUseSSL_.Enabled = ((ServerLocation)mServerLocation_.SelectedItem).Equals(ServerLocation.Online);
			
			mLocalDatabase_.Enabled = ((ServerLocation)mServerLocation_.SelectedItem).Equals(ServerLocation.Local);
			mFileChooser_.Enabled = ((ServerLocation)mServerLocation_.SelectedItem).Equals(ServerLocation.Local);
		}
		
		private void mFileChooser__Click(Object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.ShowDialog();
			
			mLocalDatabase_.Text = openFileDialog.FileName;
		}
		
		private void mCancel__Click(Object sender, EventArgs e)
		{
			Parent.Controls.Clear();
			Parent.Controls.Add(new LoginPanel(Parent));
		}
	}
}
