using MPersist.Core.Debug;
using System;
using System.Windows.Forms;

namespace MPFinance.Forms.Controls
{
    public partial class MessageTimingGridView : DataGridView
    {
        #region Variable Declarations

        private DataGridViewTextBoxColumn MessageName = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn MessageExecutionTime = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn SqlExecutionTime = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn PercentSql = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn TotalSqlCalls = new DataGridViewTextBoxColumn();

        #endregion

        public MessageTimingGridView()
        {
            AutoGenerateColumns = false;
            InitializeComponent();

            DataSource = new MessageTimings<MessageTiming>();
        }

        protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
        {
            base.OnDataBindingComplete(e);

            if(Rows.Count > 0)
            {
                Rows[0].Selected = true;
            }            
        }

        public void FillColumns()
        {
            Columns.Clear();

            if (Columns.Count == 0 && !DesignMode)
            {
                MessageName.DataPropertyName = "MessageName";
                MessageName.HeaderText = "Message Name";
                MessageName.Name = "MessageName";
                MessageName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
                MessageName.ReadOnly = true;

                MessageExecutionTime.ValueType = typeof(Double);
                MessageExecutionTime.DataPropertyName = "TotalMessageTime";
                MessageExecutionTime.HeaderText = "Msg Time (sec)";
                MessageExecutionTime.Name = "TotalMessageTime";
                MessageExecutionTime.ReadOnly = true;
                MessageExecutionTime.Width = 125;

                SqlExecutionTime.ValueType = typeof(Double);
                SqlExecutionTime.DataPropertyName = "TotalSqlTime";
                SqlExecutionTime.HeaderText = "Sql Time (sec)";
                SqlExecutionTime.Name = "TotalSqlTime";
                SqlExecutionTime.ReadOnly = true;
                SqlExecutionTime.Width = 125;

                PercentSql.ValueType = typeof(Double);
                PercentSql.DataPropertyName = "PercentSql";
                PercentSql.HeaderText = "Percent Sql";
                PercentSql.Name = "PercentSql";
                PercentSql.ReadOnly = true;
                PercentSql.Width = 125;

                TotalSqlCalls.ValueType = typeof(Int32);
                TotalSqlCalls.DataPropertyName = "TotalSqlCalls";
                TotalSqlCalls.HeaderText = "# Sql Calls";
                TotalSqlCalls.Name = "TotalSqlCalls";
                TotalSqlCalls.ReadOnly = true;
                TotalSqlCalls.Width = 100;                

                Columns.AddRange(new DataGridViewColumn[] {
                                MessageName,
                                MessageExecutionTime,
                                SqlExecutionTime,
                                PercentSql,
                                TotalSqlCalls});
            }
        }
    }
}
