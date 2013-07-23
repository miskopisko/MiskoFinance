﻿using System;
using System.Windows.Forms;
using MPersist.Core;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Enums;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;

namespace MPFinance.Forms
{
    public partial class EditAccountsDialog : Form
    {
        private static Logger Log = Logger.GetInstance(typeof(EditAccountsDialog));

        #region Variable Declarations



        #endregion

        #region Properties



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
            existingAccounts.DataSource = MPFinanceMain.Instance.Operator.BankAccounts;

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
            BankName.Text = ((BankAccount)((ListBox)sender).SelectedItem).BankNumber;
            AccountNumber.Text = ((BankAccount)((ListBox)sender).SelectedItem).AccountNumber;
            AccountTypeCmb.SelectedItem = ((BankAccount)((ListBox)sender).SelectedItem).AccountType;
            Nickname.Text = ((BankAccount)((ListBox)sender).SelectedItem).Nickname;
            OpeningBalance.Value = ((BankAccount)((ListBox)sender).SelectedItem).OpeningBalance;
        }

        private void Done_Click(object sender, EventArgs e)
        {
            if (((BankAccounts)existingAccounts.DataSource).Count > 0)
            {
                UpdateAccountsRQ request = new UpdateAccountsRQ();
                request.Accounts = ((BankAccounts)existingAccounts.DataSource);
                MessageProcessor.SendRequest(request, UpdateAccountsSuccess);
            }
            else
            {
                Dispose();
            }
        }

        private void DataChanged(object sender, EventArgs e)
        {
            ((BankAccount)existingAccounts.SelectedItem).BankNumber = BankName.Text;
            ((BankAccount)existingAccounts.SelectedItem).AccountNumber = AccountNumber.Text;
            ((BankAccount)existingAccounts.SelectedItem).AccountType = (AccountType)AccountTypeCmb.SelectedItem;
            ((BankAccount)existingAccounts.SelectedItem).Nickname = Nickname.Text;
            ((BankAccount)existingAccounts.SelectedItem).OpeningBalance = OpeningBalance.Value;
        }

        #endregion

        #region Private Methods

        private void UpdateAccountsSuccess(ResponseMessage response)
        {
            MPFinanceMain.Instance.Operator.BankAccounts = ((UpdateAccountsRS)response).Accounts;

            Dispose();
        }

        #endregion
    }
}