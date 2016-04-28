/*
 * Created by SharpDevelop.
 * User: mpiskuric
 * Date: 26/06/2015
 * Time: 1:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
namespace MiskoFinance.Panels
{
	partial class LoginPanel
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox mUsername_;
		private System.Windows.Forms.TextBox mPassword_;
		private System.Windows.Forms.Label mUsernameLbl_;
		private System.Windows.Forms.Label mPasswordlbl_;
		private System.Windows.Forms.TableLayoutPanel mButtonLayoutPanel_;
		private System.Windows.Forms.Button mLogin_;
		private System.Windows.Forms.Button mCancel_;
		private System.Windows.Forms.TableLayoutPanel mTableLayoutPanel_;
		private System.Windows.Forms.Button mMore_;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(Boolean disposing)
		{
			if(disposing) {
				if(components != null) {
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
			this.mUsername_ = new System.Windows.Forms.TextBox();
			this.mPassword_ = new System.Windows.Forms.TextBox();
			this.mUsernameLbl_ = new System.Windows.Forms.Label();
			this.mPasswordlbl_ = new System.Windows.Forms.Label();
			this.mButtonLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
			this.mLogin_ = new System.Windows.Forms.Button();
			this.mCancel_ = new System.Windows.Forms.Button();
			this.mMore_ = new System.Windows.Forms.Button();
			this.mTableLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
			this.mButtonLayoutPanel_.SuspendLayout();
			this.mTableLayoutPanel_.SuspendLayout();
			this.SuspendLayout();
			// 
			// mUsername_
			// 
			this.mUsername_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mUsername_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mUsername_.Location = new System.Drawing.Point(67, 3);
			this.mUsername_.Name = "mUsername_";
			this.mUsername_.Size = new System.Drawing.Size(179, 20);
			this.mUsername_.TabIndex = 0;
			// 
			// mPassword_
			// 
			this.mPassword_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mPassword_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mPassword_.Location = new System.Drawing.Point(67, 29);
			this.mPassword_.Name = "mPassword_";
			this.mPassword_.PasswordChar = '*';
			this.mPassword_.Size = new System.Drawing.Size(179, 20);
			this.mPassword_.TabIndex = 1;
			// 
			// mUsernameLbl_
			// 
			this.mUsernameLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mUsernameLbl_.AutoSize = true;
			this.mUsernameLbl_.Location = new System.Drawing.Point(3, 6);
			this.mUsernameLbl_.Name = "mUsernameLbl_";
			this.mUsernameLbl_.Size = new System.Drawing.Size(58, 13);
			this.mUsernameLbl_.TabIndex = 3;
			this.mUsernameLbl_.Text = "Username:";
			this.mUsernameLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mPasswordlbl_
			// 
			this.mPasswordlbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mPasswordlbl_.AutoSize = true;
			this.mPasswordlbl_.Location = new System.Drawing.Point(3, 32);
			this.mPasswordlbl_.Name = "mPasswordlbl_";
			this.mPasswordlbl_.Size = new System.Drawing.Size(58, 13);
			this.mPasswordlbl_.TabIndex = 4;
			this.mPasswordlbl_.Text = "Password:";
			this.mPasswordlbl_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mButtonLayoutPanel_
			// 
			this.mButtonLayoutPanel_.AutoSize = true;
			this.mButtonLayoutPanel_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.mButtonLayoutPanel_.ColumnCount = 3;
			this.mTableLayoutPanel_.SetColumnSpan(this.mButtonLayoutPanel_, 2);
			this.mButtonLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mButtonLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mButtonLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mButtonLayoutPanel_.Controls.Add(this.mLogin_, 0, 0);
			this.mButtonLayoutPanel_.Controls.Add(this.mCancel_, 1, 0);
			this.mButtonLayoutPanel_.Controls.Add(this.mMore_, 2, 0);
			this.mButtonLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Right;
			this.mButtonLayoutPanel_.Location = new System.Drawing.Point(3, 55);
			this.mButtonLayoutPanel_.Name = "mButtonLayoutPanel_";
			this.mButtonLayoutPanel_.RowCount = 1;
			this.mButtonLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mButtonLayoutPanel_.Size = new System.Drawing.Size(243, 29);
			this.mButtonLayoutPanel_.TabIndex = 3;
			// 
			// mLogin_
			// 
			this.mLogin_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mLogin_.Location = new System.Drawing.Point(3, 3);
			this.mLogin_.Name = "mLogin_";
			this.mLogin_.Size = new System.Drawing.Size(75, 23);
			this.mLogin_.TabIndex = 0;
			this.mLogin_.Text = "Login";
			this.mLogin_.UseVisualStyleBackColor = true;
			this.mLogin_.Click += new System.EventHandler(this.mLogin__Click);
			// 
			// mCancel_
			// 
			this.mCancel_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mCancel_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.mCancel_.Location = new System.Drawing.Point(84, 3);
			this.mCancel_.Name = "mCancel_";
			this.mCancel_.Size = new System.Drawing.Size(75, 23);
			this.mCancel_.TabIndex = 1;
			this.mCancel_.Text = "Cancel";
			this.mCancel_.UseVisualStyleBackColor = true;
			// 
			// mMore_
			// 
			this.mMore_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mMore_.Location = new System.Drawing.Point(165, 3);
			this.mMore_.Name = "mMore_";
			this.mMore_.Size = new System.Drawing.Size(75, 23);
			this.mMore_.TabIndex = 2;
			this.mMore_.Text = "More...";
			this.mMore_.UseVisualStyleBackColor = true;
			this.mMore_.Click += new System.EventHandler(this.mMore__Click);
			// 
			// mTableLayoutPanel_
			// 
			this.mTableLayoutPanel_.AutoSize = true;
			this.mTableLayoutPanel_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.mTableLayoutPanel_.ColumnCount = 2;
			this.mTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mTableLayoutPanel_.Controls.Add(this.mPassword_, 1, 1);
			this.mTableLayoutPanel_.Controls.Add(this.mButtonLayoutPanel_, 0, 2);
			this.mTableLayoutPanel_.Controls.Add(this.mUsername_, 1, 0);
			this.mTableLayoutPanel_.Controls.Add(this.mUsernameLbl_, 0, 0);
			this.mTableLayoutPanel_.Controls.Add(this.mPasswordlbl_, 0, 1);
			this.mTableLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mTableLayoutPanel_.Location = new System.Drawing.Point(0, 0);
			this.mTableLayoutPanel_.Name = "mTableLayoutPanel_";
			this.mTableLayoutPanel_.RowCount = 3;
			this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mTableLayoutPanel_.Size = new System.Drawing.Size(249, 87);
			this.mTableLayoutPanel_.TabIndex = 4;
			// 
			// LoginPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.mTableLayoutPanel_);
			this.Name = "LoginPanel";
			this.Size = new System.Drawing.Size(249, 87);
			this.mButtonLayoutPanel_.ResumeLayout(false);
			this.mTableLayoutPanel_.ResumeLayout(false);
			this.mTableLayoutPanel_.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
