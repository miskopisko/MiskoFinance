using System;
using System.Windows.Forms;
using MiskoFinance.Forms;
using MiskoFinanceCore.Data.Viewed;
using MiskoPersist.Core;

namespace MiskoFinance.Panels
{
	public partial class SearchPanel : UserControl
	{
		private static Logger Log = Logger.GetInstance(typeof(SearchPanel));

        #region Fields
        
		
        
        #endregion
        
        #region Properties
        
        public VwBankAccounts Accounts 
        {
        	get
        	{
        		return (VwBankAccounts)mAccounts_.DataSource;
        	}
        	set
        	{
        		mAccounts_.DataSource = value ?? new VwBankAccounts();
        		mAccounts_.Enabled = Accounts.Count > 0;
        		mFromDate_.Enabled = Accounts.Count > 0;
        		mToDate_.Enabled = Accounts.Count > 0;
        		mDescription_.Enabled = Accounts.Count > 0;
        		mCategories_.Enabled = Accounts.Count > 0;
        		mSearch_.Enabled = Accounts.Count > 0;
        		mMore_.Enabled = false;
        	}
        }
        
        public VwBankAccount Account
        {
        	get
        	{
        		return (VwBankAccount)mAccounts_.SelectedItem ?? new VwBankAccount();
        	}
        }

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
        		mCategories_.Enabled = mCategories_.DataSource != null && ((VwCategories)mCategories_.DataSource).Count > 0;
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
        
        public Button Search
        {
        	get
        	{
        		return mSearch_;
        	}
        }
        
        public Button More
        {
        	get
        	{
        		return mMore_;
        	}
        }
        
        #endregion
		
		public SearchPanel()
		{
			InitializeComponent();
			
			mCategories_.ValueMember = "CategoryId";
			mCategories_.DisplayMember = "Name";
			
			mAccounts_.ValueMember = "BankAccountId";
			mAccounts_.DisplayMember = "Nickname";
			
			mFromDate_.Value = new DateTime(DateTime.Now.Year, 1, 1);
			
			mSearch_.Click += DoSearch;
			mMore_.Click += DoMore;
            mAccounts_.SelectionChangeCommitted += DoSearch;
            mCategories_.SelectionChangeCommitted += DoSearch;
            mFromDate_.ValueChanged += DoSearch;
            mToDate_.ValueChanged += DoSearch;
        }

        #region Private Methods

        private void DoSearch(object sender, EventArgs e)
		{
			MiskoFinanceMain.Instance.TransactionsPanel.Search();
		}

		private void DoMore(object sender, EventArgs e)
		{
			MiskoFinanceMain.Instance.TransactionsPanel.More();
		}
		
		#endregion		
	}
}
