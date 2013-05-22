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
            this.importedTransactionsGridView = new MPFinance.Forms.Controls.ImportedTransactionsGridView();
            ((System.ComponentModel.ISupportInitialize)(this.importedTransactionsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // importedTransactionsGridView
            // 
            this.importedTransactionsGridView.AllowUserToAddRows = false;
            this.importedTransactionsGridView.AllowUserToDeleteRows = false;
            this.importedTransactionsGridView.AllowUserToResizeColumns = false;
            this.importedTransactionsGridView.AllowUserToResizeRows = false;
            this.importedTransactionsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.importedTransactionsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.importedTransactionsGridView.Location = new System.Drawing.Point(0, 0);
            this.importedTransactionsGridView.Name = "importedTransactionsGridView";
            this.importedTransactionsGridView.RowHeadersVisible = false;
            this.importedTransactionsGridView.Size = new System.Drawing.Size(1059, 482);
            this.importedTransactionsGridView.TabIndex = 1;
            // 
            // ChooseTransactionsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.importedTransactionsGridView);
            this.Name = "ChooseTransactionsPanel";
            this.Size = new System.Drawing.Size(1059, 482);
            ((System.ComponentModel.ISupportInitialize)(this.importedTransactionsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Controls.ImportedTransactionsGridView importedTransactionsGridView;



    }
}
