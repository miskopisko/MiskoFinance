﻿using System;
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

            existingExpense.FillColumns();
            existingIncome.FillColumns();
            existingTransfer.FillColumns();

            GetCategoriesRQ request = new GetCategoriesRQ();
            request.Operator = MPFinanceMain.Instance.Operator.OperatorId;
            request.Status = Status.NULL;
            MessageProcessor.SendRequest(request, GetCategoriesSuccess);
        }

        #endregion

        #region Private Methods

        private void GetCategoriesSuccess(ResponseMessage response)
        {
            existingIncome.DataSource = ((GetCategoriesRS)response).Categories.GetByType(CategoryType.Income);
            existingExpense.DataSource = ((GetCategoriesRS)response).Categories.GetByType(CategoryType.Expense);
            existingTransfer.DataSource = ((GetCategoriesRS)response).Categories.GetByType(CategoryType.Transfer);
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

        private void AddBtn_Click(object sender, EventArgs e)
        {
            VwCategory newCategory = null;

            if(tabControl.SelectedTab.Equals(ExpenseTab))
            {
                newCategory = (VwCategory)((VwCategories)existingExpense.DataSource).AddNew();
                newCategory.CategoryType = CategoryType.Expense;
                existingExpense.CurrentCell = existingExpense.Rows[existingExpense.Rows.Count - 1].Cells["Name"];
                existingExpense.BeginEdit(true);
            }
            else if (tabControl.SelectedTab.Equals(IncomeTab))
            {
                newCategory = (VwCategory)((VwCategories)existingIncome.DataSource).AddNew();
                newCategory.CategoryType = CategoryType.Income;                
                existingIncome.CurrentCell = existingIncome.Rows[existingIncome.Rows.Count - 1].Cells["Name"];
                existingIncome.BeginEdit(true);
            }
            else if (tabControl.SelectedTab.Equals(TransferTab))
            {
                newCategory = (VwCategory)((VwCategories)existingTransfer.DataSource).AddNew();
                newCategory.CategoryType = CategoryType.Transfer;
                existingTransfer.CurrentCell = existingTransfer.Rows[existingTransfer.Rows.Count - 1].Cells["Name"];
                existingTransfer.BeginEdit(true);
            }

            newCategory.Status = Status.Active;
            newCategory.OperatorId = MPFinanceMain.Instance.Operator.OperatorId;
        }

        private void DoneBtn_Click(object sender, EventArgs e)
        {
            VwCategories categories = new VwCategories();
            categories.AddRange(((VwCategories)existingIncome.DataSource));
            categories.AddRange((VwCategories)existingExpense.DataSource);
            categories.AddRange((VwCategories)existingTransfer.DataSource);

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
