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
            System.Windows.Forms.GroupBox Transactions;
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Accounts");
            this.TransactionsView = new System.Windows.Forms.DataGridView();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.AccountsView = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.AccountHeader = new System.Windows.Forms.Label();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportTxns = new System.Windows.Forms.Button();
            Transactions = new System.Windows.Forms.GroupBox();
            Transactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionsView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Transactions
            // 
            Transactions.Controls.Add(this.TransactionsView);
            Transactions.Dock = System.Windows.Forms.DockStyle.Fill;
            Transactions.Location = new System.Drawing.Point(194, 112);
            Transactions.Name = "Transactions";
            Transactions.Size = new System.Drawing.Size(915, 345);
            Transactions.TabIndex = 1;
            Transactions.TabStop = false;
            Transactions.Text = "Transactions";
            // 
            // TransactionsView
            // 
            this.TransactionsView.AllowUserToAddRows = false;
            this.TransactionsView.AllowUserToDeleteRows = false;
            this.TransactionsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TransactionsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TransactionsView.Location = new System.Drawing.Point(3, 16);
            this.TransactionsView.Name = "TransactionsView";
            this.TransactionsView.ReadOnly = true;
            this.TransactionsView.Size = new System.Drawing.Size(909, 326);
            this.TransactionsView.TabIndex = 0;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "OpenFileDialog";
            // 
            // AccountsView
            // 
            this.AccountsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AccountsView.Location = new System.Drawing.Point(3, 77);
            this.AccountsView.Name = "AccountsView";
            treeNode1.Name = "Accounts";
            treeNode1.Text = "Accounts";
            this.AccountsView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tableLayoutPanel1.SetRowSpan(this.AccountsView, 2);
            this.AccountsView.Size = new System.Drawing.Size(185, 380);
            this.AccountsView.TabIndex = 0;
            this.AccountsView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.AccountsView_AfterSelect);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.17626F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.82374F));
            this.tableLayoutPanel1.Controls.Add(this.AccountsView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(Transactions, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ToolStrip, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.AccountHeader, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ImportTxns, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 24, 0, 22);
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1112, 517);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // ToolStrip
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.ToolStrip, 2);
            this.ToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStrip.Location = new System.Drawing.Point(0, 24);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(1112, 50);
            this.ToolStrip.TabIndex = 2;
            this.ToolStrip.Text = "ToolStrip";
            // 
            // AccountHeader
            // 
            this.AccountHeader.AutoSize = true;
            this.AccountHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AccountHeader.Location = new System.Drawing.Point(194, 74);
            this.AccountHeader.Name = "AccountHeader";
            this.AccountHeader.Size = new System.Drawing.Size(915, 35);
            this.AccountHeader.TabIndex = 3;
            this.AccountHeader.Text = "label1";
            this.AccountHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusStrip
            // 
            this.StatusStrip.Location = new System.Drawing.Point(0, 495);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(1112, 22);
            this.StatusStrip.TabIndex = 2;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1112, 24);
            this.MenuStrip.TabIndex = 3;
            this.MenuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.toolStripSeparator1,
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
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(104, 6);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // ImportTxns
            // 
            this.ImportTxns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImportTxns.Location = new System.Drawing.Point(3, 463);
            this.ImportTxns.Name = "ImportTxns";
            this.ImportTxns.Size = new System.Drawing.Size(185, 29);
            this.ImportTxns.TabIndex = 4;
            this.ImportTxns.Text = "Import Txns";
            this.ImportTxns.UseVisualStyleBackColor = true;
            this.ImportTxns.Click += new System.EventHandler(this.ImportTxns_Click);
            // 
            // MPFinanceMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 517);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "MPFinanceMain";
            this.Text = "MPFinance";
            this.Load += new System.EventHandler(this.MPFinanceMain_Load);
            Transactions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TransactionsView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TreeView AccountsView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView TransactionsView;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.Label AccountHeader;
        private System.Windows.Forms.Button ImportTxns;

    }
}