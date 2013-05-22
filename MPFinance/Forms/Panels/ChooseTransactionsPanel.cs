using MPersist.Core;
using MPFinance.Core.Data.Viewed;
using System;
using System.Windows.Forms;

namespace MPFinance.Forms.Panels
{
    public partial class ChooseTransactionsPanel : UserControl
    {
        private static Logger Log = Logger.GetInstance(typeof(ChooseTransactionsPanel));

        #region Properties

        public VwTxns VwTxns { get; set; }

        #endregion

        public ChooseTransactionsPanel()
        {
            InitializeComponent();
            importedTransactionsGridView.FillColumns();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            if (Visible)
            {
                importedTransactionsGridView.DataSource = VwTxns;
                Parent.Text = "Choose transactions to add...";
            }
        }
    }
}
