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

            GetCategoriesRQ request = new GetCategoriesRQ();
            request.Operator = MPFinanceMain.Instance.Operator.Id;
            request.Status = Status.NULL;
            MessageProcessor.SendRequest(request, GetCategoriesSuccess);
        }

        #endregion

        #region Private Methods

        private void GetCategoriesSuccess(AbstractResponse response)
        {
            existingIncome.DataSource = ((GetCategoriesRS)response).Categories.GetByType(CategoryType.Income);
            existingExpense.DataSource = ((GetCategoriesRS)response).Categories.GetByType(CategoryType.Expense);
            existingTransfer.DataSource = ((GetCategoriesRS)response).Categories.GetByType(CategoryType.Transfer);
        }

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
                existingExpense.CurrentCell = existingExpense.Rows[existingExpense.Rows.Count - 1].Cells["Name"];
                existingExpense.BeginEdit(true);
            }
            else if (tabControl.SelectedTab.Equals(IncomeTab))
            {
                newCategory = (Category)((Categories)existingIncome.DataSource).AddNew();
                newCategory.CategoryType = CategoryType.Income;                
                existingIncome.CurrentCell = existingIncome.Rows[existingIncome.Rows.Count - 1].Cells["Name"];
                existingIncome.BeginEdit(true);
            }
            else if (tabControl.SelectedTab.Equals(TransferTab))
            {
                newCategory = (Category)((Categories)existingTransfer.DataSource).AddNew();
                newCategory.CategoryType = CategoryType.Transfer;
                existingTransfer.CurrentCell = existingTransfer.Rows[existingTransfer.Rows.Count - 1].Cells["Name"];
                existingTransfer.BeginEdit(true);
            }

            newCategory.Status = Status.Active;
            newCategory.Operator = MPFinanceMain.Instance.Operator.Id;
        }

        private void DoneBtn_Click(object sender, EventArgs e)
        {
            Categories categories = new Categories();
            categories.AddRange((Categories)existingIncome.DataSource);
            categories.AddRange((Categories)existingExpense.DataSource);
            categories.AddRange((Categories)existingTransfer.DataSource);

            if (categories.Count > 0)
            {
                UpdateCategoriesRQ request = new UpdateCategoriesRQ();
                request.Categories = categories;
                MessageProcessor.SendRequest(request, UpdateCategoriesSuccess);
            }
            else
            {
                Dispose();
            }
        }

        #endregion
    }
}
