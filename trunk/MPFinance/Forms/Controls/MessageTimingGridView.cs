using System;
using System.Windows.Forms;
using MPersist.Core;
using MPersist.Core.Debug;

namespace MPFinance.Forms.Controls
{
    public partial class MessageTimingGridView : DataGridView
    {
        private static Logger Log = Logger.GetInstance(typeof(TransactionsGridView));

        #region Variable Declarations

        private DataGridViewTextBoxColumn mMessageName_ = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn mMessageExecutionTime_ = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn mSqlExecutionTime_ = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn mPercentSql_ = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn mTotalSqlCalls_ = new DataGridViewTextBoxColumn();

        #endregion

        #region Constructors

        public MessageTimingGridView()
        {
            AutoGenerateColumns = false;
            InitializeComponent();

            DataSource = new MessageTimings<MessageTiming>();
        }

        #endregion

        #region Override Methods

        protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
        {
            base.OnDataBindingComplete(e);

            if(Rows.Count > 0)
            {
                Rows[0].Selected = true;
            }            
        }

        #endregion

        #region Public Methods

        public void FillColumns()
        {
            Columns.Clear();

            if (Columns.Count == 0 && !DesignMode)
            {
                mMessageName_.DataPropertyName = "MessageName";
                mMessageName_.HeaderText = "Message Name";
                mMessageName_.Name = "MessageName";
                mMessageName_.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
                mMessageName_.ReadOnly = true;

                mMessageExecutionTime_.ValueType = typeof(Double);
                mMessageExecutionTime_.DataPropertyName = "TotalMessageTime";
                mMessageExecutionTime_.HeaderText = "Msg Time (sec)";
                mMessageExecutionTime_.Name = "TotalMessageTime";
                mMessageExecutionTime_.ReadOnly = true;
                mMessageExecutionTime_.Width = 125;

                mSqlExecutionTime_.ValueType = typeof(Double);
                mSqlExecutionTime_.DataPropertyName = "TotalSqlTime";
                mSqlExecutionTime_.HeaderText = "Sql Time (sec)";
                mSqlExecutionTime_.Name = "TotalSqlTime";
                mSqlExecutionTime_.ReadOnly = true;
                mSqlExecutionTime_.Width = 125;

                mPercentSql_.ValueType = typeof(Double);
                mPercentSql_.DataPropertyName = "PercentSql";
                mPercentSql_.HeaderText = "Percent Sql";
                mPercentSql_.Name = "PercentSql";
                mPercentSql_.ReadOnly = true;
                mPercentSql_.Width = 125;

                mTotalSqlCalls_.ValueType = typeof(Int32);
                mTotalSqlCalls_.DataPropertyName = "TotalSqlCalls";
                mTotalSqlCalls_.HeaderText = "# Sql Calls";
                mTotalSqlCalls_.Name = "TotalSqlCalls";
                mTotalSqlCalls_.ReadOnly = true;
                mTotalSqlCalls_.Width = 100;                

                Columns.AddRange(new DataGridViewColumn[] {
                                mMessageName_,
                                mMessageExecutionTime_,
                                mSqlExecutionTime_,
                                mPercentSql_,
                                mTotalSqlCalls_});
            }
        }

        #endregion
    }
}
