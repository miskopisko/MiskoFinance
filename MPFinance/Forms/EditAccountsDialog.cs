using MPersist.Core;
using MPersist.Core.Interfaces;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Enums;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;
using System;
using System.Windows.Forms;

namespace MPFinance.Forms
{
    public partial class EditAccountsDialog : Form, IDataRequestor
    {
        public EditAccountsDialog()
        {
            InitializeComponent();
            AccountTypeCmb.DataSource = AccountType.Elements;
            existingAccounts.SelectedValueChanged += existingAccounts_SelectedValueChanged;
        }

        private void existingAccounts_SelectedValueChanged(object sender, EventArgs e)
        {
            Account account = (Account)((ListBox)sender).SelectedItem;

            BankName.Text = account.BankNumber;
            AccountNumber.Text = account.AccountNumber;
            AccountTypeCmb.SelectedItem = account.AccountType;
            Nickname.Text = account.Nickname;
            OpeningBalance.Value = account.OpeningBalance;
        }

        protected override void OnLoad(EventArgs e)
        {
            GetAccountsRQ request = new GetAccountsRQ();
            request.Operator = Program.Operator;
            MessageProcessor.SendRequest(request, this);
        }

        private void Done_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        public void ResponseRecieved(AbstractResponse response)
        {
            if (!response.HasErrors && response is GetAccountsRS)
            {
                Accounts accounts = ((GetAccountsRS)response).Accounts;

                foreach (Account account in accounts)
                {
                    existingAccounts.Items.Add(account);
                }

                if (accounts.Count > 0)
                {
                    existingAccounts.SelectedIndex = 0;
                }
            }
            else if (!response.HasErrors && response is UpdateAccountRS)
            {
                return;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            UpdateAccountRQ request = new UpdateAccountRQ();
            request.Account = (Account)existingAccounts.SelectedItem;
            request.Account.BankNumber = BankName.Text;
            request.Account.AccountNumber = AccountNumber.Text;
            request.Account.AccountType = (AccountType)AccountTypeCmb.SelectedItem;
            request.Account.Nickname = Nickname.Text;
            request.Account.OpeningBalance = OpeningBalance.Value;
            MessageProcessor.SendRequest(request, this);
        }
    }
}
