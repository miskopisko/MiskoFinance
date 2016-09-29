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
			if(disposing && (components != null))
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
			this.mSummaryRow_ = new System.Windows.Forms.TableLayoutPanel();
			this.mCreditTotal_ = new MiskoFinance.Controls.MoneyBox();
			this.mPageCountLbl_ = new System.Windows.Forms.Label();
			this.mTransfersTotal_ = new MiskoFinance.Controls.MoneyBox();
			this.mOneTimeTotal_ = new MiskoFinance.Controls.MoneyBox();
			this.mDebitTotal_ = new MiskoFinance.Controls.MoneyBox();
			this.mTransactionCountLbl_ = new System.Windows.Forms.Label();
			this.mTransactionsGridView_ = new MiskoFinance.Controls.TransactionsGridView();
			this.mSummaryRow_.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mTransactionsGridView_)).BeginInit();
			this.SuspendLayout();
			// 
			// mSummaryRow_
			// 
			this.mSummaryRow_.AutoSize = true;
			this.mSummaryRow_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.mSummaryRow_.BackColor = System.Drawing.SystemColors.Control;
			this.mSummaryRow_.ColumnCount = 8;
			this.mSummaryRow_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mSummaryRow_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mSummaryRow_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mSummaryRow_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mSummaryRow_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mSummaryRow_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mSummaryRow_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mSummaryRow_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mSummaryRow_.Controls.Add(this.mCreditTotal_, 3, 0);
			this.mSummaryRow_.Controls.Add(this.mPageCountLbl_, 0, 0);
			this.mSummaryRow_.Controls.Add(this.mTransfersTotal_, 5, 0);
			this.mSummaryRow_.Controls.Add(this.mOneTimeTotal_, 6, 0);
			this.mSummaryRow_.Controls.Add(this.mDebitTotal_, 4, 0);
			this.mSummaryRow_.Controls.Add(this.mTransactionCountLbl_, 7, 0);
			this.mSummaryRow_.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.mSummaryRow_.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			this.mSummaryRow_.Location = new System.Drawing.Point(0, 229);
			this.mSummaryRow_.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.mSummaryRow_.Name = "mSummaryRow_";
			this.mSummaryRow_.RowCount = 3;
			this.mSummaryRow_.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mSummaryRow_.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mSummaryRow_.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mSummaryRow_.Size = new System.Drawing.Size(500, 21);
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
			this.mCreditTotal_.Location = new System.Drawing.Point(65, 0);
			this.mCreditTotal_.Margin = new System.Windows.Forms.Padding(2, 0, 0, 1);
			this.mCreditTotal_.Name = "mCreditTotal_";
			this.mCreditTotal_.ReadOnly = true;
			this.mCreditTotal_.Size = new System.Drawing.Size(71, 20);
			this.mCreditTotal_.TabIndex = 2;
			this.mCreditTotal_.Text = "$0.00";
			this.mCreditTotal_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// mPageCountLbl_
			// 
			this.mPageCountLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.mPageCountLbl_.AutoSize = true;
			this.mPageCountLbl_.BackColor = System.Drawing.SystemColors.Control;
			this.mPageCountLbl_.CausesValidation = false;
			this.mPageCountLbl_.Location = new System.Drawing.Point(0, 0);
			this.mPageCountLbl_.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
			this.mPageCountLbl_.Name = "mPageCountLbl_";
			this.mPageCountLbl_.Size = new System.Drawing.Size(63, 20);
			this.mPageCountLbl_.TabIndex = 6;
			this.mPageCountLbl_.Text = "Page Count";
			this.mPageCountLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mTransfersTotal_
			// 
			this.mTransfersTotal_.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.mTransfersTotal_.BackColor = System.Drawing.SystemColors.Window;
			this.mTransfersTotal_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mTransfersTotal_.CausesValidation = false;
			this.mTransfersTotal_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.mTransfersTotal_.Cursor = System.Windows.Forms.Cursors.Default;
			this.mTransfersTotal_.ForeColor = System.Drawing.Color.Black;
			this.mTransfersTotal_.Location = new System.Drawing.Point(214, 0);
			this.mTransfersTotal_.Margin = new System.Windows.Forms.Padding(2, 0, 0, 1);
			this.mTransfersTotal_.Name = "mTransfersTotal_";
			this.mTransfersTotal_.ReadOnly = true;
			this.mTransfersTotal_.Size = new System.Drawing.Size(71, 20);
			this.mTransfersTotal_.TabIndex = 9;
			this.mTransfersTotal_.Text = "$0.00";
			this.mTransfersTotal_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// mOneTimeTotal_
			// 
			this.mOneTimeTotal_.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.mOneTimeTotal_.BackColor = System.Drawing.SystemColors.Window;
			this.mOneTimeTotal_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mOneTimeTotal_.CausesValidation = false;
			this.mOneTimeTotal_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.mOneTimeTotal_.Cursor = System.Windows.Forms.Cursors.Default;
			this.mOneTimeTotal_.ForeColor = System.Drawing.Color.Black;
			this.mOneTimeTotal_.Location = new System.Drawing.Point(287, 0);
			this.mOneTimeTotal_.Margin = new System.Windows.Forms.Padding(2, 0, 0, 1);
			this.mOneTimeTotal_.Name = "mOneTimeTotal_";
			this.mOneTimeTotal_.ReadOnly = true;
			this.mOneTimeTotal_.Size = new System.Drawing.Size(71, 20);
			this.mOneTimeTotal_.TabIndex = 8;
			this.mOneTimeTotal_.Text = "$0.00";
			this.mOneTimeTotal_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
			this.mDebitTotal_.Location = new System.Drawing.Point(138, 0);
			this.mDebitTotal_.Margin = new System.Windows.Forms.Padding(2, 0, 0, 1);
			this.mDebitTotal_.Name = "mDebitTotal_";
			this.mDebitTotal_.ReadOnly = true;
			this.mDebitTotal_.Size = new System.Drawing.Size(74, 20);
			this.mDebitTotal_.TabIndex = 3;
			this.mDebitTotal_.Text = "$0.00";
			this.mDebitTotal_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// mTransactionCountLbl_
			// 
			this.mTransactionCountLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.mTransactionCountLbl_.BackColor = System.Drawing.SystemColors.Control;
			this.mTransactionCountLbl_.CausesValidation = false;
			this.mTransactionCountLbl_.Location = new System.Drawing.Point(360, 0);
			this.mTransactionCountLbl_.Margin = new System.Windows.Forms.Padding(2, 0, 0, 1);
			this.mTransactionCountLbl_.Name = "mTransactionCountLbl_";
			this.mTransactionCountLbl_.Size = new System.Drawing.Size(140, 20);
			this.mTransactionCountLbl_.TabIndex = 7;
			this.mTransactionCountLbl_.Text = "Txn Count";
			this.mTransactionCountLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mTransactionsGridView_
			// 
			this.mTransactionsGridView_.AllowUserToAddRows = false;
			this.mTransactionsGridView_.AllowUserToDeleteRows = false;
			this.mTransactionsGridView_.AllowUserToResizeColumns = false;
			this.mTransactionsGridView_.AllowUserToResizeRows = false;
			this.mTransactionsGridView_.AutoGenerateColumns = false;
			this.mTransactionsGridView_.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.mTransactionsGridView_.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.mTransactionsGridView_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mTransactionsGridView_.Location = new System.Drawing.Point(0, 0);
			this.mTransactionsGridView_.Name = "mTransactionsGridView_";
			this.mTransactionsGridView_.Page = null;
			this.mTransactionsGridView_.RowHeadersVisible = false;
			this.mTransactionsGridView_.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.mTransactionsGridView_.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.mTransactionsGridView_.Size = new System.Drawing.Size(500, 229);
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
		private System.Windows.Forms.Label mPageCountLbl_;
		private System.Windows.Forms.Label mTransactionCountLbl_;
		private MiskoFinance.Controls.MoneyBox mTransfersTotal_;
		private MiskoFinance.Controls.MoneyBox mOneTimeTotal_;
	}
}
