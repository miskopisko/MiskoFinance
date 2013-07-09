using MPersist.Core;
using MPersist.Core.Enums;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Enums;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;
using MPFinance.Resources;
using System;
using System.Windows.Forms;

namespace MPFinance.Forms.Panels
{
    public partial class ChooseAccountPanel : UserControl
    {
        private static Logger Log = Logger.GetInstance(typeof(ChooseAccountPanel));

        #region Events

        public delegate void CompletedWork();
        public event CompletedWork OnCompletedWork;

        #endregion

        #region Variable declarations

        private ImportNewTransactionsDialog mParentForm_;
        private BankAccount mAccount_;

        #endregion

        #region Properties

        public BankAccount Account { get { return mAccount_; } }

        #endregion

        #region Constructor

        public ChooseAccountPanel(ImportNewTransactionsDialog parentForm)
        {
            mParentForm_ = parentForm;

            InitializeComponent();

            existingAccounts.ItemCheck += existingAccounts_ItemCheck;
            
            AccountTypeCmb.DataSource = AccountType.Elements;

            BankName.Text = mParentForm_.OFXDocument.BankID;
            AccountNumber.Text = mParentForm_.OFXDocument.AccountID;
            AccountTypeCmb.SelectedItem = mParentForm_.OFXDocument.AccountType;
            Nickname.Text = "";
            OpeningBalance.Text = "";
        }

        #endregion

        #region Override Methods

        protected override void OnLoad(EventArgs e)
        {
            GetAccountsRQ request = new GetAccountsRQ();
            request.Operator = MPFinanceMain.Instance.Operator;
            MessageProcessor.SendRequest(request, GetAccountsSuccess);
        }

        #endregion

        #region Event Listenners

        private void existingAccounts_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < existingAccounts.Items.Count; ++ix)
            {
                if (ix != e.Index)
                {
                    existingAccounts.SetItemChecked(ix, false);
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
            existingAccounts.Enabled = existingAccount.Checked;
            BankName.Enabled = !existingAccount.Checked;
            AccountNumber.Enabled = !existingAccount.Checked;
            OpeningBalance.Enabled = !existingAccount.Checked;
            AccountTypeCmb.Enabled = !existingAccount.Checked;
            Nickname.Enabled = !existingAccount.Checked;
        }
        
        private void GetAccountsSuccess(AbstractResponse response)
        {
            BankAccounts accounts = ((GetAccountsRS)response).Accounts;

            foreach (Account account in accounts)
            {
                existingAccounts.Items.Add(account);
            }

            existingAccount.Checked = accounts.Count > 0;
            createNewAccount.Checked = accounts.Count <= 0;

            if (accounts.Count == 0)
            {
                existingAccount.Enabled = false;
            }

            GetAccountRQ request = new GetAccountRQ();
            request.AccountNo = mParentForm_.OFXDocument.AccountID;
            request.BankNo = mParentForm_.OFXDocument.BankID;
            request.AccountType = mParentForm_.OFXDocument.AccountType;
            request.Operator = MPFinanceMain.Instance.Operator;
            MessageProcessor.SendRequest(request, GetAccountSuccess);
        }

        private void GetAccountSuccess(AbstractResponse response)
        {
            Account foundAccount = ((GetAccountRS)response).Account;

            for (int i = 0; i < existingAccounts.Items.Count; i++)
            {
                existingAccounts.SetItemChecked(i, ((Account)existingAccounts.Items[i]).Id.Equals(foundAccount.Id));
            }
        }

        private void AddAccountSuccess(AbstractResponse response)
        {
            mAccount_ = ((AddAccountRS)response).NewAccount;

            if (OnCompletedWork != null)
            {
                OnCompletedWork();
            }
        }

        private void AddAccountError(AbstractResponse response)
        {
            mParentForm_.nextBtn.Enabled = true;
        }

        #endregion

        #region Public Methods

        public void GetAccount()
        {
            if (createNewAccount.Checked)
            {
                AddAccountRQ request = new AddAccountRQ();
                request.Account = new BankAccount();
                request.Account.Operator = MPFinanceMain.Instance.Operator;
                request.Account.AccountNumber = AccountNumber.Text.Trim();
                request.Account.BankNumber = BankName.Text.Trim();
                request.Account.Nickname = Nickname.Text.Trim();
                request.Account.AccountType = (AccountType)AccountTypeCmb.SelectedItem;
                request.Account.OpeningBalance = OpeningBalance.Value;
                request.MessageMode = MessageMode.Trial; // We dont want to save the account just yet
                MessageProcessor.SendRequest(request, AddAccountSuccess, AddAccountError);
            }
            else if (existingAccount.Checked)
            {
                if (existingAccounts.CheckedItems.Count == 0)
                {
                    throw new MPException(ErrorStrings.errChooseExistingAccount);
                }
                else if (existingAccounts.CheckedItems.Count > 1)
                {
                    throw new MPException(ErrorStrings.errChooseOnlyOneExistingAccount);
                }
                else
                {
                    mAccount_ = (BankAccount)existingAccounts.CheckedItems[0];

                    if (OnCompletedWork != null)
                    {
                        OnCompletedWork();
                    }
                }
            }
        }

        #endregion
    }
}
