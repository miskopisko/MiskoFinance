namespace MPFinance.Forms.Panels
{
    partial class ChooseAccountPanel
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

        #region Component Designer generated code

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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.existingAccounts = new System.Windows.Forms.CheckedListBox();
            this.existingAccount = new System.Windows.Forms.RadioButton();
            this.createNewAccount = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Nickname = new System.Windows.Forms.TextBox();
            this.AccountNumber = new System.Windows.Forms.TextBox();
            this.BankName = new System.Windows.Forms.TextBox();
            this.AccountTypeCmb = new System.Windows.Forms.ComboBox();
            this.OpeningBalance = new MPFinance.Forms.Controls.MoneyBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(63, 10);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(63, 13);
            label1.TabIndex = 0;
            label1.Text = "Bank Name";
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(39, 43);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(87, 13);
            label2.TabIndex = 2;
            label2.Text = "Account Number";
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(52, 76);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(74, 13);
            label3.TabIndex = 4;
            label3.Text = "Account Type";
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(71, 109);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(55, 13);
            label4.TabIndex = 6;
            label4.Text = "Nickname";
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(37, 144);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(89, 13);
            label5.TabIndex = 8;
            label5.Text = "Opening Balance";
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel.Controls.Add(this.existingAccounts, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.existingAccount, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.createNewAccount, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 1, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(494, 210);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // existingAccounts
            // 
            this.existingAccounts.CheckOnClick = true;
            this.existingAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.existingAccounts.FormattingEnabled = true;
            this.existingAccounts.Location = new System.Drawing.Point(3, 38);
            this.existingAccounts.Name = "existingAccounts";
            this.existingAccounts.Size = new System.Drawing.Size(191, 169);
            this.existingAccounts.Sorted = true;
            this.existingAccounts.TabIndex = 0;
            this.existingAccounts.ThreeDCheckBoxes = true;
            // 
            // existingAccount
            // 
            this.existingAccount.AutoSize = true;
            this.existingAccount.Dock = System.Windows.Forms.DockStyle.Left;
            this.existingAccount.Location = new System.Drawing.Point(3, 3);
            this.existingAccount.Name = "existingAccount";
            this.existingAccount.Size = new System.Drawing.Size(124, 29);
            this.existingAccount.TabIndex = 1;
            this.existingAccount.TabStop = true;
            this.existingAccount.Text = "Use existing account";
            this.existingAccount.UseVisualStyleBackColor = true;
            this.existingAccount.CheckedChanged += new System.EventHandler(this.existingAccount_CheckedChanged);
            // 
            // createNewAccount
            // 
            this.createNewAccount.AutoSize = true;
            this.createNewAccount.Dock = System.Windows.Forms.DockStyle.Left;
            this.createNewAccount.Location = new System.Drawing.Point(200, 3);
            this.createNewAccount.Name = "createNewAccount";
            this.createNewAccount.Size = new System.Drawing.Size(133, 29);
            this.createNewAccount.TabIndex = 2;
            this.createNewAccount.TabStop = true;
            this.createNewAccount.Text = "Create a new  account";
            this.createNewAccount.UseVisualStyleBackColor = true;
            this.createNewAccount.CheckedChanged += new System.EventHandler(this.createNewAccount_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
            this.tableLayoutPanel1.Controls.Add(label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Nickname, 1, 3);
            this.tableLayoutPanel1.Controls.Add(label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.AccountNumber, 1, 1);
            this.tableLayoutPanel1.Controls.Add(label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BankName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.AccountTypeCmb, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.OpeningBalance, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(200, 38);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(291, 169);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // Nickname
            // 
            this.Nickname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Nickname.Location = new System.Drawing.Point(132, 105);
            this.Nickname.Name = "Nickname";
            this.Nickname.Size = new System.Drawing.Size(156, 20);
            this.Nickname.TabIndex = 7;
            // 
            // AccountNumber
            // 
            this.AccountNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AccountNumber.Location = new System.Drawing.Point(132, 39);
            this.AccountNumber.Name = "AccountNumber";
            this.AccountNumber.Size = new System.Drawing.Size(156, 20);
            this.AccountNumber.TabIndex = 3;
            // 
            // BankName
            // 
            this.BankName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BankName.Location = new System.Drawing.Point(132, 6);
            this.BankName.Name = "BankName";
            this.BankName.Size = new System.Drawing.Size(156, 20);
            this.BankName.TabIndex = 1;
            // 
            // AccountTypeCmb
            // 
            this.AccountTypeCmb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AccountTypeCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AccountTypeCmb.FormattingEnabled = true;
            this.AccountTypeCmb.Location = new System.Drawing.Point(132, 72);
            this.AccountTypeCmb.Name = "AccountTypeCmb";
            this.AccountTypeCmb.Size = new System.Drawing.Size(156, 21);
            this.AccountTypeCmb.TabIndex = 10;
            // 
            // OpeningBalance
            // 
            this.OpeningBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.OpeningBalance.ForeColor = System.Drawing.Color.Black;
            this.OpeningBalance.Location = new System.Drawing.Point(132, 140);
            this.OpeningBalance.Name = "OpeningBalance";
            this.OpeningBalance.Size = new System.Drawing.Size(156, 20);
            this.OpeningBalance.TabIndex = 11;
            this.OpeningBalance.Text = "\r\n";
            this.OpeningBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ChooseAccountPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "ChooseAccountPanel";
            this.Size = new System.Drawing.Size(494, 210);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        public System.Windows.Forms.CheckedListBox existingAccounts;
        public System.Windows.Forms.RadioButton existingAccount;
        public System.Windows.Forms.RadioButton createNewAccount;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.TextBox Nickname;
        public System.Windows.Forms.TextBox AccountNumber;
        public System.Windows.Forms.TextBox BankName;
        public System.Windows.Forms.ComboBox AccountTypeCmb;
        public Controls.MoneyBox OpeningBalance;

    }
}
