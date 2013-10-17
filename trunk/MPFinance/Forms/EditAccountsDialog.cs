using System;
using System.Windows.Forms;
using MPersist.Core;
using MPersist.Message.Response;
using MPFinanceCore.Data.Viewed;
using MPFinanceCore.Enums;
using MPFinanceCore.Message.Requests;
using MPFinanceCore.Message.Responses;

namespace MPFinance.Forms
{
    public partial class EditAccountsDialog : Form
    {
        private static Logger Log = Logger.GetInstance(typeof(EditAccountsDialog));

        #region Fields



        #endregion

        #region Properties

        private VwBankAccount SelectedAccount { get { return (VwBankAccount)mExistingAccounts_.SelectedItem; } }
        private VwBankAccounts ExistingAccounts { get { return (VwBankAccounts)mExistingAccounts_.DataSource; } set { mExistingAccounts_.DataSource = value; } }

        #endregion

        #region Constructor

        public EditAccountsDialog()
        {
            InitializeComponent();
            mAccountType_.DataSource = AccountType.Elements;

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
            ExistingAccounts = MPFinanceMain.Instance.Operator.BankAccounts;

            if (mExistingAccounts_.Items.Count > 0)
            {
                mBankName_.Enabled = true;
                mAccountNumber_.Enabled = true;
                mAccountType_.Enabled = true;
                mNickname_.Enabled = true;
                mOpeningBalance_.Enabled = true;

                mExistingAccounts_.SelectedIndex = 0;
            }
        }

        #endregion

        #region Event Listenners

        private void mCancel__Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void existingAccounts_SelectedValueChanged(object sender, EventArgs e)
        {
            mBankName_.Text = SelectedAccount.BankNumber;
            mAccountNumber_.Text = SelectedAccount.AccountNumber;
            mAccountType_.SelectedItem = SelectedAccount.AccountType;
            mNickname_.Text = SelectedAccount.Nickname;
            mOpeningBalance_.Value = SelectedAccount.OpeningBalance;
        }

        private void Done_Click(object sender, EventArgs e)
        {
            if (ExistingAccounts.Count > 0)
            {
                UpdateAccountsRQ request = new UpdateAccountsRQ();
                request.BankAccounts = ExistingAccounts;
                MessageProcessor.SendRequest(request, UpdateAccountsSuccess);
            }
            else
            {
                Dispose();
            }
        }

        private void DataChanged(object sender, EventArgs e)
        {
            SelectedAccount.BankNumber = mBankName_.Text;
            SelectedAccount.AccountNumber = mAccountNumber_.Text;
            SelectedAccount.AccountType = (AccountType)mAccountType_.SelectedItem;
            SelectedAccount.Nickname = mNickname_.Text;
            SelectedAccount.OpeningBalance = mOpeningBalance_.Value;
        }

        #endregion

        #region Private Methods

        private void UpdateAccountsSuccess(ResponseMessage response)
        {
            MPFinanceMain.Instance.Operator.BankAccounts = ((UpdateAccountsRS)response).BankAccounts;

            Dispose();
        }

        #endregion
    }
}
