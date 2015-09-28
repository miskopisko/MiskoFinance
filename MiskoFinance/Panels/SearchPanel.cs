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
        		VwBankAccounts dataSource = new VwBankAccounts();
        		dataSource.Insert(0, new VwBankAccount() { Nickname = "All" });
        		dataSource.AddRange(value);
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
        		VwCategories dataSource = new VwCategories();
        		dataSource.Insert(0, new VwCategory());
        		dataSource.AddRange(value);
        		mCategories_.DataSource = dataSource;
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
			
			mCategories_.ValueMember = "CategoryId";
			mCategories_.DisplayMember = "Name";
			
			mAccounts_.ValueMember = "BankAccountId";
			mAccounts_.DisplayMember = "Nickname";
			
			mFromDate_.Value = new DateTime(DateTime.Now.Year, 1, 1);
			
			mSearch_.Click += DoSearch;
			mMore_.Click += DoMore;
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
