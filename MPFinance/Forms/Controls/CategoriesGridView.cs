using System;
using System.Drawing;
using System.Windows.Forms;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Enums;

namespace MPFinance.Forms.Controls
{
    public partial class CategoriesGridView : DataGridView
    {
        #region Variable Declarations

        private DataGridViewTextBoxColumn CategoryName = new DataGridViewTextBoxColumn();
        private DGVComboBoxColumn Status = new DGVComboBoxColumn();
        private DataGridViewButtonColumn Delete = new DataGridViewButtonColumn();

        #endregion

        public Categories Categories
        {
            get { return ((Categories)DataSource);  }
            set { DataSource = value; }
        }

        public CategoriesGridView()
        {
            AutoGenerateColumns = false;
            InitializeComponent();
        }

        protected override void OnCellClick(DataGridViewCellEventArgs e)
        {
            base.OnCellClick(e);

            if(e.RowIndex >= 0 && e.ColumnIndex.Equals(Columns.IndexOf(Delete)))
            {
                if (Math.Abs(((Category)Rows[e.RowIndex].DataBoundItem).Id) > 0)
                {
                    ((Category)Rows[e.RowIndex].DataBoundItem).Id = -((Category)Rows[e.RowIndex].DataBoundItem).Id;
                }
                else
                {
                    Categories.Remove((Category)Rows[e.RowIndex].DataBoundItem);
                }
            }
        }

        protected override void OnCellFormatting(DataGridViewCellFormattingEventArgs e)
        {
            base.OnCellFormatting(e);

            if (e.RowIndex >= 0 && e.RowIndex < Categories.Count && e.ColumnIndex.Equals(Columns.IndexOf(Delete)))
            {
                Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ((Category)Rows[e.RowIndex].DataBoundItem).Id >= 0 ? "Delete" : "Undelete";
            }
        }

        public void FillColumns()
        {
            if (Columns.Count == 0 && !DesignMode)
            {
                CategoryName.ValueType = typeof(String);
                CategoryName.DataPropertyName = "Name";
                CategoryName.HeaderText = "Category Name";
                CategoryName.Name = "Name";
                CategoryName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;

                Status.ValueType = typeof(Status);
                Status.HeaderText = "Status";
                Status.Name = "Status";
                Status.Width = 100;
                Status.DisplayMember = "Description";
                Status.DataPropertyName = "Status";                
                Status.DataSource = MPFinance.Core.Enums.Status.NonNullElements;
                Status.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                Status.SortMode = DataGridViewColumnSortMode.Automatic;

                Delete.ValueType = typeof(String);
                Delete.HeaderText = "";
                Delete.FlatStyle = FlatStyle.Flat;
                Delete.Width = 75;
                Delete.SortMode = DataGridViewColumnSortMode.Automatic;
                Delete.ReadOnly = false;

                Columns.AddRange(new DataGridViewColumn[] {
                                CategoryName,
                                Status,
                                Delete});                
            }
        }
    }
}
