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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            MPersist.MoneyType.Money money1 = new MPersist.MoneyType.Money();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseAccountPanel));
            this.mMainTableLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
            this.mExistingAccount_ = new System.Windows.Forms.RadioButton();
            this.mCreateNewAccount_ = new System.Windows.Forms.RadioButton();
            this.mExistingAccounts_ = new System.Windows.Forms.CheckedListBox();
            this.mFieldsLayoutTable_ = new System.Windows.Forms.TableLayoutPanel();
            this.mOpeningBalance_ = new MPFinance.Controls.MoneyBox();
            this.mNickname_ = new System.Windows.Forms.TextBox();
            this.mAccountNumber_ = new System.Windows.Forms.TextBox();
            this.mBankName_ = new System.Windows.Forms.TextBox();
            this.mAccountType_ = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            this.mMainTableLayoutPanel_.SuspendLayout();
            this.mFieldsLayoutTable_.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(89, 13);
            label1.TabIndex = 0;
            label1.Text = "Bank Name";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 102);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(89, 13);
            label2.TabIndex = 1;
            label2.Text = "Nickname";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(3, 40);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(89, 13);
            label3.TabIndex = 2;
            label3.Text = "Account Number";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(3, 134);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(89, 13);
            label4.TabIndex = 3;
            label4.Text = "Opening Balance";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(3, 71);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(89, 13);
            label5.TabIndex = 4;
            label5.Text = "Account Type";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mMainTableLayoutPanel_
            // 
            this.mMainTableLayoutPanel_.ColumnCount = 2;
            this.mMainTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.mMainTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.mMainTableLayoutPanel_.Controls.Add(this.mExistingAccount_, 0, 0);
            this.mMainTableLayoutPanel_.Controls.Add(this.mCreateNewAccount_, 1, 0);
            this.mMainTableLayoutPanel_.Controls.Add(this.mExistingAccounts_, 0, 1);
            this.mMainTableLayoutPanel_.Controls.Add(this.mFieldsLayoutTable_, 1, 1);
            this.mMainTableLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mMainTableLayoutPanel_.Location = new System.Drawing.Point(0, 0);
            this.mMainTableLayoutPanel_.Name = "mMainTableLayoutPanel_";
            this.mMainTableLayoutPanel_.RowCount = 2;
            this.mMainTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mMainTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mMainTableLayoutPanel_.Size = new System.Drawing.Size(498, 187);
            this.mMainTableLayoutPanel_.TabIndex = 0;
            // 
            // mExistingAccount_
            // 
            this.mExistingAccount_.AutoSize = true;
            this.mExistingAccount_.Location = new System.Drawing.Point(3, 3);
            this.mExistingAccount_.Name = "mExistingAccount_";
            this.mExistingAccount_.Size = new System.Drawing.Size(104, 17);
            this.mExistingAccount_.TabIndex = 0;
            this.mExistingAccount_.TabStop = true;
            this.mExistingAccount_.Text = "Existing Account";
            this.mExistingAccount_.UseVisualStyleBackColor = true;
            // 
            // mCreateNewAccount_
            // 
            this.mCreateNewAccount_.AutoSize = true;
            this.mCreateNewAccount_.Location = new System.Drawing.Point(202, 3);
            this.mCreateNewAccount_.Name = "mCreateNewAccount_";
            this.mCreateNewAccount_.Size = new System.Drawing.Size(124, 17);
            this.mCreateNewAccount_.TabIndex = 1;
            this.mCreateNewAccount_.TabStop = true;
            this.mCreateNewAccount_.Text = "Create New Account";
            this.mCreateNewAccount_.UseVisualStyleBackColor = true;
            // 
            // mExistingAccounts_
            // 
            this.mExistingAccounts_.CheckOnClick = true;
            this.mExistingAccounts_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mExistingAccounts_.FormattingEnabled = true;
            this.mExistingAccounts_.Location = new System.Drawing.Point(3, 26);
            this.mExistingAccounts_.Name = "mExistingAccounts_";
            this.mExistingAccounts_.Size = new System.Drawing.Size(193, 158);
            this.mExistingAccounts_.TabIndex = 2;
            // 
            // mFieldsLayoutTable_
            // 
            this.mFieldsLayoutTable_.ColumnCount = 2;
            this.mFieldsLayoutTable_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.mFieldsLayoutTable_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mFieldsLayoutTable_.Controls.Add(label5, 0, 2);
            this.mFieldsLayoutTable_.Controls.Add(label3, 0, 1);
            this.mFieldsLayoutTable_.Controls.Add(label1, 0, 0);
            this.mFieldsLayoutTable_.Controls.Add(label2, 0, 3);
            this.mFieldsLayoutTable_.Controls.Add(label4, 0, 4);
            this.mFieldsLayoutTable_.Controls.Add(this.mOpeningBalance_, 1, 4);
            this.mFieldsLayoutTable_.Controls.Add(this.mNickname_, 1, 3);
            this.mFieldsLayoutTable_.Controls.Add(this.mAccountNumber_, 1, 1);
            this.mFieldsLayoutTable_.Controls.Add(this.mBankName_, 1, 0);
            this.mFieldsLayoutTable_.Controls.Add(this.mAccountType_, 1, 2);
            this.mFieldsLayoutTable_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mFieldsLayoutTable_.Location = new System.Drawing.Point(202, 26);
            this.mFieldsLayoutTable_.Name = "mFieldsLayoutTable_";
            this.mFieldsLayoutTable_.RowCount = 5;
            this.mFieldsLayoutTable_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mFieldsLayoutTable_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mFieldsLayoutTable_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mFieldsLayoutTable_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mFieldsLayoutTable_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mFieldsLayoutTable_.Size = new System.Drawing.Size(293, 158);
            this.mFieldsLayoutTable_.TabIndex = 3;
            // 
            // mOpeningBalance_
            // 
            this.mOpeningBalance_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mOpeningBalance_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mOpeningBalance_.ForeColor = System.Drawing.Color.Black;
            this.mOpeningBalance_.Location = new System.Drawing.Point(98, 131);
            this.mOpeningBalance_.Name = "mOpeningBalance_";
            this.mOpeningBalance_.Size = new System.Drawing.Size(192, 20);
            this.mOpeningBalance_.TabIndex = 5;
            this.mOpeningBalance_.Text = "$0.00";
            this.mOpeningBalance_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mOpeningBalance_.Value = money1;
            // 
            // mNickname_
            // 
            this.mNickname_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mNickname_.Location = new System.Drawing.Point(98, 98);
            this.mNickname_.Name = "mNickname_";
            this.mNickname_.Size = new System.Drawing.Size(192, 20);
            this.mNickname_.TabIndex = 6;
            // 
            // mAccountNumber_
            // 
            this.mAccountNumber_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mAccountNumber_.Location = new System.Drawing.Point(98, 36);
            this.mAccountNumber_.Name = "mAccountNumber_";
            this.mAccountNumber_.Size = new System.Drawing.Size(192, 20);
            this.mAccountNumber_.TabIndex = 7;
            // 
            // mBankName_
            // 
            this.mBankName_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mBankName_.Location = new System.Drawing.Point(98, 5);
            this.mBankName_.Name = "mBankName_";
            this.mBankName_.Size = new System.Drawing.Size(192, 20);
            this.mBankName_.TabIndex = 8;
            // 
            // mAccountType_
            // 
            this.mAccountType_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mAccountType_.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mAccountType_.FormattingEnabled = true;
            this.mAccountType_.Location = new System.Drawing.Point(98, 67);
            this.mAccountType_.Name = "mAccountType_";
            this.mAccountType_.Size = new System.Drawing.Size(192, 21);
            this.mAccountType_.TabIndex = 9;
            // 
            // ChooseAccountPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mMainTableLayoutPanel_);
            this.Name = "ChooseAccountPanel";
            this.Size = new System.Drawing.Size(498, 187);
            this.mMainTableLayoutPanel_.ResumeLayout(false);
            this.mMainTableLayoutPanel_.PerformLayout();
            this.mFieldsLayoutTable_.ResumeLayout(false);
            this.mFieldsLayoutTable_.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mMainTableLayoutPanel_;
        private System.Windows.Forms.RadioButton mExistingAccount_;
        private System.Windows.Forms.RadioButton mCreateNewAccount_;
        private System.Windows.Forms.CheckedListBox mExistingAccounts_;
        private System.Windows.Forms.TableLayoutPanel mFieldsLayoutTable_;
        private Controls.MoneyBox mOpeningBalance_;
        private System.Windows.Forms.TextBox mNickname_;
        private System.Windows.Forms.TextBox mAccountNumber_;
        private System.Windows.Forms.TextBox mBankName_;
        private System.Windows.Forms.ComboBox mAccountType_;
    }
}
