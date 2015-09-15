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
using MiskoPersist.Message.Response;
using MiskoPersist.MoneyType;

namespace MiskoFinance.Forms
{
    public partial class ImportTransactionsDialog : Form
    {
        private static Logger Log = Logger.GetInstance(typeof(ImportTransactionsDialog));

        #region Fields

        private OfxDocument mOfxDocument_;
        private VwBankAccount mAccount_;

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
            mExistingAccounts_.SelectedItems.Clear();
            
            mCreateNewAccount_.CheckedChanged += AccountType__CheckedChanged;
            mExistingAccount_.CheckedChanged += AccountType__CheckedChanged;;

            mAccountType_.DataSource = AccountType.Elements;
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
            	
            	CenterToParent();
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
                if (mExistingAccounts_.SelectedItems.Count == 1)
                {
                	return (VwBankAccount)mExistingAccounts_.SelectedItem;
                }
            }
            
            throw new MiskoException(ErrorStrings.errChooseExistingAccount);
        }

		private void GetAccountSuccess(ResponseMessage response)
        {
			mAccount_ = ((GetAccountRS)response).BankAccount;
			mExistingAccounts_.SelectedIndex = mExistingAccounts_.FindStringExact(mAccount_.Nickname);
			mExistingAccount_.Checked = true;
		}
		
		private void GetAccountError(ResponseMessage response)
        {
			mCreateNewAccount_.Checked = true;

            mBankName_.Text = mOfxDocument_.BankID;
            mAccountNumber_.Text = mOfxDocument_.AccountID;
            mAccountType_.SelectedItem = mOfxDocument_.AccountType;
            mNickname_.Text = String.Empty;
            mOpeningBalance_.Value = Money.ZERO;

            mExistingAccounts_.SelectedItems.Clear();
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
			VwBankAccount bankAccount;
			
			if(mExistingAccounts_.SelectedItems.Count == 1)
			{
				bankAccount = (VwBankAccount)mExistingAccounts_.SelectedValue;            
			}
			else
			{
				bankAccount = new VwBankAccount()
				{
					AccountNumber = mOfxDocument_ != null ? mOfxDocument_.AccountID : null,
					AccountType = mOfxDocument_ != null ? mOfxDocument_.AccountType : null,
					BankNumber = mOfxDocument_ != null ? mOfxDocument_.BankID : null,
				};
			}
			
			mBankName_.Text = bankAccount.BankNumber;
            mAccountNumber_.Text = bankAccount.AccountNumber;
            mAccountType_.SelectedItem = bankAccount.AccountType;
            mNickname_.Text = bankAccount.Nickname;
            mOpeningBalance_.Value = bankAccount.OpeningBalance;
		}
		
		private void AccountType__CheckedChanged(object sender, System.EventArgs e)
		{
			mExistingAccounts_.Enabled = mExistingAccount_.Checked;
			
			if(mExistingAccounts_.Enabled)
			{
				mExistingAccounts_.SelectedIndex = mExistingAccounts_.FindStringExact(mAccount_.Nickname);
			}
			else
			{
				mExistingAccounts_.SelectedItems.Clear();
			}
			
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
			ImportTxnsRQ request = new ImportTxnsRQ();
            request.BankAccount = GetAccount();
            request.Operator = MiskoFinanceMain.Instance.Operator;
            request.VwTxns = mOfxDocument_.Transactions;
            request.FromDate = mOfxDocument_.StartDate;
            request.ToDate = mOfxDocument_.EndDate;
            ServerConnection.SendRequest(request, ImportTxnsSuccess, ImportTxnsError);
            
            mCancel_.Enabled = false;
            mImport_.Enabled = false;
		}
		
		#endregion
    }
}
