using MPersist.Core.Debug;
using MPFinance.Forms.Controls;
using System.Windows.Forms;

namespace MPFinance.Forms
{
    public partial class DebugWindow : Form
    {
        #region Parameters

        public MessageTimingGridView Messages { get { return messageTimingGridView; } }
        public SqlTimingGridView SQL { get { return sqlTimingGridView; } }

        #endregion

        public DebugWindow()
        {
            InitializeComponent();

            messageTimingGridView.SelectionChanged += messageTimingGridView_SelectionChanged;
            sqlTimingGridView.SelectionChanged += sqlTimingGridView_SelectionChanged;
        }

        void sqlTimingGridView_SelectionChanged(object sender, System.EventArgs e)
        {
            MessageText.Text = ((SqlTiming)SQL.CurrentRow.DataBoundItem).FormattedSql;
        }

        private void messageTimingGridView_SelectionChanged(object sender, System.EventArgs e)
        {
            MessageText.Text = ((MessageTiming)Messages.CurrentRow.DataBoundItem).Message.ToXml();
            SQL.DataSource = ((MessageTiming)Messages.CurrentRow.DataBoundItem).SqlTimings;
        }
    }
}
