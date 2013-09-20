using System;
using System.Windows.Forms;
using MPersist.Core;
using MPersist.Enums;
using MPersist.Message.Response;
using MPersist.MoneyType;
using MPFinance.Forms;
using MPFinanceCore.Data.Viewed;
using MPFinanceCore.Enums;
using MPFinanceCore.Message.Requests;
using MPFinanceCore.Message.Responses;
using MPFinanceCore.OFX;
using MPFinanceCore.Resources;

namespace MPFinance.Panels
{
    public partial class ChooseAccountPanel : UserControl
    {
        private static Logger Log = Logger.GetInstance(typeof(ChooseAccountPanel));

        #region Events

        public delegate void OnSuccess(VwBankAccount account);
        public event OnSuccess Success;

        public delegate void OnFail();
        public event OnFail Fail;

        #endregion

        #region Fields

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

            Refresh();
        }

        public override void Refresh()
        {
            mBankName_.Text = mOfxDocument_.BankID;
            mAccountNumber_.Text = mOfxDocument_.AccountID;
            mAccountType_.SelectedItem = mOfxDocument_.AccountType;
            mNickname_.Text = null;
            mOpeningBalance_.Value = Money.ZERO;

            GetAccountRQ request = new GetAccountRQ();
            request.AccountNo = mOfxDocument_.AccountID;
            request.Operator = MPFinanceMain.Instance.Operator.OperatorId;
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

        private void GetAccountSuccess(ResponseMessage response)
        {
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

                for (int i = 0; i < mExistingAccounts_.Items.Count; i++)
                {
                    mExistingAccounts_.SetItemChecked(i, false);
                }                
            }
        }

        private void AddAccountSuccess(ResponseMessage response)
        {
            if (Success != null)
            {
                Success(((AddAccountRS)response).NewAccount);
            }
        }

        private void AddAccountError(ResponseMessage response)
        {
            if(Fail != null)
            {
                Fail();
            }
        }

        #endregion

        #region Public Methods

        public void Refresh(OfxDocument document)
        {
            mOfxDocument_ = document;

            Refresh();
        }

        public void GetAccount()
        {
            if (mCreateNewAccount_.Checked)
            {
                AddAccountRQ request = new AddAccountRQ();
                request.Operator = MPFinanceMain.Instance.Operator;
                request.BankAccount = new VwBankAccount();
                request.BankAccount.AccountNumber = mAccountNumber_.Text.Trim();
                request.BankAccount.BankNumber = mBankName_.Text.Trim();
                request.BankAccount.Nickname = mNickname_.Text.Trim();
                request.BankAccount.AccountType = (AccountType)mAccountType_.SelectedItem;
                request.BankAccount.OpeningBalance = mOpeningBalance_.Value;
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
                        Success((VwBankAccount)mExistingAccounts_.CheckedItems[0]);
                    }
                }
            }
        }

        #endregion
    }
}
