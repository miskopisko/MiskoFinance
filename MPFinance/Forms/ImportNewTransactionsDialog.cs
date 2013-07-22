using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MPersist.Core;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;
using MPFinance.Core.OFX;
using MPFinance.Forms.Panels;
using MPFinance.Resources;

namespace MPFinance.Forms
{
    public partial class ImportNewTransactionsDialog : Form
    {
        private static Logger Log = Logger.GetInstance(typeof(ImportNewTransactionsDialog));

        #region Variable Declarations

        private ChooseAccountPanel mChooseAccountPanel_;
        private ChooseTransactionsPanel mChooseTransactionsPanel_;
        private OfxDocument mOfxDocument_;
        private BankAccount mAccount_;

        #endregion

        #region Properties

        

        #endregion

        #region Constructor

        public ImportNewTransactionsDialog(OfxDocument document)
        {
            mOfxDocument_ = document;           

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;

            InitializeComponent();
        }        

        #endregion

        #region Override Methods

        protected override void OnLoad(System.EventArgs e)
        {
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

        private void CheckDuplicateTxnsSuccess(AbstractResponse Response)
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

        private void ImportTxnsSuccess(AbstractResponse Response)
        {
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

        private void mChooseAccountPanel_Success(BankAccount account)
        {
            mAccount_ = account;

            Text = Strings.strCheckingForDuplicateTxns;

            CheckDuplicateTxnsRQ request = new CheckDuplicateTxnsRQ();
            request.Account = mAccount_;
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
            request.Account = mAccount_;
            request.VwTxns = mChooseTransactionsPanel_.mImportedTransactionsGridView_.GetSelected();
            MessageProcessor.SendRequest(request, ImportTxnsSuccess);
        }

        private void BackBtn_Click(object sender, System.EventArgs e)
        {
            if (mChooseAccountPanel_.Visible)
            {
                if (MPFinanceMain.Instance.OpenFileDialog.ShowDialog(this).Equals(DialogResult.OK))
                {
                    mOfxDocument_ = new OfxDocument(new FileStream(MPFinanceMain.Instance.OpenFileDialog.FileName, FileMode.Open));
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
