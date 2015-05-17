namespace MiskoFinance.Forms
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
        	MiskoPersist.MoneyType.Money money1 = new MiskoPersist.MoneyType.Money();
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditAccountsDialog));
        	this.mNickname_ = new System.Windows.Forms.TextBox();
        	this.mAccountNumber_ = new System.Windows.Forms.TextBox();
        	this.mBankName_ = new System.Windows.Forms.TextBox();
        	this.mAccountType_ = new System.Windows.Forms.ComboBox();
        	this.mOpeningBalance_ = new MiskoFinance.Controls.MoneyBox();
        	this.mTableLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
        	this.mAccountLbl_ = new System.Windows.Forms.Label();
        	this.mOpeningBalanceLbl_ = new System.Windows.Forms.Label();
        	this.mNicknamelbl_ = new System.Windows.Forms.Label();
        	this.mAccountTypeLbl_ = new System.Windows.Forms.Label();
        	this.mAccountNumberLbl_ = new System.Windows.Forms.Label();
        	this.mBankNameLbl_ = new System.Windows.Forms.Label();
        	this.mExistingAccounts_ = new System.Windows.Forms.ComboBox();
        	this.mButtonFlowLayoutPanel_ = new System.Windows.Forms.FlowLayoutPanel();
        	this.mCancel_ = new System.Windows.Forms.Button();
        	this.mOK_ = new System.Windows.Forms.Button();
        	this.mTableLayoutPanel_.SuspendLayout();
        	this.mButtonFlowLayoutPanel_.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// mNickname_
        	// 
        	this.mNickname_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mNickname_.Enabled = false;
        	this.mNickname_.Location = new System.Drawing.Point(98, 143);
        	this.mNickname_.Name = "mNickname_";
        	this.mNickname_.Size = new System.Drawing.Size(195, 20);
        	this.mNickname_.TabIndex = 7;
        	// 
        	// mAccountNumber_
        	// 
        	this.mAccountNumber_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mAccountNumber_.Enabled = false;
        	this.mAccountNumber_.Location = new System.Drawing.Point(98, 75);
        	this.mAccountNumber_.Name = "mAccountNumber_";
        	this.mAccountNumber_.Size = new System.Drawing.Size(195, 20);
        	this.mAccountNumber_.TabIndex = 3;
        	// 
        	// mBankName_
        	// 
        	this.mBankName_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mBankName_.Enabled = false;
        	this.mBankName_.Location = new System.Drawing.Point(98, 41);
        	this.mBankName_.Name = "mBankName_";
        	this.mBankName_.Size = new System.Drawing.Size(195, 20);
        	this.mBankName_.TabIndex = 1;
        	// 
        	// mAccountType_
        	// 
        	this.mAccountType_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mAccountType_.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.mAccountType_.Enabled = false;
        	this.mAccountType_.FormattingEnabled = true;
        	this.mAccountType_.Location = new System.Drawing.Point(98, 108);
        	this.mAccountType_.Name = "mAccountType_";
        	this.mAccountType_.Size = new System.Drawing.Size(195, 21);
        	this.mAccountType_.TabIndex = 10;
        	// 
        	// mOpeningBalance_
        	// 
        	this.mOpeningBalance_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mOpeningBalance_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        	this.mOpeningBalance_.Enabled = false;
        	this.mOpeningBalance_.ForeColor = System.Drawing.Color.Black;
        	this.mOpeningBalance_.Location = new System.Drawing.Point(98, 179);
        	this.mOpeningBalance_.Name = "mOpeningBalance_";
        	this.mOpeningBalance_.Size = new System.Drawing.Size(195, 20);
        	this.mOpeningBalance_.TabIndex = 11;
        	this.mOpeningBalance_.Text = "$0.00";
        	this.mOpeningBalance_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	money1.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
        	this.mOpeningBalance_.Value = money1;
        	// 
        	// mTableLayoutPanel_
        	// 
        	this.mTableLayoutPanel_.AutoSize = true;
        	this.mTableLayoutPanel_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.mTableLayoutPanel_.ColumnCount = 2;
        	this.mTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        	this.mTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        	this.mTableLayoutPanel_.Controls.Add(this.mAccountLbl_, 0, 0);
        	this.mTableLayoutPanel_.Controls.Add(this.mOpeningBalance_, 1, 5);
        	this.mTableLayoutPanel_.Controls.Add(this.mOpeningBalanceLbl_, 0, 5);
        	this.mTableLayoutPanel_.Controls.Add(this.mNicknamelbl_, 0, 4);
        	this.mTableLayoutPanel_.Controls.Add(this.mNickname_, 1, 4);
        	this.mTableLayoutPanel_.Controls.Add(this.mAccountType_, 1, 3);
        	this.mTableLayoutPanel_.Controls.Add(this.mAccountTypeLbl_, 0, 3);
        	this.mTableLayoutPanel_.Controls.Add(this.mAccountNumberLbl_, 0, 2);
        	this.mTableLayoutPanel_.Controls.Add(this.mAccountNumber_, 1, 2);
        	this.mTableLayoutPanel_.Controls.Add(this.mBankNameLbl_, 0, 1);
        	this.mTableLayoutPanel_.Controls.Add(this.mBankName_, 1, 1);
        	this.mTableLayoutPanel_.Controls.Add(this.mExistingAccounts_, 1, 0);
        	this.mTableLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mTableLayoutPanel_.Location = new System.Drawing.Point(0, 0);
        	this.mTableLayoutPanel_.Name = "mTableLayoutPanel_";
        	this.mTableLayoutPanel_.RowCount = 6;
        	this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
        	this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
        	this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
        	this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
        	this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
        	this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
        	this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        	this.mTableLayoutPanel_.Size = new System.Drawing.Size(296, 209);
        	this.mTableLayoutPanel_.TabIndex = 7;
        	// 
        	// mAccountLbl_
        	// 
        	this.mAccountLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mAccountLbl_.AutoSize = true;
        	this.mAccountLbl_.Location = new System.Drawing.Point(3, 10);
        	this.mAccountLbl_.Name = "mAccountLbl_";
        	this.mAccountLbl_.Size = new System.Drawing.Size(89, 13);
        	this.mAccountLbl_.TabIndex = 13;
        	this.mAccountLbl_.Text = "Account";
        	this.mAccountLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// mOpeningBalanceLbl_
        	// 
        	this.mOpeningBalanceLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mOpeningBalanceLbl_.AutoSize = true;
        	this.mOpeningBalanceLbl_.Location = new System.Drawing.Point(3, 183);
        	this.mOpeningBalanceLbl_.Name = "mOpeningBalanceLbl_";
        	this.mOpeningBalanceLbl_.Size = new System.Drawing.Size(89, 13);
        	this.mOpeningBalanceLbl_.TabIndex = 8;
        	this.mOpeningBalanceLbl_.Text = "Opening Balance";
        	this.mOpeningBalanceLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// mNicknamelbl_
        	// 
        	this.mNicknamelbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mNicknamelbl_.AutoSize = true;
        	this.mNicknamelbl_.Location = new System.Drawing.Point(3, 146);
        	this.mNicknamelbl_.Name = "mNicknamelbl_";
        	this.mNicknamelbl_.Size = new System.Drawing.Size(89, 13);
        	this.mNicknamelbl_.TabIndex = 6;
        	this.mNicknamelbl_.Text = "Nickname";
        	this.mNicknamelbl_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// mAccountTypeLbl_
        	// 
        	this.mAccountTypeLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mAccountTypeLbl_.AutoSize = true;
        	this.mAccountTypeLbl_.Location = new System.Drawing.Point(3, 112);
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
        	this.mAccountNumberLbl_.Location = new System.Drawing.Point(3, 78);
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
        	this.mBankNameLbl_.Location = new System.Drawing.Point(3, 44);
        	this.mBankNameLbl_.Name = "mBankNameLbl_";
        	this.mBankNameLbl_.Size = new System.Drawing.Size(89, 13);
        	this.mBankNameLbl_.TabIndex = 0;
        	this.mBankNameLbl_.Text = "Bank Name";
        	this.mBankNameLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// mExistingAccounts_
        	// 
        	this.mExistingAccounts_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mExistingAccounts_.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.mExistingAccounts_.FormattingEnabled = true;
        	this.mExistingAccounts_.Location = new System.Drawing.Point(98, 6);
        	this.mExistingAccounts_.Name = "mExistingAccounts_";
        	this.mExistingAccounts_.Size = new System.Drawing.Size(195, 21);
        	this.mExistingAccounts_.TabIndex = 12;
        	// 
        	// mButtonFlowLayoutPanel_
        	// 
        	this.mButtonFlowLayoutPanel_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.mButtonFlowLayoutPanel_.Controls.Add(this.mCancel_);
        	this.mButtonFlowLayoutPanel_.Controls.Add(this.mOK_);
        	this.mButtonFlowLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.mButtonFlowLayoutPanel_.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
        	this.mButtonFlowLayoutPanel_.Location = new System.Drawing.Point(0, 209);
        	this.mButtonFlowLayoutPanel_.Name = "mButtonFlowLayoutPanel_";
        	this.mButtonFlowLayoutPanel_.Size = new System.Drawing.Size(296, 30);
        	this.mButtonFlowLayoutPanel_.TabIndex = 5;
        	// 
        	// mCancel_
        	// 
        	this.mCancel_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.mCancel_.Location = new System.Drawing.Point(218, 3);
        	this.mCancel_.Name = "mCancel_";
        	this.mCancel_.Size = new System.Drawing.Size(75, 23);
        	this.mCancel_.TabIndex = 4;
        	this.mCancel_.Text = "Cancel";
        	this.mCancel_.UseVisualStyleBackColor = true;
        	this.mCancel_.Click += new System.EventHandler(this.mCancel__Click);
        	// 
        	// mOK_
        	// 
        	this.mOK_.Location = new System.Drawing.Point(137, 3);
        	this.mOK_.Name = "mOK_";
        	this.mOK_.Size = new System.Drawing.Size(75, 23);
        	this.mOK_.TabIndex = 3;
        	this.mOK_.Text = "OK";
        	this.mOK_.UseVisualStyleBackColor = true;
        	this.mOK_.Click += new System.EventHandler(this.Done_Click);
        	// 
        	// EditAccountsDialog
        	// 
        	this.AcceptButton = this.mOK_;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.AutoSize = true;
        	this.CancelButton = this.mCancel_;
        	this.ClientSize = new System.Drawing.Size(296, 239);
        	this.Controls.Add(this.mTableLayoutPanel_);
        	this.Controls.Add(this.mButtonFlowLayoutPanel_);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "EditAccountsDialog";
        	this.ShowInTaskbar = false;
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Edit Accounts";
        	this.mTableLayoutPanel_.ResumeLayout(false);
        	this.mTableLayoutPanel_.PerformLayout();
        	this.mButtonFlowLayoutPanel_.ResumeLayout(false);
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox mNickname_;
        private System.Windows.Forms.TextBox mAccountNumber_;
        private System.Windows.Forms.TextBox mBankName_;
        private System.Windows.Forms.ComboBox mAccountType_;
        private MiskoFinance.Controls.MoneyBox mOpeningBalance_;
        private System.Windows.Forms.Button mOK_;
        private System.Windows.Forms.Button mCancel_;
        private System.Windows.Forms.Label mOpeningBalanceLbl_;
        private System.Windows.Forms.Label mNicknamelbl_;
        private System.Windows.Forms.Label mAccountTypeLbl_;
        private System.Windows.Forms.Label mAccountNumberLbl_;
        private System.Windows.Forms.Label mBankNameLbl_;
        private System.Windows.Forms.FlowLayoutPanel mButtonFlowLayoutPanel_;
        private System.Windows.Forms.TableLayoutPanel mTableLayoutPanel_;
        private System.Windows.Forms.Label mAccountLbl_;
        private System.Windows.Forms.ComboBox mExistingAccounts_;
    }
}