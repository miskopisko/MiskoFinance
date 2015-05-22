using System;
using System.IO;
using System.Windows.Forms;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Enums;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;
using MiskoFinanceCore.OFX;
using MiskoFinanceCore.Resources;
using MiskoPersist.Core;
using MiskoPersist.Enums;
using MiskoPersist.Message.Response;
using MiskoPersist.MoneyType;

namespace MiskoFinance.Forms
{
    public partial class ImportTransactionsDialog : Form
    {
        private static Logger Log = Logger.GetInstance(typeof(ImportTransactionsDialog));

        #region Fields

        private OfxDocument mOfxDocument_;

        #endregion

        #region Properties

        

        #endregion

        #region Constructor

        public ImportTransactionsDialog()
        {
            InitializeComponent();
            
            mExistingAccounts_.DisplayMember = "Nickname";            
            mExistingAccounts_.DataSource = MiskoFinanceMain.Instance.Operator.BankAccounts;
            mExistingAccounts_.SelectedValueChanged += mExistingAccounts_SelectedValueChanged;
            
            mCreateNewAccount_.CheckedChanged += mCreateNewAccount__CheckedChanged;
            mExistingAccount_.CheckedChanged += mExistingAccount__CheckedChanged;;

            mAccountType_.DataSource = AccountType.Elements;
            
            mExistingAccount_.Enabled = MiskoFinanceMain.Instance.Operator.BankAccounts.Count > 0;
        }        

        #endregion

        #region Override Methods

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            if (mOpenFileDialog_.ShowDialog(MiskoFinanceMain.Instance).Equals(DialogResult.OK))
            {
                mOfxDocument_ = new OfxDocument(new FileStream(mOpenFileDialog_.FileName, FileMode.Open));                
                
                GetAccountRQ request = new GetAccountRQ();
            	request.AccountNo = mOfxDocument_.AccountID;
            	request.Operator = MiskoFinanceMain.Instance.Operator.OperatorId;
            	ServerConnection.SendRequest(request, GetAccountSuccess, GetAccountError);
            }
            else
            {
                Dispose();
            }
        }        

        #endregion

        #region Public Methods

        

        #endregion

        #region Private Methods
        
        private VwBankAccount GetAccount()
        {
            if (mCreateNewAccount_.Checked)
            {
                VwBankAccount bankAccount = new VwBankAccount();
                bankAccount.OperatorId = MiskoFinanceMain.Instance.Operator.OperatorId;
                bankAccount.AccountNumber = mAccountNumber_.Text.Trim();
                bankAccount.BankNumber = mBankName_.Text.Trim();
                bankAccount.Nickname = mNickname_.Text.Trim();
                bankAccount.AccountType = (AccountType)mAccountType_.SelectedItem;
                bankAccount.OpeningBalance = mOpeningBalance_.Value;
                return bankAccount;
            }
            else if (mExistingAccount_.Checked)
            {
                if (mExistingAccounts_.SelectedItems.Count != 1)
                {
                	throw new MiskoException(ErrorStrings.errChooseExistingAccount);
                }
                else
                {
                    return (VwBankAccount)mExistingAccounts_.SelectedItem;
                }
            }
            return null;
        }

		private void GetAccountSuccess(ResponseMessage response)
        {
			mExistingAccount_.Checked = true;

            for (int i = 0; i < mExistingAccounts_.Items.Count; i++)
            {
                //mExistingAccounts_.SetItemChecked(i, ((VwBankAccount)mExistingAccounts_.Items[i]).BankAccountId.Equals(((GetAccountRS)response).BankAccount.BankAccountId));
            }
		}
		
		private void GetAccountError(ResponseMessage response)
        {
			mCreateNewAccount_.Checked = true;

            mBankName_.Text = mOfxDocument_.BankID;
            mAccountNumber_.Text = mOfxDocument_.AccountID;
            mAccountType_.SelectedItem = mOfxDocument_.AccountType;
            mNickname_.Text = String.Empty;
            mOpeningBalance_.Value = Money.ZERO;

            for (int i = 0; i < mExistingAccounts_.Items.Count; i++)
            {
            	mExistingAccounts_.SelectedItems.Clear();
            }
		}
		
		private void ImportTxnsSuccess(ResponseMessage response)
		{
			Dispose();
		}
		
		private void ImportTxnsError(ResponseMessage response)
		{
			mCancel_.Enabled = true;
            mImport_.Enabled = true;
		}

        #endregion

        #region Event Listenners

		private void mExistingAccounts_SelectedValueChanged(object sender, EventArgs e)
		{
			VwBankAccount bankAccount = (VwBankAccount)mExistingAccounts_.SelectedValue;

            mBankName_.Text = bankAccount.BankNumber;
            mAccountNumber_.Text = bankAccount.AccountNumber;
            mAccountType_.SelectedItem = bankAccount.AccountType;
            mNickname_.Text = bankAccount.Nickname;
            mOpeningBalance_.Value = bankAccount.OpeningBalance;
		}
		
		private void mCreateNewAccount__CheckedChanged(object sender, System.EventArgs e)
		{
			mExistingAccounts_.Enabled = mExistingAccount_.Checked;
			mExistingAccounts_.SelectedItems.Clear();
			
            mBankName_.Enabled = !mExistingAccount_.Checked;
            mAccountNumber_.Enabled = !mExistingAccount_.Checked;
            mOpeningBalance_.Enabled = !mExistingAccount_.Checked;
            mAccountType_.Enabled = !mExistingAccount_.Checked;
            mNickname_.Enabled = !mExistingAccount_.Checked;
		}

		private void mExistingAccount__CheckedChanged(object sender, System.EventArgs e)
		{
			mExistingAccounts_.Enabled = mExistingAccount_.Checked;
			mExistingAccounts_.SelectedItems.Clear();
			
            mBankName_.Enabled = !mExistingAccount_.Checked;
            mAccountNumber_.Enabled = !mExistingAccount_.Checked;
            mOpeningBalance_.Enabled = !mExistingAccount_.Checked;
            mAccountType_.Enabled = !mExistingAccount_.Checked;
            mNickname_.Enabled = !mExistingAccount_.Checked;
		}
		
		private void mCancel__Click(object sender, EventArgs e)
		{
			Dispose();
		}
		
		private void mImport__Click(object sender, EventArgs e)
		{
			mCancel_.Enabled = false;
            mImport_.Enabled = false;

            ImportTxnsRQ request = new ImportTxnsRQ();
            request.BankAccount = GetAccount();
            request.Operator = MiskoFinanceMain.Instance.Operator;
            request.VwTxns = mOfxDocument_.Transactions;
            ServerConnection.SendRequest(request, ImportTxnsSuccess, ImportTxnsError);
		}
		
		#endregion
    }
}
