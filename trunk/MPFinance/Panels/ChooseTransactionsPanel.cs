using System;
using System.Windows.Forms;
using MPersist.Core;

namespace MPFinance.Panels
{
    public partial class ChooseTransactionsPanel : UserControl
    {
        private static Logger Log = Logger.GetInstance(typeof(ChooseTransactionsPanel));

        #region Fields



        #endregion

        #region Properties



        #endregion

        #region Constructor

        public ChooseTransactionsPanel()
        {
            InitializeComponent();
        }

        #endregion

        #region Override Methods

        protected override void OnLoad(EventArgs e)
        {
            mImportedTransactionsGridView_.FillColumns();
        }

        #endregion

        #region Private Methods

        

        #endregion

        #region Public Methods



        #endregion
    }
}
