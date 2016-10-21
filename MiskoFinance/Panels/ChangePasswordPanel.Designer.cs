
namespace MiskoFinance.Panels
{
	partial class ChangePasswordPanel
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TableLayoutPanel mTableLayoutPanel_;
		private System.Windows.Forms.FlowLayoutPanel mFlowLayoutPanel_;
		private System.Windows.Forms.Button mCancel_;
		private System.Windows.Forms.Button mOKBtn_;
		private System.Windows.Forms.Label mOldPasswordLbl_;
		private System.Windows.Forms.Label mNewPasswordLbl_;
		private System.Windows.Forms.Label mrepeatPasswordLbl_;
		private System.Windows.Forms.TextBox mCurrentPassword_;
		private System.Windows.Forms.TextBox mNewPassword_;
		private System.Windows.Forms.TextBox mConfirmPassword_;
		
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
			this.mFlowLayoutPanel_ = new System.Windows.Forms.FlowLayoutPanel();
			this.mCancel_ = new System.Windows.Forms.Button();
			this.mOKBtn_ = new System.Windows.Forms.Button();
			this.mOldPasswordLbl_ = new System.Windows.Forms.Label();
			this.mNewPasswordLbl_ = new System.Windows.Forms.Label();
			this.mrepeatPasswordLbl_ = new System.Windows.Forms.Label();
			this.mCurrentPassword_ = new System.Windows.Forms.TextBox();
			this.mNewPassword_ = new System.Windows.Forms.TextBox();
			this.mConfirmPassword_ = new System.Windows.Forms.TextBox();
			this.mTableLayoutPanel_.SuspendLayout();
			this.mFlowLayoutPanel_.SuspendLayout();
			this.SuspendLayout();
			// 
			// mTableLayoutPanel_
			// 
			this.mTableLayoutPanel_.AutoSize = true;
			this.mTableLayoutPanel_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.mTableLayoutPanel_.ColumnCount = 2;
			this.mTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mTableLayoutPanel_.Controls.Add(this.mFlowLayoutPanel_, 0, 3);
			this.mTableLayoutPanel_.Controls.Add(this.mOldPasswordLbl_, 0, 0);
			this.mTableLayoutPanel_.Controls.Add(this.mNewPasswordLbl_, 0, 1);
			this.mTableLayoutPanel_.Controls.Add(this.mrepeatPasswordLbl_, 0, 2);
			this.mTableLayoutPanel_.Controls.Add(this.mCurrentPassword_, 1, 0);
			this.mTableLayoutPanel_.Controls.Add(this.mNewPassword_, 1, 1);
			this.mTableLayoutPanel_.Controls.Add(this.mConfirmPassword_, 1, 2);
			this.mTableLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mTableLayoutPanel_.Location = new System.Drawing.Point(0, 0);
			this.mTableLayoutPanel_.Name = "mTableLayoutPanel_";
			this.mTableLayoutPanel_.RowCount = 4;
			this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mTableLayoutPanel_.Size = new System.Drawing.Size(253, 113);
			this.mTableLayoutPanel_.TabIndex = 0;
			// 
			// mFlowLayoutPanel_
			// 
			this.mFlowLayoutPanel_.AutoSize = true;
			this.mFlowLayoutPanel_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.mTableLayoutPanel_.SetColumnSpan(this.mFlowLayoutPanel_, 2);
			this.mFlowLayoutPanel_.Controls.Add(this.mCancel_);
			this.mFlowLayoutPanel_.Controls.Add(this.mOKBtn_);
			this.mFlowLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mFlowLayoutPanel_.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.mFlowLayoutPanel_.Location = new System.Drawing.Point(3, 81);
			this.mFlowLayoutPanel_.Name = "mFlowLayoutPanel_";
			this.mFlowLayoutPanel_.Size = new System.Drawing.Size(247, 29);
			this.mFlowLayoutPanel_.TabIndex = 1;
			// 
			// mCancel_
			// 
			this.mCancel_.Location = new System.Drawing.Point(169, 3);
			this.mCancel_.Name = "mCancel_";
			this.mCancel_.Size = new System.Drawing.Size(75, 23);
			this.mCancel_.TabIndex = 1;
			this.mCancel_.Text = "Cancel";
			this.mCancel_.UseVisualStyleBackColor = true;
			this.mCancel_.Click += new System.EventHandler(this.mCancel__Click);
			// 
			// mOKBtn_
			// 
			this.mOKBtn_.Location = new System.Drawing.Point(88, 3);
			this.mOKBtn_.Name = "mOKBtn_";
			this.mOKBtn_.Size = new System.Drawing.Size(75, 23);
			this.mOKBtn_.TabIndex = 0;
			this.mOKBtn_.Text = "OK";
			this.mOKBtn_.UseVisualStyleBackColor = true;
			this.mOKBtn_.Click += new System.EventHandler(this.mOKBtn__Click);
			// 
			// mOldPasswordLbl_
			// 
			this.mOldPasswordLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mOldPasswordLbl_.AutoSize = true;
			this.mOldPasswordLbl_.Location = new System.Drawing.Point(3, 6);
			this.mOldPasswordLbl_.Name = "mOldPasswordLbl_";
			this.mOldPasswordLbl_.Size = new System.Drawing.Size(91, 13);
			this.mOldPasswordLbl_.TabIndex = 0;
			this.mOldPasswordLbl_.Text = "Old Password";
			// 
			// mNewPasswordLbl_
			// 
			this.mNewPasswordLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mNewPasswordLbl_.AutoSize = true;
			this.mNewPasswordLbl_.Location = new System.Drawing.Point(3, 32);
			this.mNewPasswordLbl_.Name = "mNewPasswordLbl_";
			this.mNewPasswordLbl_.Size = new System.Drawing.Size(91, 13);
			this.mNewPasswordLbl_.TabIndex = 1;
			this.mNewPasswordLbl_.Text = "New Password";
			// 
			// mrepeatPasswordLbl_
			// 
			this.mrepeatPasswordLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mrepeatPasswordLbl_.AutoSize = true;
			this.mrepeatPasswordLbl_.Location = new System.Drawing.Point(3, 58);
			this.mrepeatPasswordLbl_.Name = "mrepeatPasswordLbl_";
			this.mrepeatPasswordLbl_.Size = new System.Drawing.Size(91, 13);
			this.mrepeatPasswordLbl_.TabIndex = 2;
			this.mrepeatPasswordLbl_.Text = "Confirm Password";
			// 
			// mCurrentPassword_
			// 
			this.mCurrentPassword_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mCurrentPassword_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mCurrentPassword_.Location = new System.Drawing.Point(100, 3);
			this.mCurrentPassword_.Name = "mCurrentPassword_";
			this.mCurrentPassword_.PasswordChar = '*';
			this.mCurrentPassword_.Size = new System.Drawing.Size(150, 20);
			this.mCurrentPassword_.TabIndex = 3;
			// 
			// mNewPassword_
			// 
			this.mNewPassword_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mNewPassword_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mNewPassword_.Location = new System.Drawing.Point(100, 29);
			this.mNewPassword_.Name = "mNewPassword_";
			this.mNewPassword_.PasswordChar = '*';
			this.mNewPassword_.Size = new System.Drawing.Size(150, 20);
			this.mNewPassword_.TabIndex = 4;
			// 
			// mConfirmPassword_
			// 
			this.mConfirmPassword_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mConfirmPassword_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mConfirmPassword_.Location = new System.Drawing.Point(100, 55);
			this.mConfirmPassword_.Name = "mConfirmPassword_";
			this.mConfirmPassword_.PasswordChar = '*';
			this.mConfirmPassword_.Size = new System.Drawing.Size(150, 20);
			this.mConfirmPassword_.TabIndex = 5;
			// 
			// ChangePasswordPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.mTableLayoutPanel_);
			this.Name = "ChangePasswordPanel";
			this.Size = new System.Drawing.Size(253, 113);
			this.mTableLayoutPanel_.ResumeLayout(false);
			this.mTableLayoutPanel_.PerformLayout();
			this.mFlowLayoutPanel_.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
