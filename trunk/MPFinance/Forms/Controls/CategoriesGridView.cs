using System;
using System.Windows.Forms;
using MPFinance.Core.Enums;

namespace MPFinance.Forms.Controls
{
    public partial class CategoriesGridView : DataGridView
    {
        #region Variable Declarations

        private DataGridViewTextBoxColumn CategoryName = new DataGridViewTextBoxColumn();
        private DGVComboBoxColumn Status = new DGVComboBoxColumn();

        #endregion

        public CategoriesGridView()
        {
            AutoGenerateColumns = false;
            InitializeComponent();
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

                Columns.AddRange(new DataGridViewColumn[] {
                                CategoryName,
                                Status});                
            }
        }
    }
}
