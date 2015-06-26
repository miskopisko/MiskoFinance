/*
 * Created by SharpDevelop.
 * User: mpiskuric
 * Date: 26/06/2015
 * Time: 2:11 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MiskoFinance.Panels
{
	partial class DatasourcePanel
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TableLayoutPanel mTableLayoutPanel_;
		private System.Windows.Forms.ComboBox mServerLocation_;
		private System.Windows.Forms.TextBox mHostname_;
		private System.Windows.Forms.TextBox mScript_;
		private System.Windows.Forms.TextBox mLocalDatabase_;
		private System.Windows.Forms.Button mFileChooser_;
		private System.Windows.Forms.Label mServerLocationLbl_;
		private System.Windows.Forms.Label mHostnameLbl_;
		private System.Windows.Forms.Label mPortLbl_;
		private System.Windows.Forms.Label mScriptLbl_;
		private System.Windows.Forms.Label mUseSSLLbl_;
		private System.Windows.Forms.Label mLocalDatabaselbl_;
		private System.Windows.Forms.CheckBox mUseSSL_;
		private System.Windows.Forms.NumericUpDown mPort_;
		private System.Windows.Forms.Button mSave_;
		private System.Windows.Forms.FlowLayoutPanel mFlowLayoutPanel_;
		private System.Windows.Forms.Button mCancel_;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.mTableLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
			this.mServerLocation_ = new System.Windows.Forms.ComboBox();
			this.mHostname_ = new System.Windows.Forms.TextBox();
			this.mScript_ = new System.Windows.Forms.TextBox();
			this.mLocalDatabase_ = new System.Windows.Forms.TextBox();
			this.mFileChooser_ = new System.Windows.Forms.Button();
			this.mServerLocationLbl_ = new System.Windows.Forms.Label();
			this.mHostnameLbl_ = new System.Windows.Forms.Label();
			this.mPortLbl_ = new System.Windows.Forms.Label();
			this.mScriptLbl_ = new System.Windows.Forms.Label();
			this.mUseSSLLbl_ = new System.Windows.Forms.Label();
			this.mLocalDatabaselbl_ = new System.Windows.Forms.Label();
			this.mUseSSL_ = new System.Windows.Forms.CheckBox();
			this.mPort_ = new System.Windows.Forms.NumericUpDown();
			this.mSave_ = new System.Windows.Forms.Button();
			this.mFlowLayoutPanel_ = new System.Windows.Forms.FlowLayoutPanel();
			this.mCancel_ = new System.Windows.Forms.Button();
			this.mTableLayoutPanel_.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mPort_)).BeginInit();
			this.mFlowLayoutPanel_.SuspendLayout();
			this.SuspendLayout();
			// 
			// mTableLayoutPanel_
			// 
			this.mTableLayoutPanel_.ColumnCount = 3;
			this.mTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
			this.mTableLayoutPanel_.Controls.Add(this.mServerLocation_, 1, 0);
			this.mTableLayoutPanel_.Controls.Add(this.mHostname_, 1, 1);
			this.mTableLayoutPanel_.Controls.Add(this.mScript_, 1, 3);
			this.mTableLayoutPanel_.Controls.Add(this.mLocalDatabase_, 1, 5);
			this.mTableLayoutPanel_.Controls.Add(this.mFileChooser_, 2, 5);
			this.mTableLayoutPanel_.Controls.Add(this.mServerLocationLbl_, 0, 0);
			this.mTableLayoutPanel_.Controls.Add(this.mHostnameLbl_, 0, 1);
			this.mTableLayoutPanel_.Controls.Add(this.mPortLbl_, 0, 2);
			this.mTableLayoutPanel_.Controls.Add(this.mScriptLbl_, 0, 3);
			this.mTableLayoutPanel_.Controls.Add(this.mUseSSLLbl_, 0, 4);
			this.mTableLayoutPanel_.Controls.Add(this.mLocalDatabaselbl_, 0, 5);
			this.mTableLayoutPanel_.Controls.Add(this.mUseSSL_, 1, 4);
			this.mTableLayoutPanel_.Controls.Add(this.mPort_, 1, 2);
			this.mTableLayoutPanel_.Controls.Add(this.mFlowLayoutPanel_, 1, 6);
			this.mTableLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mTableLayoutPanel_.Location = new System.Drawing.Point(0, 0);
			this.mTableLayoutPanel_.Name = "mTableLayoutPanel_";
			this.mTableLayoutPanel_.RowCount = 7;
			this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mTableLayoutPanel_.Size = new System.Drawing.Size(299, 186);
			this.mTableLayoutPanel_.TabIndex = 0;
			// 
			// mServerLocation_
			// 
			this.mServerLocation_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mServerLocation_.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.mServerLocation_.FormattingEnabled = true;
			this.mServerLocation_.Location = new System.Drawing.Point(91, 3);
			this.mServerLocation_.Name = "mServerLocation_";
			this.mServerLocation_.Size = new System.Drawing.Size(170, 21);
			this.mServerLocation_.TabIndex = 0;
			// 
			// mHostname_
			// 
			this.mHostname_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mHostname_.Enabled = false;
			this.mHostname_.Location = new System.Drawing.Point(91, 28);
			this.mHostname_.Name = "mHostname_";
			this.mHostname_.Size = new System.Drawing.Size(170, 20);
			this.mHostname_.TabIndex = 1;
			// 
			// mScript_
			// 
			this.mScript_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mScript_.Enabled = false;
			this.mScript_.Location = new System.Drawing.Point(91, 78);
			this.mScript_.Name = "mScript_";
			this.mScript_.Size = new System.Drawing.Size(170, 20);
			this.mScript_.TabIndex = 2;
			// 
			// mLocalDatabase_
			// 
			this.mLocalDatabase_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mLocalDatabase_.Enabled = false;
			this.mLocalDatabase_.Location = new System.Drawing.Point(91, 128);
			this.mLocalDatabase_.Name = "mLocalDatabase_";
			this.mLocalDatabase_.Size = new System.Drawing.Size(170, 20);
			this.mLocalDatabase_.TabIndex = 5;
			// 
			// mFileChooser_
			// 
			this.mFileChooser_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mFileChooser_.Enabled = false;
			this.mFileChooser_.Location = new System.Drawing.Point(267, 128);
			this.mFileChooser_.Name = "mFileChooser_";
			this.mFileChooser_.Size = new System.Drawing.Size(29, 19);
			this.mFileChooser_.TabIndex = 6;
			this.mFileChooser_.Text = "...";
			this.mFileChooser_.UseVisualStyleBackColor = true;
			this.mFileChooser_.Click += new System.EventHandler(this.mFileChooser__Click);
			// 
			// mServerLocationLbl_
			// 
			this.mServerLocationLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mServerLocationLbl_.AutoSize = true;
			this.mServerLocationLbl_.Location = new System.Drawing.Point(3, 6);
			this.mServerLocationLbl_.Name = "mServerLocationLbl_";
			this.mServerLocationLbl_.Size = new System.Drawing.Size(82, 13);
			this.mServerLocationLbl_.TabIndex = 7;
			this.mServerLocationLbl_.Text = "Server Location";
			this.mServerLocationLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mHostnameLbl_
			// 
			this.mHostnameLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mHostnameLbl_.AutoSize = true;
			this.mHostnameLbl_.Location = new System.Drawing.Point(3, 31);
			this.mHostnameLbl_.Name = "mHostnameLbl_";
			this.mHostnameLbl_.Size = new System.Drawing.Size(82, 13);
			this.mHostnameLbl_.TabIndex = 8;
			this.mHostnameLbl_.Text = "Hostname";
			this.mHostnameLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mPortLbl_
			// 
			this.mPortLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mPortLbl_.AutoSize = true;
			this.mPortLbl_.Location = new System.Drawing.Point(3, 56);
			this.mPortLbl_.Name = "mPortLbl_";
			this.mPortLbl_.Size = new System.Drawing.Size(82, 13);
			this.mPortLbl_.TabIndex = 9;
			this.mPortLbl_.Text = "Port";
			this.mPortLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mScriptLbl_
			// 
			this.mScriptLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mScriptLbl_.AutoSize = true;
			this.mScriptLbl_.Location = new System.Drawing.Point(3, 81);
			this.mScriptLbl_.Name = "mScriptLbl_";
			this.mScriptLbl_.Size = new System.Drawing.Size(82, 13);
			this.mScriptLbl_.TabIndex = 10;
			this.mScriptLbl_.Text = "Script";
			this.mScriptLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mUseSSLLbl_
			// 
			this.mUseSSLLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mUseSSLLbl_.AutoSize = true;
			this.mUseSSLLbl_.Location = new System.Drawing.Point(3, 106);
			this.mUseSSLLbl_.Name = "mUseSSLLbl_";
			this.mUseSSLLbl_.Size = new System.Drawing.Size(82, 13);
			this.mUseSSLLbl_.TabIndex = 11;
			this.mUseSSLLbl_.Text = "Use SSL";
			this.mUseSSLLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mLocalDatabaselbl_
			// 
			this.mLocalDatabaselbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mLocalDatabaselbl_.AutoSize = true;
			this.mLocalDatabaselbl_.Location = new System.Drawing.Point(3, 131);
			this.mLocalDatabaselbl_.Name = "mLocalDatabaselbl_";
			this.mLocalDatabaselbl_.Size = new System.Drawing.Size(82, 13);
			this.mLocalDatabaselbl_.TabIndex = 12;
			this.mLocalDatabaselbl_.Text = "Local Database";
			this.mLocalDatabaselbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mUseSSL_
			// 
			this.mUseSSL_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mUseSSL_.Enabled = false;
			this.mUseSSL_.Location = new System.Drawing.Point(91, 103);
			this.mUseSSL_.Name = "mUseSSL_";
			this.mUseSSL_.Size = new System.Drawing.Size(170, 19);
			this.mUseSSL_.TabIndex = 13;
			this.mUseSSL_.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.mUseSSL_.UseVisualStyleBackColor = true;
			// 
			// mPort_
			// 
			this.mPort_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mPort_.Enabled = false;
			this.mPort_.Location = new System.Drawing.Point(91, 53);
			this.mPort_.Maximum = new decimal(new int[] {
			65535,
			0,
			0,
			0});
			this.mPort_.Name = "mPort_";
			this.mPort_.Size = new System.Drawing.Size(170, 20);
			this.mPort_.TabIndex = 14;
			this.mPort_.Value = new decimal(new int[] {
			80,
			0,
			0,
			0});
			// 
			// mSave_
			// 
			this.mSave_.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.mSave_.Location = new System.Drawing.Point(43, 3);
			this.mSave_.Name = "mSave_";
			this.mSave_.Size = new System.Drawing.Size(78, 23);
			this.mSave_.TabIndex = 15;
			this.mSave_.Text = "Save";
			this.mSave_.UseVisualStyleBackColor = true;
			this.mSave_.Click += new System.EventHandler(this.mSave__Click);
			// 
			// mFlowLayoutPanel_
			// 
			this.mFlowLayoutPanel_.AutoSize = true;
			this.mFlowLayoutPanel_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.mTableLayoutPanel_.SetColumnSpan(this.mFlowLayoutPanel_, 2);
			this.mFlowLayoutPanel_.Controls.Add(this.mCancel_);
			this.mFlowLayoutPanel_.Controls.Add(this.mSave_);
			this.mFlowLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mFlowLayoutPanel_.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.mFlowLayoutPanel_.Location = new System.Drawing.Point(91, 153);
			this.mFlowLayoutPanel_.Name = "mFlowLayoutPanel_";
			this.mFlowLayoutPanel_.Size = new System.Drawing.Size(205, 30);
			this.mFlowLayoutPanel_.TabIndex = 16;
			// 
			// mCancel_
			// 
			this.mCancel_.Location = new System.Drawing.Point(127, 3);
			this.mCancel_.Name = "mCancel_";
			this.mCancel_.Size = new System.Drawing.Size(75, 23);
			this.mCancel_.TabIndex = 16;
			this.mCancel_.Text = "Cancel";
			this.mCancel_.UseVisualStyleBackColor = true;
			this.mCancel_.Click += new System.EventHandler(this.mCancel__Click);
			// 
			// DatasourcePanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.mTableLayoutPanel_);
			this.Name = "DatasourcePanel";
			this.Size = new System.Drawing.Size(299, 186);
			this.mTableLayoutPanel_.ResumeLayout(false);
			this.mTableLayoutPanel_.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.mPort_)).EndInit();
			this.mFlowLayoutPanel_.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
