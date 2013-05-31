﻿using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using MPersist.Core;
using MPersist.Core.Enums;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Enums;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;
using MPFinance.Core.OFX;
using MPFinance.Forms.Panels;
using MPFinance.Resources;

namespace MPFinance.Forms
{
    public partial class ImportNewTransactionsDialog : Form
    {
        #region Variable Declarations

        private ChooseAccountPanel mChooseAccountPanel_;
        private ChooseTransactionsPanel mChooseTransactionsPanel_;

        private OfxDocument mDocument_;
        private Account mAccount_ = null;

        #endregion

        #region Properties



        #endregion

        public ImportNewTransactionsDialog(OfxDocument document)
        {
            mDocument_ = document;

            mChooseAccountPanel_ = new ChooseAccountPanel(mDocument_);
            mChooseTransactionsPanel_ = new ChooseTransactionsPanel();

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;

            InitializeComponent();

            backBtn.Visible = false;
            nextBtn.Visible = true;
            importBtn.Visible = false;
        }

        protected override void OnLoad(System.EventArgs e)
        {
            tableLayoutPanel.Controls.Add(mChooseAccountPanel_, 0, 0);
            tableLayoutPanel.Controls.Add(mChooseTransactionsPanel_, 0, 0);

            Text = "Choose an account to add the transactions to...";
            mChooseAccountPanel_.Visible = true;
            mChooseTransactionsPanel_.Visible = false;            
            repositionWindow();
        }

        private void repositionWindow()
        {
            if (Owner != null && StartPosition == FormStartPosition.Manual)
            {
                int offset = Owner.OwnedForms.Length * 38;  // approx. 10mm
                Point p = new Point(Owner.Left + Owner.Width / 2 - Width / 2 + offset, Owner.Top + Owner.Height / 2 - Height / 2 + offset);
                this.Location = p;
            }
        }

        private void nextBtn_Click(object sender, System.EventArgs e)
        {
            if (mChooseAccountPanel_.createNewAccount.Checked)
            {
                AddAccountRQ request = new AddAccountRQ();
                request.Account = new Account();
                request.Account.Operator = Program.GetOperator();
                request.Account.AccountNumber = mChooseAccountPanel_.AccountNumber.Text.Trim();
                request.Account.BankNumber = mChooseAccountPanel_.BankName.Text.Trim();
                request.Account.Nickname = mChooseAccountPanel_.Nickname.Text.Trim();
                request.Account.AccountType = (AccountType)mChooseAccountPanel_.AccountTypeCmb.SelectedItem;
                request.Account.OpeningBalance = mChooseAccountPanel_.OpeningBalance.Value;
                request.MessageMode = MessageMode.Trial; // We dont want to save the account just yet
                MessageProcessor.SendRequest(request, ResponseRecieved);
            }
            else if (mChooseAccountPanel_.existingAccount.Checked)
            {
                if (mChooseAccountPanel_.existingAccounts.CheckedItems.Count == 0)
                {
                    throw new MPException(GetType(), MethodInfo.GetCurrentMethod(), ErrorStrings.errChooseExistingAccount);
                }
                else if (mChooseAccountPanel_.existingAccounts.CheckedItems.Count > 1)
                {
                    throw new MPException(GetType(), MethodInfo.GetCurrentMethod(), ErrorStrings.errChooseOnlyOneExistingAccount);
                }
                else
                {
                    mAccount_ = (Account)mChooseAccountPanel_.existingAccounts.CheckedItems[0];

                    CheckDuplicateTxnsRQ request = new CheckDuplicateTxnsRQ();
                    request.Account = mAccount_;
                    request.OfxDucument = mDocument_;
                    MessageProcessor.SendRequest(request, ResponseRecieved);                    
                }
            }
        }

        private void importBtn_Click(object sender, System.EventArgs e)
        {
            ImportTxnsRQ request = new ImportTxnsRQ();
            request.Account = mAccount_;
            request.VwTxns = mChooseTransactionsPanel_.importedTransactionsGridView.GetSelected();
            MessageProcessor.SendRequest(request, ResponseRecieved);
        }

        private void backBtn_Click(object sender, System.EventArgs e)
        {
            mChooseAccountPanel_.Visible = true;
            mChooseTransactionsPanel_.Visible = false;
            Text = "Choose an account to add the transactions to...";
            backBtn.Visible = false;
            nextBtn.Visible = true;
            importBtn.Visible = false;
            repositionWindow();
        }

        public void ResponseRecieved(AbstractResponse response)
        {
            if (!response.HasErrors && response is AddAccountRS)
            {
                mAccount_ = ((AddAccountRS)response).NewAccount;

                CheckDuplicateTxnsRQ request = new CheckDuplicateTxnsRQ();
                request.Account = mAccount_;
                request.OfxDucument = mDocument_;
                MessageProcessor.SendRequest(request, ResponseRecieved);
            }
            else if (!response.HasErrors && response is CheckDuplicateTxnsRS)
            {
                Text = "Inspect the transactions to be added...";
                mChooseAccountPanel_.Visible = false;
                mChooseTransactionsPanel_.VwTxns = ((CheckDuplicateTxnsRS)response).Txns;
                mChooseTransactionsPanel_.Visible = true;
                backBtn.Visible = true;
                nextBtn.Visible = false;
                importBtn.Visible = true;
                repositionWindow();
            }
            else if (!response.HasErrors && response is ImportTxnsRS)
            {
                Dispose();
            }
        }
    }
}
