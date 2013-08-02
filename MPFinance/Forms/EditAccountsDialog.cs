using System;
using System.Windows.Forms;
using MPersist.Core;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Viewed;
using MPFinance.Core.Enums;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;

namespace MPFinance.Forms
{
    public partial class EditAccountsDialog : Form
    {
        private static Logger Log = Logger.GetInstance(typeof(EditAccountsDialog));

        #region Fields



        #endregion

        #region Properties

        private VwBankAccount SelectedAccount { get { return (VwBankAccount)existingAccounts.SelectedItem; } }
        private VwBankAccounts ExistingAccounts { get { return (VwBankAccounts)existingAccounts.DataSource; } set { existingAccounts.DataSource = value; } }

        #endregion

        #region Constructor

        public EditAccountsDialog()
        {
            InitializeComponent();
            AccountTypeCmb.DataSource = AccountType.Elements;

            existingAccounts.SelectedValueChanged += existingAccounts_SelectedValueChanged;
            BankName.Leave += DataChanged;
            AccountNumber.Leave += DataChanged;
            AccountTypeCmb.Leave += DataChanged;
            Nickname.Leave += DataChanged;
            OpeningBalance.Leave += DataChanged;
        }

        #endregion

        #region Override Methods

        protected override void OnLoad(EventArgs e)
        {
            ExistingAccounts = MPFinanceMain.Instance.Operator.BankAccounts;

            if (existingAccounts.Items.Count > 0)
            {
                BankName.Enabled = true;
                AccountNumber.Enabled = true;
                AccountTypeCmb.Enabled = true;
                Nickname.Enabled = true;
                OpeningBalance.Enabled = true;

                existingAccounts.SelectedIndex = 0;
            }
        }

        #endregion

        #region Event Listenners

        private void existingAccounts_SelectedValueChanged(object sender, EventArgs e)
        {
            BankName.Text = SelectedAccount.BankNumber;
            AccountNumber.Text = SelectedAccount.AccountNumber;
            AccountTypeCmb.SelectedItem = SelectedAccount.AccountType;
            Nickname.Text = SelectedAccount.Nickname;
            OpeningBalance.Value = SelectedAccount.OpeningBalance;
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
            SelectedAccount.BankNumber = BankName.Text;
            SelectedAccount.AccountNumber = AccountNumber.Text;
            SelectedAccount.AccountType = (AccountType)AccountTypeCmb.SelectedItem;
            SelectedAccount.Nickname = Nickname.Text;
            SelectedAccount.OpeningBalance = OpeningBalance.Value;
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
