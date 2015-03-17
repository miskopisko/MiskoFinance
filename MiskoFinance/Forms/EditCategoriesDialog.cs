using System;
using System.Windows.Forms;
using MiskoPersist.Core;
using MiskoPersist.Message.Response;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Enums;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;

namespace MiskoFinance.Forms
{
    public partial class EditCategoriesDialog : Form
    {
        private static Logger Log = Logger.GetInstance(typeof(EditCategoriesDialog));

        #region Fields

        

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

            GetCategoriesRQ request = new GetCategoriesRQ();
            request.Operator = MiskoFinanceMain.Instance.Operator.OperatorId;
            request.Status = Status.NULL;
            MessageProcessor.SendRequest(request, GetCategoriesSuccess);
        }

        #endregion

        #region Private Methods

        private void GetCategoriesSuccess(ResponseMessage response)
        {
            mExistingIncome_.Categories = ((GetCategoriesRS)response).Categories.GetByType(CategoryType.Income, false);
            mExistingExpenses_.Categories = ((GetCategoriesRS)response).Categories.GetByType(CategoryType.Expense, false);
            mExistingTransfers_.Categories = ((GetCategoriesRS)response).Categories.GetByType(CategoryType.Transfer, false);
        }

        private void UpdateCategoriesSuccess(ResponseMessage response)
        {
            MiskoFinanceMain.Instance.Operator.Categories = ((UpdateCategoriesRS)response).Categories.GetByStatus(Status.Active);
            
            Dispose();
        }

        #endregion

        #region Event Listenners

        private void mCancel__Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void mAddExpense__Click(object sender, EventArgs e)
        {
            VwCategory newCategory = (VwCategory)((VwCategories)mExistingExpenses_.Categories).AddNew();
            newCategory.CategoryType = CategoryType.Expense;
            mExistingExpenses_.CurrentCell = mExistingExpenses_.Rows[mExistingExpenses_.Rows.Count - 1].Cells["Name"];
            mExistingExpenses_.BeginEdit(true);
            newCategory.Status = Status.Active;
            newCategory.OperatorId = MiskoFinanceMain.Instance.Operator.OperatorId;
        }

        private void mAddTransfer__Click(object sender, EventArgs e)
        {
            VwCategory newCategory = (VwCategory)((VwCategories)mExistingTransfers_.Categories).AddNew();
            newCategory.CategoryType = CategoryType.Transfer;
            mExistingTransfers_.CurrentCell = mExistingTransfers_.Rows[mExistingTransfers_.Rows.Count - 1].Cells["Name"];
            mExistingTransfers_.BeginEdit(true);
            newCategory.Status = Status.Active;
            newCategory.OperatorId = MiskoFinanceMain.Instance.Operator.OperatorId;
        }

        private void mAddIncome__Click(object sender, EventArgs e)
        {
            VwCategory newCategory = (VwCategory)((VwCategories)mExistingIncome_.Categories).AddNew();
            newCategory.CategoryType = CategoryType.Income;
            mExistingIncome_.CurrentCell = mExistingIncome_.Rows[mExistingIncome_.Rows.Count - 1].Cells["Name"];
            mExistingIncome_.BeginEdit(true);
            newCategory.Status = Status.Active;
            newCategory.OperatorId = MiskoFinanceMain.Instance.Operator.OperatorId;
        }

        private void DoneBtn_Click(object sender, EventArgs e)
        {
            VwCategories categories = new VwCategories();
            categories.AddRange(((VwCategories)mExistingIncome_.Categories));
            categories.AddRange((VwCategories)mExistingExpenses_.Categories);
            categories.AddRange((VwCategories)mExistingTransfers_.Categories);

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
