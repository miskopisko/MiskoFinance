using System;
using System.Windows.Forms;
using MPersist.Core;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Enums;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;

namespace MPFinance.Forms
{
    public partial class EditCategoriesDialog : Form
    {
        public EditCategoriesDialog()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            existingExpense.FillColumns();
            existingIncome.FillColumns();
            existingTransfer.FillColumns();

            GetCategoriesRQ getCategories = new GetCategoriesRQ();
            getCategories.Operator = Program.GetOperator();
            MessageProcessor.SendRequest(getCategories, GetCategoriesSuccess);

            base.OnLoad(e);
        }

        private void GetCategoriesSuccess(AbstractResponse Response)
        {
            GetCategoriesRS response = Response as GetCategoriesRS;

            existingIncome.DataSource = response.IncomeCategories;
            existingExpense.DataSource = response.ExpenseCategories;
            existingTransfer.DataSource = response.TransferCategories;
        }

        private void UpdateCategorySuccess(AbstractResponse Response)
        {
            Dispose();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            Category newCategory = null;

            if(tabControl.SelectedTab.Equals(ExpenseTab))
            {
                newCategory = (Category)((Categories)existingExpense.DataSource).AddNew();
                newCategory.CategoryType = CategoryType.Expense;
                existingExpense.Rows[existingExpense.Rows.Count - 1].Selected = true;
                existingExpense.Rows[existingExpense.Rows.Count - 1].Cells["Status"].Value = Status.Active;
            }
            else if (tabControl.SelectedTab.Equals(IncomeTab))
            {
                newCategory = (Category)((Categories)existingIncome.DataSource).AddNew();
                newCategory.CategoryType = CategoryType.Income;
                existingIncome.Rows[existingIncome.Rows.Count - 1].Selected = true;
                existingIncome.Rows[existingIncome.Rows.Count - 1].Cells["Status"].Value = Status.Active;
            }
            else if (tabControl.SelectedTab.Equals(TransferTab))
            {
                newCategory = (Category)((Categories)existingTransfer.DataSource).AddNew();
                newCategory.CategoryType = CategoryType.Transfer;
                existingTransfer.Rows[existingTransfer.Rows.Count - 1].Selected = true;
                existingTransfer.Rows[existingTransfer.Rows.Count - 1].Cells["Status"].Value = Status.Active;
            }

            newCategory.Operator = Program.GetOperator();
        }

        private void DoneBtn_Click(object sender, EventArgs e)
        {
            UpdateCategoriesRQ request = new UpdateCategoriesRQ();
            request.ExpenseCategories = (Categories)existingExpense.DataSource;
            request.IncomeCategories = (Categories)existingIncome.DataSource;
            request.TransferCategories = (Categories)existingTransfer.DataSource;
            MessageProcessor.SendRequest(request, UpdateCategorySuccess);
        }
    }
}
