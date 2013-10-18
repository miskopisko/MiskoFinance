using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MPersist.Core;
using MPersist.Enums;
using MPersist.Message.Response;
using MPFinance.Controls;
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

        private ChooseAccountPanel mChooseAccountPanel_ = new ChooseAccountPanel();
        private ImportedTransactionsGridView mImportedTransactionsGridView_ = new ImportedTransactionsGridView();
        private OfxDocument mOfxDocument_;
        private VwBankAccount mAccount_;

        #endregion

        #region Properties

        public OfxDocument OfxDocument
        {
            get { return mOfxDocument_; }
        }

        public VwBankAccount Account
        {
            get { return mAccount_; }
            set { mAccount_ = value; }
        }

        #endregion

        #region Constructor

        public ImportNewTransactionsDialog()
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;

            InitializeComponent();

            mImportedTransactionsGridView_.FillColumns();

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
            if (mOpenFileDialog_.ShowDialog(MPFinanceMain.Instance).Equals(DialogResult.OK))
            {
                mOfxDocument_ = new OfxDocument(new FileStream(mOpenFileDialog_.FileName, FileMode.Open));

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

            mImportedTransactionsGridView_.DataSource = ((CheckDuplicateTxnsRS)Response).Txns;
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
                Location = new Point(Owner.Left + Owner.Width / 2 - Width / 2, Owner.Top + Owner.Height / 2 - Height / 2);
            }
        }

        #endregion

        #region Event Listenners

        private void AddAccountSuccess(ResponseMessage response)
        {
            mAccount_ = ((AddAccountRS)response).NewAccount;

            Text = Strings.strCheckingForDuplicateTxns;

            CheckDuplicateTxnsRQ request = new CheckDuplicateTxnsRQ();
            request.BankAccount = mAccount_;
            request.FromDate = mOfxDocument_.StartDate;
            request.ToDate = mOfxDocument_.EndDate;
            request.Transactions = mOfxDocument_.Transactions;
            IOController.SendRequest(request, CheckDuplicateTxnsSuccess);
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
            IOController.SendRequest(request, AddAccountSuccess, AddAccountError);
        }

        private void ImportBtn_Click(object sender, System.EventArgs e)
        {
            ImportTxnsRQ request = new ImportTxnsRQ();
            request.Operator = MPFinanceMain.Instance.Operator;
            request.BankAccount = mAccount_;
            request.VwTxns = mImportedTransactionsGridView_.GetSelected();
            IOController.SendRequest(request, ImportTxnsSuccess);
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
