using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using MPersist.Core;
using MPersist.Core.Data;
using MPersist.Core.Debug;
using MPersist.Core.Enums;
using MPersist.Core.Interfaces;
using MPersist.Core.Message.Response;
using MPersist.Core.Tools;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Data.Viewed;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;
using MPFinance.Core.OFX;
using MPFinance.Properties;
using MPFinance.Resources;

namespace MPFinance.Forms
{
    public partial class MPFinanceMain : Form, IOController
    {   
        private static Logger Log = Logger.GetInstance(typeof(MPFinanceMain));

        #region Fields

        private static MPFinanceMain mInstance_;

        private VwOperator mOperator_;
        
        #endregion

        #region Properties

        public static MPFinanceMain Instance
        {
            get
            {
                if (mInstance_ == null)
                {
                    mInstance_ = new MPFinanceMain();
                    Application.ThreadException += mInstance_.ExceptionHandler;
                }
                return mInstance_;
            }
        }

        public VwOperator Operator { get { return mOperator_; } }
        public VwBankAccount BankAccount { get { return (VwBankAccount)mAccountsList_.SelectedItem; } }
        public DateTime FromDate { get { return mFromDate_.Value; } }
        public DateTime ToDate { get { return mToDate_.Value; } }
        public VwCategory Category { get { return (VwCategory)mCategoriesCmb_.SelectedItem; } }
        public String Description { get { return mDescriptionSearch_.Text.Trim(); } }
        public OpenFileDialog OpenFileDialog { get { return mOpenFileDialog_; } }

        #endregion

        #region Constructor

        public MPFinanceMain()
        {
            MessageProcessor.IOController = this;

            InitializeComponent();

            mFromDate_.Value = new DateTime(DateTime.Now.Year, 1, 1);

            mTransactionsGridView_.TxnUpdated += transactionsGridView_TxnUpdated;
            mPageCountsLbl_.Text = Utils.ResolveTextParameters(Strings.strPageCounts, new Object[] { 0, 0 });
            mTransactionCountsLbl_.Text = Utils.ResolveTextParameters(Strings.strTransactionCounts, new Object[] { 0, 0 });
        }        

        #endregion

        #region Local Private Methods

        // Fetch all txns as per the search criteria
        private void GetTxns(Page page)
        {
            mTransactionsGridView_.Focus();
            mMoreBtn_.Enabled = false;
            mSearchBtn_.Enabled = false;

            // Clear the table if fetching first page
            if(page.PageNo <= 1)
            {
                mTransactionsGridView_.DataSource = new VwTxns();
            }

            GetTxnsRQ request = new GetTxnsRQ();
            request.Operator = Operator.OperatorId;
            request.Account = BankAccount.BankAccountId;
            request.FromDate = FromDate;
            request.ToDate = ToDate;
            request.Category = Category.CategoryId;
            request.Description = Description;
            request.Page = page;
            MessageProcessor.SendRequest(request, GetTxnsSuccess);
        }

        // Callback method for GetTxns
        private void GetTxnsSuccess(ResponseMessage response)
        {
            ((VwTxns)mTransactionsGridView_.DataSource).AddRange(((GetTxnsRS)response).Txns);
            ((VwTxns)mTransactionsGridView_.DataSource).ResetBindings();

            mSummaryPanel_.Update(((GetTxnsRS)response).Summary);
            mPageCountsLbl_.Text = Utils.ResolveTextParameters(Strings.strPageCounts, new Object[] { response.Page.PageNo, response.Page.TotalPageCount });
            mTransactionCountsLbl_.Text = Utils.ResolveTextParameters(Strings.strTransactionCounts, new Object[] { response.Page.RowsFetchedSoFar, response.Page.TotalRowCount });

            mTransactionsGridView_.CurrentPage = response.Page;

            mSearchBtn_.Enabled = true;
            mMoreBtn_.Enabled = mTransactionsGridView_.CurrentPage.HasNext;
        }

        // Callback method for GetOperator if successful
        private void GetOperatorSuccess(ResponseMessage response)
        {
            mOperator_ = ((GetOperatorRS)response).Operator;
            Operator.BankAccountsChanged += Operator_BankAccountsChanged;
            Operator.CategoriesChanged += Operator_CategoriesChanged;

            Operator.Refresh();

            mSummaryPanel_.Update(((GetOperatorRS)response).Summary);
            mTransactionsGridView_.DataSource = ((GetOperatorRS)response).Txns;
            mTransactionsGridView_.CurrentPage = response.Page;

            mPageCountsLbl_.Text = Utils.ResolveTextParameters(Strings.strPageCounts, new Object[] { response.Page.PageNo, response.Page.TotalPageCount });
            mTransactionCountsLbl_.Text = Utils.ResolveTextParameters(Strings.strTransactionCounts, new Object[] { response.Page.RowsFetchedSoFar, response.Page.TotalRowCount });
            mMoreBtn_.Enabled = mTransactionsGridView_.CurrentPage.HasNext;
            mSearchBtn_.Enabled = true;

            // Enable the settings menu now
            mSettingsToolStripMenuItem_.Enabled = true;
        }        

