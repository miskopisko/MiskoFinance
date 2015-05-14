using System;
using System.Windows.Forms;
using MiskoFinanceCore.Data.Viewed;
using MiskoPersist.Core;
using MiskoFinance.Forms;

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
			
			mAccounts_.SelectedValueChanged += mAccounts_SelectedValueChanged;
			mSearch_.Click += mSearch_Click;
			mMore_.Click += mMore_Click;
		}

		#region Private Methods
		
		private void mAccounts_SelectedValueChanged(object sender, EventArgs e)
		{
			MiskoFinanceMain.Instance.TransactionsPanel.Search();
		}

		private void mSearch_Click(object sender, EventArgs e)
		{
			MiskoFinanceMain.Instance.TransactionsPanel.Search();
		}

		private void mMore_Click(object sender, EventArgs e)
		{
			MiskoFinanceMain.Instance.TransactionsPanel.More();
		}
		
		#endregion		
	}
}
