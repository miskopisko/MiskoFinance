using System;
using System.Windows.Forms;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Enums;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;
using MiskoFinanceCore.Resources;
using MiskoPersist.Core;
using MiskoPersist.Message.Response;
using MiskoPersist.MoneyType;
using MiskoFinance.Forms;

namespace MiskoFinance.Panels
{
    public partial class ChooseAccountPanel : UserControl
    {
        private static Logger Log = Logger.GetInstance(typeof(ChooseAccountPanel));

        #region Fields

        

        #endregion

        #region Properties

        private ImportNewTransactionsDialog Owner
        {
            get 
            { 
            	return (ImportNewTransactionsDialog)Parent.Parent; 
            }
        }

        #endregion

        public ChooseAccountPanel()
        {
            InitializeComponent();

            mExistingAccounts_.ItemCheck += existingAccounts_ItemCheck;
            mCreateNewAccount_.CheckedChanged += createNewAccount_CheckedChanged;
            mExistingAccount_.CheckedChanged += existingAccount_CheckedChanged;

            mAccountType_.DataSource = AccountType.Elements;
            mExistingAccounts_.DataSource = MiskoFinanceMain.Instance.Operator.BankAccounts;
        }

        #region Override Methods

        public override void Refresh()
        {
            base.Refresh();

            mBankName_.Text = String.Empty;
            mAccountNumber_.Text = String.Empty;
            mAccountType_.SelectedItem = AccountType.NULL;
            mNickname_.Text = String.Empty;
            mOpeningBalance_.Value = Money.ZERO;

            mExistingAccount_.Checked = false;
            mCreateNewAccount_.Checked = false;

            for (int ix = 0; ix < mExistingAccounts_.Items.Count; ++ix)
            {
                mExistingAccounts_.SetItemChecked(ix, false);
            }

            ToggleFields(false);
            
            GetAccountRQ request = new GetAccountRQ();
            request.AccountNo = Owner.OfxDocument.AccountID;
            request.Operator = MiskoFinanceMain.Instance.Operator.OperatorId;
            MessageProcessor.SendRequest(request, GetAccountSuccess);
        }

        #endregion

        #region Event Listenners

        private void existingAccounts_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < mExistingAccounts_.Items.Count; ++ix)
            {
                if (ix != e.Index)
                {
                    mExistingAccounts_.SetItemChecked(ix, false);
                }
            }

            VwBankAccount bankAccount = (VwBankAccount)mExistingAccounts_.Items[e.Index];

            mBankName_.Text = bankAccount.BankNumber;
            mAccountNumber_.Text = bankAccount.AccountNumber;
            mAccountType_.SelectedItem = bankAccount.AccountType;
            mNickname_.Text = bankAccount.Nickname;
            mOpeningBalance_.Value = bankAccount.OpeningBalance;
        }

        private void createNewAccount_CheckedChanged(object sender, EventArgs e)
        {
            ToggleAccountCreation();
        }

        private void existingAccount_CheckedChanged(object sender, EventArgs e)
        {
            ToggleAccountCreation();
        }

        #endregion

        #region Private Methods

        private void ToggleFields(Boolean value)
        {
            mExistingAccounts_.Enabled = value;
            mBankName_.Enabled = value;
            mAccountNumber_.Enabled = value;
            mOpeningBalance_.Enabled = value;
            mAccountType_.Enabled = value;
            mNickname_.Enabled = value;

            mExistingAccount_.Enabled = value;
            mCreateNewAccount_.Enabled = value;

            Owner.mBackBtn_.Enabled = value;
            Owner.mNextBtn_.Enabled = value;
            Owner.mImportBtn_.Enabled = value;
        }

        private void ToggleAccountCreation()
        {
            mExistingAccounts_.Enabled = mExistingAccount_.Checked;
            mBankName_.Enabled = !mExistingAccount_.Checked;
            mAccountNumber_.Enabled = !mExistingAccount_.Checked;
            mOpeningBalance_.Enabled = !mExistingAccount_.Checked;
            mAccountType_.Enabled = !mExistingAccount_.Checked;
            mNickname_.Enabled = !mExistingAccount_.Checked;
        }

        private void GetAccountSuccess(ResponseMessage response)
        {
            ToggleFields(true);

            if (((GetAccountRS)response).BankAccount.BankAccountId != null && ((GetAccountRS)response).BankAccount.BankAccountId.IsSet)
            {
                mExistingAccount_.Checked = true;

                for (int i = 0; i < mExistingAccounts_.Items.Count; i++)
                {
                    mExistingAccounts_.SetItemChecked(i, ((VwBankAccount)mExistingAccounts_.Items[i]).BankAccountId.Equals(((GetAccountRS)response).BankAccount.BankAccountId));
                }
            }
            else
            {
                mCreateNewAccount_.Checked = true;

                mBankName_.Text = Owner.OfxDocument.BankID;
                mAccountNumber_.Text = Owner.OfxDocument.AccountID;
                mAccountType_.SelectedItem = Owner.OfxDocument.AccountType;
                mNickname_.Text = String.Empty;
                mOpeningBalance_.Value = Money.ZERO;

                for (int i = 0; i < mExistingAccounts_.Items.Count; i++)
                {
                    mExistingAccounts_.SetItemChecked(i, false);
                }
            }
        }        

        #endregion

        #region Public Methods

        public VwBankAccount GetAccount()
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
                if (mExistingAccounts_.CheckedItems.Count == 0)
                {
                	MiskoFinanceMain.Instance.Error(ErrorStrings.errChooseExistingAccount);
                    return null;
                }
                else
                {
                    return (VwBankAccount)mExistingAccounts_.CheckedItems[0];
                }
            }
            return null;
        }

        #endregion
    }
}
