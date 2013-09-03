﻿using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MPersist.Core;
using MPersist.Message.Response;
using MPFinance.Panels;
using MPFinanceCore.Data.Viewed;
using MPFinanceCore.Message.Requests;
using MPFinanceCore.Message.Responses;
using MPFinanceCore.OFX;
using MPFinanceCore.Resources;

namespace MPFinance.Forms
{
    public partial class ImportNewTransactionsDialog : Form
    {
        private static Logger Log = Logger.GetInstance(typeof(ImportNewTransactionsDialog));

        #region Fields

        private ChooseAccountPanel mChooseAccountPanel_;
        private ChooseTransactionsPanel mChooseTransactionsPanel_;
        private OfxDocument mOfxDocument_;
        private VwBankAccount mAccount_;

        #endregion

        #region Properties

        

        #endregion

        #region Constructor

        public ImportNewTransactionsDialog()
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;

            InitializeComponent();
        }        

        #endregion

        #region Override Methods

        protected override void OnLoad(System.EventArgs e)
        {
            if (mOpenFileDialog_.ShowDialog(MPFinanceMain.Instance).Equals(DialogResult.OK))
            {
                mOfxDocument_ = new OfxDocument(new FileStream(mOpenFileDialog_.FileName, FileMode.Open));
            }
            else
            {
                Dispose();
            }

            mChooseAccountPanel_ = new ChooseAccountPanel(mOfxDocument_);
            mChooseTransactionsPanel_ = new ChooseTransactionsPanel();

            mTableLayoutPanel_.Controls.Add(mChooseAccountPanel_, 0, 0);
            mTableLayoutPanel_.Controls.Add(mChooseTransactionsPanel_, 0, 0);

            mChooseAccountPanel_.Success += mChooseAccountPanel_Success;
            mChooseAccountPanel_.Fail += mChooseAccountPanel_Fail;            

            mNextBtn_.Visible = true;
            mImportBtn_.Visible = false;

            mChooseAccountPanel_.Visible = true;
            mChooseTransactionsPanel_.Visible = false;

            Text = Strings.strChooseAnAccount;

            RepositionWindow();
        }        

        #endregion

        #region Public Methods

        

        #endregion

        #region Private Methods

        private void CheckDuplicateTxnsSuccess(ResponseMessage Response)
        {
            Text = Strings.strChooseTxnsToAdd;

            mChooseAccountPanel_.Visible = false;
            mChooseTransactionsPanel_.Visible = true;

            mBackBtn_.Enabled = true;
            mNextBtn_.Visible = false;
            mNextBtn_.Enabled = false;
            mImportBtn_.Visible = true;
            mImportBtn_.Enabled = true;

            RepositionWindow();

            mChooseTransactionsPanel_.mImportedTransactionsGridView_.DataSource = ((CheckDuplicateTxnsRS)Response).Txns;
        }

        private void ImportTxnsSuccess(ResponseMessage Response)
        {
            mAccount_ = ((ImportTxnsRS)Response).BankAccount;

            if (!MPFinanceMain.Instance.Operator.BankAccounts.Contains(mAccount_))
            {
                MPFinanceMain.Instance.Operator.BankAccounts.Add(mAccount_);
                MPFinanceMain.Instance.Operator.Refresh();
            }

            Dispose();
        }

        private void RepositionWindow()
        {
            if (Owner != null && StartPosition == FormStartPosition.Manual)
            {
                int offset = Owner.OwnedForms.Length * 38;  // approx. 10mm
                Point p = new Point(Owner.Left + Owner.Width / 2 - Width / 2 + offset, Owner.Top + Owner.Height / 2 - Height / 2 + offset);
                Location = p;
            }
        }

        #endregion

        #region Event Listenners

        private void mChooseAccountPanel_Fail()
        {
            mNextBtn_.Enabled = true;
            mBackBtn_.Enabled = true;
        }

        private void mChooseAccountPanel_Success(VwBankAccount account)
        {
            mAccount_ = account;

            Text = Strings.strCheckingForDuplicateTxns;

            CheckDuplicateTxnsRQ request = new CheckDuplicateTxnsRQ();
            request.BankAccount = mAccount_;
            request.FromDate = mOfxDocument_.StartDate;
            request.ToDate = mOfxDocument_.EndDate;
            request.Transactions = mOfxDocument_.Transactions;
            MessageProcessor.SendRequest(request, CheckDuplicateTxnsSuccess);
        }

        private void nextBtn_Click(object sender, System.EventArgs e)
        {
            mNextBtn_.Enabled = false;
            mBackBtn_.Enabled = false;
            mChooseAccountPanel_.GetAccount();
        }

        private void ImportBtn_Click(object sender, System.EventArgs e)
        {
            ImportTxnsRQ request = new ImportTxnsRQ();
            request.Operator = MPFinanceMain.Instance.Operator;
            request.BankAccount = mAccount_;
            request.VwTxns = mChooseTransactionsPanel_.mImportedTransactionsGridView_.GetSelected();
            MessageProcessor.SendRequest(request, ImportTxnsSuccess);
        }

        private void BackBtn_Click(object sender, System.EventArgs e)
        {
            if (mChooseAccountPanel_.Visible)
            {
                if (mOpenFileDialog_.ShowDialog(MPFinanceMain.Instance).Equals(DialogResult.OK))
                {
                    mOfxDocument_ = new OfxDocument(new FileStream(mOpenFileDialog_.FileName, FileMode.Open));
                    mChooseAccountPanel_.Refresh(mOfxDocument_);
                }
                else
                {
                    Dispose();
                }
            }
            else if (mChooseTransactionsPanel_.Visible)
            {
                Text = Strings.strChooseAnAccount;

                mChooseAccountPanel_.Visible = true;
                mChooseTransactionsPanel_.Visible = false;

                mNextBtn_.Visible = true;
                mNextBtn_.Enabled = true;
                mImportBtn_.Visible = false;
                mImportBtn_.Enabled = false;
                RepositionWindow();
            }
        }

        #endregion
    }
}