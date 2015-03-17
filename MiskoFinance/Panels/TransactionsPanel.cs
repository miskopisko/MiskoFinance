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

        public DateTime FromDate 
        { 
        	get 
        	{ 
        		return mFromDate_.Value; 
        	} 
        }
        
        public DateTime ToDate 
        { 
        	get 
        	{ 
        		return mToDate_.Value; 
        	} 
        }
        
        public VwCategories Categories 
        { 
        	get 
        	{ 
				return (VwCategories)mCategories_.DataSource; 
        	}
        	set
        	{
        		mCategories_.DataSource = value ?? new VwCategories();
        		mCategories_.Update();
        	}
        }
        
        public VwCategory Category 
        { 
        	get 
        	{ 
        		return (VwCategory)mCategories_.SelectedItem ?? new VwCategory();
        	}
        }
        
        public String Description 
        { 
        	get 
        	{ 
        		return mDescription_.Text.Trim(); 
        	} 
        }

        #endregion

        public TransactionsPanel()
        {
            InitializeComponent();
            
            mFromDate_.Value = new DateTime(DateTime.Now.Year, 1, 1);
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
            mTransactionCountsLbl_.Text = Utils.ResolveTextParameters(Strings.strTransactionCounts, new Object[] { page.RowsFetchedSoFar, page.TotalRowCount });
			mSearch_.Enabled = true;
            mMore_.Enabled = page.HasNext;
		}
		
        private void mMore__Click(object sender, EventArgs e)
        {
        	mMore_.Enabled = false;
            mSearch_.Enabled = false;
            mTransactionsGridView_.GetTxns();
        }

        private void mSearch__Click(object sender, EventArgs e)
        {
        	GetTxns();
        }
		
        #endregion

        #region Public Methods

        public void GetTxns()
        {
        	mMore_.Enabled = false;
            mSearch_.Enabled = false;
            mTransactionsGridView_.Txns = null;
           	mTransactionsGridView_.GetTxns();
        }

        #endregion

        #region Private Methods

        

        #endregion
    }
}
