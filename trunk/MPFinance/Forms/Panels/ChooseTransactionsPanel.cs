using MPersist.Core;
using System.Windows.Forms;

namespace MPFinance.Forms.Panels
{
    public partial class ChooseTransactionsPanel : UserControl
    {
        private static Logger Log = Logger.GetInstance(typeof(ChooseTransactionsPanel));

        #region Variable Declarations



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

        protected override void OnLoad(System.EventArgs e)
        {
            importedTransactionsGridView.FillColumns();
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods



        #endregion
    }
}
