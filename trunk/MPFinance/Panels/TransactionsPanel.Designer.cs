namespace MPFinance.Panels
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
            System.Windows.Forms.Label mCategoryLbl_;
            System.Windows.Forms.Label mDescriptionLbl_;
            System.Windows.Forms.Label mToDateLbl_;
            System.Windows.Forms.Label mFromDateLbl_;
            MPersist.Data.Page page1 = new MPersist.Data.Page();
            this.mStatusStrip_ = new System.Windows.Forms.StatusStrip();
            this.mPageCountsLbl_ = new System.Windows.Forms.ToolStripStatusLabel();
            this.mTransactionCountsLbl_ = new System.Windows.Forms.ToolStripStatusLabel();
            this.mTableLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
            this.mTransactionsGridView_ = new MPFinance.Controls.TransactionsGridView();
            this.mFlowLayoutPanel_ = new System.Windows.Forms.FlowLayoutPanel();
            this.mMore_ = new System.Windows.Forms.Button();
            this.mSearch_ = new System.Windows.Forms.Button();
            this.mCategory_ = new System.Windows.Forms.ComboBox();
            this.mDescription_ = new System.Windows.Forms.TextBox();
            this.mToDate_ = new System.Windows.Forms.DateTimePicker();
            this.mFromDate_ = new System.Windows.Forms.DateTimePicker();
            mCategoryLbl_ = new System.Windows.Forms.Label();
            mDescriptionLbl_ = new System.Windows.Forms.Label();
            mToDateLbl_ = new System.Windows.Forms.Label();
            mFromDateLbl_ = new System.Windows.Forms.Label();
            this.mStatusStrip_.SuspendLayout();
            this.mTableLayoutPanel_.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mTransactionsGridView_)).BeginInit();
            this.mFlowLayoutPanel_.SuspendLayout();
            this.SuspendLayout();
            // 
            // mCategoryLbl_
            // 
            mCategoryLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            mCategoryLbl_.AutoSize = true;
            mCategoryLbl_.Location = new System.Drawing.Point(650, 0);
            mCategoryLbl_.Name = "mCategoryLbl_";
            mCategoryLbl_.Size = new System.Drawing.Size(52, 29);
            mCategoryLbl_.TabIndex = 3;
            mCategoryLbl_.Text = "Category:";
            mCategoryLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mDescriptionLbl_
            // 
            mDescriptionLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            mDescriptionLbl_.AutoSize = true;
            mDescriptionLbl_.Location = new System.Drawing.Point(429, 0);
            mDescriptionLbl_.Name = "mDescriptionLbl_";
            mDescriptionLbl_.Size = new System.Drawing.Size(63, 29);
            mDescriptionLbl_.TabIndex = 5;
            mDescriptionLbl_.Text = "Description:";
            mDescriptionLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mToDateLbl_
            // 
            mToDateLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            mToDateLbl_.AutoSize = true;
            mToDateLbl_.Location = new System.Drawing.Point(247, 0);
            mToDateLbl_.Name = "mToDateLbl_";
            mToDateLbl_.Size = new System.Drawing.Size(49, 29);
            mToDateLbl_.TabIndex = 7;
            mToDateLbl_.Text = "To Date:";
            mToDateLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mFromDateLbl_
            // 
            mFromDateLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            mFromDateLbl_.AutoSize = true;
            mFromDateLbl_.Location = new System.Drawing.Point(58, 0);
            mFromDateLbl_.Name = "mFromDateLbl_";
            mFromDateLbl_.Size = new System.Drawing.Size(59, 29);
            mFromDateLbl_.TabIndex = 9;
            mFromDateLbl_.Text = "From Date:";
            mFromDateLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mStatusStrip_
            // 
            this.mStatusStrip_.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mPageCountsLbl_,
            this.mTransactionCountsLbl_});
            this.mStatusStrip_.Location = new System.Drawing.Point(0, 380);
            this.mStatusStrip_.Name = "mStatusStrip_";
            this.mStatusStrip_.Size = new System.Drawing.Size(1000, 22);
            this.mStatusStrip_.SizingGrip = false;
            this.mStatusStrip_.TabIndex = 0;
            this.mStatusStrip_.Text = "mStatusStrip_";
            // 
            // mPageCountsLbl_
            // 
            this.mPageCountsLbl_.Name = "mPageCountsLbl_";
            this.mPageCountsLbl_.Size = new System.Drawing.Size(880, 17);
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
            // mTableLayoutPanel_
            // 
            this.mTableLayoutPanel_.ColumnCount = 1;
            this.mTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mTableLayoutPanel_.Controls.Add(this.mTransactionsGridView_, 0, 1);
            this.mTableLayoutPanel_.Controls.Add(this.mFlowLayoutPanel_, 0, 0);
            this.mTableLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTableLayoutPanel_.Location = new System.Drawing.Point(0, 0);
            this.mTableLayoutPanel_.Name = "mTableLayoutPanel_";
            this.mTableLayoutPanel_.RowCount = 2;
            this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mTableLayoutPanel_.Size = new System.Drawing.Size(1000, 380);
            this.mTableLayoutPanel_.TabIndex = 1;
            // 
            // mTransactionsGridView_
            // 
            this.mTransactionsGridView_.AllowUserToAddRows = false;
            this.mTransactionsGridView_.AllowUserToDeleteRows = false;
            this.mTransactionsGridView_.AllowUserToResizeColumns = false;
            this.mTransactionsGridView_.AllowUserToResizeRows = false;
            this.mTransactionsGridView_.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            page1.IncludeRecordCount = true;
            page1.PageNo = 0;
            page1.RowsFetchedSoFar = 0;
            page1.TotalPageCount = 0;
            page1.TotalRowCount = 0;
            this.mTransactionsGridView_.CurrentPage = page1;
            this.mTransactionsGridView_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTransactionsGridView_.Location = new System.Drawing.Point(3, 38);
            this.mTransactionsGridView_.Name = "mTransactionsGridView_";
            this.mTransactionsGridView_.RowHeadersVisible = false;
            this.mTransactionsGridView_.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mTransactionsGridView_.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mTransactionsGridView_.Size = new System.Drawing.Size(994, 339);
            this.mTransactionsGridView_.TabIndex = 0;
            // 
            // mFlowLayoutPanel_
            // 
            this.mFlowLayoutPanel_.Controls.Add(this.mMore_);
            this.mFlowLayoutPanel_.Controls.Add(this.mSearch_);
            this.mFlowLayoutPanel_.Controls.Add(this.mCategory_);
            this.mFlowLayoutPanel_.Controls.Add(mCategoryLbl_);
            this.mFlowLayoutPanel_.Controls.Add(this.mDescription_);
            this.mFlowLayoutPanel_.Controls.Add(mDescriptionLbl_);
            this.mFlowLayoutPanel_.Controls.Add(this.mToDate_);
            this.mFlowLayoutPanel_.Controls.Add(mToDateLbl_);
            this.mFlowLayoutPanel_.Controls.Add(this.mFromDate_);
            this.mFlowLayoutPanel_.Controls.Add(mFromDateLbl_);
            this.mFlowLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mFlowLayoutPanel_.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.mFlowLayoutPanel_.Location = new System.Drawing.Point(3, 3);
            this.mFlowLayoutPanel_.Name = "mFlowLayoutPanel_";
            this.mFlowLayoutPanel_.Size = new System.Drawing.Size(994, 29);
            this.mFlowLayoutPanel_.TabIndex = 1;
            // 
            // mMore_
            // 
            this.mMore_.Location = new System.Drawing.Point(916, 3);
            this.mMore_.Name = "mMore_";
            this.mMore_.Size = new System.Drawing.Size(75, 23);
            this.mMore_.TabIndex = 0;
            this.mMore_.Text = "More";
            this.mMore_.UseVisualStyleBackColor = true;
            this.mMore_.Click += new System.EventHandler(this.mMore__Click);
            // 
            // mSearch_
            // 
            this.mSearch_.Location = new System.Drawing.Point(835, 3);
            this.mSearch_.Name = "mSearch_";
            this.mSearch_.Size = new System.Drawing.Size(75, 23);
            this.mSearch_.TabIndex = 1;
            this.mSearch_.Text = "Search";
            this.mSearch_.UseVisualStyleBackColor = true;
            this.mSearch_.Click += new System.EventHandler(this.mSearch__Click);
            // 
            // mCategory_
            // 
            this.mCategory_.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mCategory_.FormattingEnabled = true;
            this.mCategory_.Location = new System.Drawing.Point(708, 3);
            this.mCategory_.Name = "mCategory_";
            this.mCategory_.Size = new System.Drawing.Size(121, 21);
            this.mCategory_.TabIndex = 2;
            // 
            // mDescription_
            // 
            this.mDescription_.Location = new System.Drawing.Point(498, 3);
            this.mDescription_.Name = "mDescription_";
            this.mDescription_.Size = new System.Drawing.Size(146, 20);
            this.mDescription_.TabIndex = 4;
            // 
            // mToDate_
            // 
            this.mToDate_.CustomFormat = "MMM dd, yyyy";
            this.mToDate_.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.mToDate_.Location = new System.Drawing.Point(302, 3);
            this.mToDate_.Name = "mToDate_";
            this.mToDate_.Size = new System.Drawing.Size(121, 20);
            this.mToDate_.TabIndex = 6;
            // 
            // mFromDate_
            // 
            this.mFromDate_.CustomFormat = "MMM dd, yyyy";
            this.mFromDate_.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.mFromDate_.Location = new System.Drawing.Point(123, 3);
            this.mFromDate_.Name = "mFromDate_";
            this.mFromDate_.Size = new System.Drawing.Size(118, 20);
            this.mFromDate_.TabIndex = 8;
            // 
            // TransactionsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mTableLayoutPanel_);
            this.Controls.Add(this.mStatusStrip_);
            this.Name = "TransactionsPanel";
            this.Size = new System.Drawing.Size(1000, 402);
            this.mStatusStrip_.ResumeLayout(false);
            this.mStatusStrip_.PerformLayout();
            this.mTableLayoutPanel_.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mTransactionsGridView_)).EndInit();
            this.mFlowLayoutPanel_.ResumeLayout(false);
            this.mFlowLayoutPanel_.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip mStatusStrip_;
        private System.Windows.Forms.TableLayoutPanel mTableLayoutPanel_;
        private Controls.TransactionsGridView mTransactionsGridView_;
        private System.Windows.Forms.FlowLayoutPanel mFlowLayoutPanel_;
        private System.Windows.Forms.Button mSearch_;
        private System.Windows.Forms.Button mMore_;
        private System.Windows.Forms.ComboBox mCategory_;
        private System.Windows.Forms.TextBox mDescription_;
        private System.Windows.Forms.DateTimePicker mFromDate_;
        private System.Windows.Forms.DateTimePicker mToDate_;
        private System.Windows.Forms.ToolStripStatusLabel mPageCountsLbl_;
        private System.Windows.Forms.ToolStripStatusLabel mTransactionCountsLbl_;
    }
}
