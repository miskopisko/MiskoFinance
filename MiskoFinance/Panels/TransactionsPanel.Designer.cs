using System;
namespace MiskoFinance.Panels
{
    partial class TransactionsPanel
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
        	MiskoPersist.MoneyType.Money money1 = new MiskoPersist.MoneyType.Money();
        	MiskoPersist.MoneyType.Money money2 = new MiskoPersist.MoneyType.Money();
        	MiskoPersist.MoneyType.Money money3 = new MiskoPersist.MoneyType.Money();
        	MiskoPersist.MoneyType.Money money4 = new MiskoPersist.MoneyType.Money();
        	MiskoPersist.MoneyType.Money money5 = new MiskoPersist.MoneyType.Money();
        	MiskoPersist.MoneyType.Money money6 = new MiskoPersist.MoneyType.Money();
        	MiskoPersist.MoneyType.Money money7 = new MiskoPersist.MoneyType.Money();
        	MiskoPersist.MoneyType.Money money8 = new MiskoPersist.MoneyType.Money();
        	MiskoPersist.MoneyType.Money money9 = new MiskoPersist.MoneyType.Money();
        	this.mSummaryRow_ = new System.Windows.Forms.TableLayoutPanel();
        	this.mCreditTotal_ = new MiskoFinance.Controls.MoneyBox();
        	this.mPageCountLbl_ = new System.Windows.Forms.Label();
        	this.mTotalTransferIn_ = new MiskoFinance.Controls.MoneyBox();
        	this.mTotalTransferOut_ = new MiskoFinance.Controls.MoneyBox();
        	this.mTransferDiff_ = new MiskoFinance.Controls.MoneyBox();
        	this.mTotalOneTimeIn_ = new MiskoFinance.Controls.MoneyBox();
        	this.mTotalOneTimeOut_ = new MiskoFinance.Controls.MoneyBox();
        	this.mOneTimeDiff_ = new MiskoFinance.Controls.MoneyBox();
        	this.mDebitTotal_ = new MiskoFinance.Controls.MoneyBox();
        	this.mTransactionCountLbl_ = new System.Windows.Forms.Label();
        	this.mCreditDebitDiff_ = new MiskoFinance.Controls.MoneyBox();
        	this.mTransactionsGridView_ = new MiskoFinance.Controls.TransactionsGridView();
        	this.mSummaryRow_.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.mTransactionsGridView_)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// mSummaryRow_
        	// 
        	this.mSummaryRow_.AutoSize = true;
        	this.mSummaryRow_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.mSummaryRow_.ColumnCount = 7;
        	this.mSummaryRow_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        	this.mSummaryRow_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        	this.mSummaryRow_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        	this.mSummaryRow_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        	this.mSummaryRow_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        	this.mSummaryRow_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        	this.mSummaryRow_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        	this.mSummaryRow_.Controls.Add(this.mCreditTotal_, 2, 0);
        	this.mSummaryRow_.Controls.Add(this.mPageCountLbl_, 0, 0);
        	this.mSummaryRow_.Controls.Add(this.mTotalTransferIn_, 4, 0);
        	this.mSummaryRow_.Controls.Add(this.mTotalTransferOut_, 4, 1);
        	this.mSummaryRow_.Controls.Add(this.mTransferDiff_, 4, 2);
        	this.mSummaryRow_.Controls.Add(this.mTotalOneTimeIn_, 5, 0);
        	this.mSummaryRow_.Controls.Add(this.mTotalOneTimeOut_, 5, 1);
        	this.mSummaryRow_.Controls.Add(this.mOneTimeDiff_, 5, 2);
        	this.mSummaryRow_.Controls.Add(this.mDebitTotal_, 3, 0);
        	this.mSummaryRow_.Controls.Add(this.mTransactionCountLbl_, 6, 0);
        	this.mSummaryRow_.Controls.Add(this.mCreditDebitDiff_, 2, 1);
        	this.mSummaryRow_.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.mSummaryRow_.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
        	this.mSummaryRow_.Location = new System.Drawing.Point(0, 187);
        	this.mSummaryRow_.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
        	this.mSummaryRow_.Name = "mSummaryRow_";
        	this.mSummaryRow_.RowCount = 3;
        	this.mSummaryRow_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mSummaryRow_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mSummaryRow_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mSummaryRow_.Size = new System.Drawing.Size(500, 63);
        	this.mSummaryRow_.TabIndex = 1;
        	// 
        	// mCreditTotal_
        	// 
        	this.mCreditTotal_.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.mCreditTotal_.BackColor = System.Drawing.SystemColors.Window;
        	this.mCreditTotal_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.mCreditTotal_.CausesValidation = false;
        	this.mCreditTotal_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        	this.mCreditTotal_.Cursor = System.Windows.Forms.Cursors.Default;
        	this.mCreditTotal_.ForeColor = System.Drawing.Color.Black;
        	this.mCreditTotal_.Location = new System.Drawing.Point(73, 0);
        	this.mCreditTotal_.Margin = new System.Windows.Forms.Padding(2, 0, 0, 1);
        	this.mCreditTotal_.Name = "mCreditTotal_";
        	this.mCreditTotal_.ReadOnly = true;
        	this.mCreditTotal_.Size = new System.Drawing.Size(71, 20);
        	this.mCreditTotal_.TabIndex = 2;
        	this.mCreditTotal_.Text = "$0.00";
        	this.mCreditTotal_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	money1.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
        	this.mCreditTotal_.Value = money1;
        	// 
        	// mPageCountLbl_
        	// 
        	this.mPageCountLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mPageCountLbl_.CausesValidation = false;
        	this.mPageCountLbl_.Location = new System.Drawing.Point(0, 1);
        	this.mPageCountLbl_.Margin = new System.Windows.Forms.Padding(0);
        	this.mPageCountLbl_.Name = "mPageCountLbl_";
        	this.mPageCountLbl_.Size = new System.Drawing.Size(71, 19);
        	this.mPageCountLbl_.TabIndex = 6;
        	this.mPageCountLbl_.Text = "Page Count";
        	this.mPageCountLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// mTotalTransferIn_
        	// 
        	this.mTotalTransferIn_.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.mTotalTransferIn_.BackColor = System.Drawing.SystemColors.Window;
        	this.mTotalTransferIn_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.mTotalTransferIn_.CausesValidation = false;
        	this.mTotalTransferIn_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        	this.mTotalTransferIn_.Cursor = System.Windows.Forms.Cursors.Default;
        	this.mTotalTransferIn_.ForeColor = System.Drawing.Color.Black;
        	this.mTotalTransferIn_.Location = new System.Drawing.Point(222, 0);
        	this.mTotalTransferIn_.Margin = new System.Windows.Forms.Padding(2, 0, 0, 1);
        	this.mTotalTransferIn_.Name = "mTotalTransferIn_";
        	this.mTotalTransferIn_.ReadOnly = true;
        	this.mTotalTransferIn_.Size = new System.Drawing.Size(71, 20);
        	this.mTotalTransferIn_.TabIndex = 9;
        	this.mTotalTransferIn_.Text = "$0.00";
        	this.mTotalTransferIn_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	money2.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
        	this.mTotalTransferIn_.Value = money2;
        	// 
        	// mTotalTransferOut_
        	// 
        	this.mTotalTransferOut_.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.mTotalTransferOut_.BackColor = System.Drawing.SystemColors.Window;
        	this.mTotalTransferOut_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.mTotalTransferOut_.CausesValidation = false;
        	this.mTotalTransferOut_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        	this.mTotalTransferOut_.Cursor = System.Windows.Forms.Cursors.Default;
        	this.mTotalTransferOut_.ForeColor = System.Drawing.Color.Black;
        	this.mTotalTransferOut_.Location = new System.Drawing.Point(222, 21);
        	this.mTotalTransferOut_.Margin = new System.Windows.Forms.Padding(2, 0, 0, 1);
        	this.mTotalTransferOut_.Name = "mTotalTransferOut_";
        	this.mTotalTransferOut_.ReadOnly = true;
        	this.mTotalTransferOut_.Size = new System.Drawing.Size(71, 20);
        	this.mTotalTransferOut_.TabIndex = 15;
        	this.mTotalTransferOut_.Text = "$0.00";
        	this.mTotalTransferOut_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	money3.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
        	this.mTotalTransferOut_.Value = money3;
        	// 
        	// mTransferDiff_
        	// 
        	this.mTransferDiff_.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.mTransferDiff_.BackColor = System.Drawing.SystemColors.Window;
        	this.mTransferDiff_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.mTransferDiff_.CausesValidation = false;
        	this.mTransferDiff_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        	this.mTransferDiff_.Cursor = System.Windows.Forms.Cursors.Default;
        	this.mTransferDiff_.ForeColor = System.Drawing.Color.Black;
        	this.mTransferDiff_.Location = new System.Drawing.Point(222, 42);
        	this.mTransferDiff_.Margin = new System.Windows.Forms.Padding(2, 0, 0, 1);
        	this.mTransferDiff_.Name = "mTransferDiff_";
        	this.mTransferDiff_.ReadOnly = true;
        	this.mTransferDiff_.Size = new System.Drawing.Size(71, 20);
        	this.mTransferDiff_.TabIndex = 4;
        	this.mTransferDiff_.Text = "$0.00";
        	this.mTransferDiff_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	money4.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
        	this.mTransferDiff_.Value = money4;
        	// 
        	// mTotalOneTimeIn_
        	// 
        	this.mTotalOneTimeIn_.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.mTotalOneTimeIn_.BackColor = System.Drawing.SystemColors.Window;
        	this.mTotalOneTimeIn_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.mTotalOneTimeIn_.CausesValidation = false;
        	this.mTotalOneTimeIn_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        	this.mTotalOneTimeIn_.Cursor = System.Windows.Forms.Cursors.Default;
        	this.mTotalOneTimeIn_.ForeColor = System.Drawing.Color.Black;
        	this.mTotalOneTimeIn_.Location = new System.Drawing.Point(295, 0);
        	this.mTotalOneTimeIn_.Margin = new System.Windows.Forms.Padding(2, 0, 0, 1);
        	this.mTotalOneTimeIn_.Name = "mTotalOneTimeIn_";
        	this.mTotalOneTimeIn_.ReadOnly = true;
        	this.mTotalOneTimeIn_.Size = new System.Drawing.Size(71, 20);
        	this.mTotalOneTimeIn_.TabIndex = 8;
        	this.mTotalOneTimeIn_.Text = "$0.00";
        	this.mTotalOneTimeIn_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	money5.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
        	this.mTotalOneTimeIn_.Value = money5;
        	// 
        	// mTotalOneTimeOut_
        	// 
        	this.mTotalOneTimeOut_.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.mTotalOneTimeOut_.BackColor = System.Drawing.SystemColors.Window;
        	this.mTotalOneTimeOut_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.mTotalOneTimeOut_.CausesValidation = false;
        	this.mTotalOneTimeOut_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        	this.mTotalOneTimeOut_.Cursor = System.Windows.Forms.Cursors.Default;
        	this.mTotalOneTimeOut_.ForeColor = System.Drawing.Color.Black;
        	this.mTotalOneTimeOut_.Location = new System.Drawing.Point(295, 21);
        	this.mTotalOneTimeOut_.Margin = new System.Windows.Forms.Padding(2, 0, 0, 1);
        	this.mTotalOneTimeOut_.Name = "mTotalOneTimeOut_";
        	this.mTotalOneTimeOut_.ReadOnly = true;
        	this.mTotalOneTimeOut_.Size = new System.Drawing.Size(71, 20);
        	this.mTotalOneTimeOut_.TabIndex = 13;
        	this.mTotalOneTimeOut_.Text = "$0.00";
        	this.mTotalOneTimeOut_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	money6.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
        	this.mTotalOneTimeOut_.Value = money6;
        	// 
        	// mOneTimeDiff_
        	// 
        	this.mOneTimeDiff_.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.mOneTimeDiff_.BackColor = System.Drawing.SystemColors.Window;
        	this.mOneTimeDiff_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.mOneTimeDiff_.CausesValidation = false;
        	this.mOneTimeDiff_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        	this.mOneTimeDiff_.Cursor = System.Windows.Forms.Cursors.Default;
        	this.mOneTimeDiff_.ForeColor = System.Drawing.Color.Black;
        	this.mOneTimeDiff_.Location = new System.Drawing.Point(295, 42);
        	this.mOneTimeDiff_.Margin = new System.Windows.Forms.Padding(2, 0, 0, 1);
        	this.mOneTimeDiff_.Name = "mOneTimeDiff_";
        	this.mOneTimeDiff_.ReadOnly = true;
        	this.mOneTimeDiff_.Size = new System.Drawing.Size(71, 20);
        	this.mOneTimeDiff_.TabIndex = 5;
        	this.mOneTimeDiff_.Text = "$0.00";
        	this.mOneTimeDiff_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	money7.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
        	this.mOneTimeDiff_.Value = money7;
        	// 
        	// mDebitTotal_
        	// 
        	this.mDebitTotal_.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.mDebitTotal_.BackColor = System.Drawing.SystemColors.Window;
        	this.mDebitTotal_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.mDebitTotal_.CausesValidation = false;
        	this.mDebitTotal_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        	this.mDebitTotal_.Cursor = System.Windows.Forms.Cursors.Default;
        	this.mDebitTotal_.ForeColor = System.Drawing.Color.Black;
        	this.mDebitTotal_.Location = new System.Drawing.Point(146, 0);
        	this.mDebitTotal_.Margin = new System.Windows.Forms.Padding(2, 0, 0, 1);
        	this.mDebitTotal_.Name = "mDebitTotal_";
        	this.mDebitTotal_.ReadOnly = true;
        	this.mDebitTotal_.Size = new System.Drawing.Size(74, 20);
        	this.mDebitTotal_.TabIndex = 3;
        	this.mDebitTotal_.Text = "$0.00";
        	this.mDebitTotal_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	money8.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
        	this.mDebitTotal_.Value = money8;
        	// 
        	// mTransactionCountLbl_
        	// 
        	this.mTransactionCountLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mTransactionCountLbl_.BackColor = System.Drawing.SystemColors.Control;
        	this.mTransactionCountLbl_.CausesValidation = false;
        	this.mTransactionCountLbl_.Location = new System.Drawing.Point(366, 1);
        	this.mTransactionCountLbl_.Margin = new System.Windows.Forms.Padding(0);
        	this.mTransactionCountLbl_.Name = "mTransactionCountLbl_";
        	this.mTransactionCountLbl_.Size = new System.Drawing.Size(142, 19);
        	this.mTransactionCountLbl_.TabIndex = 7;
        	this.mTransactionCountLbl_.Text = "Txn Count";
        	this.mTransactionCountLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// mCreditDebitDiff_
        	// 
        	this.mCreditDebitDiff_.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.mCreditDebitDiff_.BackColor = System.Drawing.SystemColors.Window;
        	this.mCreditDebitDiff_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.mCreditDebitDiff_.CausesValidation = false;
        	this.mCreditDebitDiff_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        	this.mSummaryRow_.SetColumnSpan(this.mCreditDebitDiff_, 2);
        	this.mCreditDebitDiff_.Cursor = System.Windows.Forms.Cursors.Default;
        	this.mCreditDebitDiff_.ForeColor = System.Drawing.Color.Black;
        	this.mCreditDebitDiff_.Location = new System.Drawing.Point(73, 21);
        	this.mCreditDebitDiff_.Margin = new System.Windows.Forms.Padding(2, 0, 0, 1);
        	this.mCreditDebitDiff_.Name = "mCreditDebitDiff_";
        	this.mCreditDebitDiff_.ReadOnly = true;
        	this.mCreditDebitDiff_.Size = new System.Drawing.Size(147, 20);
        	this.mCreditDebitDiff_.TabIndex = 12;
        	this.mCreditDebitDiff_.Text = "$0.00";
        	this.mCreditDebitDiff_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	money9.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
        	this.mCreditDebitDiff_.Value = money9;
        	// 
        	// mTransactionsGridView_
        	// 
        	this.mTransactionsGridView_.AllowUserToAddRows = false;
        	this.mTransactionsGridView_.AllowUserToDeleteRows = false;
        	this.mTransactionsGridView_.AllowUserToResizeColumns = false;
        	this.mTransactionsGridView_.AllowUserToResizeRows = false;
        	this.mTransactionsGridView_.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        	this.mTransactionsGridView_.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.mTransactionsGridView_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mTransactionsGridView_.Location = new System.Drawing.Point(0, 0);
        	this.mTransactionsGridView_.Name = "mTransactionsGridView_";
        	this.mTransactionsGridView_.Page = null;
        	this.mTransactionsGridView_.RowHeadersVisible = false;
        	this.mTransactionsGridView_.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        	this.mTransactionsGridView_.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.mTransactionsGridView_.Size = new System.Drawing.Size(500, 187);
        	this.mTransactionsGridView_.TabIndex = 0;
        	this.mTransactionsGridView_.VirtualMode = true;
        	// 
        	// TransactionsPanel
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.AutoSize = true;
        	this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.Controls.Add(this.mTransactionsGridView_);
        	this.Controls.Add(this.mSummaryRow_);
        	this.MinimumSize = new System.Drawing.Size(500, 250);
        	this.Name = "TransactionsPanel";
        	this.Size = new System.Drawing.Size(500, 250);
        	this.mSummaryRow_.ResumeLayout(false);
        	this.mSummaryRow_.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.mTransactionsGridView_)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        #endregion

        private Controls.TransactionsGridView mTransactionsGridView_;
        private System.Windows.Forms.TableLayoutPanel mSummaryRow_;
        private MiskoFinance.Controls.MoneyBox mCreditTotal_;
        private MiskoFinance.Controls.MoneyBox mDebitTotal_;
        private MiskoFinance.Controls.MoneyBox mTransferDiff_;
        private MiskoFinance.Controls.MoneyBox mOneTimeDiff_;
        private System.Windows.Forms.Label mPageCountLbl_;
        private System.Windows.Forms.Label mTransactionCountLbl_;
        private MiskoFinance.Controls.MoneyBox mTotalTransferIn_;
        private MiskoFinance.Controls.MoneyBox mTotalOneTimeIn_;
        private MiskoFinance.Controls.MoneyBox mTotalOneTimeOut_;
        private MiskoFinance.Controls.MoneyBox mTotalTransferOut_;
        private MiskoFinance.Controls.MoneyBox mCreditDebitDiff_;
    }
}
