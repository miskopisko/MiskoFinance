using System;
using System.Windows.Forms;
using MPersist.Core;
using MPersist.Message.Response;
using MPFinanceCore.Data.Viewed;
using MPFinanceCore.Enums;
using MPFinanceCore.Message.Requests;
using MPFinanceCore.Message.Responses;

namespace MPFinance.Forms
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

            mExistingExpenses_.FillColumns();
            mExistingIncome_.FillColumns();
            mExistingTransfers_.FillColumns();

            GetCategoriesRQ request = new GetCategoriesRQ();
            request.Operator = MPFinanceMain.Instance.Operator.OperatorId;
            request.Status = Status.NULL;
            MessageProcessor.SendRequest(request, GetCategoriesSuccess);
        }

        #endregion

        #region Private Methods

        private void GetCategoriesSuccess(ResponseMessage response)
        {
            mExistingIncome_.DataSource = ((GetCategoriesRS)response).Categories.GetByType(CategoryType.Income);
            mExistingExpenses_.DataSource = ((GetCategoriesRS)response).Categories.GetByType(CategoryType.Expense);
            mExistingTransfers_.DataSource = ((GetCategoriesRS)response).Categories.GetByType(CategoryType.Transfer);
        }

        private void UpdateCategoriesSuccess(ResponseMessage response)
        {
            MPFinanceMain.Instance.Operator.Categories = ((UpdateCategoriesRS)response).Categories.GetByStatus(Status.Active);
            
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
            VwCategory newCategory = (VwCategory)((VwCategories)mExistingExpenses_.DataSource).AddNew();
            newCategory.CategoryType = CategoryType.Expense;
            mExistingExpenses_.CurrentCell = mExistingExpenses_.Rows[mExistingExpenses_.Rows.Count - 1].Cells["Name"];
            mExistingExpenses_.BeginEdit(true);
            newCategory.Status = Status.Active;
            newCategory.OperatorId = MPFinanceMain.Instance.Operator.OperatorId;
        }

        private void mAddTransfer__Click(object sender, EventArgs e)
        {
            VwCategory newCategory = (VwCategory)((VwCategories)mExistingTransfers_.DataSource).AddNew();
            newCategory.CategoryType = CategoryType.Transfer;
            mExistingTransfers_.CurrentCell = mExistingTransfers_.Rows[mExistingTransfers_.Rows.Count - 1].Cells["Name"];
            mExistingTransfers_.BeginEdit(true);
            newCategory.Status = Status.Active;
            newCategory.OperatorId = MPFinanceMain.Instance.Operator.OperatorId;
        }

        private void mAddIncome__Click(object sender, EventArgs e)
        {
            VwCategory newCategory = (VwCategory)((VwCategories)mExistingIncome_.DataSource).AddNew();
            newCategory.CategoryType = CategoryType.Income;
            mExistingIncome_.CurrentCell = mExistingIncome_.Rows[mExistingIncome_.Rows.Count - 1].Cells["Name"];
            mExistingIncome_.BeginEdit(true);
            newCategory.Status = Status.Active;
            newCategory.OperatorId = MPFinanceMain.Instance.Operator.OperatorId;
        }

        private void DoneBtn_Click(object sender, EventArgs e)
        {
            VwCategories categories = new VwCategories();
            categories.AddRange(((VwCategories)mExistingIncome_.DataSource));
            categories.AddRange((VwCategories)mExistingExpenses_.DataSource);
            categories.AddRange((VwCategories)mExistingTransfers_.DataSource);

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
