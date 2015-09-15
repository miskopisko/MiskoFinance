namespace MiskoFinance.Forms
{
    partial class MiskoFinanceMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiskoFinanceMain));
            this.mToolStripSeparator1_ = new System.Windows.Forms.ToolStripSeparator();
            this.mToolStripSeparator3_ = new System.Windows.Forms.ToolStripSeparator();
            this.mToolStripSeparator4_ = new System.Windows.Forms.ToolStripSeparator();
            this.mToolStripSeparator2_ = new System.Windows.Forms.ToolStripSeparator();
            this.mRootEditToolStripMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
            this.mAccountsToolStripMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
            this.mCatagoriesToolStripMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
            this.mSettingsToolStripMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
            this.mStatusStrip_ = new System.Windows.Forms.StatusStrip();
            this.mMessageStatusBar_ = new System.Windows.Forms.ToolStripProgressBar();
            this.mMessageStatusLbl_ = new System.Windows.Forms.ToolStripStatusLabel();
            this.mMenuStrip_ = new System.Windows.Forms.MenuStrip();
            this.mRootFileToolStripMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
            this.mImportToolStripMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
            this.mOFXFileToolStripMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
            this.mLogoutToolStripMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
            this.mExitToolStripMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
            this.mRootHelpToolStripMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
            this.mAboutToolStripMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
            this.mHelpToolStripMenuItem_ = new System.Windows.Forms.ToolStripMenuItem();
            this.mMainLayoutTable_ = new System.Windows.Forms.TableLayoutPanel();
            this.mTransactionsPanel_ = new MiskoFinance.Panels.TransactionsPanel();
            this.mSearchPanel_ = new MiskoFinance.Panels.SearchPanel();
            this.mSummaryPanel_ = new MiskoFinance.Panels.SummaryPanel();
            this.mStatusStrip_.SuspendLayout();
            this.mMenuStrip_.SuspendLayout();
            this.mMainLayoutTable_.SuspendLayout();
            this.SuspendLayout();
            // 
            // mToolStripSeparator1_
            // 
            this.mToolStripSeparator1_.Name = "mToolStripSeparator1_";
            this.mToolStripSeparator1_.Size = new System.Drawing.Size(153, 6);
            // 
            // mToolStripSeparator3_
            // 
            this.mToolStripSeparator3_.Name = "mToolStripSeparator3_";
            this.mToolStripSeparator3_.Size = new System.Drawing.Size(109, 6);
            // 
            // mToolStripSeparator4_
            // 
            this.mToolStripSeparator4_.Name = "mToolStripSeparator4_";
            this.mToolStripSeparator4_.Size = new System.Drawing.Size(127, 6);
            // 
            // mToolStripSeparator2_
            // 
            this.mToolStripSeparator2_.Name = "mToolStripSeparator2_";
            this.mToolStripSeparator2_.Size = new System.Drawing.Size(104, 6);
            // 
            // mRootEditToolStripMenuItem_
            // 
            this.mRootEditToolStripMenuItem_.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mAccountsToolStripMenuItem_,
            this.mCatagoriesToolStripMenuItem_,
            this.mToolStripSeparator4_,
            this.mSettingsToolStripMenuItem_});
            this.mRootEditToolStripMenuItem_.Name = "mRootEditToolStripMenuItem_";
            this.mRootEditToolStripMenuItem_.Size = new System.Drawing.Size(39, 20);
            this.mRootEditToolStripMenuItem_.Text = "Edit";
            // 
            // mAccountsToolStripMenuItem_
            // 
            this.mAccountsToolStripMenuItem_.Enabled = false;
            this.mAccountsToolStripMenuItem_.Name = "mAccountsToolStripMenuItem_";
            this.mAccountsToolStripMenuItem_.Size = new System.Drawing.Size(130, 22);
            this.mAccountsToolStripMenuItem_.Text = "Accounts";
            this.mAccountsToolStripMenuItem_.Click += new System.EventHandler(this.mAccountsToolStripMenuItem_Click);
            // 
            // mCatagoriesToolStripMenuItem_
            // 
            this.mCatagoriesToolStripMenuItem_.Enabled = false;
            this.mCatagoriesToolStripMenuItem_.Name = "mCatagoriesToolStripMenuItem_";
            this.mCatagoriesToolStripMenuItem_.Size = new System.Drawing.Size(130, 22);
            this.mCatagoriesToolStripMenuItem_.Text = "Categories";
            this.mCatagoriesToolStripMenuItem_.Click += new System.EventHandler(this.mCatagoriesToolStripMenuItem_Click);
            // 
            // mSettingsToolStripMenuItem_
            // 
            this.mSettingsToolStripMenuItem_.Enabled = false;
            this.mSettingsToolStripMenuItem_.Name = "mSettingsToolStripMenuItem_";
            this.mSettingsToolStripMenuItem_.Size = new System.Drawing.Size(130, 22);
            this.mSettingsToolStripMenuItem_.Text = "Settings";
            this.mSettingsToolStripMenuItem_.Click += new System.EventHandler(this.mSettingsToolStripMenuItem_Click);
            // 
            // mStatusStrip_
            // 
            this.mStatusStrip_.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mMessageStatusBar_,
            this.mMessageStatusLbl_});
            this.mStatusStrip_.Location = new System.Drawing.Point(0, 740);
            this.mStatusStrip_.Name = "mStatusStrip_";
            this.mStatusStrip_.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mStatusStrip_.Size = new System.Drawing.Size(1206, 22);
            this.mStatusStrip_.TabIndex = 2;
            this.mStatusStrip_.Text = "statusStrip1";
            // 
            // mMessageStatusBar_
            // 
            this.mMessageStatusBar_.Enabled = false;
            this.mMessageStatusBar_.MarqueeAnimationSpeed = 0;
            this.mMessageStatusBar_.Name = "mMessageStatusBar_";
            this.mMessageStatusBar_.Size = new System.Drawing.Size(100, 16);
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
            this.mMenuStrip_.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mMenuStrip_.Size = new System.Drawing.Size(1206, 24);
            this.mMenuStrip_.TabIndex = 3;
            this.mMenuStrip_.Text = "menuStrip";
            // 
            // mRootFileToolStripMenuItem_
            // 
            this.mRootFileToolStripMenuItem_.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mImportToolStripMenuItem_,
            this.mLogoutToolStripMenuItem_,
            this.mToolStripSeparator3_,
            this.mExitToolStripMenuItem_});
            this.mRootFileToolStripMenuItem_.Name = "mRootFileToolStripMenuItem_";
            this.mRootFileToolStripMenuItem_.Size = new System.Drawing.Size(37, 20);
            this.mRootFileToolStripMenuItem_.Text = "File";
            // 
            // mImportToolStripMenuItem_
            // 
            this.mImportToolStripMenuItem_.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mOFXFileToolStripMenuItem_});
            this.mImportToolStripMenuItem_.Enabled = false;
            this.mImportToolStripMenuItem_.Name = "mImportToolStripMenuItem_";
            this.mImportToolStripMenuItem_.Size = new System.Drawing.Size(112, 22);
            this.mImportToolStripMenuItem_.Text = "Import";
            // 
            // mOFXFileToolStripMenuItem_
            // 
            this.mOFXFileToolStripMenuItem_.Name = "mOFXFileToolStripMenuItem_";
            this.mOFXFileToolStripMenuItem_.Size = new System.Drawing.Size(117, 22);
            this.mOFXFileToolStripMenuItem_.Text = "OFX File";
            this.mOFXFileToolStripMenuItem_.Click += new System.EventHandler(this.mOFXFileToolStripMenuItem_Click);
            // 
            // mLogoutToolStripMenuItem_
            // 
            this.mLogoutToolStripMenuItem_.Enabled = false;
            this.mLogoutToolStripMenuItem_.Name = "mLogoutToolStripMenuItem_";
            this.mLogoutToolStripMenuItem_.Size = new System.Drawing.Size(112, 22);
            this.mLogoutToolStripMenuItem_.Text = "Logout";
            this.mLogoutToolStripMenuItem_.Click += new System.EventHandler(this.mLogoutToolStripMenuItem__Click);
            // 
            // mExitToolStripMenuItem_
            // 
            this.mExitToolStripMenuItem_.Name = "mExitToolStripMenuItem_";
            this.mExitToolStripMenuItem_.Size = new System.Drawing.Size(112, 22);
            this.mExitToolStripMenuItem_.Text = "Exit";
            this.mExitToolStripMenuItem_.Click += new System.EventHandler(this.mExitToolStripMenuItem_Click);
            // 
            // mRootHelpToolStripMenuItem_
            // 
            this.mRootHelpToolStripMenuItem_.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mAboutToolStripMenuItem_,
            this.mToolStripSeparator2_,
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
            this.mAboutToolStripMenuItem_.Click += new System.EventHandler(this.mAboutToolStripMenuItem_Click);
            // 
            // mHelpToolStripMenuItem_
            // 
            this.mHelpToolStripMenuItem_.Name = "mHelpToolStripMenuItem_";
            this.mHelpToolStripMenuItem_.Size = new System.Drawing.Size(107, 22);
            this.mHelpToolStripMenuItem_.Text = "Help";
            // 
            // mMainLayoutTable_
            // 
            this.mMainLayoutTable_.ColumnCount = 1;
            this.mMainLayoutTable_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mMainLayoutTable_.Controls.Add(this.mTransactionsPanel_, 0, 1);
            this.mMainLayoutTable_.Controls.Add(this.mSearchPanel_, 0, 0);
            this.mMainLayoutTable_.Controls.Add(this.mSummaryPanel_, 0, 2);
            this.mMainLayoutTable_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mMainLayoutTable_.Location = new System.Drawing.Point(0, 24);
            this.mMainLayoutTable_.Name = "mMainLayoutTable_";
            this.mMainLayoutTable_.RowCount = 3;
            this.mMainLayoutTable_.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mMainLayoutTable_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mMainLayoutTable_.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mMainLayoutTable_.Size = new System.Drawing.Size(1206, 716);
            this.mMainLayoutTable_.TabIndex = 4;
            // 
            // mTransactionsPanel_
            // 
            this.mTransactionsPanel_.AutoSize = true;
            this.mTransactionsPanel_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mTransactionsPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTransactionsPanel_.Location = new System.Drawing.Point(3, 38);
            this.mTransactionsPanel_.MinimumSize = new System.Drawing.Size(500, 250);
            this.mTransactionsPanel_.Name = "mTransactionsPanel_";
            this.mTransactionsPanel_.Size = new System.Drawing.Size(1200, 588);
            this.mTransactionsPanel_.TabIndex = 1;
            // 
            // mSearchPanel_
            // 
            this.mSearchPanel_.AutoSize = true;
            this.mSearchPanel_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mSearchPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mSearchPanel_.Location = new System.Drawing.Point(3, 3);
            this.mSearchPanel_.Name = "mSearchPanel_";
            this.mSearchPanel_.Size = new System.Drawing.Size(1200, 29);
            this.mSearchPanel_.TabIndex = 2;
            // 
            // mSummaryPanel_
            // 
            this.mSummaryPanel_.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.mSummaryPanel_.AutoSize = true;
            this.mSummaryPanel_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mSummaryPanel_.Location = new System.Drawing.Point(3, 632);
            this.mSummaryPanel_.Name = "mSummaryPanel_";
            this.mSummaryPanel_.Size = new System.Drawing.Size(317, 25);
            this.mSummaryPanel_.TabIndex = 0;
            // 
            // MiskoFinanceMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 762);
            this.Controls.Add(this.mMainLayoutTable_);
            this.Controls.Add(this.mStatusStrip_);
            this.Controls.Add(this.mMenuStrip_);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mMenuStrip_;
            this.MinimumSize = new System.Drawing.Size(1200, 758);
            this.Name = "MiskoFinanceMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Misko-Finance";
            this.mStatusStrip_.ResumeLayout(false);
            this.mStatusStrip_.PerformLayout();
            this.mMenuStrip_.ResumeLayout(false);
            this.mMenuStrip_.PerformLayout();
            this.mMainLayoutTable_.ResumeLayout(false);
            this.mMainLayoutTable_.PerformLayout();
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
        private System.Windows.Forms.StatusStrip mStatusStrip_;
        private System.Windows.Forms.ToolStripMenuItem mLogoutToolStripMenuItem_;
        private System.Windows.Forms.ToolStripSeparator mToolStripSeparator1_;
        private System.Windows.Forms.ToolStripSeparator mToolStripSeparator3_;
        private System.Windows.Forms.ToolStripSeparator mToolStripSeparator4_;
        private System.Windows.Forms.ToolStripSeparator mToolStripSeparator2_;
        private System.Windows.Forms.ToolStripProgressBar mMessageStatusBar_;
        private System.Windows.Forms.ToolStripStatusLabel mMessageStatusLbl_;        
        private System.Windows.Forms.TableLayoutPanel mMainLayoutTable_;
        private MiskoFinance.Panels.SummaryPanel mSummaryPanel_;
        private MiskoFinance.Panels.TransactionsPanel mTransactionsPanel_;
        private MiskoFinance.Panels.SearchPanel mSearchPanel_;
    }
}