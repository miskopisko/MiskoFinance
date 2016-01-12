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
