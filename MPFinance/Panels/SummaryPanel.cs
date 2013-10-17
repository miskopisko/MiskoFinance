using System.Windows.Forms;
using MPersist.Core;
using MPFinanceCore.Data.Viewed;

namespace MPFinance.Panels
{
    public partial class SummaryPanel : UserControl
    {
        private static Logger Log = Logger.GetInstance(typeof(SummaryPanel));

        #region Fields



        #endregion

        #region Parameters



        #endregion

        #region Constructor

        public SummaryPanel()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Listenners



        #endregion""

        #region Override Methods



        #endregion

        #region Public Methods

        public void Update(VwSummary summary)
        {
            mTotalCredits_.Value = summary.SelectionTotalCredits;
            mTotalDebits_.Value = summary.SelectionTotalDebits;
            mCreditsDebitsDiff_.Value = summary.SelectionCreditsDebitsDifference;

            mTotalTransferIn_.Value = summary.SelectionTotalTransfersIn;
            mTotalTransferOut_.Value = summary.SelectionTotalTransfersOut;
            mTransfersDiff_.Value = summary.SelectionTransfersDifference;

            mSelectionOpeningBalance_.Value = summary.SelectionOpeningBalance;
            mSelectionClosingBalance_.Value = summary.SelectionCurrentBalance;
            mSelectionBalanceDifference_.Value = summary.SelectionBalanceDifference;

            mOpeningBalance_.Value = summary.AllTimeOpeningBalance;
            mCurrentBalance_.Value = summary.AllTimeCurrentBalance;
            mBalanceDiff_.Value = summary.AllTimeBalanceDifference;
        }

        #endregion

        #region Private Methods



        #endregion        
    }
}
