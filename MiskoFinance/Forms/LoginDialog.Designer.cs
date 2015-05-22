namespace MiskoFinance.Forms
{
    partial class LoginDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginDialog));
        	this.mUsernameLbl_ = new System.Windows.Forms.Label();
        	this.mPasswordlbl_ = new System.Windows.Forms.Label();
        	this.mTableLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
        	this.mUsername_ = new System.Windows.Forms.TextBox();
        	this.mPassword_ = new System.Windows.Forms.TextBox();
        	this.mButtonLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
        	this.mCancel_ = new System.Windows.Forms.Button();
        	this.mLogin_ = new System.Windows.Forms.Button();
        	this.mNewUser_ = new System.Windows.Forms.Button();
        	this.mTableLayoutPanel_.SuspendLayout();
        	this.mButtonLayoutPanel_.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// mUsernameLbl_
        	// 
        	this.mUsernameLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mUsernameLbl_.AutoSize = true;
        	this.mUsernameLbl_.Location = new System.Drawing.Point(3, 13);
        	this.mUsernameLbl_.Name = "mUsernameLbl_";
        	this.mUsernameLbl_.Size = new System.Drawing.Size(66, 13);
        	this.mUsernameLbl_.TabIndex = 3;
        	this.mUsernameLbl_.Text = "Username:";
        	this.mUsernameLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// mPasswordlbl_
        	// 
        	this.mPasswordlbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mPasswordlbl_.AutoSize = true;
        	this.mPasswordlbl_.Location = new System.Drawing.Point(3, 52);
        	this.mPasswordlbl_.Name = "mPasswordlbl_";
        	this.mPasswordlbl_.Size = new System.Drawing.Size(66, 13);
        	this.mPasswordlbl_.TabIndex = 4;
        	this.mPasswordlbl_.Text = "Password:";
        	this.mPasswordlbl_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// mTableLayoutPanel_
        	// 
        	this.mTableLayoutPanel_.ColumnCount = 2;
        	this.mTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
        	this.mTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
        	this.mTableLayoutPanel_.Controls.Add(this.mUsername_, 1, 0);
        	this.mTableLayoutPanel_.Controls.Add(this.mPassword_, 1, 1);
        	this.mTableLayoutPanel_.Controls.Add(this.mUsernameLbl_, 0, 0);
        	this.mTableLayoutPanel_.Controls.Add(this.mPasswordlbl_, 0, 1);
        	this.mTableLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mTableLayoutPanel_.Location = new System.Drawing.Point(0, 0);
        	this.mTableLayoutPanel_.Name = "mTableLayoutPanel_";
        	this.mTableLayoutPanel_.RowCount = 2;
        	this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        	this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        	this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        	this.mTableLayoutPanel_.Size = new System.Drawing.Size(242, 79);
        	this.mTableLayoutPanel_.TabIndex = 0;
        	// 
        	// mUsername_
        	// 
        	this.mUsername_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mUsername_.Location = new System.Drawing.Point(75, 9);
        	this.mUsername_.Name = "mUsername_";
        	this.mUsername_.Size = new System.Drawing.Size(164, 20);
        	this.mUsername_.TabIndex = 0;
        	// 
        	// mPassword_
        	// 
        	this.mPassword_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mPassword_.Location = new System.Drawing.Point(75, 49);
        	this.mPassword_.Name = "mPassword_";
        	this.mPassword_.PasswordChar = '*';
        	this.mPassword_.Size = new System.Drawing.Size(164, 20);
        	this.mPassword_.TabIndex = 1;
        	// 
        	// mButtonLayoutPanel_
        	// 
        	this.mButtonLayoutPanel_.AutoSize = true;
        	this.mButtonLayoutPanel_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.mButtonLayoutPanel_.ColumnCount = 3;
        	this.mButtonLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        	this.mButtonLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        	this.mButtonLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        	this.mButtonLayoutPanel_.Controls.Add(this.mCancel_, 1, 0);
        	this.mButtonLayoutPanel_.Controls.Add(this.mLogin_, 2, 0);
        	this.mButtonLayoutPanel_.Controls.Add(this.mNewUser_, 0, 0);
        	this.mButtonLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.mButtonLayoutPanel_.Location = new System.Drawing.Point(0, 79);
        	this.mButtonLayoutPanel_.Name = "mButtonLayoutPanel_";
        	this.mButtonLayoutPanel_.RowCount = 1;
        	this.mButtonLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mButtonLayoutPanel_.Size = new System.Drawing.Size(242, 29);
        	this.mButtonLayoutPanel_.TabIndex = 2;
        	// 
        	// mCancel_
        	// 
        	this.mCancel_.Anchor = System.Windows.Forms.AnchorStyles.None;
        	this.mCancel_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.mCancel_.Location = new System.Drawing.Point(83, 3);
        	this.mCancel_.Name = "mCancel_";
        	this.mCancel_.Size = new System.Drawing.Size(75, 23);
        	this.mCancel_.TabIndex = 1;
        	this.mCancel_.Text = "Cancel";
        	this.mCancel_.UseVisualStyleBackColor = true;
        	this.mCancel_.Click += new System.EventHandler(this.mCancel__Click);
        	// 
        	// mLogin_
        	// 
        	this.mLogin_.Anchor = System.Windows.Forms.AnchorStyles.None;
        	this.mLogin_.Location = new System.Drawing.Point(164, 3);
        	this.mLogin_.Name = "mLogin_";
        	this.mLogin_.Size = new System.Drawing.Size(75, 23);
        	this.mLogin_.TabIndex = 0;
        	this.mLogin_.Text = "Login";
        	this.mLogin_.UseVisualStyleBackColor = true;
        	this.mLogin_.Click += new System.EventHandler(this.mLogin__Click);
        	// 
        	// mNewUser_
        	// 
        	this.mNewUser_.Anchor = System.Windows.Forms.AnchorStyles.Right;
        	this.mNewUser_.Location = new System.Drawing.Point(3, 3);
        	this.mNewUser_.Name = "mNewUser_";
        	this.mNewUser_.Size = new System.Drawing.Size(74, 23);
        	this.mNewUser_.TabIndex = 2;
        	this.mNewUser_.Text = "New User";
        	this.mNewUser_.UseVisualStyleBackColor = true;
        	this.mNewUser_.Click += new System.EventHandler(this.mNewUser__Click);
        	// 
        	// LoginDialog
        	// 
        	this.AcceptButton = this.mLogin_;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.CancelButton = this.mCancel_;
        	this.ClientSize = new System.Drawing.Size(242, 108);
        	this.Controls.Add(this.mTableLayoutPanel_);
        	this.Controls.Add(this.mButtonLayoutPanel_);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "LoginDialog";
        	this.ShowInTaskbar = false;
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Login";
        	this.mTableLayoutPanel_.ResumeLayout(false);
        	this.mTableLayoutPanel_.PerformLayout();
        	this.mButtonLayoutPanel_.ResumeLayout(false);
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mTableLayoutPanel_;
        private System.Windows.Forms.TextBox mUsername_;
        private System.Windows.Forms.TextBox mPassword_;
        private System.Windows.Forms.TableLayoutPanel mButtonLayoutPanel_;
        private System.Windows.Forms.Button mLogin_;
        private System.Windows.Forms.Button mCancel_;
        private System.Windows.Forms.Button mNewUser_;
        private System.Windows.Forms.Label mUsernameLbl_;
        private System.Windows.Forms.Label mPasswordlbl_;
    }
}