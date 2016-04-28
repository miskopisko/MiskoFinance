using System;
using System.Windows.Forms;
using MiskoFinanceCore.Data.Viewed;

namespace MiskoFinance.Panels
{
	public partial class GraphingPanel : UserControl
	{
		public GraphingPanel()
		{
			InitializeComponent();
		}

		public void Populate(VwTxns txns)
		{
			mChart_.Series.Clear();

			DateTime date = DateTime.MaxValue;
			Decimal amount = Decimal.Zero;

			foreach (VwTxn txn in txns)
			{
				if(mChart_.Series.FindByName(txn.Account) == null)
				{
					mChart_.Series.Add(txn.Account);
				}

				if(!date.Equals(txn.DatePosted))
				{
					date = txn.DatePosted;
					amount = txn.Amount.ToDecimal(null) * txn.DrCr.Sign();
				}
				else
				{
					amount = Decimal.Add(amount, txn.Amount.ToDecimal(null) * txn.DrCr.Sign());
				}

				mChart_.Series[txn.Account].Points.AddXY(date, amount);
			}
		}
	}
}
