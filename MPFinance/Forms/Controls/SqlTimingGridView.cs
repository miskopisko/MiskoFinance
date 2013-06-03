using System.Windows.Forms;

namespace MPFinance.Forms.Controls
{
    public partial class SqlTimingGridView : DataGridView
    {
        #region Variable Declarations

        private DataGridViewTextBoxColumn SQL = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn Parameters = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn ExecutionTime = new DataGridViewTextBoxColumn();

        #endregion

        public SqlTimingGridView()
        {
            AutoGenerateColumns = false;
            InitializeComponent();
        }

        protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
        {
            ClearSelection();

            base.OnDataBindingComplete(e);
        }

        public void FillColumns()
        {
            Columns.Clear();

            if (Columns.Count == 0 && !DesignMode)
            {
                SQL.DataPropertyName = "SQL";
                SQL.HeaderText = "SQL";
                SQL.Name = "SQL";
                SQL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
                SQL.ReadOnly = true;

                Parameters.DataPropertyName = "ParametersString";
                Parameters.HeaderText = "Parameters";
                Parameters.Name = "Parameters";
                Parameters.ReadOnly = true;
                Parameters.Width = 125;

                ExecutionTime.DataPropertyName = "TotalExecutionTime";
                ExecutionTime.HeaderText = "Exec. Time (sec)";
                ExecutionTime.Name = "TotalExecutionTime";
                ExecutionTime.ReadOnly = true;
                ExecutionTime.Width = 125;

                Columns.AddRange(new DataGridViewColumn[] {
                                SQL,
                                Parameters,
                                ExecutionTime});
            }
        }
    }
}
