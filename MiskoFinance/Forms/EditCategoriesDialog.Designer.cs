using System;
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
        protected override void Dispose(Boolean disposing)
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
        	this.mIncomeLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
        	this.mAddIncome_ = new System.Windows.Forms.Button();
        	this.mExistingIncome_ = new MiskoFinance.Controls.CategoriesGridView();
        	this.mExpenses_ = new System.Windows.Forms.TabPage();
        	this.mExpenseLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
        	this.mAddExpense_ = new System.Windows.Forms.Button();
        	this.mExistingExpenses_ = new MiskoFinance.Controls.CategoriesGridView();
        	this.mTransfers_ = new System.Windows.Forms.TabPage();
        	this.mTransferLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
        	this.mAddTransfer_ = new System.Windows.Forms.Button();
        	this.mExistingTransfers_ = new MiskoFinance.Controls.CategoriesGridView();
        	this.mOneTime_ = new System.Windows.Forms.TabPage();
        	this.mOneTimeLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
        	this.mAddOneTime_ = new System.Windows.Forms.Button();
        	this.mExistingOneTime_ = new MiskoFinance.Controls.CategoriesGridView();
        	this.mOK_ = new System.Windows.Forms.Button();
        	this.mCancel_ = new System.Windows.Forms.Button();
        	this.mButtonFlowLayoutPanel_ = new System.Windows.Forms.FlowLayoutPanel();
        	this.mMainTableLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
        	this.mCategories_.SuspendLayout();
        	this.mIncomes_.SuspendLayout();
        	this.mIncomeLayoutPanel_.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.mExistingIncome_)).BeginInit();
        	this.mExpenses_.SuspendLayout();
        	this.mExpenseLayoutPanel_.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.mExistingExpenses_)).BeginInit();
        	this.mTransfers_.SuspendLayout();
        	this.mTransferLayoutPanel_.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.mExistingTransfers_)).BeginInit();
        	this.mOneTime_.SuspendLayout();
        	this.mOneTimeLayoutPanel_.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.mExistingOneTime_)).BeginInit();
        	this.mButtonFlowLayoutPanel_.SuspendLayout();
        	this.mMainTableLayoutPanel_.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// mCategories_
        	// 
        	this.mCategories_.Controls.Add(this.mIncomes_);
        	this.mCategories_.Controls.Add(this.mExpenses_);
        	this.mCategories_.Controls.Add(this.mTransfers_);
        	this.mCategories_.Controls.Add(this.mOneTime_);
        	this.mCategories_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mCategories_.Location = new System.Drawing.Point(3, 3);
        	this.mCategories_.Name = "mCategories_";
        	this.mCategories_.SelectedIndex = 0;
        	this.mCategories_.Size = new System.Drawing.Size(466, 308);
        	this.mCategories_.TabIndex = 3;
        	// 
        	// mIncomes_
        	// 
        	this.mIncomes_.Controls.Add(this.mIncomeLayoutPanel_);
        	this.mIncomes_.Location = new System.Drawing.Point(4, 22);
        	this.mIncomes_.Name = "mIncomes_";
        	this.mIncomes_.Padding = new System.Windows.Forms.Padding(3);
        	this.mIncomes_.Size = new System.Drawing.Size(458, 282);
        	this.mIncomes_.TabIndex = 0;
        	this.mIncomes_.Text = "Income";
        	this.mIncomes_.UseVisualStyleBackColor = true;
        	// 
        	// mIncomeLayoutPanel_
        	// 
        	this.mIncomeLayoutPanel_.AutoSize = true;
        	this.mIncomeLayoutPanel_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.mIncomeLayoutPanel_.ColumnCount = 1;
        	this.mIncomeLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        	this.mIncomeLayoutPanel_.Controls.Add(this.mAddIncome_, 0, 1);
        	this.mIncomeLayoutPanel_.Controls.Add(this.mExistingIncome_, 0, 0);
        	this.mIncomeLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mIncomeLayoutPanel_.Location = new System.Drawing.Point(3, 3);
        	this.mIncomeLayoutPanel_.Name = "mIncomeLayoutPanel_";
        	this.mIncomeLayoutPanel_.RowCount = 2;
        	this.mIncomeLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        	this.mIncomeLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mIncomeLayoutPanel_.Size = new System.Drawing.Size(452, 276);
        	this.mIncomeLayoutPanel_.TabIndex = 2;
        	// 
        	// mAddIncome_
        	// 
        	this.mAddIncome_.AutoSize = true;
        	this.mAddIncome_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.mAddIncome_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mAddIncome_.Location = new System.Drawing.Point(3, 250);
        	this.mAddIncome_.Name = "mAddIncome_";
        	this.mAddIncome_.Size = new System.Drawing.Size(446, 23);
        	this.mAddIncome_.TabIndex = 0;
        	this.mAddIncome_.Text = "Add New";
        	this.mAddIncome_.UseVisualStyleBackColor = true;
        	this.mAddIncome_.Click += new System.EventHandler(this.mAddIncome__Click);
        	// 
        	// mExistingIncome_
        	// 
        	this.mExistingIncome_.AllowUserToAddRows = false;
        	this.mExistingIncome_.AllowUserToDeleteRows = false;
        	this.mExistingIncome_.AllowUserToResizeColumns = false;
        	this.mExistingIncome_.AllowUserToResizeRows = false;
        	this.mExistingIncome_.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.mExistingIncome_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mExistingIncome_.Location = new System.Drawing.Point(3, 3);
        	this.mExistingIncome_.MultiSelect = false;
        	this.mExistingIncome_.Name = "mExistingIncome_";
        	this.mExistingIncome_.RowHeadersVisible = false;
        	this.mExistingIncome_.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        	this.mExistingIncome_.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.mExistingIncome_.Size = new System.Drawing.Size(446, 241);
        	this.mExistingIncome_.TabIndex = 1;
        	// 
        	// mExpenses_
        	// 
        	this.mExpenses_.Controls.Add(this.mExpenseLayoutPanel_);
        	this.mExpenses_.Location = new System.Drawing.Point(4, 22);
        	this.mExpenses_.Name = "mExpenses_";
        	this.mExpenses_.Padding = new System.Windows.Forms.Padding(3);
        	this.mExpenses_.Size = new System.Drawing.Size(458, 282);
        	this.mExpenses_.TabIndex = 1;
        	this.mExpenses_.Text = "Expense";
        	this.mExpenses_.UseVisualStyleBackColor = true;
        	// 
        	// mExpenseLayoutPanel_
        	// 
        	this.mExpenseLayoutPanel_.AutoSize = true;
        	this.mExpenseLayoutPanel_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.mExpenseLayoutPanel_.ColumnCount = 1;
        	this.mExpenseLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        	this.mExpenseLayoutPanel_.Controls.Add(this.mAddExpense_, 0, 1);
        	this.mExpenseLayoutPanel_.Controls.Add(this.mExistingExpenses_, 0, 0);
        	this.mExpenseLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mExpenseLayoutPanel_.Location = new System.Drawing.Point(3, 3);
        	this.mExpenseLayoutPanel_.Name = "mExpenseLayoutPanel_";
        	this.mExpenseLayoutPanel_.RowCount = 2;
        	this.mExpenseLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        	this.mExpenseLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mExpenseLayoutPanel_.Size = new System.Drawing.Size(452, 276);
        	this.mExpenseLayoutPanel_.TabIndex = 2;
        	// 
        	// mAddExpense_
        	// 
        	this.mAddExpense_.AutoSize = true;
        	this.mAddExpense_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.mAddExpense_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mAddExpense_.Location = new System.Drawing.Point(3, 250);
        	this.mAddExpense_.Name = "mAddExpense_";
        	this.mAddExpense_.Size = new System.Drawing.Size(446, 23);
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
        	this.mExistingExpenses_.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.mExistingExpenses_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mExistingExpenses_.Location = new System.Drawing.Point(3, 3);
        	this.mExistingExpenses_.MultiSelect = false;
        	this.mExistingExpenses_.Name = "mExistingExpenses_";
        	this.mExistingExpenses_.RowHeadersVisible = false;
        	this.mExistingExpenses_.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        	this.mExistingExpenses_.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.mExistingExpenses_.Size = new System.Drawing.Size(446, 241);
        	this.mExistingExpenses_.TabIndex = 0;
        	// 
        	// mTransfers_
        	// 
        	this.mTransfers_.Controls.Add(this.mTransferLayoutPanel_);
        	this.mTransfers_.Location = new System.Drawing.Point(4, 22);
        	this.mTransfers_.Name = "mTransfers_";
        	this.mTransfers_.Padding = new System.Windows.Forms.Padding(3);
        	this.mTransfers_.Size = new System.Drawing.Size(458, 282);
        	this.mTransfers_.TabIndex = 2;
        	this.mTransfers_.Text = "Transfer";
        	this.mTransfers_.UseVisualStyleBackColor = true;
        	// 
        	// mTransferLayoutPanel_
        	// 
        	this.mTransferLayoutPanel_.AutoSize = true;
        	this.mTransferLayoutPanel_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.mTransferLayoutPanel_.ColumnCount = 1;
        	this.mTransferLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        	this.mTransferLayoutPanel_.Controls.Add(this.mAddTransfer_, 0, 1);
        	this.mTransferLayoutPanel_.Controls.Add(this.mExistingTransfers_, 0, 0);
        	this.mTransferLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mTransferLayoutPanel_.Location = new System.Drawing.Point(3, 3);
        	this.mTransferLayoutPanel_.Name = "mTransferLayoutPanel_";
        	this.mTransferLayoutPanel_.RowCount = 2;
        	this.mTransferLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        	this.mTransferLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mTransferLayoutPanel_.Size = new System.Drawing.Size(452, 276);
        	this.mTransferLayoutPanel_.TabIndex = 2;
        	// 
        	// mAddTransfer_
        	// 
        	this.mAddTransfer_.AutoSize = true;
        	this.mAddTransfer_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.mAddTransfer_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mAddTransfer_.Location = new System.Drawing.Point(3, 250);
        	this.mAddTransfer_.Name = "mAddTransfer_";
        	this.mAddTransfer_.Size = new System.Drawing.Size(446, 23);
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
        	this.mExistingTransfers_.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.mExistingTransfers_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mExistingTransfers_.Location = new System.Drawing.Point(3, 3);
        	this.mExistingTransfers_.MultiSelect = false;
        	this.mExistingTransfers_.Name = "mExistingTransfers_";
        	this.mExistingTransfers_.RowHeadersVisible = false;
        	this.mExistingTransfers_.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        	this.mExistingTransfers_.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.mExistingTransfers_.Size = new System.Drawing.Size(446, 241);
        	this.mExistingTransfers_.TabIndex = 0;
        	// 
        	// mOneTime_
        	// 
        	this.mOneTime_.Controls.Add(this.mOneTimeLayoutPanel_);
        	this.mOneTime_.Location = new System.Drawing.Point(4, 22);
        	this.mOneTime_.Name = "mOneTime_";
        	this.mOneTime_.Padding = new System.Windows.Forms.Padding(3);
        	this.mOneTime_.Size = new System.Drawing.Size(458, 282);
        	this.mOneTime_.TabIndex = 3;
        	this.mOneTime_.Text = "One Time";
        	this.mOneTime_.UseVisualStyleBackColor = true;
        	// 
        	// mOneTimeLayoutPanel_
        	// 
        	this.mOneTimeLayoutPanel_.AutoSize = true;
        	this.mOneTimeLayoutPanel_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.mOneTimeLayoutPanel_.ColumnCount = 1;
        	this.mOneTimeLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        	this.mOneTimeLayoutPanel_.Controls.Add(this.mAddOneTime_, 0, 1);
        	this.mOneTimeLayoutPanel_.Controls.Add(this.mExistingOneTime_, 0, 0);
        	this.mOneTimeLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mOneTimeLayoutPanel_.Location = new System.Drawing.Point(3, 3);
        	this.mOneTimeLayoutPanel_.Name = "mOneTimeLayoutPanel_";
        	this.mOneTimeLayoutPanel_.RowCount = 2;
        	this.mOneTimeLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        	this.mOneTimeLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mOneTimeLayoutPanel_.Size = new System.Drawing.Size(452, 276);
        	this.mOneTimeLayoutPanel_.TabIndex = 2;
        	// 
        	// mAddOneTime_
        	// 
        	this.mAddOneTime_.AutoSize = true;
        	this.mAddOneTime_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.mAddOneTime_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mAddOneTime_.Location = new System.Drawing.Point(3, 250);
        	this.mAddOneTime_.Name = "mAddOneTime_";
        	this.mAddOneTime_.Size = new System.Drawing.Size(446, 23);
        	this.mAddOneTime_.TabIndex = 1;
        	this.mAddOneTime_.Text = "Add New";
        	this.mAddOneTime_.UseVisualStyleBackColor = true;
        	this.mAddOneTime_.Click += new System.EventHandler(this.mAddOneTime__Click);
        	// 
        	// mExistingOneTime_
        	// 
        	this.mExistingOneTime_.AllowUserToAddRows = false;
        	this.mExistingOneTime_.AllowUserToDeleteRows = false;
        	this.mExistingOneTime_.AllowUserToResizeColumns = false;
        	this.mExistingOneTime_.AllowUserToResizeRows = false;
        	this.mExistingOneTime_.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.mExistingOneTime_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mExistingOneTime_.Location = new System.Drawing.Point(3, 3);
        	this.mExistingOneTime_.MultiSelect = false;
        	this.mExistingOneTime_.Name = "mExistingOneTime_";
        	this.mExistingOneTime_.RowHeadersVisible = false;
        	this.mExistingOneTime_.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        	this.mExistingOneTime_.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.mExistingOneTime_.Size = new System.Drawing.Size(446, 241);
        	this.mExistingOneTime_.TabIndex = 0;
        	// 
        	// mOK_
        	// 
        	this.mOK_.Anchor = System.Windows.Forms.AnchorStyles.None;
        	this.mOK_.AutoSize = true;
        	this.mOK_.Location = new System.Drawing.Point(307, 3);
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
        	this.mCancel_.Location = new System.Drawing.Point(388, 3);
        	this.mCancel_.Name = "mCancel_";
        	this.mCancel_.Size = new System.Drawing.Size(75, 23);
        	this.mCancel_.TabIndex = 2;
        	this.mCancel_.Text = "Cancel";
        	this.mCancel_.UseVisualStyleBackColor = true;
        	this.mCancel_.Click += new System.EventHandler(this.mCancel__Click);
        	// 
        	// mButtonFlowLayoutPanel_
        	// 
        	this.mButtonFlowLayoutPanel_.AutoSize = true;
        	this.mButtonFlowLayoutPanel_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.mButtonFlowLayoutPanel_.Controls.Add(this.mCancel_);
        	this.mButtonFlowLayoutPanel_.Controls.Add(this.mOK_);
        	this.mButtonFlowLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mButtonFlowLayoutPanel_.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
        	this.mButtonFlowLayoutPanel_.Location = new System.Drawing.Point(3, 317);
        	this.mButtonFlowLayoutPanel_.Name = "mButtonFlowLayoutPanel_";
        	this.mButtonFlowLayoutPanel_.Size = new System.Drawing.Size(466, 29);
        	this.mButtonFlowLayoutPanel_.TabIndex = 4;
        	// 
        	// mMainTableLayoutPanel_
        	// 
        	this.mMainTableLayoutPanel_.AutoSize = true;
        	this.mMainTableLayoutPanel_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.mMainTableLayoutPanel_.ColumnCount = 1;
        	this.mMainTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        	this.mMainTableLayoutPanel_.Controls.Add(this.mButtonFlowLayoutPanel_, 0, 1);
        	this.mMainTableLayoutPanel_.Controls.Add(this.mCategories_, 0, 0);
        	this.mMainTableLayoutPanel_.Location = new System.Drawing.Point(0, 0);
        	this.mMainTableLayoutPanel_.Name = "mMainTableLayoutPanel_";
        	this.mMainTableLayoutPanel_.RowCount = 2;
        	this.mMainTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        	this.mMainTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mMainTableLayoutPanel_.Size = new System.Drawing.Size(472, 349);
        	this.mMainTableLayoutPanel_.TabIndex = 5;
        	// 
        	// EditCategoriesDialog
        	// 
        	this.AcceptButton = this.mOK_;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.AutoSize = true;
        	this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.CancelButton = this.mCancel_;
        	this.ClientSize = new System.Drawing.Size(490, 370);
        	this.Controls.Add(this.mMainTableLayoutPanel_);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
        	this.mIncomeLayoutPanel_.ResumeLayout(false);
        	this.mIncomeLayoutPanel_.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.mExistingIncome_)).EndInit();
        	this.mExpenses_.ResumeLayout(false);
        	this.mExpenses_.PerformLayout();
        	this.mExpenseLayoutPanel_.ResumeLayout(false);
        	this.mExpenseLayoutPanel_.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.mExistingExpenses_)).EndInit();
        	this.mTransfers_.ResumeLayout(false);
        	this.mTransfers_.PerformLayout();
        	this.mTransferLayoutPanel_.ResumeLayout(false);
        	this.mTransferLayoutPanel_.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.mExistingTransfers_)).EndInit();
        	this.mOneTime_.ResumeLayout(false);
        	this.mOneTime_.PerformLayout();
        	this.mOneTimeLayoutPanel_.ResumeLayout(false);
        	this.mOneTimeLayoutPanel_.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.mExistingOneTime_)).EndInit();
        	this.mButtonFlowLayoutPanel_.ResumeLayout(false);
        	this.mButtonFlowLayoutPanel_.PerformLayout();
        	this.mMainTableLayoutPanel_.ResumeLayout(false);
        	this.mMainTableLayoutPanel_.PerformLayout();
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mOK_;
        private System.Windows.Forms.Button mCancel_;
        private System.Windows.Forms.TabControl mCategories_;
        private System.Windows.Forms.TabPage mIncomes_;
        private System.Windows.Forms.TabPage mExpenses_;
        private System.Windows.Forms.TabPage mTransfers_;
        private System.Windows.Forms.TabPage mOneTime_;
        private MiskoFinance.Controls.CategoriesGridView mExistingIncome_;
        private MiskoFinance.Controls.CategoriesGridView mExistingTransfers_;
        private MiskoFinance.Controls.CategoriesGridView mExistingExpenses_;  
        private MiskoFinance.Controls.CategoriesGridView mExistingOneTime_;
        private System.Windows.Forms.FlowLayoutPanel mButtonFlowLayoutPanel_;
        private System.Windows.Forms.Button mAddIncome_;
        private System.Windows.Forms.Button mAddExpense_;
        private System.Windows.Forms.Button mAddTransfer_;
        private System.Windows.Forms.Button mAddOneTime_;        
        private System.Windows.Forms.TableLayoutPanel mIncomeLayoutPanel_;
        private System.Windows.Forms.TableLayoutPanel mExpenseLayoutPanel_;
        private System.Windows.Forms.TableLayoutPanel mTransferLayoutPanel_;
        private System.Windows.Forms.TableLayoutPanel mOneTimeLayoutPanel_;
        private System.Windows.Forms.TableLayoutPanel mMainTableLayoutPanel_;
    }
}