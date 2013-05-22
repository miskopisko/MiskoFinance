using MPFinance.Core.Data.Viewed;
using System.Windows.Forms;

namespace MPFinance.Forms.Panels
{
    public partial class SummaryPanel : UserControl
    {
        public SummaryPanel()
        {
            InitializeComponent();
        }

        public void Update(VwSummary summary)
        {
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
    }
}
