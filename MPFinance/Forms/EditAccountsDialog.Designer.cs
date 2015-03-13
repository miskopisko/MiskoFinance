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
            MPersist.MoneyType.Money money1 = new MPersist.MoneyType.Money();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditAccountsDialog));
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mNickname_ = new System.Windows.Forms.TextBox();
            this.mAccountNumber_ = new System.Windows.Forms.TextBox();
            this.mBankName_ = new System.Windows.Forms.TextBox();
            this.mAccountType_ = new System.Windows.Forms.ComboBox();
            this.mOpeningBalance_ = new MPFinance.Controls.MoneyBox();
            this.mOK_ = new System.Windows.Forms.Button();
            this.mCancel_ = new System.Windows.Forms.Button();
            this.mButtonFlowLayoutPanel_ = new System.Windows.Forms.FlowLayoutPanel();
            this.mMainTableLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
            this.mInnerTableLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
            this.mExistingAccounts_ = new System.Windows.Forms.ListBox();
            this.mButtonFlowLayoutPanel_.SuspendLayout();
            this.mMainTableLayoutPanel_.SuspendLayout();
            this.mInnerTableLayoutPanel_.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Opening Balance";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nickname";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Account Type";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Account Number";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bank Name";
            // 
            // mNickname_
            // 
            this.mNickname_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mNickname_.Enabled = false;
            this.mNickname_.Location = new System.Drawing.Point(98, 98);
            this.mNickname_.Name = "mNickname_";
            this.mNickname_.Size = new System.Drawing.Size(188, 20);
            this.mNickname_.TabIndex = 7;
            // 
            // mAccountNumber_
            // 
            this.mAccountNumber_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mAccountNumber_.Enabled = false;
            this.mAccountNumber_.Location = new System.Drawing.Point(98, 36);
            this.mAccountNumber_.Name = "mAccountNumber_";
            this.mAccountNumber_.Size = new System.Drawing.Size(188, 20);
            this.mAccountNumber_.TabIndex = 3;
            // 
            // mBankName_
            // 
            this.mBankName_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mBankName_.Enabled = false;
            this.mBankName_.Location = new System.Drawing.Point(98, 5);
            this.mBankName_.Name = "mBankName_";
            this.mBankName_.Size = new System.Drawing.Size(188, 20);
            this.mBankName_.TabIndex = 1;
            // 
            // mAccountType_
            // 
            this.mAccountType_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mAccountType_.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mAccountType_.Enabled = false;
            this.mAccountType_.FormattingEnabled = true;
            this.mAccountType_.Location = new System.Drawing.Point(98, 67);
            this.mAccountType_.Name = "mAccountType_";
            this.mAccountType_.Size = new System.Drawing.Size(188, 21);
            this.mAccountType_.TabIndex = 10;
            // 
            // mOpeningBalance_
            // 
            this.mOpeningBalance_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mOpeningBalance_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mOpeningBalance_.Enabled = false;
            this.mOpeningBalance_.ForeColor = System.Drawing.Color.Black;
            this.mOpeningBalance_.Location = new System.Drawing.Point(98, 130);
            this.mOpeningBalance_.Name = "mOpeningBalance_";
            this.mOpeningBalance_.Size = new System.Drawing.Size(188, 20);
            this.mOpeningBalance_.TabIndex = 11;
            this.mOpeningBalance_.Text = "$0.00";
            this.mOpeningBalance_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mOpeningBalance_.Value = money1;
            // 
            // mOK_
            // 
            this.mOK_.Location = new System.Drawing.Point(326, 3);
            this.mOK_.Name = "mOK_";
            this.mOK_.Size = new System.Drawing.Size(75, 23);
            this.mOK_.TabIndex = 3;
            this.mOK_.Text = "OK";
            this.mOK_.UseVisualStyleBackColor = true;
            this.mOK_.Click += new System.EventHandler(this.Done_Click);
            // 
            // mCancel_
            // 
            this.mCancel_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.mCancel_.Location = new System.Drawing.Point(407, 3);
            this.mCancel_.Name = "mCancel_";
            this.mCancel_.Size = new System.Drawing.Size(75, 23);
            this.mCancel_.TabIndex = 4;
            this.mCancel_.Text = "Cancel";
            this.mCancel_.UseVisualStyleBackColor = true;
            this.mCancel_.Click += new System.EventHandler(this.mCancel__Click);
            // 
            // mButtonFlowLayoutPanel_
            // 
            this.mButtonFlowLayoutPanel_.AutoSize = true;
            this.mMainTableLayoutPanel_.SetColumnSpan(this.mButtonFlowLayoutPanel_, 2);
            this.mButtonFlowLayoutPanel_.Controls.Add(this.mCancel_);
            this.mButtonFlowLayoutPanel_.Controls.Add(this.mOK_);
            this.mButtonFlowLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mButtonFlowLayoutPanel_.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.mButtonFlowLayoutPanel_.Location = new System.Drawing.Point(3, 166);
            this.mButtonFlowLayoutPanel_.Name = "mButtonFlowLayoutPanel_";
            this.mButtonFlowLayoutPanel_.Size = new System.Drawing.Size(485, 29);
            this.mButtonFlowLayoutPanel_.TabIndex = 5;
            // 
            // mMainTableLayoutPanel_
            // 
            this.mMainTableLayoutPanel_.ColumnCount = 2;
            this.mMainTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.mMainTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.mMainTableLayoutPanel_.Controls.Add(this.mInnerTableLayoutPanel_, 1, 0);
            this.mMainTableLayoutPanel_.Controls.Add(this.mExistingAccounts_, 0, 0);
            this.mMainTableLayoutPanel_.Controls.Add(this.mButtonFlowLayoutPanel_, 0, 1);
            this.mMainTableLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mMainTableLayoutPanel_.Location = new System.Drawing.Point(0, 0);
            this.mMainTableLayoutPanel_.Name = "mMainTableLayoutPanel_";
            this.mMainTableLayoutPanel_.RowCount = 2;
            this.mMainTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mMainTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mMainTableLayoutPanel_.Size = new System.Drawing.Size(491, 198);
            this.mMainTableLayoutPanel_.TabIndex = 6;
            // 
            // mInnerTableLayoutPanel_
            // 
            this.mInnerTableLayoutPanel_.ColumnCount = 2;
            this.mInnerTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.mInnerTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mInnerTableLayoutPanel_.Controls.Add(this.mNickname_, 1, 3);
            this.mInnerTableLayoutPanel_.Controls.Add(this.label5, 0, 4);
            this.mInnerTableLayoutPanel_.Controls.Add(this.mAccountNumber_, 1, 1);
            this.mInnerTableLayoutPanel_.Controls.Add(this.label1, 0, 0);
            this.mInnerTableLayoutPanel_.Controls.Add(this.mBankName_, 1, 0);
            this.mInnerTableLayoutPanel_.Controls.Add(this.label4, 0, 3);
            this.mInnerTableLayoutPanel_.Controls.Add(this.mAccountType_, 1, 2);
            this.mInnerTableLayoutPanel_.Controls.Add(this.label2, 0, 1);
            this.mInnerTableLayoutPanel_.Controls.Add(this.mOpeningBalance_, 1, 4);
            this.mInnerTableLayoutPanel_.Controls.Add(this.label3, 0, 2);
            this.mInnerTableLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mInnerTableLayoutPanel_.Location = new System.Drawing.Point(199, 3);
            this.mInnerTableLayoutPanel_.Name = "mInnerTableLayoutPanel_";
            this.mInnerTableLayoutPanel_.RowCount = 5;
            this.mInnerTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mInnerTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mInnerTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mInnerTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mInnerTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mInnerTableLayoutPanel_.Size = new System.Drawing.Size(289, 157);
            this.mInnerTableLayoutPanel_.TabIndex = 7;
            // 
            // mExistingAccounts_
            // 
            this.mExistingAccounts_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mExistingAccounts_.FormattingEnabled = true;
            this.mExistingAccounts_.Location = new System.Drawing.Point(3, 3);
            this.mExistingAccounts_.Name = "mExistingAccounts_";
            this.mExistingAccounts_.Size = new System.Drawing.Size(190, 157);
            this.mExistingAccounts_.TabIndex = 6;
            // 
            // EditAccountsDialog
            // 
            this.AcceptButton = this.mOK_;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.mCancel_;
            this.ClientSize = new System.Drawing.Size(491, 198);
            this.Controls.Add(this.mMainTableLayoutPanel_);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditAccountsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Accounts";
            this.mButtonFlowLayoutPanel_.ResumeLayout(false);
            this.mMainTableLayoutPanel_.ResumeLayout(false);
            this.mMainTableLayoutPanel_.PerformLayout();
            this.mInnerTableLayoutPanel_.ResumeLayout(false);
            this.mInnerTableLayoutPanel_.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TextBox mNickname_;
        public System.Windows.Forms.TextBox mAccountNumber_;
        public System.Windows.Forms.TextBox mBankName_;
        public System.Windows.Forms.ComboBox mAccountType_;
        public Controls.MoneyBox mOpeningBalance_;
        private System.Windows.Forms.Button mOK_;
        private System.Windows.Forms.Button mCancel_;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel mButtonFlowLayoutPanel_;
        private System.Windows.Forms.TableLayoutPanel mMainTableLayoutPanel_;
        private System.Windows.Forms.ListBox mExistingAccounts_;
        private System.Windows.Forms.TableLayoutPanel mInnerTableLayoutPanel_;
    }
}