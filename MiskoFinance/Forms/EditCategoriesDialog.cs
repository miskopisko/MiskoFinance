﻿using System;
using System.Windows.Forms;
using log4net;
using MiskoFinance.Controls;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Enums;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;
using MiskoPersist.Core;
using MiskoPersist.Message.Responses;

namespace MiskoFinance.Forms
{
	public partial class EditCategoriesDialog : Form
    {
        private static ILog Log = LogManager.GetLogger(typeof(EditCategoriesDialog));

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
            
            Enabled = false;

            GetCategoriesRQ request = new GetCategoriesRQ();
            request.Operator = MiskoFinanceMain.Instance.Operator.OperatorId;
            Server.SendRequest(request, GetCategoriesSuccess);
            
            CenterToParent();
        }

        #endregion

        #region Private Methods

        private void GetCategoriesSuccess(ResponseMessage response)
        {
        	Enabled = true;
        	
        	mExistingIncome_.DataSource.Add(((GetCategoriesRS)response).Categories.GetByType(CategoryType.Income));
        	mExistingExpenses_.DataSource.Add(((GetCategoriesRS)response).Categories.GetByType(CategoryType.Expense));
        	mExistingTransfers_.DataSource.Add(((GetCategoriesRS)response).Categories.GetByType(CategoryType.Transfer));
        	mExistingOneTime_.DataSource.Add(((GetCategoriesRS)response).Categories.GetByType(CategoryType.OneTime));
            
            mExistingIncome_.ClearSelection();
            mExistingIncome_.CurrentCell = null;
        }

        private void UpdateCategoriesSuccess(ResponseMessage response)
        {
        	UpdateCategoriesRS rs = response as UpdateCategoriesRS;
        	if(rs != null)
        	{
        		MiskoFinanceMain.Instance.Operator.Categories = rs.Categories;
        		MiskoFinanceMain.Instance.SearchPanel.Categories = rs.Categories.GetByStatus(Status.Active, true);
        	}            
            
            Dispose();
        }
        
        private void UpdateCategoriesError(ResponseMessage response)
        {
        	Enabled = true;
        }

        #endregion

        #region Event Listenners

        private void mCancel__Click(Object sender, EventArgs e)
        {
            Dispose();
        }

        private void mAddExpense__Click(Object sender, EventArgs e)
        {
        	VwCategory newCategory = mExistingExpenses_.DataSource.AddNew();
            newCategory.CategoryType = CategoryType.Expense;
            newCategory.Status = Status.Active;
            mExistingExpenses_.CurrentCell = mExistingExpenses_.Rows[mExistingExpenses_.Rows.Count - 1].Cells["Name"];
            mExistingExpenses_.BeginEdit(true);
            newCategory.OperatorId = MiskoFinanceMain.Instance.Operator.OperatorId;
        }

        private void mAddTransfer__Click(Object sender, EventArgs e)
        {
        	VwCategory newCategory = mExistingTransfers_.DataSource.AddNew();
            newCategory.CategoryType = CategoryType.Transfer;
            newCategory.Status = Status.Active;
            mExistingTransfers_.CurrentCell = mExistingTransfers_.Rows[mExistingTransfers_.Rows.Count - 1].Cells["Name"];
            mExistingTransfers_.BeginEdit(true);            
            newCategory.OperatorId = MiskoFinanceMain.Instance.Operator.OperatorId;
        }

        private void mAddIncome__Click(Object sender, EventArgs e)
        {
        	VwCategory newCategory = mExistingIncome_.DataSource.AddNew();
            newCategory.CategoryType = CategoryType.Income;
            newCategory.Status = Status.Active;
            mExistingIncome_.CurrentCell = mExistingIncome_.Rows[mExistingIncome_.Rows.Count - 1].Cells["Name"];
            mExistingIncome_.BeginEdit(true);
            newCategory.OperatorId = MiskoFinanceMain.Instance.Operator.OperatorId;
        }
        
        private void mAddOneTime__Click(Object sender, EventArgs e)
        {
        	VwCategory newCategory = mExistingOneTime_.DataSource.AddNew();
            newCategory.CategoryType = CategoryType.OneTime;
            newCategory.Status = Status.Active;
            mExistingOneTime_.CurrentCell = mExistingOneTime_.Rows[mExistingOneTime_.Rows.Count - 1].Cells["Name"];
            mExistingOneTime_.BeginEdit(true);
            newCategory.OperatorId = MiskoFinanceMain.Instance.Operator.OperatorId;
        }

        private void DoneBtn_Click(Object sender, EventArgs e)
        {
            VwCategories categories = new VwCategories();
            categories.Add(mExistingIncome_.DataSource);
            categories.Add(mExistingExpenses_.DataSource);
            categories.Add(mExistingTransfers_.DataSource);
            categories.Add(mExistingOneTime_.DataSource);

            if(categories.Count > 0)
            {
            	Enabled = false;
            	
                UpdateCategoriesRQ request = new UpdateCategoriesRQ();
                request.Categories = categories;
                Server.SendRequest(request, UpdateCategoriesSuccess, UpdateCategoriesError);
            }
            else
            {
                Dispose();
            }
        }
        
        private void mCategories_Selected(Object sender, EventArgs e)
		{
        	((CategoriesGridView)mCategories_.SelectedTab.Tag).ClearSelection();
        	((CategoriesGridView)mCategories_.SelectedTab.Tag).CurrentCell = null;
		}

        #endregion
    }
}
