﻿using System;
using System.Windows.Forms;
using MPersist.Core;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Data.Viewed;
using MPFinance.Core.Enums;

namespace MPFinance.Forms.Controls
{
    public partial class CategoriesGridView : DataGridView
    {
        private static readonly Logger Log = Logger.GetInstance(typeof(CategoriesGridView));

        #region Fields

        private DataGridViewTextBoxColumn mCategoryName_ = new DataGridViewTextBoxColumn();
        private DGVComboBoxColumn mStatus_ = new DGVComboBoxColumn();
        private DataGridViewButtonColumn mDelete_ = new DataGridViewButtonColumn();

        #endregion

        #region Properties

        public VwCategories Categories { get { return ((VwCategories)DataSource); } set { DataSource = value; } }

        #endregion

        #region Constructor

        public CategoriesGridView()
        {
            AutoGenerateColumns = false;
            InitializeComponent();
        }

        #endregion

        #region Override Methods

        protected override void OnCellClick(DataGridViewCellEventArgs e)
        {
            base.OnCellClick(e);

            if(e.RowIndex >= 0 && e.ColumnIndex.Equals(Columns.IndexOf(mDelete_)))
            {
                VwCategory category = GetItemAt(e.RowIndex);

                if (Math.Abs(category.CategoryId.Value) >= 0)
                {
                    category.CategoryId = -category.CategoryId;
                }
                else
                {
                    Categories.Remove(category);
                }
            }
        }

        protected override void OnCellFormatting(DataGridViewCellFormattingEventArgs e)
        {
            base.OnCellFormatting(e);

            if (e.RowIndex >= 0 && e.RowIndex < Categories.Count && e.ColumnIndex.Equals(Columns.IndexOf(mDelete_)))
            {
                Rows[e.RowIndex].Cells[e.ColumnIndex].Value = GetItemAt(e.RowIndex).CategoryId >= 0 ? "Delete" : "Undelete";
            }
        }

        #endregion

        #region Private Methods

        private VwCategory GetItemAt(Int32 row)
        {
            return (VwCategory)Rows[row].DataBoundItem;
        }

        #endregion

        #region Public Methods

        public void FillColumns()
        {
            if (Columns.Count == 0 && !DesignMode)
            {
                mCategoryName_.ValueType = typeof(String);
                mCategoryName_.DataPropertyName = "Name";
                mCategoryName_.HeaderText = "Category Name";
                mCategoryName_.Name = "Name";
                mCategoryName_.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;

                mStatus_.ValueType = typeof(Status);
                mStatus_.HeaderText = "Status";
                mStatus_.Name = "Status";
                mStatus_.Width = 100;
                mStatus_.DisplayMember = "Description";
                mStatus_.DataPropertyName = "Status";                
                mStatus_.DataSource = MPFinance.Core.Enums.Status.NonNullElements;
                mStatus_.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                mStatus_.SortMode = DataGridViewColumnSortMode.Automatic;

                mDelete_.ValueType = typeof(String);
                mDelete_.HeaderText = "";
                mDelete_.FlatStyle = FlatStyle.Flat;
                mDelete_.Width = 75;
                mDelete_.SortMode = DataGridViewColumnSortMode.Automatic;
                mDelete_.ReadOnly = false;

                Columns.AddRange(new DataGridViewColumn[] {
                                mCategoryName_,
                                mStatus_,
                                mDelete_});                
            }
        }

        #endregion
    }
}
