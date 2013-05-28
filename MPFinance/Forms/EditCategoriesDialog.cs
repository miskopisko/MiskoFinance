﻿using MPersist.Core;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Enums;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;
using System;
using System.Data;
using System.Windows.Forms;

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

            GetCategoriesRQ getCategories = new GetCategoriesRQ();
            getCategories.Operator = Program.Operator;
            MessageProcessor.SendRequest(getCategories, GetCategoriesSuccess);

            base.OnLoad(e);
        }

        private void GetCategoriesSuccess(AbstractResponse Response)
        {
            GetCategoriesRS response = Response as GetCategoriesRS;

            existingIncome.DataSource = response.IncomeCategories;
            existingExpense.DataSource = response.ExpenseCategories;
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
            }
            else if (tabControl.SelectedTab.Equals(IncomeTab))
            {
                newCategory = (Category)((Categories)existingIncome.DataSource).AddNew();
                newCategory.CategoryType = CategoryType.Income;
                existingIncome.Rows[existingIncome.Rows.Count - 1].Selected = true;
            }

            newCategory.Operator = Program.Operator;
        }

        private void DoneBtn_Click(object sender, EventArgs e)
        {
            UpdateCategoriesRQ request = new UpdateCategoriesRQ();
            request.ExpenseCategories = (Categories)existingExpense.DataSource;
            request.IncomeCategories = (Categories)existingIncome.DataSource;            
            MessageProcessor.SendRequest(request, UpdateCategorySuccess);
        }
    }
}
