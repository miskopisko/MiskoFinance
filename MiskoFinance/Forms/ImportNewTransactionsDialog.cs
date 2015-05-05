using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;
using MiskoFinanceCore.OFX;
using MiskoFinanceCore.Resources;
using MiskoPersist.Core;
using MiskoPersist.Enums;
using MiskoPersist.Message.Response;
using MiskoFinance.Controls;
using MiskoFinance.Panels;

namespace MiskoFinance.Forms
{
    public partial class ImportNewTransactionsDialog : Form
    {
        private static Logger Log = Logger.GetInstance(typeof(ImportNewTransactionsDialog));

        #region Fields

        private readonly ChooseAccountPanel mChooseAccountPanel_ = new ChooseAccountPanel();
        private readonly ImportedTransactionsGridView mImportedTransactionsGridView_ = new ImportedTransactionsGridView();

        #endregion

        #region Properties

		public OfxDocument OfxDocument 
		{
			get;
			set;
		}

		public VwBankAccount Account 
		{
			get; 
			set;
		}

        #endregion

        #region Constructor

        public ImportNewTransactionsDialog()
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;

            InitializeComponent();

            mTableLayoutPanel_.Controls.Add(mChooseAccountPanel_, 0, 0);
            mTableLayoutPanel_.Controls.Add(mImportedTransactionsGridView_, 0, 0);
        }        

        #endregion

        #region Override Methods

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            LoadOfxDocument();
        }        

        #endregion

        #region Public Methods

        

        #endregion

        #region Private Methods

        private void LoadOfxDocument()
        {
            if (mOpenFileDialog_.ShowDialog(MiskoFinanceMain.Instance).Equals(DialogResult.OK))
            {
                OfxDocument = new OfxDocument(new FileStream(mOpenFileDialog_.FileName, FileMode.Open));

                mChooseAccountPanel_.Visible = true;
                mImportedTransactionsGridView_.Visible = false;

                mBackBtn_.Visible = true;
                mNextBtn_.Visible = true;
                mImportBtn_.Visible = false;

                RepositionWindow();

                Text = Strings.strChooseAnAccount;
                mChooseAccountPanel_.Refresh();
            }
            else
            {
                Dispose();
            }
        }

        private void CheckDuplicateTxnsSuccess(ResponseMessage Response)
        {
            Text = Strings.strChooseTxnsToAdd;

            mChooseAccountPanel_.Visible = false;
            mImportedTransactionsGridView_.Visible = true;

            mBackBtn_.Enabled = true;
            mNextBtn_.Visible = false;
            mNextBtn_.Enabled = false;
            mImportBtn_.Visible = true;
            mImportBtn_.Enabled = false;

            RepositionWindow();

            mImportedTransactionsGridView_.Txns = ((CheckDuplicateTxnsRS)Response).Txns;
        }

        private void ImportTxnsSuccess(ResponseMessage Response)
        {
            Account = ((ImportTxnsRS)Response).BankAccount;

            if (!MiskoFinanceMain.Instance.Operator.BankAccounts.Contains(Account))
            {
                MiskoFinanceMain.Instance.Operator.BankAccounts.Add(Account);
            }

            Dispose();
        }

        private void RepositionWindow()
        {
            if (Owner != null && StartPosition == FormStartPosition.Manual)
            {
                Location = new Point(Owner.Left + Owner.Width / 2 - Width / 2, Owner.Top + Owner.Height / 2 - Height / 2);
            }
        }

        #endregion

        #region Event Listenners

        private void AddAccountSuccess(ResponseMessage response)
        {
            Account = ((AddAccountRS)response).NewAccount;

            Text = Strings.strCheckingForDuplicateTxns;

            CheckDuplicateTxnsRQ request = new CheckDuplicateTxnsRQ();
            request.BankAccount = Account;
            request.FromDate = OfxDocument.StartDate;
            request.ToDate = OfxDocument.EndDate;
            request.Transactions = OfxDocument.Transactions;
            ServerConnection.SendRequest(request, CheckDuplicateTxnsSuccess);
        }

        private void AddAccountError(ResponseMessage response)
        {
            mNextBtn_.Enabled = true;
            mBackBtn_.Enabled = true;
        }

        private void nextBtn_Click(object sender, System.EventArgs e)
        {
            mNextBtn_.Enabled = false;
            mBackBtn_.Enabled = false;

            AddAccountRQ request = new AddAccountRQ();
            request.BankAccount = mChooseAccountPanel_.GetAccount();
            request.MessageMode = MessageMode.Trial;
            ServerConnection.SendRequest(request, AddAccountSuccess, AddAccountError);
        }

        private void ImportBtn_Click(object sender, System.EventArgs e)
        {
            ImportTxnsRQ request = new ImportTxnsRQ();
            request.Operator = MiskoFinanceMain.Instance.Operator;
            request.BankAccount = Account;
            request.VwTxns = mImportedTransactionsGridView_.GetSelected();
            ServerConnection.SendRequest(request, ImportTxnsSuccess);
        }

        private void BackBtn_Click(object sender, System.EventArgs e)
        {
            if (mChooseAccountPanel_.Visible)
            {
                LoadOfxDocument();
            }
            else if (mImportedTransactionsGridView_.Visible)
            {
                Text = Strings.strChooseAnAccount;

                mChooseAccountPanel_.Visible = true;
                mImportedTransactionsGridView_.Visible = false;

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
