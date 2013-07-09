namespace MPFinance.Forms
{
    partial class EditAccountsDialog
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
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditAccountsDialog));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Nickname = new System.Windows.Forms.TextBox();
            this.AccountNumber = new System.Windows.Forms.TextBox();
            this.BankName = new System.Windows.Forms.TextBox();
            this.AccountTypeCmb = new System.Windows.Forms.ComboBox();
            this.OpeningBalance = new MPFinance.Forms.Controls.MoneyBox();
            this.existingAccounts = new System.Windows.Forms.ListBox();
            this.Done = new System.Windows.Forms.Button();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(3, 175);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(89, 13);
            label5.TabIndex = 8;
            label5.Text = "Opening Balance";
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(37, 133);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(55, 13);
            label4.TabIndex = 6;
            label4.Text = "Nickname";
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(18, 93);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(74, 13);
            label3.TabIndex = 4;
            label3.Text = "Account Type";
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(5, 53);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(87, 13);
            label2.TabIndex = 2;
            label2.Text = "Account Number";
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(29, 13);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(63, 13);
            label1.TabIndex = 0;
            label1.Text = "Bank Name";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.existingAccounts, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(509, 209);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(232, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(274, 203);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // Nickname
            // 
            this.Nickname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Nickname.Location = new System.Drawing.Point(98, 130);
            this.Nickname.Name = "Nickname";
            this.Nickname.Size = new System.Drawing.Size(173, 20);
            this.Nickname.TabIndex = 7;
            // 
            // AccountNumber
            // 
            this.AccountNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AccountNumber.Location = new System.Drawing.Point(98, 50);
            this.AccountNumber.Name = "AccountNumber";
            this.AccountNumber.Size = new System.Drawing.Size(173, 20);
            this.AccountNumber.TabIndex = 3;
            // 
            // BankName
            // 
            this.BankName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BankName.Location = new System.Drawing.Point(98, 10);
            this.BankName.Name = "BankName";
            this.BankName.Size = new System.Drawing.Size(173, 20);
            this.BankName.TabIndex = 1;
            // 
            // AccountTypeCmb
            // 
            this.AccountTypeCmb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AccountTypeCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AccountTypeCmb.FormattingEnabled = true;
            this.AccountTypeCmb.Location = new System.Drawing.Point(98, 89);
            this.AccountTypeCmb.Name = "AccountTypeCmb";
            this.AccountTypeCmb.Size = new System.Drawing.Size(173, 21);
            this.AccountTypeCmb.TabIndex = 10;
            // 
            // OpeningBalance
            // 
            this.OpeningBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.OpeningBalance.ForeColor = System.Drawing.Color.Black;
            this.OpeningBalance.Location = new System.Drawing.Point(98, 171);
            this.OpeningBalance.Name = "OpeningBalance";
            this.OpeningBalance.Size = new System.Drawing.Size(173, 20);
            this.OpeningBalance.TabIndex = 11;
            this.OpeningBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.OpeningBalance.Value = null;
            // 
            // existingAccounts
            // 
            this.existingAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.existingAccounts.FormattingEnabled = true;
            this.existingAccounts.Location = new System.Drawing.Point(3, 3);
            this.existingAccounts.Name = "existingAccounts";
            this.existingAccounts.Size = new System.Drawing.Size(223, 203);
            this.existingAccounts.TabIndex = 5;
            // 
            // Done
            // 
            this.Done.Location = new System.Drawing.Point(217, 215);
            this.Done.Name = "Done";
            this.Done.Size = new System.Drawing.Size(75, 23);
            this.Done.TabIndex = 3;
            this.Done.Text = "Done";
            this.Done.UseVisualStyleBackColor = true;
            this.Done.Click += new System.EventHandler(this.Done_Click);
            // 
            // EditAccountsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(509, 244);
            this.Controls.Add(this.Done);
            this.Controls.Add(this.tableLayoutPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditAccountsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Accounts";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.TextBox Nickname;
        public System.Windows.Forms.TextBox AccountNumber;
        public System.Windows.Forms.TextBox BankName;
        public System.Windows.Forms.ComboBox AccountTypeCmb;
        public Controls.MoneyBox OpeningBalance;
        private System.Windows.Forms.Button Done;
        private System.Windows.Forms.ListBox existingAccounts;
    }
}