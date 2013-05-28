namespace MPFinance.Forms
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.IncomeTab = new System.Windows.Forms.TabPage();
            this.existingIncome = new MPFinance.Forms.Controls.CategoriesGridView();
            this.ExpenseTab = new System.Windows.Forms.TabPage();
            this.existingExpense = new MPFinance.Forms.Controls.CategoriesGridView();
            this.TransferTab = new System.Windows.Forms.TabPage();
            this.existingTransfer = new MPFinance.Forms.Controls.CategoriesGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.AddBtn = new System.Windows.Forms.Button();
            this.DoneBtn = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.IncomeTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.existingIncome)).BeginInit();
            this.ExpenseTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.existingExpense)).BeginInit();
            this.TransferTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.existingTransfer)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(312, 267);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.IncomeTab);
            this.tabControl.Controls.Add(this.ExpenseTab);
            this.tabControl.Controls.Add(this.TransferTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(3, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(306, 226);
            this.tabControl.TabIndex = 3;
            // 
            // IncomeTab
            // 
            this.IncomeTab.Controls.Add(this.existingIncome);
            this.IncomeTab.Location = new System.Drawing.Point(4, 22);
            this.IncomeTab.Name = "IncomeTab";
            this.IncomeTab.Padding = new System.Windows.Forms.Padding(3);
            this.IncomeTab.Size = new System.Drawing.Size(298, 200);
            this.IncomeTab.TabIndex = 0;
            this.IncomeTab.Text = "Income";
            this.IncomeTab.UseVisualStyleBackColor = true;
            // 
            // existingIncome
            // 
            this.existingIncome.AllowUserToAddRows = false;
            this.existingIncome.AllowUserToDeleteRows = false;
            this.existingIncome.AllowUserToResizeColumns = false;
            this.existingIncome.AllowUserToResizeRows = false;
            this.existingIncome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.existingIncome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.existingIncome.Location = new System.Drawing.Point(3, 3);
            this.existingIncome.MultiSelect = false;
            this.existingIncome.Name = "existingIncome";
            this.existingIncome.RowHeadersVisible = false;
            this.existingIncome.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.existingIncome.Size = new System.Drawing.Size(292, 194);
            this.existingIncome.TabIndex = 0;
            this.existingIncome.VirtualMode = true;
            // 
            // ExpenseTab
            // 
            this.ExpenseTab.Controls.Add(this.existingExpense);
            this.ExpenseTab.Location = new System.Drawing.Point(4, 22);
            this.ExpenseTab.Name = "ExpenseTab";
            this.ExpenseTab.Padding = new System.Windows.Forms.Padding(3);
            this.ExpenseTab.Size = new System.Drawing.Size(298, 200);
            this.ExpenseTab.TabIndex = 1;
            this.ExpenseTab.Text = "Expense";
            this.ExpenseTab.UseVisualStyleBackColor = true;
            // 
            // existingExpense
            // 
            this.existingExpense.AllowUserToAddRows = false;
            this.existingExpense.AllowUserToDeleteRows = false;
            this.existingExpense.AllowUserToResizeColumns = false;
            this.existingExpense.AllowUserToResizeRows = false;
            this.existingExpense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.existingExpense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.existingExpense.Location = new System.Drawing.Point(3, 3);
            this.existingExpense.MultiSelect = false;
            this.existingExpense.Name = "existingExpense";
            this.existingExpense.RowHeadersVisible = false;
            this.existingExpense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.existingExpense.Size = new System.Drawing.Size(292, 194);
            this.existingExpense.TabIndex = 0;
            this.existingExpense.VirtualMode = true;
            // 
            // TransferTab
            // 
            this.TransferTab.Controls.Add(this.existingTransfer);
            this.TransferTab.Location = new System.Drawing.Point(4, 22);
            this.TransferTab.Name = "TransferTab";
            this.TransferTab.Padding = new System.Windows.Forms.Padding(3);
            this.TransferTab.Size = new System.Drawing.Size(298, 200);
            this.TransferTab.TabIndex = 2;
            this.TransferTab.Text = "Transfer";
            this.TransferTab.UseVisualStyleBackColor = true;
            // 
            // existingTransfer
            // 
            this.existingTransfer.AllowUserToAddRows = false;
            this.existingTransfer.AllowUserToDeleteRows = false;
            this.existingTransfer.AllowUserToResizeColumns = false;
            this.existingTransfer.AllowUserToResizeRows = false;
            this.existingTransfer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.existingTransfer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.existingTransfer.Location = new System.Drawing.Point(3, 3);
            this.existingTransfer.MultiSelect = false;
            this.existingTransfer.Name = "existingTransfer";
            this.existingTransfer.RowHeadersVisible = false;
            this.existingTransfer.Size = new System.Drawing.Size(292, 194);
            this.existingTransfer.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.AddBtn, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.DoneBtn, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 235);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(306, 29);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // AddBtn
            // 
            this.AddBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddBtn.Location = new System.Drawing.Point(39, 3);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(75, 23);
            this.AddBtn.TabIndex = 0;
            this.AddBtn.Text = "Add New";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // DoneBtn
            // 
            this.DoneBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DoneBtn.Location = new System.Drawing.Point(192, 3);
            this.DoneBtn.Name = "DoneBtn";
            this.DoneBtn.Size = new System.Drawing.Size(75, 23);
            this.DoneBtn.TabIndex = 1;
            this.DoneBtn.Text = "Save";
            this.DoneBtn.UseVisualStyleBackColor = true;
            this.DoneBtn.Click += new System.EventHandler(this.DoneBtn_Click);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 267);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditCategoriesDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Edit Categories";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.IncomeTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.existingIncome)).EndInit();
            this.ExpenseTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.existingExpense)).EndInit();
            this.TransferTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.existingTransfer)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button DoneBtn;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage IncomeTab;
        private MPFinance.Forms.Controls.CategoriesGridView existingIncome;
        private System.Windows.Forms.TabPage ExpenseTab;
        private MPFinance.Forms.Controls.CategoriesGridView existingExpense;
        private System.Windows.Forms.TabPage TransferTab;
        private MPFinance.Forms.Controls.CategoriesGridView existingTransfer;
    }
}