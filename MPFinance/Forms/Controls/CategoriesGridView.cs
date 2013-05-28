using MPFinance.Core.Data.Stored;
using MPFinance.Core.Enums;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MPFinance.Forms.Controls
{
    public partial class CategoriesGridView : DataGridView
    {
        #region Variable Declarations

        private DataGridViewTextBoxColumn CategoryName = new DataGridViewTextBoxColumn();
        private DataGridViewComboBoxColumn Status = new DataGridViewComboBoxColumn();

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
                Status.DataPropertyName = "Status";
                Status.HeaderText = "Status";
                Status.Name = "Status";
                Status.Width = 100;
                Status.DataSource = MPFinance.Core.Enums.Status.Elements;


                Columns.AddRange(new DataGridViewColumn[] {
                                CategoryName,
                                Status});                
            }
        }
    }
}
