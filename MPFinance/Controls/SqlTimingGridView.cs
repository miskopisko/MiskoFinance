using System.Windows.Forms;
using MPersist.Core;

namespace MPFinance.Controls
{
    public partial class SqlTimingGridView : DataGridView
    {
        private static Logger Log = Logger.GetInstance(typeof(TransactionsGridView));

        #region Fileds

        private DataGridViewTextBoxColumn mSQL_ = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn mParameters_ = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn mExecutionTime_ = new DataGridViewTextBoxColumn();

        #endregion

        #region Constructor

        public SqlTimingGridView()
        {
            AutoGenerateColumns = false;
            InitializeComponent();
        }

        #endregion

        #region Override Methods

        protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
        {
            base.OnDataBindingComplete(e);
            ClearSelection();
        }

        #endregion

        #region Public Methods

        public void FillColumns()
        {
            Columns.Clear();

            if (Columns.Count == 0 && !DesignMode)
            {
                mSQL_.DataPropertyName = "SQL";
                mSQL_.HeaderText = "SQL";
                mSQL_.Name = "SQL";
                mSQL_.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
                mSQL_.ReadOnly = true;

                mParameters_.DataPropertyName = "ParametersString";
                mParameters_.HeaderText = "Parameters";
                mParameters_.Name = "Parameters";
                mParameters_.ReadOnly = true;
                mParameters_.Width = 125;

                mExecutionTime_.DataPropertyName = "TotalExecutionTime";
                mExecutionTime_.HeaderText = "Exec. Time (sec)";
                mExecutionTime_.Name = "TotalExecutionTime";
                mExecutionTime_.ReadOnly = true;
                mExecutionTime_.Width = 125;

                Columns.AddRange(new DataGridViewColumn[] {
                                mSQL_,
                                mParameters_,
                                mExecutionTime_});
            }
        }

        #endregion
    }
}
