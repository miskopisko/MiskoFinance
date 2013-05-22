using MPersist.Core;
using MPersist.Core.Interfaces;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Enums;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;
using MPFinance.Core.OFX;
using System;
using System.Windows.Forms;

namespace MPFinance.Forms.Panels
{
    public partial class ChooseAccountPanel : UserControl, IDataRequestor
    {
        private static Logger Log = Logger.GetInstance(typeof(ChooseAccountPanel));

        private OfxDocument mDocument_;

        public ChooseAccountPanel(OfxDocument document)
        {
            mDocument_ = document;

            InitializeComponent();

            AccountTypeCmb.DataSource = AccountType.Elements;

            BankName.Text = document.BankID;
            AccountNumber.Text = document.AccountID;            
            AccountTypeCmb.SelectedItem = document.AccountType;
            Nickname.Text = "";
            OpeningBalance.Text = "";
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            if (Visible)
            {
                Parent.Text = "Choose and account...";
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            GetAccountsRQ request = new GetAccountsRQ();
            request.Operator = Program.Operator;
            MessageProcessor.SendRequest(request, this);
        }

        private void toggleAccountCreation()
        {
            existingAccounts.Enabled = existingAccount.Checked;
            BankName.Enabled = !existingAccount.Checked;
            AccountNumber.Enabled = !existingAccount.Checked;
            OpeningBalance.Enabled = !existingAccount.Checked;
            AccountTypeCmb.Enabled = !existingAccount.Checked;
            Nickname.Enabled = !existingAccount.Checked;
        }

        private void createNewAccount_CheckedChanged(object sender, EventArgs e)
        {
            toggleAccountCreation();
        }

        private void existingAccount_CheckedChanged(object sender, EventArgs e)
        {
            toggleAccountCreation();
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

                existingAccount.Checked = accounts.Count > 0;
                createNewAccount.Checked = accounts.Count <= 0;

                if (accounts.Count == 0)
                {
                    existingAccount.Enabled = false;
                }

                GetAccountRQ request = new GetAccountRQ();
                request.AccountNo = mDocument_.AccountID;
                request.BankNo = mDocument_.BankID;
                request.AccountType = mDocument_.AccountType;
                request.Operator = Program.Operator;
                MessageProcessor.SendRequest(request, this);
            }
            else if (!response.HasErrors && response is GetAccountRS)
            {
                Account foundAccount = ((GetAccountRS)response).Account;

                for (int i = 0; i < existingAccounts.Items.Count; i++)
                {
                    existingAccounts.SetItemChecked(i, ((Account)existingAccounts.Items[i]).Id.Equals(foundAccount.Id));
                }
            }
        }
    }
}
