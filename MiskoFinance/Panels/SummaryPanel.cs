﻿using System.ComponentModel;
using System.Windows.Forms;
using MiskoFinanceCore.Data.Viewed;
using log4net;

namespace MiskoFinance.Panels
{
	public partial class SummaryPanel : UserControl
	{
		private static ILog Log = LogManager.GetLogger(typeof(SummaryPanel));
		
		#region Fields



		#endregion

		#region Parameters

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public VwSummary Summary
		{
			set
			{
				mSelectionOpeningBalance_.Value = value.SelectionOpeningBalance;
				mSelectionClosingBalance_.Value = value.SelectionClosingBalance;
				mSelectionBalanceDifference_.Value = value.SelectionClosingBalance - value.SelectionOpeningBalance;
	
				mOpeningBalance_.Value = value.AllTimeOpeningBalance;
				mCurrentBalance_.Value = value.AllTimeClosingBalance;
				mBalanceDiff_.Value = value.AllTimeClosingBalance - value.AllTimeOpeningBalance;
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
