namespace MPFinance.Forms
{
    partial class MPFinanceMain
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
            System.Windows.Forms.ToolStripSeparator mToolStripSeparator1_;
            System.Windows.Forms.ToolStripSeparator mToolStripSeparator3_;
            System.Windows.Forms.ToolStripSeparator mToolStripSeparator4_;
            System.Windows.Forms.ToolStripSeparator mToolStripSeparator2_;
            System.Windows.Forms.Label mfromDateLbl_;
            System.Windows.Forms.Label mToDateLbl_;
            System.Windows.Forms.Label mDescriptionLbl_;
            System.Windows.Forms.Label mCategoryLbl_;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            MPersist.Core.Data.Page page1 = new MPersist.Core.Data.Page();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MPFinanceMain));
            this.mRootEditToolStripMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
            this.mAccountsToolStripMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
            this.mCatagoriesToolStripMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
            this.mSettingsToolStripMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
            this.mOpenFileDialog_ = new System.Windows.Forms.OpenFileDialog();
            this.mStatusStrip_ = new System.Windows.Forms.StatusStrip();
            this.mMessageStatusBar_ = new System.Windows.Forms.ToolStripProgressBar();
            this.mMessageStatusLbl_ = new System.Windows.Forms.ToolStripStatusLabel();
            this.mMenuStrip_ = new System.Windows.Forms.MenuStrip();
            this.mRootFileToolStripMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
            this.mImportToolStripMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
            this.mOFXFileToolStripMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
            this.mExitToolStripMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
            this.mRootHelpToolStripMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
            this.mAboutToolStripMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
            this.mHelpToolStripMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
            this.mMainLayout_ = new System.Windows.Forms.TableLayoutPanel();
            this.mAccountsAndSummary_ = new System.Windows.Forms.TableLayoutPanel();
            this.mAccountsList_ = new System.Windows.Forms.ListBox();
            this.mTransactionsAndHeaderPanel_ = new System.Windows.Forms.Panel();
            this.mTransactionsAndHeader_ = new System.Windows.Forms.TableLayoutPanel();
            this.mTransactionsGridView_ = new MPFinance.Forms.Controls.TransactionsGridView();
            this.mTransactionsStatusStrip_ = new System.Windows.Forms.StatusStrip();
            this.mPageCountsLbl_ = new System.Windows.Forms.ToolStripStatusLabel();
            this.mTransactionCountsLbl_ = new System.Windows.Forms.ToolStripStatusLabel();
            this.mTopFlowLayoutPanel_ = new System.Windows.Forms.FlowLayoutPanel();
            this.mMoreBtn_ = new System.Windows.Forms.Button();
            this.mSearchBtn_ = new System.Windows.Forms.Button();
            this.mCategoriesCmb_ = new System.Windows.Forms.ComboBox();
            this.mDescriptionSearch_ = new System.Windows.Forms.TextBox();
            this.mToDate_ = new System.Windows.Forms.DateTimePicker();
            this.mFromDate_ = new System.Windows.Forms.DateTimePicker();
            this.mSummaryPanel_ = new MPFinance.Forms.Panels.SummaryPanel();
            mToolStripSeparator1_ = new System.Windows.Forms.ToolStripSeparator();
            mToolStripSeparator3_ = new System.Windows.Forms.ToolStripSeparator();
            mToolStripSeparator4_ = new System.Windows.Forms.ToolStripSeparator();
            mToolStripSeparator2_ = new System.Windows.Forms.ToolStripSeparator();
            mfromDateLbl_ = new System.Windows.Forms.Label();
            mToDateLbl_ = new System.Windows.Forms.Label();
            mDescriptionLbl_ = new System.Windows.Forms.Label();
            mCategoryLbl_ = new System.Windows.Forms.Label();
            this.mStatusStrip_.SuspendLayout();
            this.mMenuStrip_.SuspendLayout();
            this.mMainLayout_.SuspendLayout();
            this.mAccountsAndSummary_.SuspendLayout();
            this.mTransactionsAndHeaderPanel_.SuspendLayout();
            this.mTransactionsAndHeader_.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mTransactionsGridView_)).BeginInit();
            this.mTransactionsStatusStrip_.SuspendLayout();
            this.mTopFlowLayoutPanel_.SuspendLayout();
            this.SuspendLayout();
            // 
            // mToolStripSeparator1_
            // 
            mToolStripSeparator1_.Name = "mToolStripSeparator1_";
            mToolStripSeparator1_.Size = new System.Drawing.Size(153, 6);
            // 
            // mToolStripSeparator3_
            // 
            mToolStripSeparator3_.Name = "mToolStripSeparator3_";
            mToolStripSeparator3_.Size = new System.Drawing.Size(107, 6);
            // 
            // mToolStripSeparator4_
            // 
            mToolStripSeparator4_.Name = "mToolStripSeparator4_";
            mToolStripSeparator4_.Size = new System.Drawing.Size(127, 6);
            // 
            // mToolStripSeparator2_
            // 
            mToolStripSeparator2_.Name = "mToolStripSeparator2_";
            mToolStripSeparator2_.Size = new System.Drawing.Size(104, 6);
            // 
            // mfromDateLbl_
            // 
            mfromDateLbl_.AutoSize = true;
            mfromDateLbl_.Dock = System.Windows.Forms.DockStyle.Fill;
            mfromDateLbl_.Location = new System.Drawing.Point(28, 0);
            mfromDateLbl_.Name = "mfromDateLbl_";
            mfromDateLbl_.Size = new System.Drawing.Size(56, 27);
            mfromDateLbl_.TabIndex = 11;
            mfromDateLbl_.Text = "From Date";
            mfromDateLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mToDateLbl_
            // 
            mToDateLbl_.AutoSize = true;
            mToDateLbl_.Dock = System.Windows.Forms.DockStyle.Fill;
            mToDateLbl_.Location = new System.Drawing.Point(196, 0);
            mToDateLbl_.Name = "mToDateLbl_";
            mToDateLbl_.Size = new System.Drawing.Size(46, 27);
            mToDateLbl_.TabIndex = 13;
            mToDateLbl_.Text = "To Date";
            mToDateLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mDescriptionLbl_
            // 
            mDescriptionLbl_.AutoSize = true;
            mDescriptionLbl_.Dock = System.Windows.Forms.DockStyle.Fill;
            mDescriptionLbl_.Location = new System.Drawing.Point(354, 0);
            mDescriptionLbl_.Name = "mDescriptionLbl_";
            mDescriptionLbl_.Size = new System.Drawing.Size(60, 27);
            mDescriptionLbl_.TabIndex = 15;
            mDescriptionLbl_.Text = "Description";
            mDescriptionLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mCategoryLbl_
            // 
            mCategoryLbl_.AutoSize = true;
            mCategoryLbl_.Dock = System.Windows.Forms.DockStyle.Fill;
            mCategoryLbl_.Location = new System.Drawing.Point(593, 0);
            mCategoryLbl_.Name = "mCategoryLbl_";
            mCategoryLbl_.Size = new System.Drawing.Size(49, 27);
            mCategoryLbl_.TabIndex = 17;
            mCategoryLbl_.Text = "Category";
            mCategoryLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mRootEditToolStripMenuItem_
            // 
            this.mRootEditToolStripMenuItem_.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mAccountsToolStripMenuItem_,
            this.mCatagoriesToolStripMenuItem_,
            mToolStripSeparator4_,
            this.mSettingsToolStripMenuItem_});
            this.mRootEditToolStripMenuItem_.Name = "mRootEditToolStripMenuItem_";
            this.mRootEditToolStripMenuItem_.Size = new System.Drawing.Size(39, 20);
            this.mRootEditToolStripMenuItem_.Text = "Edit";
            // 
            // mAccountsToolStripMenuItem_
            // 
            this.mAccountsToolStripMenuItem_.Name = "mAccountsToolStripMenuItem_";
            this.mAccountsToolStripMenuItem_.Size = new System.Drawing.Size(130, 22);
            this.mAccountsToolStripMenuItem_.Text = "Accounts";
            this.mAccountsToolStripMenuItem_.Click += new System.EventHandler(this.accountsToolStripMenuItem_Click);
            // 
            // mCatagoriesToolStripMenuItem_
            // 
            this.mCatagoriesToolStripMenuItem_.Name = "mCatagoriesToolStripMenuItem_";
            this.mCatagoriesToolStripMenuItem_.Size = new System.Drawing.Size(130, 22);
            this.mCatagoriesToolStripMenuItem_.Text = "Categories";
            this.mCatagoriesToolStripMenuItem_.Click += new System.EventHandler(this.catagoriesToolStripMenuItem_Click);
            // 
            // mSettingsToolStripMenuItem_
            // 
            this.mSettingsToolStripMenuItem_.Enabled = false;
            this.mSettingsToolStripMenuItem_.Name = "mSettingsToolStripMenuItem_";
            this.mSettingsToolStripMenuItem_.Size = new System.Drawing.Size(130, 22);
            this.mSettingsToolStripMenuItem_.Text = "Settings";
            this.mSettingsToolStripMenuItem_.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // mOpenFileDialog_
            // 
            this.mOpenFileDialog_.Filter = "OFX Files|*.ofx";
            // 
            // mStatusStrip_
            // 
            this.mStatusStrip_.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mMessageStatusBar_,
            this.mMessageStatusLbl_});
            this.mStatusStrip_.Location = new System.Drawing.Point(0, 751);
            this.mStatusStrip_.Name = "mStatusStrip_";
            this.mStatusStrip_.Size = new System.Drawing.Size(1192, 22);
            this.mStatusStrip_.TabIndex = 2;
            this.mStatusStrip_.Text = "statusStrip1";
            // 
            // mMessageStatusBar_
            // 
            this.mMessageStatusBar_.Maximum = 200;
            this.mMessageStatusBar_.Name = "mMessageStatusBar_";
            this.mMessageStatusBar_.Size = new System.Drawing.Size(200, 16);
            // 
            // mMessageStatusLbl_
            // 
            this.mMessageStatusLbl_.Name = "mMessageStatusLbl_";
            this.mMessageStatusLbl_.Size = new System.Drawing.Size(0, 17);
            // 
            // mMenuStrip_
            // 
            this.mMenuStrip_.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mRootFileToolStripMenuItem_,
            this.mRootEditToolStripMenuItem_,
            this.mRootHelpToolStripMenuItem_});
            this.mMenuStrip_.Location = new System.Drawing.Point(0, 0);
            this.mMenuStrip_.Name = "mMenuStrip_";
            this.mMenuStrip_.Size = new System.Drawing.Size(1192, 24);
            this.mMenuStrip_.TabIndex = 3;
            this.mMenuStrip_.Text = "menuStrip";
            // 
            // mRootFileToolStripMenuItem_
            // 
            this.mRootFileToolStripMenuItem_.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mImportToolStripMenuItem_,
            mToolStripSeparator3_,
            this.mExitToolStripMenuItem_});
            this.mRootFileToolStripMenuItem_.Name = "mRootFileToolStripMenuItem_";
            this.mRootFileToolStripMenuItem_.Size = new System.Drawing.Size(37, 20);
            this.mRootFileToolStripMenuItem_.Text = "File";
            // 
            // mImportToolStripMenuItem_
            // 
            this.mImportToolStripMenuItem_.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mOFXFileToolStripMenuItem_});
            this.mImportToolStripMenuItem_.Name = "mImportToolStripMenuItem_";
            this.mImportToolStripMenuItem_.Size = new System.Drawing.Size(110, 22);
            this.mImportToolStripMenuItem_.Text = "Import";
            // 
            // mOFXFileToolStripMenuItem_
            // 
            this.mOFXFileToolStripMenuItem_.Name = "mOFXFileToolStripMenuItem_";
            this.mOFXFileToolStripMenuItem_.Size = new System.Drawing.Size(117, 22);
            this.mOFXFileToolStripMenuItem_.Text = "OFX File";
            this.mOFXFileToolStripMenuItem_.Click += new System.EventHandler(this.OFXFileToolStripMenuItem_Click);
            // 
            // mExitToolStripMenuItem_
            // 
            this.mExitToolStripMenuItem_.Name = "mExitToolStripMenuItem_";
            this.mExitToolStripMenuItem_.Size = new System.Drawing.Size(110, 22);
            this.mExitToolStripMenuItem_.Text = "Exit";
            this.mExitToolStripMenuItem_.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // mRootHelpToolStripMenuItem_
            // 
            this.mRootHelpToolStripMenuItem_.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mAboutToolStripMenuItem_,
            mToolStripSeparator2_,
            this.mHelpToolStripMenuItem_});
            this.mRootHelpToolStripMenuItem_.Name = "mRootHelpToolStripMenuItem_";
            this.mRootHelpToolStripMenuItem_.Size = new System.Drawing.Size(44, 20);
            this.mRootHelpToolStripMenuItem_.Text = "Help";
            // 
            // mAboutToolStripMenuItem_
            // 
            this.mAboutToolStripMenuItem_.Name = "mAboutToolStripMenuItem_";
            this.mAboutToolStripMenuItem_.Size = new System.Drawing.Size(107, 22);
            this.mAboutToolStripMenuItem_.Text = "About";
            this.mAboutToolStripMenuItem_.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // mHelpToolStripMenuItem_
            // 
            this.mHelpToolStripMenuItem_.Name = "mHelpToolStripMenuItem_";
            this.mHelpToolStripMenuItem_.Size = new System.Drawing.Size(107, 22);
            this.mHelpToolStripMenuItem_.Text = "Help";
            // 
            // mMainLayout_
            // 
            this.mMainLayout_.ColumnCount = 2;
            this.mMainLayout_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.mMainLayout_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mMainLayout_.Controls.Add(this.mAccountsAndSummary_, 0, 0);
            this.mMainLayout_.Controls.Add(this.mTransactionsAndHeaderPanel_, 1, 0);
            this.mMainLayout_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mMainLayout_.Location = new System.Drawing.Point(0, 24);
            this.mMainLayout_.Name = "mMainLayout_";
            this.mMainLayout_.RowCount = 2;
            this.mMainLayout_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.mMainLayout_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.mMainLayout_.Size = new System.Drawing.Size(1192, 727);
            this.mMainLayout_.TabIndex = 4;
            // 
            // mAccountsAndSummary_
            // 
            this.mAccountsAndSummary_.ColumnCount = 1;
            this.mAccountsAndSummary_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mAccountsAndSummary_.Controls.Add(this.mAccountsList_, 0, 0);
            this.mAccountsAndSummary_.Controls.Add(this.mSummaryPanel_, 0, 1);
            this.mAccountsAndSummary_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mAccountsAndSummary_.Location = new System.Drawing.Point(3, 3);
            this.mAccountsAndSummary_.Name = "mAccountsAndSummary_";
            this.mAccountsAndSummary_.RowCount = 2;
            this.mAccountsAndSummary_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.mAccountsAndSummary_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.mAccountsAndSummary_.Size = new System.Drawing.Size(244, 430);
            this.mAccountsAndSummary_.TabIndex = 0;
            // 
            // mAccountsList_
            // 
            this.mAccountsList_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mAccountsList_.FormattingEnabled = true;
            this.mAccountsList_.Location = new System.Drawing.Point(3, 3);
            this.mAccountsList_.Name = "mAccountsList_";
            this.mAccountsList_.Size = new System.Drawing.Size(238, 123);
            this.mAccountsList_.TabIndex = 1;
            this.mAccountsList_.SelectedIndexChanged += new System.EventHandler(this.AccountsList_SelectedIndexChanged);
            // 
            // mTransactionsAndHeaderPanel_
            // 
            this.mTransactionsAndHeaderPanel_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mTransactionsAndHeaderPanel_.Controls.Add(this.mTransactionsAndHeader_);
            this.mTransactionsAndHeaderPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTransactionsAndHeaderPanel_.Location = new System.Drawing.Point(250, 7);
            this.mTransactionsAndHeaderPanel_.Margin = new System.Windows.Forms.Padding(0, 7, 0, 7);
            this.mTransactionsAndHeaderPanel_.Name = "mTransactionsAndHeaderPanel_";
            this.mTransactionsAndHeaderPanel_.Size = new System.Drawing.Size(942, 422);
            this.mTransactionsAndHeaderPanel_.TabIndex = 2;
            // 
            // mTransactionsAndHeader_
            // 
            this.mTransactionsAndHeader_.ColumnCount = 1;
            this.mTransactionsAndHeader_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mTransactionsAndHeader_.Controls.Add(this.mTransactionsGridView_, 0, 1);
            this.mTransactionsAndHeader_.Controls.Add(this.mTransactionsStatusStrip_, 0, 2);
            this.mTransactionsAndHeader_.Controls.Add(this.mTopFlowLayoutPanel_, 0, 0);
            this.mTransactionsAndHeader_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTransactionsAndHeader_.Location = new System.Drawing.Point(0, 0);
            this.mTransactionsAndHeader_.Name = "mTransactionsAndHeader_";
            this.mTransactionsAndHeader_.RowCount = 3;
            this.mTransactionsAndHeader_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.mTransactionsAndHeader_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mTransactionsAndHeader_.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mTransactionsAndHeader_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mTransactionsAndHeader_.Size = new System.Drawing.Size(940, 420);
            this.mTransactionsAndHeader_.TabIndex = 1;
            // 
            // mTransactionsGridView_
            // 
            this.mTransactionsGridView_.AllowUserToAddRows = false;
            this.mTransactionsGridView_.AllowUserToDeleteRows = false;
            this.mTransactionsGridView_.AllowUserToResizeColumns = false;
            this.mTransactionsGridView_.AllowUserToResizeRows = false;
            this.mTransactionsGridView_.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mTransactionsGridView_.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.mTransactionsGridView_.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            page1.IncludeRecordCount = true;
            page1.PageNo = 0;
            page1.RowsFetchedSoFar = 0;
            page1.TotalPageCount = 0;
            page1.TotalRowCount = 0;
            this.mTransactionsGridView_.CurrentPage = page1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mTransactionsGridView_.DefaultCellStyle = dataGridViewCellStyle2;
            this.mTransactionsGridView_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTransactionsGridView_.Location = new System.Drawing.Point(3, 38);
            this.mTransactionsGridView_.Name = "mTransactionsGridView_";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mTransactionsGridView_.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.mTransactionsGridView_.RowHeadersVisible = false;
            this.mTransactionsGridView_.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mTransactionsGridView_.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mTransactionsGridView_.Size = new System.Drawing.Size(934, 357);
            this.mTransactionsGridView_.TabIndex = 0;
            // 
            // mTransactionsStatusStrip_
            // 
            this.mTransactionsStatusStrip_.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mPageCountsLbl_,
            this.mTransactionCountsLbl_});
            this.mTransactionsStatusStrip_.Location = new System.Drawing.Point(0, 398);
            this.mTransactionsStatusStrip_.Name = "mTransactionsStatusStrip_";
            this.mTransactionsStatusStrip_.Size = new System.Drawing.Size(940, 22);
            this.mTransactionsStatusStrip_.SizingGrip = false;
            this.mTransactionsStatusStrip_.TabIndex = 1;
            this.mTransactionsStatusStrip_.Text = "statusStrip1";
            // 
            // mPageCountsLbl_
            // 
            this.mPageCountsLbl_.Name = "mPageCountsLbl_";
            this.mPageCountsLbl_.Size = new System.Drawing.Size(810, 17);
            this.mPageCountsLbl_.Spring = true;
            this.mPageCountsLbl_.Text = "Page Counts";
            this.mPageCountsLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mTransactionCountsLbl_
            // 
            this.mTransactionCountsLbl_.Name = "mTransactionCountsLbl_";
            this.mTransactionCountsLbl_.Size = new System.Drawing.Size(115, 17);
            this.mTransactionCountsLbl_.Text = "Transactions Counts";
            this.mTransactionCountsLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mTopFlowLayoutPanel_
            // 
            this.mTopFlowLayoutPanel_.Controls.Add(this.mMoreBtn_);
            this.mTopFlowLayoutPanel_.Controls.Add(this.mSearchBtn_);
            this.mTopFlowLayoutPanel_.Controls.Add(this.mCategoriesCmb_);
            this.mTopFlowLayoutPanel_.Controls.Add(mCategoryLbl_);
            this.mTopFlowLayoutPanel_.Controls.Add(this.mDescriptionSearch_);
            this.mTopFlowLayoutPanel_.Controls.Add(mDescriptionLbl_);
            this.mTopFlowLayoutPanel_.Controls.Add(this.mToDate_);
            this.mTopFlowLayoutPanel_.Controls.Add(mToDateLbl_);
            this.mTopFlowLayoutPanel_.Controls.Add(this.mFromDate_);
            this.mTopFlowLayoutPanel_.Controls.Add(mfromDateLbl_);
            this.mTopFlowLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTopFlowLayoutPanel_.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.mTopFlowLayoutPanel_.Location = new System.Drawing.Point(3, 3);
            this.mTopFlowLayoutPanel_.Name = "mTopFlowLayoutPanel_";
            this.mTopFlowLayoutPanel_.Size = new System.Drawing.Size(934, 29);
            this.mTopFlowLayoutPanel_.TabIndex = 2;
            // 
            // mMoreBtn_
            // 
            this.mMoreBtn_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mMoreBtn_.Location = new System.Drawing.Point(856, 3);
            this.mMoreBtn_.Name = "mMoreBtn_";
            this.mMoreBtn_.Size = new System.Drawing.Size(75, 21);
            this.mMoreBtn_.TabIndex = 20;
            this.mMoreBtn_.Text = "More";
            this.mMoreBtn_.UseVisualStyleBackColor = true;
            this.mMoreBtn_.Click += new System.EventHandler(this.MoreBtn_Click);
            // 
            // mSearchBtn_
            // 
            this.mSearchBtn_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mSearchBtn_.Location = new System.Drawing.Point(775, 3);
            this.mSearchBtn_.Name = "mSearchBtn_";
            this.mSearchBtn_.Size = new System.Drawing.Size(75, 21);
            this.mSearchBtn_.TabIndex = 19;
            this.mSearchBtn_.Text = "Search";
            this.mSearchBtn_.UseVisualStyleBackColor = true;
            this.mSearchBtn_.Click += new System.EventHandler(this.Search_Click);
            // 
            // mCategoriesCmb_
            // 
            this.mCategoriesCmb_.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mCategoriesCmb_.FormattingEnabled = true;
            this.mCategoriesCmb_.Location = new System.Drawing.Point(648, 3);
            this.mCategoriesCmb_.Name = "mCategoriesCmb_";
            this.mCategoriesCmb_.Size = new System.Drawing.Size(121, 21);
            this.mCategoriesCmb_.TabIndex = 18;
            // 
            // mDescriptionSearch_
            // 
            this.mDescriptionSearch_.Location = new System.Drawing.Point(420, 3);
            this.mDescriptionSearch_.Name = "mDescriptionSearch_";
            this.mDescriptionSearch_.Size = new System.Drawing.Size(167, 20);
            this.mDescriptionSearch_.TabIndex = 16;
            // 
            // mToDate_
            // 
            this.mToDate_.CustomFormat = "MMMM d, yyyy";
            this.mToDate_.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.mToDate_.Location = new System.Drawing.Point(248, 3);
            this.mToDate_.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.mToDate_.Name = "mToDate_";
            this.mToDate_.Size = new System.Drawing.Size(100, 20);
            this.mToDate_.TabIndex = 14;
            // 
            // mFromDate_
            // 
            this.mFromDate_.CustomFormat = "MMMM d, yyyy";
            this.mFromDate_.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.mFromDate_.Location = new System.Drawing.Point(90, 3);
            this.mFromDate_.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.mFromDate_.Name = "mFromDate_";
            this.mFromDate_.Size = new System.Drawing.Size(100, 20);
            this.mFromDate_.TabIndex = 12;
            // 
            // mSummaryPanel_
            // 
            this.mSummaryPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mSummaryPanel_.Location = new System.Drawing.Point(3, 132);
            this.mSummaryPanel_.Name = "mSummaryPanel_";
            this.mSummaryPanel_.Size = new System.Drawing.Size(238, 295);
            this.mSummaryPanel_.TabIndex = 2;
            // 
            // MPFinanceMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 773);
            this.Controls.Add(this.mMainLayout_);
            this.Controls.Add(this.mStatusStrip_);
            this.Controls.Add(this.mMenuStrip_);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mMenuStrip_;
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.Name = "MPFinanceMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MP Finance";
            this.mStatusStrip_.ResumeLayout(false);
            this.mStatusStrip_.PerformLayout();
            this.mMenuStrip_.ResumeLayout(false);
            this.mMenuStrip_.PerformLayout();
            this.mMainLayout_.ResumeLayout(false);
            this.mAccountsAndSummary_.ResumeLayout(false);
            this.mTransactionsAndHeaderPanel_.ResumeLayout(false);
            this.mTransactionsAndHeader_.ResumeLayout(false);
            this.mTransactionsAndHeader_.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mTransactionsGridView_)).EndInit();
            this.mTransactionsStatusStrip_.ResumeLayout(false);
            this.mTransactionsStatusStrip_.PerformLayout();
            this.mTopFlowLayoutPanel_.ResumeLayout(false);
            this.mTopFlowLayoutPanel_.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mMenuStrip_;
        private System.Windows.Forms.ToolStripMenuItem mRootFileToolStripMenuItem_;
        private System.Windows.Forms.ToolStripMenuItem mImportToolStripMenuItem_;
        private System.Windows.Forms.ToolStripMenuItem mOFXFileToolStripMenuItem_;
        private System.Windows.Forms.ToolStripMenuItem mExitToolStripMenuItem_;
        private System.Windows.Forms.ToolStripMenuItem mRootEditToolStripMenuItem_;
        private System.Windows.Forms.ToolStripMenuItem mAccountsToolStripMenuItem_;
        private System.Windows.Forms.ToolStripMenuItem mCatagoriesToolStripMenuItem_;
        private System.Windows.Forms.ToolStripMenuItem mSettingsToolStripMenuItem_;
        private System.Windows.Forms.ToolStripMenuItem mRootHelpToolStripMenuItem_;
        private System.Windows.Forms.ToolStripMenuItem mAboutToolStripMenuItem_;
        private System.Windows.Forms.ToolStripMenuItem mHelpToolStripMenuItem_;
        private System.Windows.Forms.OpenFileDialog mOpenFileDialog_;        
        private System.Windows.Forms.StatusStrip mStatusStrip_;        
        private System.Windows.Forms.ToolStripProgressBar mMessageStatusBar_;
        private System.Windows.Forms.ToolStripStatusLabel mMessageStatusLbl_;
        private System.Windows.Forms.TableLayoutPanel mMainLayout_;
        private System.Windows.Forms.TableLayoutPanel mAccountsAndSummary_;
        private System.Windows.Forms.TableLayoutPanel mTransactionsAndHeader_;
        private System.Windows.Forms.ListBox mAccountsList_;
        private MPFinance.Forms.Controls.TransactionsGridView mTransactionsGridView_;
        private System.Windows.Forms.StatusStrip mTransactionsStatusStrip_;
        private System.Windows.Forms.ToolStripStatusLabel mPageCountsLbl_;
        private System.Windows.Forms.ToolStripStatusLabel mTransactionCountsLbl_;
        private System.Windows.Forms.Panel mTransactionsAndHeaderPanel_;
        private System.Windows.Forms.FlowLayoutPanel mTopFlowLayoutPanel_;
        private System.Windows.Forms.DateTimePicker mFromDate_;
        private System.Windows.Forms.DateTimePicker mToDate_;
        private System.Windows.Forms.TextBox mDescriptionSearch_;
        private System.Windows.Forms.ComboBox mCategoriesCmb_;
        private System.Windows.Forms.Button mMoreBtn_;
        private System.Windows.Forms.Button mSearchBtn_;
        private Panels.SummaryPanel mSummaryPanel_;        
    }
}