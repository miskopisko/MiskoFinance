using System.ComponentModel;
using System.Windows.Forms;
using MiskoFinanceCore.Data.Viewed;
using MiskoPersist.Core;
using MiskoPersist.MoneyType;

namespace MiskoFinance.Panels
{
    public partial class SummaryPanel : UserControl
    {
        private static Logger Log = Logger.GetInstance(typeof(SummaryPanel));
        
        #region Fields



        #endregion

        #region Parameters

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public VwSummary Summary
		{
			set
			{
				mTotalCredits_.Value = value != null ? value.SelectionTotalCredits : Money.ZERO;
	            mTotalDebits_.Value = value != null ? value.SelectionTotalDebits : Money.ZERO;
	            mCreditsDebitsDiff_.Value = value != null ? value.SelectionCreditsDebitsDifference : Money.ZERO;
	
	            mTotalTransferIn_.Value = value != null ? value.SelectionTotalTransfersIn : Money.ZERO;
	            mTotalTransferOut_.Value = value != null ? value.SelectionTotalTransfersOut : Money.ZERO;
	            mTransfersDiff_.Value = value != null ? value.SelectionTransfersDifference : Money.ZERO;
	
	            mSelectionOpeningBalance_.Value = value != null ? value.SelectionOpeningBalance : Money.ZERO;
	            mSelectionClosingBalance_.Value = value != null ? value.SelectionCurrentBalance : Money.ZERO;
	            mSelectionBalanceDifference_.Value = value != null ? value.SelectionBalanceDifference : Money.ZERO;
	
	            mOpeningBalance_.Value = value != null ? value.AllTimeOpeningBalance : Money.ZERO;
	            mCurrentBalance_.Value = value != null ? value.AllTimeCurrentBalance : Money.ZERO;
	            mBalanceDiff_.Value = value != null ? value.AllTimeBalanceDifference : Money.ZERO;
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



        #endregion

        #region Override Methods



        #endregion

        #region Public Methods

		

        #endregion

        #region Private Methods



        #endregion        
    }
}
