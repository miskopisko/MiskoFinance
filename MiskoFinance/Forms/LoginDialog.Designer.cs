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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mLogin_ = new System.Windows.Forms.Button();
            this.mCancel_ = new System.Windows.Forms.Button();
            this.mNewUser_ = new System.Windows.Forms.Button();
            this.mDatasourceLbl_ = new System.Windows.Forms.Label();
            this.mDatasource_ = new System.Windows.Forms.ComboBox();
            this.mTableLayoutPanel_.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
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
            this.label2.Location = new System.Drawing.Point(3, 44);
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
            this.mTableLayoutPanel_.Controls.Add(this.tableLayoutPanel1, 0, 3);
            this.mTableLayoutPanel_.Controls.Add(this.label1, 0, 0);
            this.mTableLayoutPanel_.Controls.Add(this.label2, 0, 1);
            this.mTableLayoutPanel_.Controls.Add(this.mDatasourceLbl_, 0, 2);
            this.mTableLayoutPanel_.Controls.Add(this.mDatasource_, 1, 2);
            this.mTableLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTableLayoutPanel_.Location = new System.Drawing.Point(0, 0);
            this.mTableLayoutPanel_.Name = "mTableLayoutPanel_";
            this.mTableLayoutPanel_.RowCount = 4;
            this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.mTableLayoutPanel_.Size = new System.Drawing.Size(284, 138);
            this.mTableLayoutPanel_.TabIndex = 0;
            // 
            // mUsername_
            // 
            this.mUsername_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mUsername_.Location = new System.Drawing.Point(88, 7);
            this.mUsername_.Name = "mUsername_";
            this.mUsername_.Size = new System.Drawing.Size(193, 20);
            this.mUsername_.TabIndex = 0;
            // 
            // mPassword_
            // 
            this.mPassword_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mPassword_.Location = new System.Drawing.Point(88, 41);
            this.mPassword_.Name = "mPassword_";
            this.mPassword_.PasswordChar = '*';
            this.mPassword_.Size = new System.Drawing.Size(193, 20);
            this.mPassword_.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.mTableLayoutPanel_.SetColumnSpan(this.tableLayoutPanel1, 2);
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.mLogin_, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mCancel_, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.mNewUser_, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 105);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(278, 30);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // mLogin_
            // 
            this.mLogin_.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mLogin_.Location = new System.Drawing.Point(8, 3);
            this.mLogin_.Name = "mLogin_";
            this.mLogin_.Size = new System.Drawing.Size(75, 23);
            this.mLogin_.TabIndex = 0;
            this.mLogin_.Text = "Login";
            this.mLogin_.UseVisualStyleBackColor = true;
            this.mLogin_.Click += new System.EventHandler(this.mLogin__Click);
            // 
            // mCancel_
            // 
            this.mCancel_.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mCancel_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.mCancel_.Location = new System.Drawing.Point(100, 3);
            this.mCancel_.Name = "mCancel_";
            this.mCancel_.Size = new System.Drawing.Size(75, 23);
            this.mCancel_.TabIndex = 1;
            this.mCancel_.Text = "Cancel";
            this.mCancel_.UseVisualStyleBackColor = true;
            this.mCancel_.Click += new System.EventHandler(this.mCancel__Click);
            // 
            // mNewUser_
            // 
            this.mNewUser_.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mNewUser_.Location = new System.Drawing.Point(193, 3);
            this.mNewUser_.Name = "mNewUser_";
            this.mNewUser_.Size = new System.Drawing.Size(75, 23);
            this.mNewUser_.TabIndex = 2;
            this.mNewUser_.Text = "New user";
            this.mNewUser_.UseVisualStyleBackColor = true;
            this.mNewUser_.Click += new System.EventHandler(this.mNewUser__Click);
            // 
            // mDatasourceLbl_
            // 
            this.mDatasourceLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mDatasourceLbl_.AutoSize = true;
            this.mDatasourceLbl_.Location = new System.Drawing.Point(3, 78);
            this.mDatasourceLbl_.Name = "mDatasourceLbl_";
            this.mDatasourceLbl_.Size = new System.Drawing.Size(79, 13);
            this.mDatasourceLbl_.TabIndex = 5;
            this.mDatasourceLbl_.Text = "Datasource:";
            this.mDatasourceLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mDatasource_
            // 
            this.mDatasource_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mDatasource_.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mDatasource_.FormattingEnabled = true;
            this.mDatasource_.Location = new System.Drawing.Point(88, 74);
            this.mDatasource_.Name = "mDatasource_";
            this.mDatasource_.Size = new System.Drawing.Size(193, 21);
            this.mDatasource_.TabIndex = 6;
            // 
            // LoginDialog
            // 
            this.AcceptButton = this.mLogin_;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.mCancel_;
            this.ClientSize = new System.Drawing.Size(284, 138);
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
        private System.Windows.Forms.Label mDatasourceLbl_;
        private System.Windows.Forms.ComboBox mDatasource_;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}