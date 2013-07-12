using System;
using System.Windows.Forms;
using MPersist.Core;
using MPersist.Core.Enums;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Enums;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;
using MPFinance.Core.OFX;
using MPFinance.Resources;

namespace MPFinance.Forms.Panels
{
    public partial class ChooseAccountPanel : UserControl
    {
        private static Logger Log = Logger.GetInstance(typeof(ChooseAccountPanel));

        #region Events

        public delegate void OnSuccess(BankAccount account);
        public event OnSuccess Success;

        public delegate void OnFail();
        public event OnFail Fail;

        #endregion

        #region Variable Declarations

        private OfxDocument mOfxDocument_;

        #endregion

        #region Properties



        #endregion

        #region Constructor

        public ChooseAccountPanel(OfxDocument ofxDocument)
        {
            mOfxDocument_ = ofxDocument;

            InitializeComponent();

            mExistingAccounts_.ItemCheck += existingAccounts_ItemCheck;
        }

        #endregion

        #region Override Methods

        protected override void OnLoad(EventArgs e)
        {
            mAccountType_.DataSource = AccountType.Elements;
            mExistingAccounts_.DataSource = MPFinanceMain.Instance.Operator.BankAccounts;

            mBankName_.Text = mOfxDocument_.BankID;
            mAccountNumber_.Text = mOfxDocument_.AccountID;
            mAccountType_.SelectedItem = mOfxDocument_.AccountType;

            mExistingAccount_.Checked = mExistingAccounts_.Items.Count > 0;
            mCreateNewAccount_.Checked = !mExistingAccount_.Checked;

            if (mExistingAccounts_.Items.Count == 0)
            {
                mExistingAccount_.Enabled = false;
            }

            GetAccountRQ request = new GetAccountRQ();
            request.AccountNo = mOfxDocument_.AccountID;
            request.BankNo = mOfxDocument_.BankID;
            request.AccountType = mOfxDocument_.AccountType;
            request.Operator = MPFinanceMain.Instance.Operator.Id;
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
        }

        private void createNewAccount_CheckedChanged(object sender, EventArgs e)
        {
            toggleAccountCreation();
        }

        private void existingAccount_CheckedChanged(object sender, EventArgs e)
        {
            toggleAccountCreation();
        }

        #endregion

        #region Private Methods

        private void toggleAccountCreation()
        {
            mExistingAccounts_.Enabled = mExistingAccount_.Checked;
            mBankName_.Enabled = !mExistingAccount_.Checked;
            mAccountNumber_.Enabled = !mExistingAccount_.Checked;
            mOpeningBalance_.Enabled = !mExistingAccount_.Checked;
            mAccountType_.Enabled = !mExistingAccount_.Checked;
            mNickname_.Enabled = !mExistingAccount_.Checked;
        }

        private void GetAccountSuccess(AbstractResponse response)
        {
            Account foundAccount = ((GetAccountRS)response).Account;

            for (int i = 0; i < mExistingAccounts_.Items.Count; i++)
            {
                mExistingAccounts_.SetItemChecked(i, ((Account)mExistingAccounts_.Items[i]).Id.Equals(foundAccount.Id));
            }
        }

        private void AddAccountSuccess(AbstractResponse response)
        {
            if (Success != null)
            {
                Success(((AddAccountRS)response).NewAccount);
            }
        }

        private void AddAccountError(AbstractResponse response)
        {
            if(Fail != null)
            {
                Fail();
            }
        }

        #endregion

        #region Public Methods

        public void GetAccount()
        {
            if (mCreateNewAccount_.Checked)
            {
                AddAccountRQ request = new AddAccountRQ();
                request.Account = new BankAccount();
                request.Account.Operator = MPFinanceMain.Instance.Operator.Id;
                request.Account.AccountNumber = mAccountNumber_.Text.Trim();
                request.Account.BankNumber = mBankName_.Text.Trim();
                request.Account.Nickname = mNickname_.Text.Trim();
                request.Account.AccountType = (AccountType)mAccountType_.SelectedItem;
                request.Account.OpeningBalance = mOpeningBalance_.Value;
                request.MessageMode = MessageMode.Trial; // We dont want to save the account just yet
                MessageProcessor.SendRequest(request, AddAccountSuccess, AddAccountError);
            }
            else if (mExistingAccount_.Checked)
            {
                if (mExistingAccounts_.CheckedItems.Count == 0)
                {
                    MPFinanceMain.Instance.Error(ErrorStrings.errChooseExistingAccount);

                    if(Fail != null)
                    {
                        Fail();
                    }
                }
                else
                {
                    if (Success != null)
                    {
                        Success((BankAccount)mExistingAccounts_.CheckedItems[0]);
                    }
                }
            }
        }

        #endregion
    }
}
