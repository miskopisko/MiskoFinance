using MPersist.Core;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Enums;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;
using System;
using System.Windows.Forms;

namespace MPFinance.Forms
{
    public partial class EditCategoriesDialog : Form
    {
        private static Logger Log = Logger.GetInstance(typeof(EditCategoriesDialog));

        #region Variable Declarations

        

        #endregion

        #region Properties

        

        #endregion

        #region Constructor

        public EditCategoriesDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region Override Methods

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            existingExpense.FillColumns();
            existingIncome.FillColumns();
            existingTransfer.FillColumns();

            existingIncome.DataSource = MPFinanceMain.Instance.Operator.Categories.GetByType(CategoryType.Income);
            existingExpense.DataSource = MPFinanceMain.Instance.Operator.Categories.GetByType(CategoryType.Expense);
            existingTransfer.DataSource = MPFinanceMain.Instance.Operator.Categories.GetByType(CategoryType.Transfer);
        }

        #endregion

        #region Private Methods

        private void UpdateCategoriesSuccess(AbstractResponse response)
        {
            MPFinanceMain.Instance.Operator.Categories = ((UpdateCategoriesRS)response).Categories.GetByStatus(Status.Active);
            
            Dispose();
        }

        #endregion

        #region Event Listenners

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

            newCategory.Operator = MPFinanceMain.Instance.Operator;
        }

        private void DoneBtn_Click(object sender, EventArgs e)
        {
            Categories categories = new Categories();
            categories.AddRange((Categories)existingIncome.DataSource);
            categories.AddRange((Categories)existingExpense.DataSource);
            categories.AddRange((Categories)existingTransfer.DataSource);

            UpdateCategoriesRQ request = new UpdateCategoriesRQ();
            request.Categories = categories;
            MessageProcessor.SendRequest(request, UpdateCategoriesSuccess);
        }

        #endregion
    }
}
