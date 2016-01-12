using System;
using System.Windows.Forms;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Enums;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;
using MiskoPersist.Core;
using MiskoPersist.Message.Response;

namespace MiskoFinance.Forms
{
	public partial class EditAccountsDialog : Form
    {
        private static Logger Log = Logger.GetInstance(typeof(EditAccountsDialog));

        #region Fields



        #endregion

        #region Properties

        

        #endregion

        #region Constructor

        public EditAccountsDialog()
        {
            InitializeComponent();
            
            mAccountType_.DataSource = AccountType.Elements;
            
            VwBankAccounts accounts = (VwBankAccounts)MiskoFinanceMain.Instance.Operator.BankAccounts.Clone();
            
            mExistingAccounts_.DataSource = accounts;
            mExistingAccounts_.ValueMember = "BankAccountId";
            mExistingAccounts_.DisplayMember = "Nickname";            
            
            mBankName_.DataBindings.Add("Text", accounts, "BankNumber", true, DataSourceUpdateMode.OnPropertyChanged);
			mAccountNumber_.DataBindings.Add("Text", accounts, "AccountNumber", true, DataSourceUpdateMode.OnPropertyChanged);
			mAccountType_.DataBindings.Add("SelectedItem", accounts, "AccountType", true, DataSourceUpdateMode.OnPropertyChanged);
			mNickname_.DataBindings.Add("Text", accounts, "NickName", true, DataSourceUpdateMode.OnPropertyChanged);
			mOpeningBalance_.DataBindings.Add("Value", accounts, "OpeningBalance", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        #endregion

        #region Override Methods

        protected override void OnLoad(EventArgs e)
        {
        	base.OnLoad(e);
        	
            mBankName_.Enabled = mExistingAccounts_.Items.Count > 0;
            mAccountNumber_.Enabled = mExistingAccounts_.Items.Count > 0;
            mAccountType_.Enabled = mExistingAccounts_.Items.Count > 0;
            mNickname_.Enabled = mExistingAccounts_.Items.Count > 0;
            mOpeningBalance_.Enabled = mExistingAccounts_.Items.Count > 0;
            
            CenterToParent();
        }

        #endregion

        #region Event Listenners

        private void mCancel__Click(Object sender, EventArgs e)
        {
            Dispose();
        }

        private void Done_Click(Object sender, EventArgs e)
        {
            if (mExistingAccounts_.Items.Count > 0)
            {
            	Enabled = false;
            	
                UpdateAccountsRQ request = new UpdateAccountsRQ();
                request.BankAccounts = (VwBankAccounts)mExistingAccounts_.DataSource;
                ServerConnection.SendRequest(request, UpdateAccountsSuccess, UpdateAccountsError);
            }
            else
            {
                Dispose();
            }
        }

        #endregion

        #region Private Methods

        private void UpdateAccountsSuccess(ResponseMessage response)
        {
            MiskoFinanceMain.Instance.Operator.BankAccounts = ((UpdateAccountsRS)response).BankAccounts;
            MiskoFinanceMain.Instance.SearchPanel.Accounts = ((UpdateAccountsRS)response).BankAccounts;
            
            Dispose();
        }
        
        private void UpdateAccountsError(ResponseMessage response)
        {
        	Enabled = true;
        }

        #endregion
    }
}
