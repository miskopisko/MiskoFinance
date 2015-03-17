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
        	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
        	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
        	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
        	this.mCategoryLbl_ = new System.Windows.Forms.Label();
        	this.mDescriptionLbl_ = new System.Windows.Forms.Label();
        	this.mToDateLbl_ = new System.Windows.Forms.Label();
        	this.mFromDateLbl_ = new System.Windows.Forms.Label();
        	this.mStatusStrip_ = new System.Windows.Forms.StatusStrip();
        	this.mPageCountsLbl_ = new System.Windows.Forms.ToolStripStatusLabel();
        	this.mTransactionCountsLbl_ = new System.Windows.Forms.ToolStripStatusLabel();
        	this.mTableLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
        	this.mTransactionsGridView_ = new MiskoFinance.Controls.TransactionsGridView();
        	this.mFlowLayoutPanel_ = new System.Windows.Forms.FlowLayoutPanel();
        	this.mMore_ = new System.Windows.Forms.Button();
        	this.mSearch_ = new System.Windows.Forms.Button();
        	this.mCategories_ = new System.Windows.Forms.ComboBox();
        	this.mDescription_ = new System.Windows.Forms.TextBox();
        	this.mToDate_ = new System.Windows.Forms.DateTimePicker();
        	this.mFromDate_ = new System.Windows.Forms.DateTimePicker();
        	this.mStatusStrip_.SuspendLayout();
        	this.mTableLayoutPanel_.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.mTransactionsGridView_)).BeginInit();
        	this.mFlowLayoutPanel_.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// mCategoryLbl_
        	// 
        	this.mCategoryLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
        	this.mCategoryLbl_.AutoSize = true;
        	this.mCategoryLbl_.Location = new System.Drawing.Point(666, 0);
        	this.mCategoryLbl_.Name = "mCategoryLbl_";
        	this.mCategoryLbl_.Size = new System.Drawing.Size(52, 29);
        	this.mCategoryLbl_.TabIndex = 3;
        	this.mCategoryLbl_.Text = "Category:";
        	this.mCategoryLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// mDescriptionLbl_
        	// 
        	this.mDescriptionLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
        	this.mDescriptionLbl_.AutoSize = true;
        	this.mDescriptionLbl_.Location = new System.Drawing.Point(445, 0);
        	this.mDescriptionLbl_.Name = "mDescriptionLbl_";
        	this.mDescriptionLbl_.Size = new System.Drawing.Size(63, 29);
        	this.mDescriptionLbl_.TabIndex = 5;
        	this.mDescriptionLbl_.Text = "Description:";
        	this.mDescriptionLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// mToDateLbl_
        	// 
        	this.mToDateLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
        	this.mToDateLbl_.AutoSize = true;
        	this.mToDateLbl_.Location = new System.Drawing.Point(263, 0);
        	this.mToDateLbl_.Name = "mToDateLbl_";
        	this.mToDateLbl_.Size = new System.Drawing.Size(49, 29);
        	this.mToDateLbl_.TabIndex = 7;
        	this.mToDateLbl_.Text = "To Date:";
        	this.mToDateLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// mFromDateLbl_
        	// 
        	this.mFromDateLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
        	this.mFromDateLbl_.AutoSize = true;
        	this.mFromDateLbl_.Location = new System.Drawing.Point(74, 0);
        	this.mFromDateLbl_.Name = "mFromDateLbl_";
        	this.mFromDateLbl_.Size = new System.Drawing.Size(59, 29);
        	this.mFromDateLbl_.TabIndex = 9;
        	this.mFromDateLbl_.Text = "From Date:";
        	this.mFromDateLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// mStatusStrip_
        	// 
        	this.mStatusStrip_.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.mPageCountsLbl_,
			this.mTransactionCountsLbl_});
        	this.mStatusStrip_.Location = new System.Drawing.Point(0, 391);
        	this.mStatusStrip_.Name = "mStatusStrip_";
        	this.mStatusStrip_.Size = new System.Drawing.Size(1016, 22);
        	this.mStatusStrip_.SizingGrip = false;
        	this.mStatusStrip_.TabIndex = 0;
        	this.mStatusStrip_.Text = "mStatusStrip_";
        	// 
        	// mPageCountsLbl_
        	// 
        	this.mPageCountsLbl_.Name = "mPageCountsLbl_";
        	this.mPageCountsLbl_.Size = new System.Drawing.Size(896, 17);
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
        	this.mTableLayoutPanel_.Size = new System.Drawing.Size(1016, 391);
        	this.mTableLayoutPanel_.TabIndex = 1;
        	// 
        	// mTransactionsGridView_
        	// 
        	this.mTransactionsGridView_.AllowUserToAddRows = false;
        	this.mTransactionsGridView_.AllowUserToDeleteRows = false;
        	this.mTransactionsGridView_.AllowUserToResizeColumns = false;
        	this.mTransactionsGridView_.AllowUserToResizeRows = false;
        	this.mTransactionsGridView_.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.mTransactionsGridView_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mTransactionsGridView_.Location = new System.Drawing.Point(3, 38);
        	this.mTransactionsGridView_.Name = "mTransactionsGridView_";
        	this.mTransactionsGridView_.RowHeadersVisible = false;
        	this.mTransactionsGridView_.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        	this.mTransactionsGridView_.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.mTransactionsGridView_.Size = new System.Drawing.Size(1010, 350);
        	this.mTransactionsGridView_.TabIndex = 0;
        	// 
        	// mFlowLayoutPanel_
        	// 
        	this.mFlowLayoutPanel_.Controls.Add(this.mMore_);
        	this.mFlowLayoutPanel_.Controls.Add(this.mSearch_);
        	this.mFlowLayoutPanel_.Controls.Add(this.mCategories_);
        	this.mFlowLayoutPanel_.Controls.Add(this.mCategoryLbl_);
        	this.mFlowLayoutPanel_.Controls.Add(this.mDescription_);
        	this.mFlowLayoutPanel_.Controls.Add(this.mDescriptionLbl_);
        	this.mFlowLayoutPanel_.Controls.Add(this.mToDate_);
        	this.mFlowLayoutPanel_.Controls.Add(this.mToDateLbl_);
        	this.mFlowLayoutPanel_.Controls.Add(this.mFromDate_);
        	this.mFlowLayoutPanel_.Controls.Add(this.mFromDateLbl_);
        	this.mFlowLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mFlowLayoutPanel_.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
        	this.mFlowLayoutPanel_.Location = new System.Drawing.Point(3, 3);
        	this.mFlowLayoutPanel_.Name = "mFlowLayoutPanel_";
        	this.mFlowLayoutPanel_.Size = new System.Drawing.Size(1010, 29);
        	this.mFlowLayoutPanel_.TabIndex = 1;
        	// 
        	// mMore_
        	// 
        	this.mMore_.Location = new System.Drawing.Point(932, 3);
        	this.mMore_.Name = "mMore_";
        	this.mMore_.Size = new System.Drawing.Size(75, 23);
        	this.mMore_.TabIndex = 0;
        	this.mMore_.Text = "More";
        	this.mMore_.UseVisualStyleBackColor = true;
        	this.mMore_.Click += new System.EventHandler(this.mMore__Click);
        	// 
        	// mSearch_
        	// 
        	this.mSearch_.Location = new System.Drawing.Point(851, 3);
        	this.mSearch_.Name = "mSearch_";
        	this.mSearch_.Size = new System.Drawing.Size(75, 23);
        	this.mSearch_.TabIndex = 1;
        	this.mSearch_.Text = "Search";
        	this.mSearch_.UseVisualStyleBackColor = true;
        	this.mSearch_.Click += new System.EventHandler(this.mSearch__Click);
        	// 
        	// mCategories_
        	// 
        	this.mCategories_.DisplayMember = "Name";
        	this.mCategories_.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.mCategories_.FlatStyle = System.Windows.Forms.FlatStyle.System;
        	this.mCategories_.FormattingEnabled = true;
        	this.mCategories_.Location = new System.Drawing.Point(724, 3);
        	this.mCategories_.Name = "mCategories_";
        	this.mCategories_.Size = new System.Drawing.Size(121, 21);
        	this.mCategories_.TabIndex = 2;
        	this.mCategories_.ValueMember = "CategoryId";
        	// 
        	// mDescription_
        	// 
        	this.mDescription_.Location = new System.Drawing.Point(514, 3);
        	this.mDescription_.Name = "mDescription_";
        	this.mDescription_.Size = new System.Drawing.Size(146, 20);
        	this.mDescription_.TabIndex = 4;
        	// 
        	// mToDate_
        	// 
        	this.mToDate_.CustomFormat = "MMM dd, yyyy";
        	this.mToDate_.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        	this.mToDate_.Location = new System.Drawing.Point(318, 3);
        	this.mToDate_.Name = "mToDate_";
        	this.mToDate_.Size = new System.Drawing.Size(121, 20);
        	this.mToDate_.TabIndex = 6;
        	// 
        	// mFromDate_
        	// 
        	this.mFromDate_.CustomFormat = "MMM dd, yyyy";
        	this.mFromDate_.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        	this.mFromDate_.Location = new System.Drawing.Point(139, 3);
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
        	this.Size = new System.Drawing.Size(1016, 413);
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
        private System.Windows.Forms.ComboBox mCategories_;
        private System.Windows.Forms.TextBox mDescription_;
        private System.Windows.Forms.DateTimePicker mFromDate_;
        private System.Windows.Forms.DateTimePicker mToDate_;
        private System.Windows.Forms.ToolStripStatusLabel mPageCountsLbl_;
        private System.Windows.Forms.ToolStripStatusLabel mTransactionCountsLbl_;
        private System.Windows.Forms.Label mCategoryLbl_;
        private System.Windows.Forms.Label mDescriptionLbl_;
        private System.Windows.Forms.Label mToDateLbl_;
        private System.Windows.Forms.Label mFromDateLbl_;
    }
}
