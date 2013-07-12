namespace MPFinance.Forms.Panels
{
    partial class ChooseTransactionsPanel
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
            this.mImportedTransactionsGridView_ = new MPFinance.Forms.Controls.ImportedTransactionsGridView();
            ((System.ComponentModel.ISupportInitialize)(this.mImportedTransactionsGridView_)).BeginInit();
            this.SuspendLayout();
            // 
            // mImportedTransactionsGridView_
            // 
            this.mImportedTransactionsGridView_.AllowUserToAddRows = false;
            this.mImportedTransactionsGridView_.AllowUserToDeleteRows = false;
            this.mImportedTransactionsGridView_.AllowUserToResizeColumns = false;
            this.mImportedTransactionsGridView_.AllowUserToResizeRows = false;
            this.mImportedTransactionsGridView_.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mImportedTransactionsGridView_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mImportedTransactionsGridView_.Location = new System.Drawing.Point(0, 0);
            this.mImportedTransactionsGridView_.Name = "mImportedTransactionsGridView_";
            this.mImportedTransactionsGridView_.RowHeadersVisible = false;
            this.mImportedTransactionsGridView_.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mImportedTransactionsGridView_.Size = new System.Drawing.Size(1059, 482);
            this.mImportedTransactionsGridView_.TabIndex = 1;
            // 
            // ChooseTransactionsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mImportedTransactionsGridView_);
            this.Name = "ChooseTransactionsPanel";
            this.Size = new System.Drawing.Size(1059, 482);
            ((System.ComponentModel.ISupportInitialize)(this.mImportedTransactionsGridView_)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Controls.ImportedTransactionsGridView mImportedTransactionsGridView_;



    }
}
