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
        	this.mStatusStrip_ = new System.Windows.Forms.StatusStrip();
        	this.mPageCountsLbl_ = new System.Windows.Forms.ToolStripStatusLabel();
        	this.mTransactionCountsLbl_ = new System.Windows.Forms.ToolStripStatusLabel();
        	this.mTransactionsGridView_ = new MiskoFinance.Controls.TransactionsGridView();
        	this.mStatusStrip_.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.mTransactionsGridView_)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// mStatusStrip_
        	// 
        	this.mStatusStrip_.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.mPageCountsLbl_,
			this.mTransactionCountsLbl_});
        	this.mStatusStrip_.Location = new System.Drawing.Point(0, 228);
        	this.mStatusStrip_.Name = "mStatusStrip_";
        	this.mStatusStrip_.Size = new System.Drawing.Size(500, 22);
        	this.mStatusStrip_.SizingGrip = false;
        	this.mStatusStrip_.TabIndex = 0;
        	this.mStatusStrip_.Text = "mStatusStrip_";
        	// 
        	// mPageCountsLbl_
        	// 
        	this.mPageCountsLbl_.Name = "mPageCountsLbl_";
        	this.mPageCountsLbl_.Size = new System.Drawing.Size(380, 17);
        	this.mPageCountsLbl_.Spring = true;
        	this.mPageCountsLbl_.Text = "Page Count";
        	this.mPageCountsLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// mTransactionCountsLbl_
        	// 
        	this.mTransactionCountsLbl_.Name = "mTransactionCountsLbl_";
        	this.mTransactionCountsLbl_.Size = new System.Drawing.Size(105, 17);
        	this.mTransactionCountsLbl_.Text = "Transaction Count";
        	this.mTransactionCountsLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// mTransactionsGridView_
        	// 
        	this.mTransactionsGridView_.AllowUserToAddRows = false;
        	this.mTransactionsGridView_.AllowUserToDeleteRows = false;
        	this.mTransactionsGridView_.AllowUserToResizeColumns = false;
        	this.mTransactionsGridView_.AllowUserToResizeRows = false;
        	this.mTransactionsGridView_.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.mTransactionsGridView_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mTransactionsGridView_.Location = new System.Drawing.Point(0, 0);
        	this.mTransactionsGridView_.Name = "mTransactionsGridView_";
        	this.mTransactionsGridView_.RowHeadersVisible = false;
        	this.mTransactionsGridView_.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        	this.mTransactionsGridView_.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.mTransactionsGridView_.Size = new System.Drawing.Size(500, 228);
        	this.mTransactionsGridView_.TabIndex = 0;
        	// 
        	// TransactionsPanel
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.AutoSize = true;
        	this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.Controls.Add(this.mTransactionsGridView_);
        	this.Controls.Add(this.mStatusStrip_);
        	this.MinimumSize = new System.Drawing.Size(500, 250);
        	this.Name = "TransactionsPanel";
        	this.Size = new System.Drawing.Size(500, 250);
        	this.mStatusStrip_.ResumeLayout(false);
        	this.mStatusStrip_.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.mTransactionsGridView_)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip mStatusStrip_;
        private Controls.TransactionsGridView mTransactionsGridView_;
        private System.Windows.Forms.ToolStripStatusLabel mPageCountsLbl_;
        private System.Windows.Forms.ToolStripStatusLabel mTransactionCountsLbl_;
    }
}
