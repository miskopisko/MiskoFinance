using System;
using System.Windows.Forms;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Enums;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;
using MiskoPersist.Core;
using MiskoPersist.Message.Response;
using MiskoFinance.Controls;

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
            
            mIncomes_.Tag = mExistingIncome_;
            mExpenses_.Tag = mExistingExpenses_;
            mTransfers_.Tag = mExistingTransfers_;
            mOneTime_.Tag = mExistingOneTime_;
            
            mCategories_.SelectedIndexChanged += mCategories_Selected;
        }

        #endregion

        #region Override Methods

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GetCategoriesRQ request = new GetCategoriesRQ();
            request.Operator = MiskoFinanceMain.Instance.Operator.OperatorId;
            ServerConnection.SendRequest(request, GetCategoriesSuccess);
        }

        #endregion

        #region Private Methods

        private void GetCategoriesSuccess(ResponseMessage response)
        {
            mExistingIncome_.DataSource = ((GetCategoriesRS)response).Categories.GetByType(CategoryType.Income, false);
            mExistingExpenses_.DataSource = ((GetCategoriesRS)response).Categories.GetByType(CategoryType.Expense, false);
            mExistingTransfers_.DataSource = ((GetCategoriesRS)response).Categories.GetByType(CategoryType.Transfer, false);
            mExistingOneTime_.DataSource = ((GetCategoriesRS)response).Categories.GetByType(CategoryType.OneTime, false);
            
            mExistingIncome_.ClearSelection();
            mExistingIncome_.CurrentCell = null;
        }

        private void UpdateCategoriesSuccess(ResponseMessage response)
        {
            MiskoFinanceMain.Instance.Operator.Categories = ((UpdateCategoriesRS)response).Categories.GetByStatus(Status.Active);
            MiskoFinanceMain.Instance.SearchPanel.Categories = ((UpdateCategoriesRS)response).Categories.getAllCategories();
            
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
            VwCategory newCategory = mExistingExpenses_.DataSource.AddNew();
            newCategory.CategoryType = CategoryType.Expense;
            newCategory.Status = Status.Active;
            mExistingExpenses_.CurrentCell = mExistingExpenses_.Rows[mExistingExpenses_.Rows.Count - 1].Cells["Name"];
            mExistingExpenses_.BeginEdit(true);
            newCategory.OperatorId = MiskoFinanceMain.Instance.Operator.OperatorId;
        }

        private void mAddTransfer__Click(object sender, EventArgs e)
        {
            VwCategory newCategory = mExistingTransfers_.DataSource.AddNew();
            newCategory.CategoryType = CategoryType.Transfer;
            newCategory.Status = Status.Active;
            mExistingTransfers_.CurrentCell = mExistingTransfers_.Rows[mExistingTransfers_.Rows.Count - 1].Cells["Name"];
            mExistingTransfers_.BeginEdit(true);            
            newCategory.OperatorId = MiskoFinanceMain.Instance.Operator.OperatorId;
        }

        private void mAddIncome__Click(object sender, EventArgs e)
        {
            VwCategory newCategory = mExistingIncome_.DataSource.AddNew();
            newCategory.CategoryType = CategoryType.Income;
            newCategory.Status = Status.Active;
            mExistingIncome_.CurrentCell = mExistingIncome_.Rows[mExistingIncome_.Rows.Count - 1].Cells["Name"];
            mExistingIncome_.BeginEdit(true);
            newCategory.OperatorId = MiskoFinanceMain.Instance.Operator.OperatorId;
        }
        
        private void mAddOneTime__Click(object sender, EventArgs e)
        {
        	VwCategory newCategory = mExistingOneTime_.DataSource.AddNew();
            newCategory.CategoryType = CategoryType.OneTime;
            newCategory.Status = Status.Active;
            mExistingOneTime_.CurrentCell = mExistingOneTime_.Rows[mExistingOneTime_.Rows.Count - 1].Cells["Name"];
            mExistingOneTime_.BeginEdit(true);
            newCategory.OperatorId = MiskoFinanceMain.Instance.Operator.OperatorId;
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
                ServerConnection.SendRequest(request, UpdateCategoriesSuccess);
            }
            else
            {
                Dispose();
            }
        }
        
        private void mCategories_Selected(object sender, EventArgs e)
		{
        	((CategoriesGridView)mCategories_.SelectedTab.Tag).ClearSelection();
        	((CategoriesGridView)mCategories_.SelectedTab.Tag).CurrentCell = null;
		}

        #endregion
    }
}
