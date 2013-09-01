namespace MPFinance.Forms
{
    partial class ImportNewTransactionsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportNewTransactionsDialog));
            this.mTableLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.mImportBtn_ = new System.Windows.Forms.Button();
            this.mNextBtn_ = new System.Windows.Forms.Button();
            this.mBackBtn_ = new System.Windows.Forms.Button();
            this.mOpenFileDialog_ = new System.Windows.Forms.OpenFileDialog();
            this.mTableLayoutPanel_.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mTableLayoutPanel_
            // 
            this.mTableLayoutPanel_.AutoSize = true;
            this.mTableLayoutPanel_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mTableLayoutPanel_.ColumnCount = 1;
            this.mTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mTableLayoutPanel_.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.mTableLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTableLayoutPanel_.Location = new System.Drawing.Point(0, 0);
            this.mTableLayoutPanel_.Name = "mTableLayoutPanel_";
            this.mTableLayoutPanel_.RowCount = 2;
            this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.mTableLayoutPanel_.Size = new System.Drawing.Size(423, 92);
            this.mTableLayoutPanel_.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 55);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(417, 34);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.mImportBtn_);
            this.flowLayoutPanel1.Controls.Add(this.mNextBtn_);
            this.flowLayoutPanel1.Controls.Add(this.mBackBtn_);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(169, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(245, 28);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // mImportBtn_
            // 
            this.mImportBtn_.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.mImportBtn_.Location = new System.Drawing.Point(167, 3);
            this.mImportBtn_.Name = "mImportBtn_";
            this.mImportBtn_.Size = new System.Drawing.Size(75, 23);
            this.mImportBtn_.TabIndex = 2;
            this.mImportBtn_.Text = "Import";
            this.mImportBtn_.UseVisualStyleBackColor = true;
            this.mImportBtn_.Click += new System.EventHandler(this.ImportBtn_Click);
            // 
            // mNextBtn_
            // 
            this.mNextBtn_.Location = new System.Drawing.Point(86, 3);
            this.mNextBtn_.Name = "mNextBtn_";
            this.mNextBtn_.Size = new System.Drawing.Size(75, 23);
            this.mNextBtn_.TabIndex = 1;
            this.mNextBtn_.Text = "Next";
            this.mNextBtn_.UseVisualStyleBackColor = true;
            this.mNextBtn_.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // mBackBtn_
            // 
            this.mBackBtn_.Location = new System.Drawing.Point(5, 3);
            this.mBackBtn_.Name = "mBackBtn_";
            this.mBackBtn_.Size = new System.Drawing.Size(75, 23);
            this.mBackBtn_.TabIndex = 0;
            this.mBackBtn_.Text = "Back";
            this.mBackBtn_.UseVisualStyleBackColor = true;
            this.mBackBtn_.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // mOpenFileDialog_
            // 
            this.mOpenFileDialog_.Filter = "OFX Files|*.ofx";
            // 
            // ImportNewTransactionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 92);
            this.Controls.Add(this.mTableLayoutPanel_);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportNewTransactionsDialog";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MPFinanceDialog";
            this.mTableLayoutPanel_.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mTableLayoutPanel_;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button mImportBtn_;
        public System.Windows.Forms.Button mNextBtn_;
        public System.Windows.Forms.Button mBackBtn_;
        private System.Windows.Forms.OpenFileDialog mOpenFileDialog_;

    }
}