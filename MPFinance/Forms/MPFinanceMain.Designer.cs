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
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.Windows.Forms.GroupBox Transactions;
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Accounts");
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            MPersist.Core.Data.Page page1 = new MPersist.Core.Data.Page();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MPFinanceMain));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.messageStatusBar = new System.Windows.Forms.ToolStripProgressBar();
            this.messageStatusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.recordPageCounts = new System.Windows.Forms.ToolStripStatusLabel();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.oFXFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catagoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.AccountsList = new System.Windows.Forms.TreeView();
            this.MainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.headerLbl = new System.Windows.Forms.Label();
            this.FromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.MoreBtn = new System.Windows.Forms.Button();
            this.txnSearch = new System.Windows.Forms.Button();
            this.ToDatePicker = new System.Windows.Forms.DateTimePicker();
            this.transactionsGridView = new MPFinance.Forms.Controls.TransactionsGridView();
            this.summaryPanel = new MPFinance.Forms.Panels.SummaryPanel();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            Transactions = new System.Windows.Forms.GroupBox();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            Transactions.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.MainLayout.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(104, 6);
            // 
            // Transactions
            // 
            Transactions.Controls.Add(this.transactionsGridView);
            Transactions.Dock = System.Windows.Forms.DockStyle.Fill;
            Transactions.Location = new System.Drawing.Point(253, 62);
            Transactions.Name = "Transactions";
            this.MainLayout.SetRowSpan(Transactions, 2);
            Transactions.Size = new System.Drawing.Size(928, 655);
            Transactions.TabIndex = 1;
            Transactions.TabStop = false;
            Transactions.Text = "Transactions";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "OpenFileDialog";
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messageStatusBar,
            this.messageStatusLbl,
            this.recordPageCounts});
            this.StatusStrip.Location = new System.Drawing.Point(0, 740);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(1184, 22);
            this.StatusStrip.TabIndex = 2;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // messageStatusBar
            // 
            this.messageStatusBar.Maximum = 200;
            this.messageStatusBar.Name = "messageStatusBar";
            this.messageStatusBar.Size = new System.Drawing.Size(200, 16);
            // 
            // messageStatusLbl
            // 
            this.messageStatusLbl.Name = "messageStatusLbl";
            this.messageStatusLbl.Size = new System.Drawing.Size(0, 17);
            // 
            // recordPageCounts
            // 
            this.recordPageCounts.Name = "recordPageCounts";
            this.recordPageCounts.Size = new System.Drawing.Size(967, 17);
            this.recordPageCounts.Spring = true;
            this.recordPageCounts.Text = "0/0";
            this.recordPageCounts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1184, 24);
            this.MenuStrip.TabIndex = 3;
            this.MenuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oFXFileToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(110, 22);
            this.toolStripMenuItem1.Text = "Import";
            // 
            // oFXFileToolStripMenuItem
            // 
            this.oFXFileToolStripMenuItem.Name = "oFXFileToolStripMenuItem";
            this.oFXFileToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.oFXFileToolStripMenuItem.Text = "OFX File";
            this.oFXFileToolStripMenuItem.Click += new System.EventHandler(this.oFXFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(107, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountsToolStripMenuItem,
            this.catagoriesToolStripMenuItem,
            this.toolStripSeparator4,
            this.settingsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // accountsToolStripMenuItem
            // 
            this.accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
            this.accountsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.accountsToolStripMenuItem.Text = "Accounts";
            this.accountsToolStripMenuItem.Click += new System.EventHandler(this.accountsToolStripMenuItem_Click);
            // 
            // catagoriesToolStripMenuItem
            // 
            this.catagoriesToolStripMenuItem.Name = "catagoriesToolStripMenuItem";
            this.catagoriesToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.catagoriesToolStripMenuItem.Text = "Catagories";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(127, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            toolStripSeparator1,
            this.helpToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // AccountsList
            // 
            this.AccountsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AccountsList.Location = new System.Drawing.Point(3, 27);
            this.AccountsList.Name = "AccountsList";
            treeNode1.Checked = true;
            treeNode1.Name = "Accounts";
            treeNode1.Text = "Accounts";
            this.AccountsList.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.MainLayout.SetRowSpan(this.AccountsList, 2);
            this.AccountsList.Size = new System.Drawing.Size(244, 129);
            this.AccountsList.TabIndex = 5;
            this.AccountsList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.AccountsView_AfterSelect);
            // 
            // MainLayout
            // 
            this.MainLayout.ColumnCount = 2;
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayout.Controls.Add(Transactions, 1, 1);
            this.MainLayout.Controls.Add(this.AccountsList, 0, 0);
            this.MainLayout.Controls.Add(this.summaryPanel, 0, 2);
            this.MainLayout.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.MainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayout.Location = new System.Drawing.Point(0, 0);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.Padding = new System.Windows.Forms.Padding(0, 24, 0, 22);
            this.MainLayout.RowCount = 4;
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainLayout.Size = new System.Drawing.Size(1184, 762);
            this.MainLayout.TabIndex = 1;
            // 
            // headerLbl
            // 
            this.headerLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.headerLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.headerLbl.Location = new System.Drawing.Point(3, 0);
            this.headerLbl.Name = "headerLbl";
            this.headerLbl.Size = new System.Drawing.Size(422, 29);
            this.headerLbl.TabIndex = 1;
            this.headerLbl.Text = "headerLbl";
            this.headerLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label6.Location = new System.Drawing.Point(431, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(69, 29);
            label6.TabIndex = 4;
            label6.Text = "From Date:";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FromDatePicker
            // 
            this.FromDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FromDatePicker.Location = new System.Drawing.Point(506, 3);
            this.FromDatePicker.Name = "FromDatePicker";
            this.FromDatePicker.Size = new System.Drawing.Size(89, 20);
            this.FromDatePicker.TabIndex = 5;
            this.FromDatePicker.Value = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            // 
            // label7
            // 
            label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label7.Location = new System.Drawing.Point(601, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(69, 29);
            label7.TabIndex = 6;
            label7.Text = "To Date:";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.MoreBtn);
            this.flowLayoutPanel1.Controls.Add(this.txnSearch);
            this.flowLayoutPanel1.Controls.Add(this.ToDatePicker);
            this.flowLayoutPanel1.Controls.Add(label7);
            this.flowLayoutPanel1.Controls.Add(this.FromDatePicker);
            this.flowLayoutPanel1.Controls.Add(label6);
            this.flowLayoutPanel1.Controls.Add(this.headerLbl);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(253, 27);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(928, 29);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // MoreBtn
            // 
            this.MoreBtn.AutoSize = true;
            this.MoreBtn.Location = new System.Drawing.Point(851, 3);
            this.MoreBtn.Name = "MoreBtn";
            this.MoreBtn.Size = new System.Drawing.Size(74, 23);
            this.MoreBtn.TabIndex = 0;
            this.MoreBtn.Text = "More";
            this.MoreBtn.UseVisualStyleBackColor = true;
            this.MoreBtn.Click += new System.EventHandler(this.MoreBtn_Click);
            // 
            // txnSearch
            // 
            this.txnSearch.AutoSize = true;
            this.txnSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txnSearch.Location = new System.Drawing.Point(771, 3);
            this.txnSearch.Name = "txnSearch";
            this.txnSearch.Size = new System.Drawing.Size(74, 23);
            this.txnSearch.TabIndex = 11;
            this.txnSearch.Text = "Search";
            this.txnSearch.UseVisualStyleBackColor = true;
            this.txnSearch.Click += new System.EventHandler(this.txnSearch_Click);
            // 
            // ToDatePicker
            // 
            this.ToDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ToDatePicker.Location = new System.Drawing.Point(676, 3);
            this.ToDatePicker.Name = "ToDatePicker";
            this.ToDatePicker.Size = new System.Drawing.Size(89, 20);
            this.ToDatePicker.TabIndex = 13;
            // 
            // transactionsGridView
            // 
            this.transactionsGridView.AllowUserToAddRows = false;
            this.transactionsGridView.AllowUserToDeleteRows = false;
            this.transactionsGridView.AllowUserToResizeColumns = false;
            this.transactionsGridView.AllowUserToResizeRows = false;
            this.transactionsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            page1.IncludeRecordCount = true;
            page1.PageNo = 0;
            page1.TotalPageCount = 0;
            page1.TotalRowCount = 0;
            this.transactionsGridView.CurrentPage = page1;
            this.transactionsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transactionsGridView.Location = new System.Drawing.Point(3, 16);
            this.transactionsGridView.Name = "transactionsGridView";
            this.transactionsGridView.RowHeadersVisible = false;
            this.transactionsGridView.Size = new System.Drawing.Size(922, 636);
            this.transactionsGridView.TabIndex = 0;
            this.transactionsGridView.VirtualMode = true;
            // 
            // summaryPanel
            // 
            this.summaryPanel.Location = new System.Drawing.Point(3, 162);
            this.summaryPanel.Name = "summaryPanel";
            this.summaryPanel.Size = new System.Drawing.Size(244, 272);
            this.summaryPanel.TabIndex = 9;
            // 
            // MPFinanceMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 762);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.MainLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "MPFinanceMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MP Finance";
            Transactions.ResumeLayout(false);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.MainLayout.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem oFXFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catagoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar messageStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel messageStatusLbl;
        private System.Windows.Forms.TableLayoutPanel MainLayout;
        private Controls.TransactionsGridView transactionsGridView;
        public System.Windows.Forms.TreeView AccountsList;
        private Panels.SummaryPanel summaryPanel;
        private System.Windows.Forms.ToolStripStatusLabel recordPageCounts;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button MoreBtn;
        private System.Windows.Forms.Button txnSearch;
        public System.Windows.Forms.DateTimePicker FromDatePicker;
        public System.Windows.Forms.DateTimePicker ToDatePicker;
        private System.Windows.Forms.Label headerLbl;
    }
}