        // Callback method for GetOperator if error
        private void GetOperatorError(ResponseMessage response)
        {
            Error(new MPException(ErrorStrings.errOperatorNotFoundMustExit).ErrorMessage.Message);

            Application.Exit();
        }

        #endregion

        #region Event Listenners

        // The operators categories have changed; refresh the list
        private void Operator_CategoriesChanged()
        {
            VwCategories categories = new VwCategories();
            categories.Add(new VwCategory { Name = "" });
            categories.AddRange(Operator.Categories);
            mCategoriesCmb_.DataSource = categories;
        }

        // the operators bank accounts have changed; refresh the list
        private void Operator_BankAccountsChanged()
        {
            VwBankAccounts bankAccounts = new VwBankAccounts();
            bankAccounts.Add(new VwBankAccount { Nickname = "All" });
            bankAccounts.AddRange(Operator.BankAccounts);
            mAccountsList_.DataSource = bankAccounts;
        }

        // A transaction was updated; refresh the summary panel
        private void transactionsGridView_TxnUpdated(VwSummary summary)
        {
            mSummaryPanel_.Update(summary);
        }

        // Exit the application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        // User picked new account from list; refresh txns
        private void AccountsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetTxns(new Page(1));
        }

        // Search for transactions using search criteria
        private void Search_Click(object sender, EventArgs e)
        {
            // Load all txns if Ctrl + Click
            GetTxns(new Page((ModifierKeys & Keys.Control) == Keys.Control ? 0 : 1));
        }

        // Open file chooser and import new OFX file
        private void OFXFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mOpenFileDialog_.ShowDialog(this).Equals(DialogResult.OK))
            {
                OfxDocument document = new OfxDocument(new FileStream(mOpenFileDialog_.FileName, FileMode.Open));
                new ImportNewTransactionsDialog(document).ShowDialog(this);
            }
        }

        // Show the edit account dialog
        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EditAccountsDialog().ShowDialog(this);
        }

        // Show the about dialog
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutDialog().ShowDialog(this);
        }

        // Show settings dialog
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SettingsDialog().ShowDialog(this);
        }

        // Fetch next page of txns
        private void MoreBtn_Click(object sender, EventArgs e)
        {
            if (mTransactionsGridView_.CurrentPage.HasNext)
            {
                GetTxns(mTransactionsGridView_.CurrentPage.NextPage);
            }
        }

        // Show Edit Categorie Dialog
        private void catagoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EditCategoriesDialog().ShowDialog(this);
        }

        #endregion

        #region Override Methods

        protected override void OnLoad(EventArgs e)
        {
            mTransactionsGridView_.FillColumns();

            GetOperatorRQ request = new GetOperatorRQ();
            request.Username = "miskopisko";
            request.FromDate = FromDate;
            request.ToDate = ToDate;
            request.Page = new Page(1);
            MessageProcessor.SendRequest(request, GetOperatorSuccess, GetOperatorError);
        }

        #endregion

        #region IOController Implementation

        public Int32 RowsPerPage { get { return Settings.Default.RowsPerPage; } }

        public void ExceptionHandler(Object sender, ThreadExceptionEventArgs e)
        {
            if (e.Exception is MPException)
            {
                Error(e.Exception.Message);
            }
            else
            {
                Error(new ErrorMessage(e.Exception.TargetSite.DeclaringType, e.Exception.TargetSite, ErrorLevel.Error, ErrorStrings.errUnexpectedApplicationErrorLong, new Object[] { e.Exception.Message, e.Exception.TargetSite.DeclaringType, e.Exception.TargetSite }).Message);
            }
        }

        public DialogResult Error(String message)
        {
            return MessageBox.Show(this, message.ToString(), Strings.strError, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public DialogResult Confirm(String message)
        {
            return MessageBox.Show(this, message.ToString(), Strings.strConfirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public DialogResult Warning(String message)
        {
            return MessageBox.Show(this, message.ToString(), Strings.strWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public DialogResult Info(String message)
        {
            return MessageBox.Show(this, message.ToString(), Strings.strInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void MessageReceived(String message)
        {
            mMessageStatusLbl_.Text = message;
            mMessageStatusBar_.Increment(-10);
            Application.DoEvents();
        }

        public void MessageSent(String message)
        {
            mMessageStatusLbl_.Text = message;
            mMessageStatusBar_.Increment(10);
            Application.DoEvents();
        }

        public void Debug(MessageTiming timing)
        {
        }

        #endregion
    }
}
