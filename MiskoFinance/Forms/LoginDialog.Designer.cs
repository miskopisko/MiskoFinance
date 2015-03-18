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
        	this.label1 = new System.Windows.Forms.Label();
        	this.label2 = new System.Windows.Forms.Label();
        	this.mTableLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
        	this.mUsername_ = new System.Windows.Forms.TextBox();
        	this.mPassword_ = new System.Windows.Forms.TextBox();
        	this.mNewUser_ = new System.Windows.Forms.Button();
        	this.mCancel_ = new System.Windows.Forms.Button();
        	this.mLogin_ = new System.Windows.Forms.Button();
        	this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        	this.mTableLayoutPanel_.SuspendLayout();
        	this.tableLayoutPanel1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// label1
        	// 
        	this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(3, 6);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(79, 13);
        	this.label1.TabIndex = 3;
        	this.label1.Text = "Username:";
        	this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// label2
        	// 
        	this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(3, 32);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(79, 13);
        	this.label2.TabIndex = 4;
        	this.label2.Text = "Password:";
        	this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// mTableLayoutPanel_
        	// 
        	this.mTableLayoutPanel_.ColumnCount = 2;
        	this.mTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
        	this.mTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
        	this.mTableLayoutPanel_.Controls.Add(this.mUsername_, 1, 0);
        	this.mTableLayoutPanel_.Controls.Add(this.mPassword_, 1, 1);
        	this.mTableLayoutPanel_.Controls.Add(this.tableLayoutPanel1, 0, 2);
        	this.mTableLayoutPanel_.Controls.Add(this.label1, 0, 0);
        	this.mTableLayoutPanel_.Controls.Add(this.label2, 0, 1);
        	this.mTableLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mTableLayoutPanel_.Location = new System.Drawing.Point(0, 0);
        	this.mTableLayoutPanel_.Name = "mTableLayoutPanel_";
        	this.mTableLayoutPanel_.RowCount = 3;
        	this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        	this.mTableLayoutPanel_.Size = new System.Drawing.Size(284, 90);
        	this.mTableLayoutPanel_.TabIndex = 0;
        	// 
        	// mUsername_
        	// 
        	this.mUsername_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mUsername_.Location = new System.Drawing.Point(88, 3);
        	this.mUsername_.Name = "mUsername_";
        	this.mUsername_.Size = new System.Drawing.Size(193, 20);
        	this.mUsername_.TabIndex = 0;
        	// 
        	// mPassword_
        	// 
        	this.mPassword_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mPassword_.Location = new System.Drawing.Point(88, 29);
        	this.mPassword_.Name = "mPassword_";
        	this.mPassword_.PasswordChar = '*';
        	this.mPassword_.Size = new System.Drawing.Size(193, 20);
        	this.mPassword_.TabIndex = 1;
        	// 
        	// mNewUser_
        	// 
        	this.mNewUser_.Anchor = System.Windows.Forms.AnchorStyles.None;
        	this.mNewUser_.AutoSize = true;
        	this.mNewUser_.Location = new System.Drawing.Point(193, 4);
        	this.mNewUser_.Name = "mNewUser_";
        	this.mNewUser_.Size = new System.Drawing.Size(75, 23);
        	this.mNewUser_.TabIndex = 2;
        	this.mNewUser_.Text = "New user";
        	this.mNewUser_.UseVisualStyleBackColor = true;
        	this.mNewUser_.Click += new System.EventHandler(this.mNewUser__Click);
        	// 
        	// mCancel_
        	// 
        	this.mCancel_.Anchor = System.Windows.Forms.AnchorStyles.None;
        	this.mCancel_.AutoSize = true;
        	this.mCancel_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.mCancel_.Location = new System.Drawing.Point(100, 4);
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
        	this.mLogin_.AutoSize = true;
        	this.mLogin_.Location = new System.Drawing.Point(8, 4);
        	this.mLogin_.Name = "mLogin_";
        	this.mLogin_.Size = new System.Drawing.Size(75, 23);
        	this.mLogin_.TabIndex = 0;
        	this.mLogin_.Text = "Login";
        	this.mLogin_.UseVisualStyleBackColor = true;
        	this.mLogin_.Click += new System.EventHandler(this.mLogin__Click);
        	// 
        	// tableLayoutPanel1
        	// 
        	this.tableLayoutPanel1.AutoSize = true;
        	this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.tableLayoutPanel1.ColumnCount = 3;
        	this.mTableLayoutPanel_.SetColumnSpan(this.tableLayoutPanel1, 2);
        	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
        	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
        	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
        	this.tableLayoutPanel1.Controls.Add(this.mLogin_, 0, 0);
        	this.tableLayoutPanel1.Controls.Add(this.mCancel_, 1, 0);
        	this.tableLayoutPanel1.Controls.Add(this.mNewUser_, 2, 0);
        	this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 55);
        	this.tableLayoutPanel1.Name = "tableLayoutPanel1";
        	this.tableLayoutPanel1.RowCount = 1;
        	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        	this.tableLayoutPanel1.Size = new System.Drawing.Size(278, 32);
        	this.tableLayoutPanel1.TabIndex = 2;
        	// 
        	// LoginDialog
        	// 
        	this.AcceptButton = this.mLogin_;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.CancelButton = this.mCancel_;
        	this.ClientSize = new System.Drawing.Size(284, 90);
        	this.Controls.Add(this.mTableLayoutPanel_);
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
        	this.tableLayoutPanel1.ResumeLayout(false);
        	this.tableLayoutPanel1.PerformLayout();
        	this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mTableLayoutPanel_;
        private System.Windows.Forms.TextBox mUsername_;
        private System.Windows.Forms.TextBox mPassword_;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button mLogin_;
        private System.Windows.Forms.Button mCancel_;
        private System.Windows.Forms.Button mNewUser_;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}