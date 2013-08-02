using System.Windows.Forms;
using MPersist.Core;
using MPFinance.Core.Data.Viewed;

namespace MPFinance.Forms.Panels
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
            mAllTimeGroupBox_.Text = "All Time - " + summary.BankAccountName;

            TotalCredits.Value = summary.TotalCredits;
            TotalDebits.Value = summary.TotalDebits;
            CreditsDebitsDiff.Value = summary.DifferenceCreditsDebits;

            TotalTransferIn.Value = summary.TotalTransfersIn;
            TotalTransferOut.Value = summary.TotalTransfersOut;
            TransfersDiff.Value = summary.DifferenceTransfers;

            OpeningBalance.Value = summary.OpeningBalance;
            CurrentBalance.Value = summary.CurrentBalance;
            BalanceDiff.Value = summary.DifferenceBalance;
        }

        #endregion

        #region Private Methods



        #endregion        
    }
}
