using System.Windows.Forms;
using MPersist.Core;
using MPFinanceCore.Data.Viewed;

namespace MPFinance.Panels
{
    public partial class SummaryPanel : UserControl
    {
        private static Logger Log = Logger.GetInstance(typeof(SummaryPanel));
        
        #region Fields

        private VwSummary mDataSource_ = new VwSummary();

        #endregion

        #region Parameters

		public VwSummary Summary
		{
			get
			{
				return mDataSource_;
			}
			set
			{
				mDataSource_ = value ?? new VwSummary();
				Update();
			}
		}

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

        private new void Update()
        {
            mTotalCredits_.Value = mDataSource_.SelectionTotalCredits;
            mTotalDebits_.Value = mDataSource_.SelectionTotalDebits;
            mCreditsDebitsDiff_.Value = mDataSource_.SelectionCreditsDebitsDifference;

            mTotalTransferIn_.Value = mDataSource_.SelectionTotalTransfersIn;
            mTotalTransferOut_.Value = mDataSource_.SelectionTotalTransfersOut;
            mTransfersDiff_.Value = mDataSource_.SelectionTransfersDifference;

            mSelectionOpeningBalance_.Value = mDataSource_.SelectionOpeningBalance;
            mSelectionClosingBalance_.Value = mDataSource_.SelectionCurrentBalance;
            mSelectionBalanceDifference_.Value = mDataSource_.SelectionBalanceDifference;

            mOpeningBalance_.Value = mDataSource_.AllTimeOpeningBalance;
            mCurrentBalance_.Value = mDataSource_.AllTimeCurrentBalance;
            mBalanceDiff_.Value = mDataSource_.AllTimeBalanceDifference;
        }

        #endregion

        #region Private Methods



        #endregion        
    }
}
