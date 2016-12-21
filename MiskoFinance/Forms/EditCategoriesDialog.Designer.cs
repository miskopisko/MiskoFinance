
namespace MiskoFinance.Forms
{
	partial class EditCategoriesDialog
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TableLayoutPanel mIncomeTableLayout_;
		private System.Windows.Forms.Button mAddIncome_;
		private MiskoFinance.Controls.CategoriesGridView mExistingIncome_;
		private System.Windows.Forms.TableLayoutPanel mExpenseLayoutPanel_;
		private System.Windows.Forms.Button mAddExpense_;
		private MiskoFinance.Controls.CategoriesGridView mExistingExpenses_;
		private System.Windows.Forms.TableLayoutPanel mTransfersLayoutPanel_;
		private System.Windows.Forms.Button mAddTransfer_;
		private MiskoFinance.Controls.CategoriesGridView mExistingTransfers_;
		private System.Windows.Forms.TableLayoutPanel mOneTimeLayoutPanel_;
		private System.Windows.Forms.Button mAddOneTime_;
		private MiskoFinance.Controls.CategoriesGridView mExistingOneTime_;
		private System.Windows.Forms.TabControl mCategories_;
		private System.Windows.Forms.TabPage mIncomes_;
		private System.Windows.Forms.TabPage mExpenses_;
		private System.Windows.Forms.TabPage mTransfers_;
		private System.Windows.Forms.TabPage mOneTime_;
		private System.Windows.Forms.TableLayoutPanel mMainLayoutPanel_;
		private System.Windows.Forms.FlowLayoutPanel mButtonFlowLayoutPanel_;
		private System.Windows.Forms.Button mOK_;
		private System.Windows.Forms.Button mCancel_;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditCategoriesDialog));
			this.mIncomeTableLayout_ = new System.Windows.Forms.TableLayoutPanel();
			this.mAddIncome_ = new System.Windows.Forms.Button();
			this.mExistingIncome_ = new MiskoFinance.Controls.CategoriesGridView();
			this.mExpenseLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
			this.mAddExpense_ = new System.Windows.Forms.Button();
			this.mExistingExpenses_ = new MiskoFinance.Controls.CategoriesGridView();
			this.mTransfersLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
			this.mAddTransfer_ = new System.Windows.Forms.Button();
			this.mExistingTransfers_ = new MiskoFinance.Controls.CategoriesGridView();
			this.mOneTimeLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
			this.mAddOneTime_ = new System.Windows.Forms.Button();
			this.mExistingOneTime_ = new MiskoFinance.Controls.CategoriesGridView();
			this.mCategories_ = new System.Windows.Forms.TabControl();
			this.mIncomes_ = new System.Windows.Forms.TabPage();
			this.mExpenses_ = new System.Windows.Forms.TabPage();
			this.mTransfers_ = new System.Windows.Forms.TabPage();
			this.mOneTime_ = new System.Windows.Forms.TabPage();
			this.mMainLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
			this.mButtonFlowLayoutPanel_ = new System.Windows.Forms.FlowLayoutPanel();
			this.mCancel_ = new System.Windows.Forms.Button();
			this.mOK_ = new System.Windows.Forms.Button();
			this.mIncomeTableLayout_.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mExistingIncome_)).BeginInit();
			this.mExpenseLayoutPanel_.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mExistingExpenses_)).BeginInit();
			this.mTransfersLayoutPanel_.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mExistingTransfers_)).BeginInit();
			this.mOneTimeLayoutPanel_.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mExistingOneTime_)).BeginInit();
			this.mCategories_.SuspendLayout();
			this.mIncomes_.SuspendLayout();
			this.mExpenses_.SuspendLayout();
			this.mTransfers_.SuspendLayout();
			this.mOneTime_.SuspendLayout();
			this.mMainLayoutPanel_.SuspendLayout();
			this.mButtonFlowLayoutPanel_.SuspendLayout();
			this.SuspendLayout();
			// 
			// mIncomeTableLayout_
			// 
			this.mIncomeTableLayout_.ColumnCount = 1;
			this.mIncomeTableLayout_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mIncomeTableLayout_.Controls.Add(this.mAddIncome_, 0, 1);
			this.mIncomeTableLayout_.Controls.Add(this.mExistingIncome_, 0, 0);
			this.mIncomeTableLayout_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mIncomeTableLayout_.Location = new System.Drawing.Point(3, 3);
			this.mIncomeTableLayout_.Name = "mIncomeTableLayout_";
			this.mIncomeTableLayout_.RowCount = 2;
			this.mIncomeTableLayout_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mIncomeTableLayout_.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mIncomeTableLayout_.Size = new System.Drawing.Size(314, 232);
			this.mIncomeTableLayout_.TabIndex = 0;
			// 
			// mAddIncome_
			// 
			this.mAddIncome_.AutoSize = true;
			this.mAddIncome_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.mAddIncome_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mAddIncome_.Location = new System.Drawing.Point(3, 206);
			this.mAddIncome_.Name = "mAddIncome_";
			this.mAddIncome_.Size = new System.Drawing.Size(308, 23);
			this.mAddIncome_.TabIndex = 0;
			this.mAddIncome_.Text = "Add";
			this.mAddIncome_.UseVisualStyleBackColor = true;
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
			this.mExistingIncome_.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.mExistingIncome_.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.mExistingIncome_.Size = new System.Drawing.Size(308, 197);
			this.mExistingIncome_.TabIndex = 1;
			// 
			// mExpenseLayoutPanel_
			// 
			this.mExpenseLayoutPanel_.ColumnCount = 1;
			this.mExpenseLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mExpenseLayoutPanel_.Controls.Add(this.mAddExpense_, 0, 1);
			this.mExpenseLayoutPanel_.Controls.Add(this.mExistingExpenses_, 0, 0);
			this.mExpenseLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mExpenseLayoutPanel_.Location = new System.Drawing.Point(3, 3);
			this.mExpenseLayoutPanel_.Name = "mExpenseLayoutPanel_";
			this.mExpenseLayoutPanel_.RowCount = 2;
			this.mExpenseLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mExpenseLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mExpenseLayoutPanel_.Size = new System.Drawing.Size(319, 239);
			this.mExpenseLayoutPanel_.TabIndex = 1;
			// 
			// mAddExpense_
			// 
			this.mAddExpense_.AutoSize = true;
			this.mAddExpense_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.mAddExpense_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mAddExpense_.Location = new System.Drawing.Point(3, 213);
			this.mAddExpense_.Name = "mAddExpense_";
			this.mAddExpense_.Size = new System.Drawing.Size(313, 23);
			this.mAddExpense_.TabIndex = 0;
			this.mAddExpense_.Text = "Add";
			this.mAddExpense_.UseVisualStyleBackColor = true;
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
			this.mExistingExpenses_.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.mExistingExpenses_.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.mExistingExpenses_.Size = new System.Drawing.Size(313, 204);
			this.mExistingExpenses_.TabIndex = 1;
			// 
			// mTransfersLayoutPanel_
			// 
			this.mTransfersLayoutPanel_.ColumnCount = 1;
			this.mTransfersLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mTransfersLayoutPanel_.Controls.Add(this.mAddTransfer_, 0, 1);
			this.mTransfersLayoutPanel_.Controls.Add(this.mExistingTransfers_, 0, 0);
			this.mTransfersLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mTransfersLayoutPanel_.Location = new System.Drawing.Point(3, 3);
			this.mTransfersLayoutPanel_.Name = "mTransfersLayoutPanel_";
			this.mTransfersLayoutPanel_.RowCount = 2;
			this.mTransfersLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mTransfersLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mTransfersLayoutPanel_.Size = new System.Drawing.Size(319, 239);
			this.mTransfersLayoutPanel_.TabIndex = 2;
			// 
			// mAddTransfer_
			// 
			this.mAddTransfer_.AutoSize = true;
			this.mAddTransfer_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.mAddTransfer_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mAddTransfer_.Location = new System.Drawing.Point(3, 213);
			this.mAddTransfer_.Name = "mAddTransfer_";
			this.mAddTransfer_.Size = new System.Drawing.Size(313, 23);
			this.mAddTransfer_.TabIndex = 0;
			this.mAddTransfer_.Text = "Add";
			this.mAddTransfer_.UseVisualStyleBackColor = true;
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
			this.mExistingTransfers_.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.mExistingTransfers_.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.mExistingTransfers_.Size = new System.Drawing.Size(313, 204);
			this.mExistingTransfers_.TabIndex = 1;
			// 
			// mOneTimeLayoutPanel_
			// 
			this.mOneTimeLayoutPanel_.ColumnCount = 1;
			this.mOneTimeLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mOneTimeLayoutPanel_.Controls.Add(this.mAddOneTime_, 0, 1);
			this.mOneTimeLayoutPanel_.Controls.Add(this.mExistingOneTime_, 0, 0);
			this.mOneTimeLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mOneTimeLayoutPanel_.Location = new System.Drawing.Point(3, 3);
			this.mOneTimeLayoutPanel_.Name = "mOneTimeLayoutPanel_";
			this.mOneTimeLayoutPanel_.RowCount = 2;
			this.mOneTimeLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mOneTimeLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mOneTimeLayoutPanel_.Size = new System.Drawing.Size(319, 239);
			this.mOneTimeLayoutPanel_.TabIndex = 3;
			// 
			// mAddOneTime_
			// 
			this.mAddOneTime_.AutoSize = true;
			this.mAddOneTime_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.mAddOneTime_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mAddOneTime_.Location = new System.Drawing.Point(3, 213);
			this.mAddOneTime_.Name = "mAddOneTime_";
			this.mAddOneTime_.Size = new System.Drawing.Size(313, 23);
			this.mAddOneTime_.TabIndex = 0;
			this.mAddOneTime_.Text = "Add";
			this.mAddOneTime_.UseVisualStyleBackColor = true;
			// 
			// mExistingOneTime_
			// 
			this.mExistingOneTime_.AllowUserToAddRows = false;
			this.mExistingOneTime_.AllowUserToDeleteRows = false;
			this.mExistingOneTime_.AllowUserToResizeColumns = false;
			this.mExistingOneTime_.AllowUserToResizeRows = false;
			this.mExistingOneTime_.AutoGenerateColumns = false;
			this.mExistingOneTime_.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.mExistingOneTime_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mExistingOneTime_.Location = new System.Drawing.Point(3, 3);
			this.mExistingOneTime_.MultiSelect = false;
			this.mExistingOneTime_.Name = "mExistingOneTime_";
			this.mExistingOneTime_.RowHeadersVisible = false;
			this.mExistingOneTime_.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.mExistingOneTime_.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.mExistingOneTime_.Size = new System.Drawing.Size(313, 204);
			this.mExistingOneTime_.TabIndex = 1;
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
			this.mCategories_.Size = new System.Drawing.Size(328, 264);
			this.mCategories_.TabIndex = 4;
			// 
			// mIncomes_
			// 
			this.mIncomes_.Controls.Add(this.mIncomeTableLayout_);
			this.mIncomes_.Location = new System.Drawing.Point(4, 22);
			this.mIncomes_.Name = "mIncomes_";
			this.mIncomes_.Padding = new System.Windows.Forms.Padding(3);
			this.mIncomes_.Size = new System.Drawing.Size(320, 238);
			this.mIncomes_.TabIndex = 0;
			this.mIncomes_.Text = "Income";
			this.mIncomes_.UseVisualStyleBackColor = true;
			// 
			// mExpenses_
			// 
			this.mExpenses_.Controls.Add(this.mExpenseLayoutPanel_);
			this.mExpenses_.Location = new System.Drawing.Point(4, 22);
			this.mExpenses_.Name = "mExpenses_";
			this.mExpenses_.Padding = new System.Windows.Forms.Padding(3);
			this.mExpenses_.Size = new System.Drawing.Size(325, 245);
			this.mExpenses_.TabIndex = 1;
			this.mExpenses_.Text = "Expense";
			this.mExpenses_.UseVisualStyleBackColor = true;
			// 
			// mTransfers_
			// 
			this.mTransfers_.Controls.Add(this.mTransfersLayoutPanel_);
			this.mTransfers_.Location = new System.Drawing.Point(4, 22);
			this.mTransfers_.Name = "mTransfers_";
			this.mTransfers_.Padding = new System.Windows.Forms.Padding(3);
			this.mTransfers_.Size = new System.Drawing.Size(325, 245);
			this.mTransfers_.TabIndex = 2;
			this.mTransfers_.Text = "Transfer";
			this.mTransfers_.UseVisualStyleBackColor = true;
			// 
			// mOneTime_
			// 
			this.mOneTime_.Controls.Add(this.mOneTimeLayoutPanel_);
			this.mOneTime_.Location = new System.Drawing.Point(4, 22);
			this.mOneTime_.Name = "mOneTime_";
			this.mOneTime_.Padding = new System.Windows.Forms.Padding(3);
			this.mOneTime_.Size = new System.Drawing.Size(325, 245);
			this.mOneTime_.TabIndex = 3;
			this.mOneTime_.Text = "One Time";
			this.mOneTime_.UseVisualStyleBackColor = true;
			// 
			// mMainLayoutPanel_
			// 
			this.mMainLayoutPanel_.ColumnCount = 1;
			this.mMainLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mMainLayoutPanel_.Controls.Add(this.mButtonFlowLayoutPanel_, 0, 1);
			this.mMainLayoutPanel_.Controls.Add(this.mCategories_, 0, 0);
			this.mMainLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mMainLayoutPanel_.Location = new System.Drawing.Point(0, 0);
			this.mMainLayoutPanel_.Name = "mMainLayoutPanel_";
			this.mMainLayoutPanel_.RowCount = 2;
			this.mMainLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mMainLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mMainLayoutPanel_.Size = new System.Drawing.Size(334, 305);
			this.mMainLayoutPanel_.TabIndex = 5;
			// 
			// mButtonFlowLayoutPanel_
			// 
			this.mButtonFlowLayoutPanel_.AutoSize = true;
			this.mButtonFlowLayoutPanel_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.mButtonFlowLayoutPanel_.Controls.Add(this.mCancel_);
			this.mButtonFlowLayoutPanel_.Controls.Add(this.mOK_);
			this.mButtonFlowLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mButtonFlowLayoutPanel_.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.mButtonFlowLayoutPanel_.Location = new System.Drawing.Point(3, 273);
			this.mButtonFlowLayoutPanel_.Name = "mButtonFlowLayoutPanel_";
			this.mButtonFlowLayoutPanel_.Size = new System.Drawing.Size(328, 29);
			this.mButtonFlowLayoutPanel_.TabIndex = 0;
			// 
			// mCancel_
			// 
			this.mCancel_.Location = new System.Drawing.Point(250, 3);
			this.mCancel_.Name = "mCancel_";
			this.mCancel_.Size = new System.Drawing.Size(75, 23);
			this.mCancel_.TabIndex = 1;
			this.mCancel_.Text = "Cancel";
			this.mCancel_.UseVisualStyleBackColor = true;
			// 
			// mOK_
			// 
			this.mOK_.Location = new System.Drawing.Point(169, 3);
			this.mOK_.Name = "mOK_";
			this.mOK_.Size = new System.Drawing.Size(75, 23);
			this.mOK_.TabIndex = 0;
			this.mOK_.Text = "OK";
			this.mOK_.UseVisualStyleBackColor = true;
			// 
			// EditCategoriesDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 305);
			this.Controls.Add(this.mMainLayoutPanel_);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EditCategoriesDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Categories";
			this.mIncomeTableLayout_.ResumeLayout(false);
			this.mIncomeTableLayout_.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.mExistingIncome_)).EndInit();
			this.mExpenseLayoutPanel_.ResumeLayout(false);
			this.mExpenseLayoutPanel_.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.mExistingExpenses_)).EndInit();
			this.mTransfersLayoutPanel_.ResumeLayout(false);
			this.mTransfersLayoutPanel_.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.mExistingTransfers_)).EndInit();
			this.mOneTimeLayoutPanel_.ResumeLayout(false);
			this.mOneTimeLayoutPanel_.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.mExistingOneTime_)).EndInit();
			this.mCategories_.ResumeLayout(false);
			this.mIncomes_.ResumeLayout(false);
			this.mExpenses_.ResumeLayout(false);
			this.mTransfers_.ResumeLayout(false);
			this.mOneTime_.ResumeLayout(false);
			this.mMainLayoutPanel_.ResumeLayout(false);
			this.mMainLayoutPanel_.PerformLayout();
			this.mButtonFlowLayoutPanel_.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
