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
            
            mExistingAccounts_.ValueMember = "BankAccountid";
            mExistingAccounts_.DisplayMember = "Nickname";
            
            mExistingAccounts_.SelectedValueChanged += existingAccounts_SelectedValueChanged;
            mBankName_.Leave += DataChanged;
            mAccountNumber_.Leave += DataChanged;
            mAccountType_.Leave += DataChanged;
            mNickname_.Leave += DataChanged;
            mOpeningBalance_.Leave += DataChanged;
        }

        #endregion

        #region Override Methods

        protected override void OnLoad(EventArgs e)
        {
        	base.OnLoad(e);
        	
            mExistingAccounts_.DataSource = MiskoFinanceMain.Instance.Operator.BankAccounts;

            mBankName_.Enabled = mExistingAccounts_.Items.Count > 0;
            mAccountNumber_.Enabled = mExistingAccounts_.Items.Count > 0;
            mAccountType_.Enabled = mExistingAccounts_.Items.Count > 0;
            mNickname_.Enabled = mExistingAccounts_.Items.Count > 0;
            mOpeningBalance_.Enabled = mExistingAccounts_.Items.Count > 0;

            mExistingAccounts_.SelectedIndex = 0;
        }

        #endregion

        #region Event Listenners

        private void mCancel__Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void existingAccounts_SelectedValueChanged(object sender, EventArgs e)
        {
        	mBankName_.Text = ((VwBankAccount)mExistingAccounts_.SelectedItem).BankNumber;
            mAccountNumber_.Text = ((VwBankAccount)mExistingAccounts_.SelectedItem).AccountNumber;
            mAccountType_.SelectedItem = ((VwBankAccount)mExistingAccounts_.SelectedItem).AccountType;
            mNickname_.Text = ((VwBankAccount)mExistingAccounts_.SelectedItem).Nickname;
            mOpeningBalance_.Value = ((VwBankAccount)mExistingAccounts_.SelectedItem).OpeningBalance;
        }

        private void Done_Click(object sender, EventArgs e)
        {
            if (mExistingAccounts_.Items.Count > 0)
            {
                UpdateAccountsRQ request = new UpdateAccountsRQ();
                request.BankAccounts = (VwBankAccounts)mExistingAccounts_.DataSource;
                ServerConnection.SendRequest(request, UpdateAccountsSuccess);
            }
            else
            {
                Dispose();
            }
        }

        private void DataChanged(object sender, EventArgs e)
        {
        	((VwBankAccount)mExistingAccounts_.SelectedItem).BankNumber = mBankName_.Text;
        	((VwBankAccount)mExistingAccounts_.SelectedItem).AccountNumber = mAccountNumber_.Text;
        	((VwBankAccount)mExistingAccounts_.SelectedItem).AccountType = (AccountType)mAccountType_.SelectedItem;
        	((VwBankAccount)mExistingAccounts_.SelectedItem).Nickname = mNickname_.Text;
        	((VwBankAccount)mExistingAccounts_.SelectedItem).OpeningBalance = mOpeningBalance_.Value;
        }

        #endregion

        #region Private Methods

        private void UpdateAccountsSuccess(ResponseMessage response)
        {
            MiskoFinanceMain.Instance.Operator.BankAccounts = ((UpdateAccountsRS)response).BankAccounts;
            MiskoFinanceMain.Instance.SearchPanel.Accounts = ((UpdateAccountsRS)response).BankAccounts.getAllAccounts();
            
            Dispose();
        }

        #endregion
    }
}
