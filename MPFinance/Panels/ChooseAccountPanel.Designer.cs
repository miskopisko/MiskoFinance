namespace MPFinance.Panels
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseAccountPanel));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mExistingAccounts_ = new System.Windows.Forms.CheckedListBox();
            this.mExistingAccount_ = new System.Windows.Forms.RadioButton();
            this.mCreateNewAccount_ = new System.Windows.Forms.RadioButton();
            this.mFieldsTable_ = new System.Windows.Forms.TableLayoutPanel();
            this.mNickname_ = new System.Windows.Forms.TextBox();
            this.mAccountNumber_ = new System.Windows.Forms.TextBox();
            this.mBankName_ = new System.Windows.Forms.TextBox();
            this.mAccountType_ = new System.Windows.Forms.ComboBox();
            this.mOpeningBalance_ = new MPFinance.Controls.MoneyBox();
            this.mTableLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
            this.mFieldsTable_.SuspendLayout();
            this.mTableLayoutPanel_.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Bank Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Account Number";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(3, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Account Type";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(3, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "Nickname";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(3, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Opening Balance";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mExistingAccounts_
            // 
            this.mExistingAccounts_.CheckOnClick = true;
            this.mExistingAccounts_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mExistingAccounts_.FormattingEnabled = true;
            this.mExistingAccounts_.Location = new System.Drawing.Point(3, 38);
            this.mExistingAccounts_.Name = "mExistingAccounts_";
            this.mExistingAccounts_.Size = new System.Drawing.Size(247, 170);
            this.mExistingAccounts_.Sorted = true;
            this.mExistingAccounts_.TabIndex = 0;
            this.mExistingAccounts_.ThreeDCheckBoxes = true;
            // 
            // mExistingAccount_
            // 
            this.mExistingAccount_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mExistingAccount_.Location = new System.Drawing.Point(3, 5);
            this.mExistingAccount_.Name = "mExistingAccount_";
            this.mExistingAccount_.Size = new System.Drawing.Size(247, 24);
            this.mExistingAccount_.TabIndex = 1;
            this.mExistingAccount_.TabStop = true;
            this.mExistingAccount_.Text = "Use Existing Account";
            this.mExistingAccount_.UseVisualStyleBackColor = true;
            this.mExistingAccount_.CheckedChanged += new System.EventHandler(this.existingAccount_CheckedChanged);
            // 
            // mCreateNewAccount_
            // 
            this.mCreateNewAccount_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mCreateNewAccount_.Location = new System.Drawing.Point(256, 5);
            this.mCreateNewAccount_.Name = "mCreateNewAccount_";
            this.mCreateNewAccount_.Size = new System.Drawing.Size(247, 24);
            this.mCreateNewAccount_.TabIndex = 2;
            this.mCreateNewAccount_.TabStop = true;
            this.mCreateNewAccount_.Text = "Add New Account";
            this.mCreateNewAccount_.UseVisualStyleBackColor = true;
            this.mCreateNewAccount_.CheckedChanged += new System.EventHandler(this.createNewAccount_CheckedChanged);
            // 
            // mFieldsTable_
            // 
            this.mFieldsTable_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.mFieldsTable_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.mFieldsTable_.Controls.Add(this.label5, 0, 4);
            this.mFieldsTable_.Controls.Add(this.label4, 0, 3);
            this.mFieldsTable_.Controls.Add(this.mNickname_, 1, 3);
            this.mFieldsTable_.Controls.Add(this.label3, 0, 2);
            this.mFieldsTable_.Controls.Add(this.label2, 0, 1);
            this.mFieldsTable_.Controls.Add(this.mAccountNumber_, 1, 1);
            this.mFieldsTable_.Controls.Add(this.label1, 0, 0);
            this.mFieldsTable_.Controls.Add(this.mBankName_, 1, 0);
            this.mFieldsTable_.Controls.Add(this.mAccountType_, 1, 2);
            this.mFieldsTable_.Controls.Add(this.mOpeningBalance_, 1, 4);
            this.mFieldsTable_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mFieldsTable_.Location = new System.Drawing.Point(256, 38);
            this.mFieldsTable_.Name = "mFieldsTable_";
            this.mFieldsTable_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mFieldsTable_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mFieldsTable_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mFieldsTable_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mFieldsTable_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mFieldsTable_.Size = new System.Drawing.Size(247, 170);
            this.mFieldsTable_.TabIndex = 3;
            // 
            // mNickname_
            // 
            this.mNickname_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mNickname_.Location = new System.Drawing.Point(101, 109);
            this.mNickname_.Name = "mNickname_";
            this.mNickname_.Size = new System.Drawing.Size(143, 20);
            this.mNickname_.TabIndex = 2;
            // 
            // mAccountNumber_
            // 
            this.mAccountNumber_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mAccountNumber_.Location = new System.Drawing.Point(101, 41);
            this.mAccountNumber_.Name = "mAccountNumber_";
            this.mAccountNumber_.Size = new System.Drawing.Size(143, 20);
            this.mAccountNumber_.TabIndex = 5;
            // 
            // mBankName_
            // 
            this.mBankName_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mBankName_.Location = new System.Drawing.Point(101, 7);
            this.mBankName_.Name = "mBankName_";
            this.mBankName_.Size = new System.Drawing.Size(143, 20);
            this.mBankName_.TabIndex = 7;
            // 
            // mAccountType_
            // 
            this.mAccountType_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mAccountType_.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mAccountType_.FormattingEnabled = true;
            this.mAccountType_.Location = new System.Drawing.Point(101, 74);
            this.mAccountType_.Name = "mAccountType_";
            this.mAccountType_.Size = new System.Drawing.Size(143, 21);
            this.mAccountType_.TabIndex = 8;
            // 
            // mOpeningBalance_
            // 
            this.mOpeningBalance_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mOpeningBalance_.ForeColor = System.Drawing.Color.Black;
            this.mOpeningBalance_.Location = new System.Drawing.Point(101, 143);
            this.mOpeningBalance_.Name = "mOpeningBalance_";
            this.mOpeningBalance_.Size = new System.Drawing.Size(143, 20);
            this.mOpeningBalance_.TabIndex = 9;
            this.mOpeningBalance_.Text = "$0.00";
            this.mOpeningBalance_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mOpeningBalance_.Value = ((MPersist.MoneyType.Money)(resources.GetObject("mOpeningBalance_.Value")));
            // 
            // mTableLayoutPanel_
            // 
            this.mTableLayoutPanel_.ColumnCount = 2;
            this.mTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mTableLayoutPanel_.Controls.Add(this.mFieldsTable_, 1, 1);
            this.mTableLayoutPanel_.Controls.Add(this.mExistingAccounts_, 0, 1);
            this.mTableLayoutPanel_.Controls.Add(this.mCreateNewAccount_, 1, 0);
            this.mTableLayoutPanel_.Controls.Add(this.mExistingAccount_, 0, 0);
            this.mTableLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTableLayoutPanel_.Location = new System.Drawing.Point(0, 0);
            this.mTableLayoutPanel_.Name = "mTableLayoutPanel_";
            this.mTableLayoutPanel_.RowCount = 2;
            this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mTableLayoutPanel_.Size = new System.Drawing.Size(506, 211);
            this.mTableLayoutPanel_.TabIndex = 1;
            // 
            // ChooseAccountPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mTableLayoutPanel_);
            this.Name = "ChooseAccountPanel";
            this.Size = new System.Drawing.Size(506, 211);
            this.mFieldsTable_.ResumeLayout(false);
            this.mFieldsTable_.PerformLayout();
            this.mTableLayoutPanel_.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.CheckedListBox mExistingAccounts_;
        public System.Windows.Forms.RadioButton mExistingAccount_;
        public System.Windows.Forms.RadioButton mCreateNewAccount_;
        public System.Windows.Forms.TableLayoutPanel mFieldsTable_;
        public System.Windows.Forms.TextBox mNickname_;
        public System.Windows.Forms.TextBox mAccountNumber_;
        public System.Windows.Forms.TextBox mBankName_;
        public System.Windows.Forms.ComboBox mAccountType_;
        public Controls.MoneyBox mOpeningBalance_;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel mTableLayoutPanel_;
    }
}
