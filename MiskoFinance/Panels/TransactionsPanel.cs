using System;
using System.Windows.Forms;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Resources;
using MiskoPersist.Core;
using MiskoPersist.Data;
using MiskoPersist.Tools;
using MiskoFinance.Forms;

namespace MiskoFinance.Panels
{
    public partial class TransactionsPanel : UserControl
    {
        private static Logger Log = Logger.GetInstance(typeof(TransactionsPanel));

        #region Fields
        
		
        
        #endregion
        
        #region Properties
        
        

        #endregion

        public TransactionsPanel()
        {
            InitializeComponent();
            
            mTransactionsGridView_.FetchComplete += transactionsGridView_FetchComplete;            
            mTransactionsGridView_.TxnUpdated += transactionsGridView_TxnUpdated;
            mPageCountsLbl_.Text = Utils.ResolveTextParameters(Strings.strPageCounts, new Object[] { 0, 0 });
            mTransactionCountsLbl_.Text = Utils.ResolveTextParameters(Strings.strTransactionCounts, new Object[] { 0, 0 });
        }

        #region Override Methods

        

        #endregion

        #region Event Listenners

        private void transactionsGridView_TxnUpdated(VwSummary summary)
        {
			MiskoFinanceMain.Instance.SummaryPanel.Summary = summary;
        }

		private void transactionsGridView_FetchComplete(VwSummary summary, Page page)
		{
			MiskoFinanceMain.Instance.SummaryPanel.Summary = summary;
			
			mPageCountsLbl_.Text = Utils.ResolveTextParameters(Strings.strPageCounts, new Object[] { page.PageNo, page.TotalPageCount });
            mTransactionCountsLbl_.Text = Utils.ResolveTextParameters(Strings.strTransactionCounts, new Object[] { mTransactionsGridView_.RowCount, page.TotalRowCount });
			
            MiskoFinanceMain.Instance.SearchPanel.Search.Enabled = true;
            MiskoFinanceMain.Instance.SearchPanel.More.Enabled = page.HasNext;
		}        
		
        #endregion

        #region Public Methods

		public void More()
        {
        	MiskoFinanceMain.Instance.SearchPanel.Search.Enabled = false;
        	MiskoFinanceMain.Instance.SearchPanel.More.Enabled = false;
            mTransactionsGridView_.GetTxns();
        }

        public void Search()
        {
        	MiskoFinanceMain.Instance.SearchPanel.Search.Enabled = false;
        	MiskoFinanceMain.Instance.SearchPanel.More.Enabled = false;
            mTransactionsGridView_.DataSource = null;
           	mTransactionsGridView_.GetTxns();
        }

        #endregion

        #region Private Methods

        

        #endregion
    }
}
