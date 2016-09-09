using System;
using System.Windows.Forms;
using log4net;
using MiskoFinance.Forms;
using MiskoFinanceCore.Data.Viewed;

namespace MiskoFinance.Panels
{
	public partial class SearchPanel : UserControl
	{
		private static ILog Log = LogManager.GetLogger(typeof(SearchPanel));

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
        		VwBankAccounts dataSource = new VwBankAccounts();
        		dataSource.Add(new VwBankAccount() { Nickname = "All" });
        		dataSource.Add(value);
        		mAccounts_.DataSource = dataSource;
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
        		mCategories_.DataSource = value;
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
		
		public SearchPanel()
		{
			InitializeComponent();
			
			mSearch_.Click += DoSearch;
			mMore_.Click += DoMore;
			
			Reset();
        }

        #region Private Methods

        private void DoSearch(Object sender, EventArgs e)
		{
			MiskoFinanceMain.Instance.TransactionsPanel.Search();
		}

		private void DoMore(Object sender, EventArgs e)
		{
			MiskoFinanceMain.Instance.TransactionsPanel.More();
		}
		
		#endregion	

		#region Public Methods
		
		public void Reset()
		{
			mAccounts_.DataSource = null;
			mFromDate_.Value = new DateTime(DateTime.Now.Year, 1, 1);
			mToDate_.Value = DateTime.Today;
			mDescription_.Text = null;
			mCategories_.DataSource = null;
			
			mCategories_.ValueMember = "CategoryId";
			mCategories_.DisplayMember = "Name";
			
			mAccounts_.ValueMember = "BankAccountId";
			mAccounts_.DisplayMember = "Nickname";
		}
		
		public void Disable()
		{
			mAccounts_.Enabled = false;
			mFromDate_.Enabled = false;
			mToDate_.Enabled = false;
			mDescription_.Enabled = false;
			mCategories_.Enabled = false;
			mSearch_.Enabled = false;
			mMore_.Enabled = false;
		}
		
		public void Enable(Boolean enableMoreBtn)
		{
			mAccounts_.Enabled = true;
			mFromDate_.Enabled = true;
			mToDate_.Enabled = true;
			mDescription_.Enabled = true;
			mCategories_.Enabled = true;
			mSearch_.Enabled = true;
			mMore_.Enabled = enableMoreBtn;
		}
		
		#endregion
	}
}
