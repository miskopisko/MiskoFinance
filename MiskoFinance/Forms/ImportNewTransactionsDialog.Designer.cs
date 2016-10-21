using System;
namespace MiskoFinance.Forms
{
	partial class ImportTransactionsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(Boolean disposing)
        {
            if(disposing && (components != null))
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportTransactionsDialog));
        	this.mCancel_ = new System.Windows.Forms.Button();
        	this.mImport_ = new System.Windows.Forms.Button();
        	this.mOpenFileDialog_ = new System.Windows.Forms.OpenFileDialog();
        	this.mExistingAccount_ = new System.Windows.Forms.RadioButton();
        	this.mCreateNewAccount_ = new System.Windows.Forms.RadioButton();
        	this.mFieldsLayoutTable_ = new System.Windows.Forms.TableLayoutPanel();
        	this.mAccountTypeLbl_ = new System.Windows.Forms.Label();
        	this.mAccountNumberLbl_ = new System.Windows.Forms.Label();
        	this.mBankNameLbl_ = new System.Windows.Forms.Label();
        	this.mNicknameLbl_ = new System.Windows.Forms.Label();
        	this.mOpeningBalanceLbl_ = new System.Windows.Forms.Label();
        	this.mOpeningBalance_ = new MiskoFinance.Controls.MoneyBox();
        	this.mNickname_ = new System.Windows.Forms.TextBox();
        	this.mAccountNumber_ = new System.Windows.Forms.TextBox();
        	this.mBankName_ = new System.Windows.Forms.TextBox();
        	this.mAccountType_ = new System.Windows.Forms.ComboBox();
        	this.mExistingAccounts_ = new System.Windows.Forms.ListBox();
        	this.mFlowLayoutPanel_ = new System.Windows.Forms.FlowLayoutPanel();
        	this.mTableLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
        	this.mFieldsLayoutTable_.SuspendLayout();
        	this.mFlowLayoutPanel_.SuspendLayout();
        	this.mTableLayoutPanel_.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// mCancel_
        	// 
        	this.mCancel_.AutoSize = true;
        	this.mCancel_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.mCancel_.Location = new System.Drawing.Point(367, 3);
        	this.mCancel_.Name = "mCancel_";
        	this.mCancel_.Size = new System.Drawing.Size(75, 23);
        	this.mCancel_.TabIndex = 0;
        	this.mCancel_.Text = "Cancel";
        	this.mCancel_.UseVisualStyleBackColor = true;
        	this.mCancel_.Click += new System.EventHandler(this.mCancel__Click);
        	// 
        	// mImport_
        	// 
        	this.mImport_.AutoSize = true;
        	this.mImport_.Location = new System.Drawing.Point(286, 3);
        	this.mImport_.Name = "mImport_";
        	this.mImport_.Size = new System.Drawing.Size(75, 23);
        	this.mImport_.TabIndex = 2;
        	this.mImport_.Text = "Import";
        	this.mImport_.UseVisualStyleBackColor = true;
        	this.mImport_.Click += new System.EventHandler(this.mImport__Click);
        	// 
        	// mOpenFileDialog_
        	// 
        	this.mOpenFileDialog_.Filter = "OFX Files|*.ofx";
        	// 
        	// mExistingAccount_
        	// 
        	this.mExistingAccount_.AutoSize = true;
        	this.mExistingAccount_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mExistingAccount_.Location = new System.Drawing.Point(3, 3);
        	this.mExistingAccount_.Name = "mExistingAccount_";
        	this.mExistingAccount_.Size = new System.Drawing.Size(144, 17);
        	this.mExistingAccount_.TabIndex = 0;
        	this.mExistingAccount_.TabStop = true;
        	this.mExistingAccount_.Text = "Existing Account";
        	this.mExistingAccount_.UseVisualStyleBackColor = true;
        	// 
        	// mCreateNewAccount_
        	// 
        	this.mCreateNewAccount_.AutoSize = true;
        	this.mCreateNewAccount_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mCreateNewAccount_.FlatAppearance.BorderSize = 2;
        	this.mCreateNewAccount_.Location = new System.Drawing.Point(153, 3);
        	this.mCreateNewAccount_.Name = "mCreateNewAccount_";
        	this.mCreateNewAccount_.Size = new System.Drawing.Size(295, 17);
        	this.mCreateNewAccount_.TabIndex = 1;
        	this.mCreateNewAccount_.TabStop = true;
        	this.mCreateNewAccount_.Text = "Create New Account";
        	this.mCreateNewAccount_.UseVisualStyleBackColor = true;
        	// 
        	// mFieldsLayoutTable_
        	// 
        	this.mFieldsLayoutTable_.AutoSize = true;
        	this.mFieldsLayoutTable_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.mFieldsLayoutTable_.ColumnCount = 2;
        	this.mFieldsLayoutTable_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        	this.mFieldsLayoutTable_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        	this.mFieldsLayoutTable_.Controls.Add(this.mAccountTypeLbl_, 0, 2);
        	this.mFieldsLayoutTable_.Controls.Add(this.mAccountNumberLbl_, 0, 1);
        	this.mFieldsLayoutTable_.Controls.Add(this.mBankNameLbl_, 0, 0);
        	this.mFieldsLayoutTable_.Controls.Add(this.mNicknameLbl_, 0, 3);
        	this.mFieldsLayoutTable_.Controls.Add(this.mOpeningBalanceLbl_, 0, 4);
        	this.mFieldsLayoutTable_.Controls.Add(this.mOpeningBalance_, 1, 4);
        	this.mFieldsLayoutTable_.Controls.Add(this.mNickname_, 1, 3);
        	this.mFieldsLayoutTable_.Controls.Add(this.mAccountNumber_, 1, 1);
        	this.mFieldsLayoutTable_.Controls.Add(this.mBankName_, 1, 0);
        	this.mFieldsLayoutTable_.Controls.Add(this.mAccountType_, 1, 2);
        	this.mFieldsLayoutTable_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mFieldsLayoutTable_.Location = new System.Drawing.Point(153, 26);
        	this.mFieldsLayoutTable_.Name = "mFieldsLayoutTable_";
        	this.mFieldsLayoutTable_.RowCount = 5;
        	this.mFieldsLayoutTable_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mFieldsLayoutTable_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mFieldsLayoutTable_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mFieldsLayoutTable_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mFieldsLayoutTable_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mFieldsLayoutTable_.Size = new System.Drawing.Size(295, 131);
        	this.mFieldsLayoutTable_.TabIndex = 3;
        	// 
        	// mAccountTypeLbl_
        	// 
        	this.mAccountTypeLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mAccountTypeLbl_.AutoSize = true;
        	this.mAccountTypeLbl_.Location = new System.Drawing.Point(3, 59);
        	this.mAccountTypeLbl_.Name = "mAccountTypeLbl_";
        	this.mAccountTypeLbl_.Size = new System.Drawing.Size(89, 13);
        	this.mAccountTypeLbl_.TabIndex = 4;
        	this.mAccountTypeLbl_.Text = "Account Type";
        	this.mAccountTypeLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// mAccountNumberLbl_
        	// 
        	this.mAccountNumberLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mAccountNumberLbl_.AutoSize = true;
        	this.mAccountNumberLbl_.Location = new System.Drawing.Point(3, 32);
        	this.mAccountNumberLbl_.Name = "mAccountNumberLbl_";
        	this.mAccountNumberLbl_.Size = new System.Drawing.Size(89, 13);
        	this.mAccountNumberLbl_.TabIndex = 2;
        	this.mAccountNumberLbl_.Text = "Account Number";
        	this.mAccountNumberLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// mBankNameLbl_
        	// 
        	this.mBankNameLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mBankNameLbl_.AutoSize = true;
        	this.mBankNameLbl_.Location = new System.Drawing.Point(3, 6);
        	this.mBankNameLbl_.Name = "mBankNameLbl_";
        	this.mBankNameLbl_.Size = new System.Drawing.Size(89, 13);
        	this.mBankNameLbl_.TabIndex = 0;
        	this.mBankNameLbl_.Text = "Bank Name";
        	this.mBankNameLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// mNicknameLbl_
        	// 
        	this.mNicknameLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mNicknameLbl_.AutoSize = true;
        	this.mNicknameLbl_.Location = new System.Drawing.Point(3, 85);
        	this.mNicknameLbl_.Name = "mNicknameLbl_";
        	this.mNicknameLbl_.Size = new System.Drawing.Size(89, 13);
        	this.mNicknameLbl_.TabIndex = 1;
        	this.mNicknameLbl_.Text = "Nickname";
        	this.mNicknameLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// mOpeningBalanceLbl_
        	// 
        	this.mOpeningBalanceLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mOpeningBalanceLbl_.AutoSize = true;
        	this.mOpeningBalanceLbl_.Location = new System.Drawing.Point(3, 111);
        	this.mOpeningBalanceLbl_.Name = "mOpeningBalanceLbl_";
        	this.mOpeningBalanceLbl_.Size = new System.Drawing.Size(89, 13);
        	this.mOpeningBalanceLbl_.TabIndex = 3;
        	this.mOpeningBalanceLbl_.Text = "Opening Balance";
        	this.mOpeningBalanceLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// mOpeningBalance_
        	// 
        	this.mOpeningBalance_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mOpeningBalance_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.mOpeningBalance_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        	this.mOpeningBalance_.ForeColor = System.Drawing.Color.Black;
        	this.mOpeningBalance_.Location = new System.Drawing.Point(98, 108);
        	this.mOpeningBalance_.Name = "mOpeningBalance_";
        	this.mOpeningBalance_.Size = new System.Drawing.Size(194, 20);
        	this.mOpeningBalance_.TabIndex = 5;
        	this.mOpeningBalance_.Text = "$0.00";
        	this.mOpeningBalance_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	// 
        	// mNickname_
        	// 
        	this.mNickname_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mNickname_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.mNickname_.Location = new System.Drawing.Point(98, 82);
        	this.mNickname_.Name = "mNickname_";
        	this.mNickname_.Size = new System.Drawing.Size(194, 20);
        	this.mNickname_.TabIndex = 6;
        	// 
        	// mAccountNumber_
        	// 
        	this.mAccountNumber_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mAccountNumber_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.mAccountNumber_.Location = new System.Drawing.Point(98, 29);
        	this.mAccountNumber_.Name = "mAccountNumber_";
        	this.mAccountNumber_.Size = new System.Drawing.Size(194, 20);
        	this.mAccountNumber_.TabIndex = 7;
        	// 
        	// mBankName_
        	// 
        	this.mBankName_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mBankName_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.mBankName_.Location = new System.Drawing.Point(98, 3);
        	this.mBankName_.Name = "mBankName_";
        	this.mBankName_.Size = new System.Drawing.Size(194, 20);
        	this.mBankName_.TabIndex = 8;
        	// 
        	// mAccountType_
        	// 
        	this.mAccountType_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mAccountType_.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.mAccountType_.FormattingEnabled = true;
        	this.mAccountType_.Location = new System.Drawing.Point(98, 55);
        	this.mAccountType_.Name = "mAccountType_";
        	this.mAccountType_.Size = new System.Drawing.Size(194, 21);
        	this.mAccountType_.TabIndex = 9;
        	// 
        	// mExistingAccounts_
        	// 
        	this.mExistingAccounts_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mExistingAccounts_.FormattingEnabled = true;
        	this.mExistingAccounts_.Location = new System.Drawing.Point(3, 26);
        	this.mExistingAccounts_.Name = "mExistingAccounts_";
        	this.mExistingAccounts_.Size = new System.Drawing.Size(144, 131);
        	this.mExistingAccounts_.TabIndex = 4;
        	// 
        	// mFlowLayoutPanel_
        	// 
        	this.mFlowLayoutPanel_.AutoSize = true;
        	this.mFlowLayoutPanel_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.mTableLayoutPanel_.SetColumnSpan(this.mFlowLayoutPanel_, 2);
        	this.mFlowLayoutPanel_.Controls.Add(this.mCancel_);
        	this.mFlowLayoutPanel_.Controls.Add(this.mImport_);
        	this.mFlowLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mFlowLayoutPanel_.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
        	this.mFlowLayoutPanel_.Location = new System.Drawing.Point(3, 163);
        	this.mFlowLayoutPanel_.Name = "mFlowLayoutPanel_";
        	this.mFlowLayoutPanel_.Size = new System.Drawing.Size(445, 29);
        	this.mFlowLayoutPanel_.TabIndex = 2;
        	// 
        	// mTableLayoutPanel_
        	// 
        	this.mTableLayoutPanel_.AutoSize = true;
        	this.mTableLayoutPanel_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.mTableLayoutPanel_.ColumnCount = 2;
        	this.mTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        	this.mTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        	this.mTableLayoutPanel_.Controls.Add(this.mExistingAccount_, 0, 0);
        	this.mTableLayoutPanel_.Controls.Add(this.mExistingAccounts_, 0, 1);
        	this.mTableLayoutPanel_.Controls.Add(this.mFieldsLayoutTable_, 1, 1);
        	this.mTableLayoutPanel_.Controls.Add(this.mCreateNewAccount_, 1, 0);
        	this.mTableLayoutPanel_.Controls.Add(this.mFlowLayoutPanel_, 0, 2);
        	this.mTableLayoutPanel_.Location = new System.Drawing.Point(1, 3);
        	this.mTableLayoutPanel_.Name = "mTableLayoutPanel_";
        	this.mTableLayoutPanel_.RowCount = 3;
        	this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        	this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mTableLayoutPanel_.Size = new System.Drawing.Size(451, 195);
        	this.mTableLayoutPanel_.TabIndex = 5;
        	// 
        	// ImportTransactionsDialog
        	// 
        	this.AcceptButton = this.mImport_;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.AutoSize = true;
        	this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.CancelButton = this.mCancel_;
        	this.ClientSize = new System.Drawing.Size(501, 243);
        	this.Controls.Add(this.mTableLayoutPanel_);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "ImportTransactionsDialog";
        	this.ShowInTaskbar = false;
        	this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        	this.Text = "Import Transactions";
        	this.mFieldsLayoutTable_.ResumeLayout(false);
        	this.mFieldsLayoutTable_.PerformLayout();
        	this.mFlowLayoutPanel_.ResumeLayout(false);
        	this.mFlowLayoutPanel_.PerformLayout();
        	this.mTableLayoutPanel_.ResumeLayout(false);
        	this.mTableLayoutPanel_.PerformLayout();
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mImport_;
        private System.Windows.Forms.Button mCancel_;
        private System.Windows.Forms.OpenFileDialog mOpenFileDialog_;
        private System.Windows.Forms.RadioButton mExistingAccount_;
        private System.Windows.Forms.RadioButton mCreateNewAccount_;
        private System.Windows.Forms.ListBox mExistingAccounts_;
        private System.Windows.Forms.TableLayoutPanel mFieldsLayoutTable_;
        private System.Windows.Forms.Label mAccountTypeLbl_;
        private System.Windows.Forms.Label mAccountNumberLbl_;
        private System.Windows.Forms.Label mBankNameLbl_;
        private System.Windows.Forms.Label mNicknameLbl_;
        private System.Windows.Forms.Label mOpeningBalanceLbl_;
        private MiskoFinance.Controls.MoneyBox mOpeningBalance_;
        private System.Windows.Forms.TextBox mNickname_;
        private System.Windows.Forms.TextBox mAccountNumber_;
        private System.Windows.Forms.TextBox mBankName_;
        private System.Windows.Forms.ComboBox mAccountType_;
        private System.Windows.Forms.FlowLayoutPanel mFlowLayoutPanel_;
        private System.Windows.Forms.TableLayoutPanel mTableLayoutPanel_;

    }
}