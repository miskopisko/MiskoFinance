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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseAccountPanel));
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
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // tableLayoutPanel
            // 
            resources.ApplyResources(this.tableLayoutPanel, "tableLayoutPanel");
            this.tableLayoutPanel.Controls.Add(this.existingAccounts, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.existingAccount, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.createNewAccount, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 1, 1);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // existingAccounts
            // 
            this.existingAccounts.CheckOnClick = true;
            resources.ApplyResources(this.existingAccounts, "existingAccounts");
            this.existingAccounts.FormattingEnabled = true;
            this.existingAccounts.Name = "existingAccounts";
            this.existingAccounts.Sorted = true;
            this.existingAccounts.ThreeDCheckBoxes = true;
            // 
            // existingAccount
            // 
            resources.ApplyResources(this.existingAccount, "existingAccount");
            this.existingAccount.Name = "existingAccount";
            this.existingAccount.TabStop = true;
            this.existingAccount.UseVisualStyleBackColor = true;
            this.existingAccount.CheckedChanged += new System.EventHandler(this.existingAccount_CheckedChanged);
            // 
            // createNewAccount
            // 
            resources.ApplyResources(this.createNewAccount, "createNewAccount");
            this.createNewAccount.Name = "createNewAccount";
            this.createNewAccount.TabStop = true;
            this.createNewAccount.UseVisualStyleBackColor = true;
            this.createNewAccount.CheckedChanged += new System.EventHandler(this.createNewAccount_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
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
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // Nickname
            // 
            resources.ApplyResources(this.Nickname, "Nickname");
            this.Nickname.Name = "Nickname";
            // 
            // AccountNumber
            // 
            resources.ApplyResources(this.AccountNumber, "AccountNumber");
            this.AccountNumber.Name = "AccountNumber";
            // 
            // BankName
            // 
            resources.ApplyResources(this.BankName, "BankName");
            this.BankName.Name = "BankName";
            // 
            // AccountTypeCmb
            // 
            resources.ApplyResources(this.AccountTypeCmb, "AccountTypeCmb");
            this.AccountTypeCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AccountTypeCmb.FormattingEnabled = true;
            this.AccountTypeCmb.Name = "AccountTypeCmb";
            // 
            // OpeningBalance
            // 
            resources.ApplyResources(this.OpeningBalance, "OpeningBalance");
            this.OpeningBalance.ForeColor = System.Drawing.Color.Black;
            this.OpeningBalance.Name = "OpeningBalance";
            // 
            // ChooseAccountPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "ChooseAccountPanel";
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
