namespace MPFinance.Forms
{
    partial class SettingsDialog
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label9;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDialog));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Done = new System.Windows.Forms.Button();
            this.SettingsTabs = new System.Windows.Forms.TabControl();
            this.UserTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.EnableCacheCheck = new System.Windows.Forms.CheckBox();
            this.RowsPerPageTxt = new System.Windows.Forms.TextBox();
            this.GenderCmb = new System.Windows.Forms.ComboBox();
            this.EmailTxt = new System.Windows.Forms.TextBox();
            this.LastNameTxt = new System.Windows.Forms.TextBox();
            this.FirstNameTxt = new System.Windows.Forms.TextBox();
            this.PasswordTxt = new System.Windows.Forms.TextBox();
            this.UsernameTxt = new System.Windows.Forms.TextBox();
            this.BirthdayPicker = new System.Windows.Forms.DateTimePicker();
            this.ConnectionTab = new System.Windows.Forms.TabPage();
            this.DataSourceTabs = new System.Windows.Forms.TabControl();
            this.MySqlTab = new System.Windows.Forms.TabPage();
            this.OracleTab = new System.Windows.Forms.TabPage();
            this.SqliteTab = new System.Windows.Forms.TabPage();
            this.PostgresTab = new System.Windows.Forms.TabPage();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SettingsTabs.SuspendLayout();
            this.UserTab.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.ConnectionTab.SuspendLayout();
            this.DataSourceTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = System.Windows.Forms.DockStyle.Right;
            label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            label1.Location = new System.Drawing.Point(35, 87);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(61, 29);
            label1.TabIndex = 0;
            label1.Text = "Last Name:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = System.Windows.Forms.DockStyle.Right;
            label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            label2.Location = new System.Drawing.Point(38, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(58, 29);
            label2.TabIndex = 1;
            label2.Text = "Username:";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = System.Windows.Forms.DockStyle.Right;
            label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            label3.Location = new System.Drawing.Point(40, 29);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(56, 29);
            label3.TabIndex = 2;
            label3.Text = "Password:";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = System.Windows.Forms.DockStyle.Right;
            label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            label4.Location = new System.Drawing.Point(61, 116);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(35, 29);
            label4.TabIndex = 3;
            label4.Text = "Email:";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = System.Windows.Forms.DockStyle.Right;
            label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            label5.Location = new System.Drawing.Point(36, 58);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(60, 29);
            label5.TabIndex = 4;
            label5.Text = "First Name:";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = System.Windows.Forms.DockStyle.Right;
            label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            label6.Location = new System.Drawing.Point(51, 145);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(45, 29);
            label6.TabIndex = 5;
            label6.Text = "Gender:";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = System.Windows.Forms.DockStyle.Right;
            label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            label7.Location = new System.Drawing.Point(48, 174);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(48, 29);
            label7.TabIndex = 6;
            label7.Text = "Birthday:";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = System.Windows.Forms.DockStyle.Right;
            label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            label8.Location = new System.Drawing.Point(12, 203);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(84, 29);
            label8.TabIndex = 7;
            label8.Text = "Rows Per Page:";
            label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = System.Windows.Forms.DockStyle.Right;
            label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            label9.Location = new System.Drawing.Point(19, 232);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(77, 30);
            label9.TabIndex = 8;
            label9.Text = "Enable Cache:";
            label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.Done, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.SettingsTabs, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(342, 335);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Done
            // 
            this.Done.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Done.Location = new System.Drawing.Point(133, 306);
            this.Done.Name = "Done";
            this.Done.Size = new System.Drawing.Size(75, 23);
            this.Done.TabIndex = 0;
            this.Done.Text = "Done";
            this.Done.UseVisualStyleBackColor = true;
            this.Done.Click += new System.EventHandler(this.Done_Click);
            // 
            // SettingsTabs
            // 
            this.SettingsTabs.Controls.Add(this.UserTab);
            this.SettingsTabs.Controls.Add(this.ConnectionTab);
            this.SettingsTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsTabs.Location = new System.Drawing.Point(3, 3);
            this.SettingsTabs.Name = "SettingsTabs";
            this.SettingsTabs.SelectedIndex = 0;
            this.SettingsTabs.Size = new System.Drawing.Size(336, 294);
            this.SettingsTabs.TabIndex = 1;
            // 
            // UserTab
            // 
            this.UserTab.Controls.Add(this.tableLayoutPanel2);
            this.UserTab.Location = new System.Drawing.Point(4, 22);
            this.UserTab.Name = "UserTab";
            this.UserTab.Padding = new System.Windows.Forms.Padding(3);
            this.UserTab.Size = new System.Drawing.Size(328, 268);
            this.UserTab.TabIndex = 0;
            this.UserTab.Text = "User";
            this.UserTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.93333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.06667F));
            this.tableLayoutPanel2.Controls.Add(label9, 0, 8);
            this.tableLayoutPanel2.Controls.Add(label8, 0, 7);
            this.tableLayoutPanel2.Controls.Add(label7, 0, 6);
            this.tableLayoutPanel2.Controls.Add(label6, 0, 5);
            this.tableLayoutPanel2.Controls.Add(label5, 0, 2);
            this.tableLayoutPanel2.Controls.Add(label4, 0, 4);
            this.tableLayoutPanel2.Controls.Add(label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(label1, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.EnableCacheCheck, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.RowsPerPageTxt, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.GenderCmb, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.EmailTxt, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.LastNameTxt, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.FirstNameTxt, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.PasswordTxt, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.UsernameTxt, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.BirthdayPicker, 1, 6);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 9;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(322, 262);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // EnableCacheCheck
            // 
            this.EnableCacheCheck.AutoSize = true;
            this.EnableCacheCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EnableCacheCheck.Location = new System.Drawing.Point(102, 235);
            this.EnableCacheCheck.Name = "EnableCacheCheck";
            this.EnableCacheCheck.Size = new System.Drawing.Size(217, 24);
            this.EnableCacheCheck.TabIndex = 9;
            this.EnableCacheCheck.UseVisualStyleBackColor = true;
            // 
            // RowsPerPageTxt
            // 
            this.RowsPerPageTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RowsPerPageTxt.Location = new System.Drawing.Point(102, 206);
            this.RowsPerPageTxt.Name = "RowsPerPageTxt";
            this.RowsPerPageTxt.Size = new System.Drawing.Size(217, 20);
            this.RowsPerPageTxt.TabIndex = 10;
            // 
            // GenderCmb
            // 
            this.GenderCmb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GenderCmb.FormattingEnabled = true;
            this.GenderCmb.Location = new System.Drawing.Point(102, 148);
            this.GenderCmb.Name = "GenderCmb";
            this.GenderCmb.Size = new System.Drawing.Size(217, 21);
            this.GenderCmb.TabIndex = 11;
            // 
            // EmailTxt
            // 
            this.EmailTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EmailTxt.Location = new System.Drawing.Point(102, 119);
            this.EmailTxt.Name = "EmailTxt";
            this.EmailTxt.Size = new System.Drawing.Size(217, 20);
            this.EmailTxt.TabIndex = 12;
            // 
            // LastNameTxt
            // 
            this.LastNameTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LastNameTxt.Location = new System.Drawing.Point(102, 90);
            this.LastNameTxt.Name = "LastNameTxt";
            this.LastNameTxt.Size = new System.Drawing.Size(217, 20);
            this.LastNameTxt.TabIndex = 13;
            // 
            // FirstNameTxt
            // 
            this.FirstNameTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FirstNameTxt.Location = new System.Drawing.Point(102, 61);
            this.FirstNameTxt.Name = "FirstNameTxt";
            this.FirstNameTxt.Size = new System.Drawing.Size(217, 20);
            this.FirstNameTxt.TabIndex = 14;
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PasswordTxt.Location = new System.Drawing.Point(102, 32);
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.PasswordChar = '*';
            this.PasswordTxt.Size = new System.Drawing.Size(217, 20);
            this.PasswordTxt.TabIndex = 15;
            // 
            // UsernameTxt
            // 
            this.UsernameTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsernameTxt.Location = new System.Drawing.Point(102, 3);
            this.UsernameTxt.Name = "UsernameTxt";
            this.UsernameTxt.ReadOnly = true;
            this.UsernameTxt.Size = new System.Drawing.Size(217, 20);
            this.UsernameTxt.TabIndex = 16;
            // 
            // BirthdayPicker
            // 
            this.BirthdayPicker.CustomFormat = "MMMM dd, yyyy";
            this.BirthdayPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BirthdayPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.BirthdayPicker.Location = new System.Drawing.Point(102, 177);
            this.BirthdayPicker.Name = "BirthdayPicker";
            this.BirthdayPicker.Size = new System.Drawing.Size(217, 20);
            this.BirthdayPicker.TabIndex = 17;
            // 
            // ConnectionTab
            // 
            this.ConnectionTab.Controls.Add(this.DataSourceTabs);
            this.ConnectionTab.Location = new System.Drawing.Point(4, 22);
            this.ConnectionTab.Name = "ConnectionTab";
            this.ConnectionTab.Padding = new System.Windows.Forms.Padding(3);
            this.ConnectionTab.Size = new System.Drawing.Size(328, 268);
            this.ConnectionTab.TabIndex = 1;
            this.ConnectionTab.Text = "Datasource";
            this.ConnectionTab.UseVisualStyleBackColor = true;
            // 
            // DataSourceTabs
            // 
            this.DataSourceTabs.Controls.Add(this.MySqlTab);
            this.DataSourceTabs.Controls.Add(this.OracleTab);
            this.DataSourceTabs.Controls.Add(this.SqliteTab);
            this.DataSourceTabs.Controls.Add(this.PostgresTab);
            this.DataSourceTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataSourceTabs.Location = new System.Drawing.Point(3, 3);
            this.DataSourceTabs.Name = "DataSourceTabs";
            this.DataSourceTabs.SelectedIndex = 0;
            this.DataSourceTabs.Size = new System.Drawing.Size(322, 262);
            this.DataSourceTabs.TabIndex = 0;
            // 
            // MySqlTab
            // 
            this.MySqlTab.Location = new System.Drawing.Point(4, 22);
            this.MySqlTab.Name = "MySqlTab";
            this.MySqlTab.Padding = new System.Windows.Forms.Padding(3);
            this.MySqlTab.Size = new System.Drawing.Size(314, 236);
            this.MySqlTab.TabIndex = 0;
            this.MySqlTab.Text = "MySql";
            this.MySqlTab.UseVisualStyleBackColor = true;
            // 
            // OracleTab
            // 
            this.OracleTab.Location = new System.Drawing.Point(4, 22);
            this.OracleTab.Name = "OracleTab";
            this.OracleTab.Padding = new System.Windows.Forms.Padding(3);
            this.OracleTab.Size = new System.Drawing.Size(314, 236);
            this.OracleTab.TabIndex = 1;
            this.OracleTab.Text = "Oracle";
            // 
            // SqliteTab
            // 
            this.SqliteTab.Location = new System.Drawing.Point(4, 22);
            this.SqliteTab.Name = "SqliteTab";
            this.SqliteTab.Padding = new System.Windows.Forms.Padding(3);
            this.SqliteTab.Size = new System.Drawing.Size(314, 236);
            this.SqliteTab.TabIndex = 2;
            this.SqliteTab.Text = "Sqlite";
            this.SqliteTab.UseVisualStyleBackColor = true;
            // 
            // PostgresTab
            // 
            this.PostgresTab.Location = new System.Drawing.Point(4, 22);
            this.PostgresTab.Name = "PostgresTab";
            this.PostgresTab.Padding = new System.Windows.Forms.Padding(3);
            this.PostgresTab.Size = new System.Drawing.Size(314, 236);
            this.PostgresTab.TabIndex = 3;
            this.PostgresTab.Text = "Postgres";
            this.PostgresTab.UseVisualStyleBackColor = true;
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 335);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsDialog_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.SettingsTabs.ResumeLayout(false);
            this.UserTab.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ConnectionTab.ResumeLayout(false);
            this.DataSourceTabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Done;
        private System.Windows.Forms.TabControl SettingsTabs;
        private System.Windows.Forms.TabPage UserTab;
        private System.Windows.Forms.TabPage ConnectionTab;
        private System.Windows.Forms.TabControl DataSourceTabs;
        private System.Windows.Forms.TabPage MySqlTab;
        private System.Windows.Forms.TabPage OracleTab;
        private System.Windows.Forms.TabPage SqliteTab;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TabPage PostgresTab;
        private System.Windows.Forms.CheckBox EnableCacheCheck;
        private System.Windows.Forms.TextBox RowsPerPageTxt;
        private System.Windows.Forms.ComboBox GenderCmb;
        private System.Windows.Forms.TextBox EmailTxt;
        private System.Windows.Forms.TextBox LastNameTxt;
        private System.Windows.Forms.TextBox FirstNameTxt;
        private System.Windows.Forms.TextBox PasswordTxt;
        private System.Windows.Forms.TextBox UsernameTxt;
        private System.Windows.Forms.DateTimePicker BirthdayPicker;
    }
}