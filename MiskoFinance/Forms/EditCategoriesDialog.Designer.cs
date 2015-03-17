namespace MiskoFinance.Forms
{
    partial class EditCategoriesDialog
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditCategoriesDialog));
        	this.mCategories_ = new System.Windows.Forms.TabControl();
        	this.mIncomes_ = new System.Windows.Forms.TabPage();
        	this.mExistingIncome_ = new MiskoFinance.Controls.CategoriesGridView();
        	this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.dgvComboBoxColumn1 = new MiskoFinance.Controls.DGVComboBoxColumn();
        	this.mAddIncome_ = new System.Windows.Forms.Button();
        	this.mExpenses_ = new System.Windows.Forms.TabPage();
        	this.mAddExpense_ = new System.Windows.Forms.Button();
        	this.mExistingExpenses_ = new MiskoFinance.Controls.CategoriesGridView();
        	this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.dgvComboBoxColumn2 = new MiskoFinance.Controls.DGVComboBoxColumn();
        	this.mTransfers_ = new System.Windows.Forms.TabPage();
        	this.mAddTransfer_ = new System.Windows.Forms.Button();
        	this.mExistingTransfers_ = new MiskoFinance.Controls.CategoriesGridView();
        	this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.dgvComboBoxColumn3 = new MiskoFinance.Controls.DGVComboBoxColumn();
        	this.mOK_ = new System.Windows.Forms.Button();
        	this.mCancel_ = new System.Windows.Forms.Button();
        	this.mMainTableLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
        	this.mButtonFlowLayoutPanel_ = new System.Windows.Forms.FlowLayoutPanel();
        	this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
        	this.mCategories_.SuspendLayout();
        	this.mIncomes_.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.mExistingIncome_)).BeginInit();
        	this.mExpenses_.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.mExistingExpenses_)).BeginInit();
        	this.mTransfers_.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.mExistingTransfers_)).BeginInit();
        	this.mMainTableLayoutPanel_.SuspendLayout();
        	this.mButtonFlowLayoutPanel_.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// mCategories_
        	// 
        	this.mCategories_.Controls.Add(this.mIncomes_);
        	this.mCategories_.Controls.Add(this.mExpenses_);
        	this.mCategories_.Controls.Add(this.mTransfers_);
        	this.mCategories_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mCategories_.Location = new System.Drawing.Point(3, 3);
        	this.mCategories_.Name = "mCategories_";
        	this.mCategories_.SelectedIndex = 0;
        	this.mCategories_.Size = new System.Drawing.Size(396, 248);
        	this.mCategories_.TabIndex = 3;
        	// 
        	// mIncomes_
        	// 
        	this.mIncomes_.Controls.Add(this.mExistingIncome_);
        	this.mIncomes_.Controls.Add(this.mAddIncome_);
        	this.mIncomes_.Location = new System.Drawing.Point(4, 22);
        	this.mIncomes_.Name = "mIncomes_";
        	this.mIncomes_.Padding = new System.Windows.Forms.Padding(3);
        	this.mIncomes_.Size = new System.Drawing.Size(388, 222);
        	this.mIncomes_.TabIndex = 0;
        	this.mIncomes_.Text = "Income";
        	this.mIncomes_.UseVisualStyleBackColor = true;
        	// 
        	// mExistingIncome_
        	// 
        	this.mExistingIncome_.AllowUserToAddRows = false;
        	this.mExistingIncome_.AllowUserToDeleteRows = false;
        	this.mExistingIncome_.AllowUserToResizeColumns = false;
        	this.mExistingIncome_.AllowUserToResizeRows = false;
        	this.mExistingIncome_.AutoGenerateColumns = false;
        	this.mExistingIncome_.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.mExistingIncome_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mExistingIncome_.Location = new System.Drawing.Point(3, 3);
        	this.mExistingIncome_.MultiSelect = false;
        	this.mExistingIncome_.Name = "mExistingIncome_";
        	this.mExistingIncome_.RowHeadersVisible = false;
        	this.mExistingIncome_.Size = new System.Drawing.Size(382, 193);
        	this.mExistingIncome_.TabIndex = 0;
        	// 
        	// dataGridViewTextBoxColumn2
        	// 
        	this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        	this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
        	this.dataGridViewTextBoxColumn2.HeaderText = "Category Name";
        	this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
        	// 
        	// dgvComboBoxColumn1
        	// 
        	this.dgvComboBoxColumn1.DataPropertyName = "Status";
        	this.dgvComboBoxColumn1.DisplayMember = "Description";
        	this.dgvComboBoxColumn1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
        	this.dgvComboBoxColumn1.HeaderText = "Status";
        	this.dgvComboBoxColumn1.Name = "dgvComboBoxColumn1";
        	this.dgvComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
        	// 
        	// mAddIncome_
        	// 
        	this.mAddIncome_.AutoSize = true;
        	this.mAddIncome_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.mAddIncome_.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.mAddIncome_.Location = new System.Drawing.Point(3, 196);
        	this.mAddIncome_.Name = "mAddIncome_";
        	this.mAddIncome_.Size = new System.Drawing.Size(382, 23);
        	this.mAddIncome_.TabIndex = 0;
        	this.mAddIncome_.Text = "Add New";
        	this.mAddIncome_.UseVisualStyleBackColor = true;
        	this.mAddIncome_.Click += new System.EventHandler(this.mAddIncome__Click);
        	// 
        	// mExpenses_
        	// 
        	this.mExpenses_.Controls.Add(this.mAddExpense_);
        	this.mExpenses_.Controls.Add(this.mExistingExpenses_);
        	this.mExpenses_.Location = new System.Drawing.Point(4, 22);
        	this.mExpenses_.Name = "mExpenses_";
        	this.mExpenses_.Padding = new System.Windows.Forms.Padding(3);
        	this.mExpenses_.Size = new System.Drawing.Size(388, 222);
        	this.mExpenses_.TabIndex = 1;
        	this.mExpenses_.Text = "Expense";
        	this.mExpenses_.UseVisualStyleBackColor = true;
        	// 
        	// mAddExpense_
        	// 
        	this.mAddExpense_.AutoSize = true;
        	this.mAddExpense_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.mAddExpense_.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.mAddExpense_.Location = new System.Drawing.Point(3, 196);
        	this.mAddExpense_.Name = "mAddExpense_";
        	this.mAddExpense_.Size = new System.Drawing.Size(382, 23);
        	this.mAddExpense_.TabIndex = 1;
        	this.mAddExpense_.Text = "Add New";
        	this.mAddExpense_.UseVisualStyleBackColor = true;
        	this.mAddExpense_.Click += new System.EventHandler(this.mAddExpense__Click);
        	// 
        	// mExistingExpenses_
        	// 
        	this.mExistingExpenses_.AllowUserToAddRows = false;
        	this.mExistingExpenses_.AllowUserToDeleteRows = false;
        	this.mExistingExpenses_.AllowUserToResizeColumns = false;
        	this.mExistingExpenses_.AllowUserToResizeRows = false;
        	this.mExistingExpenses_.AutoGenerateColumns = false;
        	this.mExistingExpenses_.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.mExistingExpenses_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mExistingExpenses_.Location = new System.Drawing.Point(3, 3);
        	this.mExistingExpenses_.MultiSelect = false;
        	this.mExistingExpenses_.Name = "mExistingExpenses_";
        	this.mExistingExpenses_.RowHeadersVisible = false;
        	this.mExistingExpenses_.Size = new System.Drawing.Size(382, 216);
        	this.mExistingExpenses_.TabIndex = 0;
        	// 
        	// dataGridViewTextBoxColumn3
        	// 
        	this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        	this.dataGridViewTextBoxColumn3.DataPropertyName = "Name";
        	this.dataGridViewTextBoxColumn3.HeaderText = "Category Name";
        	this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
        	// 
        	// dgvComboBoxColumn2
        	// 
        	this.dgvComboBoxColumn2.DataPropertyName = "Status";
        	this.dgvComboBoxColumn2.DisplayMember = "Description";
        	this.dgvComboBoxColumn2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
        	this.dgvComboBoxColumn2.HeaderText = "Status";
        	this.dgvComboBoxColumn2.Name = "dgvComboBoxColumn2";
        	this.dgvComboBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
        	// 
        	// mTransfers_
        	// 
        	this.mTransfers_.Controls.Add(this.mAddTransfer_);
        	this.mTransfers_.Controls.Add(this.mExistingTransfers_);
        	this.mTransfers_.Location = new System.Drawing.Point(4, 22);
        	this.mTransfers_.Name = "mTransfers_";
        	this.mTransfers_.Padding = new System.Windows.Forms.Padding(3);
        	this.mTransfers_.Size = new System.Drawing.Size(388, 222);
        	this.mTransfers_.TabIndex = 2;
        	this.mTransfers_.Text = "Transfer";
        	this.mTransfers_.UseVisualStyleBackColor = true;
        	// 
        	// mAddTransfer_
        	// 
        	this.mAddTransfer_.AutoSize = true;
        	this.mAddTransfer_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.mAddTransfer_.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.mAddTransfer_.Location = new System.Drawing.Point(3, 196);
        	this.mAddTransfer_.Name = "mAddTransfer_";
        	this.mAddTransfer_.Size = new System.Drawing.Size(382, 23);
        	this.mAddTransfer_.TabIndex = 1;
        	this.mAddTransfer_.Text = "Add New";
        	this.mAddTransfer_.UseVisualStyleBackColor = true;
        	this.mAddTransfer_.Click += new System.EventHandler(this.mAddTransfer__Click);
        	// 
        	// mExistingTransfers_
        	// 
        	this.mExistingTransfers_.AllowUserToAddRows = false;
        	this.mExistingTransfers_.AllowUserToDeleteRows = false;
        	this.mExistingTransfers_.AllowUserToResizeColumns = false;
        	this.mExistingTransfers_.AllowUserToResizeRows = false;
        	this.mExistingTransfers_.AutoGenerateColumns = false;
        	this.mExistingTransfers_.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.mExistingTransfers_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mExistingTransfers_.Location = new System.Drawing.Point(3, 3);
        	this.mExistingTransfers_.MultiSelect = false;
        	this.mExistingTransfers_.Name = "mExistingTransfers_";
        	this.mExistingTransfers_.RowHeadersVisible = false;
        	this.mExistingTransfers_.Size = new System.Drawing.Size(382, 216);
        	this.mExistingTransfers_.TabIndex = 0;
        	// 
        	// dataGridViewTextBoxColumn4
        	// 
        	this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        	this.dataGridViewTextBoxColumn4.DataPropertyName = "Name";
        	this.dataGridViewTextBoxColumn4.HeaderText = "Category Name";
        	this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
        	// 
        	// dgvComboBoxColumn3
        	// 
        	this.dgvComboBoxColumn3.DataPropertyName = "Status";
        	this.dgvComboBoxColumn3.DisplayMember = "Description";
        	this.dgvComboBoxColumn3.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
        	this.dgvComboBoxColumn3.HeaderText = "Status";
        	this.dgvComboBoxColumn3.Name = "dgvComboBoxColumn3";
        	this.dgvComboBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
        	// 
        	// mOK_
        	// 
        	this.mOK_.Anchor = System.Windows.Forms.AnchorStyles.None;
        	this.mOK_.Location = new System.Drawing.Point(237, 3);
        	this.mOK_.Name = "mOK_";
        	this.mOK_.Size = new System.Drawing.Size(75, 23);
        	this.mOK_.TabIndex = 1;
        	this.mOK_.Text = "OK";
        	this.mOK_.UseVisualStyleBackColor = true;
        	this.mOK_.Click += new System.EventHandler(this.DoneBtn_Click);
        	// 
        	// mCancel_
        	// 
        	this.mCancel_.Anchor = System.Windows.Forms.AnchorStyles.None;
        	this.mCancel_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.mCancel_.Location = new System.Drawing.Point(318, 3);
        	this.mCancel_.Name = "mCancel_";
        	this.mCancel_.Size = new System.Drawing.Size(75, 23);
        	this.mCancel_.TabIndex = 2;
        	this.mCancel_.Text = "Cancel";
        	this.mCancel_.UseVisualStyleBackColor = true;
        	this.mCancel_.Click += new System.EventHandler(this.mCancel__Click);
        	// 
        	// mMainTableLayoutPanel_
        	// 
        	this.mMainTableLayoutPanel_.ColumnCount = 1;
        	this.mMainTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        	this.mMainTableLayoutPanel_.Controls.Add(this.mCategories_, 0, 0);
        	this.mMainTableLayoutPanel_.Controls.Add(this.mButtonFlowLayoutPanel_, 0, 1);
        	this.mMainTableLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mMainTableLayoutPanel_.Location = new System.Drawing.Point(0, 0);
        	this.mMainTableLayoutPanel_.Name = "mMainTableLayoutPanel_";
        	this.mMainTableLayoutPanel_.RowCount = 2;
        	this.mMainTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        	this.mMainTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mMainTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        	this.mMainTableLayoutPanel_.Size = new System.Drawing.Size(402, 289);
        	this.mMainTableLayoutPanel_.TabIndex = 5;
        	// 
        	// mButtonFlowLayoutPanel_
        	// 
        	this.mButtonFlowLayoutPanel_.AutoSize = true;
        	this.mButtonFlowLayoutPanel_.Controls.Add(this.mCancel_);
        	this.mButtonFlowLayoutPanel_.Controls.Add(this.mOK_);
        	this.mButtonFlowLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mButtonFlowLayoutPanel_.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
        	this.mButtonFlowLayoutPanel_.Location = new System.Drawing.Point(3, 257);
        	this.mButtonFlowLayoutPanel_.Name = "mButtonFlowLayoutPanel_";
        	this.mButtonFlowLayoutPanel_.Size = new System.Drawing.Size(396, 29);
        	this.mButtonFlowLayoutPanel_.TabIndex = 4;
        	// 
        	// dataGridViewTextBoxColumn1
        	// 
        	this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        	this.dataGridViewTextBoxColumn1.DataPropertyName = "Category.Name";
        	this.dataGridViewTextBoxColumn1.HeaderText = "Category Name";
        	this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
        	// 
        	// dataGridViewButtonColumn1
        	// 
        	this.dataGridViewButtonColumn1.HeaderText = "Delete";
        	this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
        	// 
        	// EditCategoriesDialog
        	// 
        	this.AcceptButton = this.mOK_;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.CancelButton = this.mCancel_;
        	this.ClientSize = new System.Drawing.Size(402, 289);
        	this.Controls.Add(this.mMainTableLayoutPanel_);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "EditCategoriesDialog";
        	this.ShowInTaskbar = false;
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        	this.Text = "Add/Edit Categories";
        	this.mCategories_.ResumeLayout(false);
        	this.mIncomes_.ResumeLayout(false);
        	this.mIncomes_.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.mExistingIncome_)).EndInit();
        	this.mExpenses_.ResumeLayout(false);
        	this.mExpenses_.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.mExistingExpenses_)).EndInit();
        	this.mTransfers_.ResumeLayout(false);
        	this.mTransfers_.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.mExistingTransfers_)).EndInit();
        	this.mMainTableLayoutPanel_.ResumeLayout(false);
        	this.mMainTableLayoutPanel_.PerformLayout();
        	this.mButtonFlowLayoutPanel_.ResumeLayout(false);
        	this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.Button mAddIncome_;
        private System.Windows.Forms.Button mOK_;
        private System.Windows.Forms.TabControl mCategories_;
        private System.Windows.Forms.TabPage mIncomes_;
        private System.Windows.Forms.TabPage mExpenses_;
        private System.Windows.Forms.TabPage mTransfers_;
        private MiskoFinance.Controls.CategoriesGridView mExistingTransfers_;
        private MiskoFinance.Controls.CategoriesGridView mExistingExpenses_;
        private MiskoFinance.Controls.CategoriesGridView mExistingIncome_;
        private System.Windows.Forms.Button mCancel_;
        private System.Windows.Forms.TableLayoutPanel mMainTableLayoutPanel_;
        private System.Windows.Forms.FlowLayoutPanel mButtonFlowLayoutPanel_;
        private System.Windows.Forms.Button mAddExpense_;
        private System.Windows.Forms.Button mAddTransfer_;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private MiskoFinance.Controls.DGVComboBoxColumn dgvComboBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private MiskoFinance.Controls.DGVComboBoxColumn dgvComboBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private MiskoFinance.Controls.DGVComboBoxColumn dgvComboBoxColumn3;
    }
}