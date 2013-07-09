using MPersist.Core;
using MPersist.Core.Data;
using MPersist.Core.Debug;
using MPersist.Core.Interfaces;
using MPersist.Core.Message.Response;
using MPersist.Core.Tools;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Data.Viewed;
using MPFinance.Core.Enums;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;
using MPFinance.Core.OFX;
using MPFinance.Properties;
using MPFinance.Resources;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace MPFinance.Forms
{
    public partial class MPFinanceMain : Form, IOController
    {   
        private static Logger Log = Logger.GetInstance(typeof(MPFinanceMain));

        #region Variable Declarations

        private static MPFinanceMain mInstance_;

        private DebugWindow mDebugWindow_;
        
        #endregion

        #region Properties

        private DebugWindow DebugWindow
        {
            get
            {
                if (mDebugWindow_ == null || mDebugWindow_.IsDisposed)
                {
                    mDebugWindow_ = new DebugWindow();
                    mDebugWindow_.WindowState = FormWindowState.Normal;           
                }
                return mDebugWindow_;
            }
        }

        public static MPFinanceMain Instance
        {
            get
            {
                if (mInstance_ == null)
                {
                    mInstance_ = new MPFinanceMain();
                }
                return mInstance_;
            }
        }

        public Operator Operator { get; set; }

        #endregion

        #region Constructor

        public MPFinanceMain()
        {
            InitializeComponent();            

            transactionsGridView.TxnUpdated += transactionsGridView_TxnUpdated;
            PageCountsLbl.Text = Utils.ResolveTextParameters(Strings.strPageCounts, new Object[] { 0, 0 });
            TransactionCountsLbl.Text = Utils.ResolveTextParameters(Strings.strTransactionCounts, new Object[] { 0, 0 });

            DebugWindow.Show();            
        }

        #endregion

        #region Local Private Methods

        // Feth all txns as per the search criteria
        private void GetTxns(Page page)
        {
            MoreBtn.Enabled = false;
            txnSearch.Enabled = false;

            GetTxnsRQ request = new GetTxnsRQ();
            request.Operator = MPFinanceMain.Instance.Operator;
//request.Account = AccountsList.SelectedNode != null ? (Account)AccountsList.SelectedNode.Tag : null;
            request.FromDate = FromDatePicker.Value;
            request.ToDate = ToDatePicker.Value;
            request.Category = (Category)AllCategoriesCmb.SelectedItem;
            request.Page = page;
            MessageProcessor.SendRequest(request, GetTxnsSuccess);
        }

        // Callback method for GetTxns
        private void GetTxnsSuccess(AbstractResponse response)
        {
            GetTxnsRS Response = response as GetTxnsRS;

            if (Response.Page.PageNo.Equals(1))
            {
                transactionsGridView.DataSource = Response.Txns;
            }
            else
            {
                ((AbstractViewedDataList<VwTxn>)transactionsGridView.DataSource).AddRange(Response.Txns);
                ((AbstractViewedDataList<VwTxn>)transactionsGridView.DataSource).ResetBindings();
            }

            summaryPanel.Update(Response.Summary);
            PageCountsLbl.Text = Utils.ResolveTextParameters(Strings.strPageCounts, new Object[] { Response.Page.PageNo, Response.Page.TotalPageCount });
            TransactionCountsLbl.Text = Utils.ResolveTextParameters(Strings.strTransactionCounts, new Object[] { Response.Page.RowsFetchedSoFar, Response.Page.TotalRowCount });

            transactionsGridView.CurrentPage = Response.Page;

            txnSearch.Enabled = true;
            MoreBtn.Enabled = transactionsGridView.CurrentPage.HasNext;
        }

        // Fetch the summary as per the selection criteris
        private void GetSummary()
        {            
            GetSummaryRQ request = new GetSummaryRQ();
            request.Operator = Operator;
//request.Account = AccountsList.SelectedNode != null ? (Account)AccountsList.SelectedNode.Tag : null;
            request.FromDate = FromDatePicker.Value;
            request.ToDate = ToDatePicker.Value;
            MessageProcessor.SendRequest(request, GetSummarySuccess);   
        }

        // Callback method for GetSummary
        private void GetSummarySuccess(AbstractResponse response)
        {
            summaryPanel.Update(((GetSummaryRS)response).Summary);
        }

        // Load the Accounts tree
        private void GetAccounts()
        {
            GetAccountsRQ request = new GetAccountsRQ();
            request.Operator = Operator;
            MessageProcessor.SendRequest(request, GetAccountsSuccess);
        }

        // Callback method for GetAccounts
        private void GetAccountsSuccess(AbstractResponse response)
        {
            AccountsList.DataSource = ((GetAccountsRS)response).Accounts;
        }

        // Load the Categories
        private void GetCategories()
        {
            GetCategoriesRQ request = new GetCategoriesRQ();
            request.Operator = MPFinanceMain.Instance.Operator;
            request.Status = Status.Active;
            MessageProcessor.SendRequest(request, GetCategoriesSuccess);
        }

        // Callback method for GetCatagories
        private void GetCategoriesSuccess(AbstractResponse response)
        {
            AllCategoriesCmb.DataSource = ((GetCategoriesRS)response).AllCategories;
        }

        // Load the operator, categories and accounts
        private void GetOperator()
        {
            GetOperatorRQ request = new GetOperatorRQ();
            request.Username = "miskopisko";
            request.FromDate = FromDatePicker.Value;
            request.ToDate = ToDatePicker.Value;
            request.Page = new Page(1);
            MessageProcessor.SendRequest(request, GetOperatorSuccess);
        }

        // Callback method for GetOperator
        private void GetOperatorSuccess(AbstractResponse response)
        {
            Operator = ((GetOperatorRS)response).Operator;
            headerLbl.Text = Operator.LastName + ", " + Operator.FirstName;

            AccountsList.DataSource = ((GetOperatorRS)response).Operator.BankAccounts;
            AllCategoriesCmb.DataSource = ((GetOperatorRS)response).Operator.Categories;
            transactionsGridView.DataSource = ((GetOperatorRS)response).Txns;

            summaryPanel.Update(((GetOperatorRS)response).Summary);
            PageCountsLbl.Text = Utils.ResolveTextParameters(Strings.strPageCounts, new Object[] { response.Page.PageNo, response.Page.TotalPageCount });
            TransactionCountsLbl.Text = Utils.ResolveTextParameters(Strings.strTransactionCounts, new Object[] { response.Page.RowsFetchedSoFar, response.Page.TotalRowCount });

            transactionsGridView.CurrentPage = response.Page;

            MoreBtn.Enabled = transactionsGridView.CurrentPage.HasNext;
        }        

        #endregion

        #region Event Listenners

        private void transactionsGridView_TxnUpdated()
        {
            GetSummary();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void AccountsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            String accountName = ((BankAccount)AccountsList.SelectedItem).Nickname;
            headerLbl.Text = Operator.LastName + ", " + Operator.FirstName + " - " + accountName;
            GetTxns(new Page(1));
        }

        private void txnSearch_Click(object sender, EventArgs e)
        {
            transactionsGridView.DataSource = null;

            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                // Load all txns if Ctrl + Click
                GetTxns(new Page(0));
            }
            else
            {
                // Load the first page of txns
                GetTxns(new Page(1));
            }            
        }

        private void oFXFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the file chooser
            if (openFileDialog.ShowDialog(this).Equals(DialogResult.OK))
            {
                // Show the new txns dialog
                new ImportNewTransactionsDialog(new OfxDocument(new FileStream(openFileDialog.FileName, FileMode.Open))).ShowDialog(this);

                GetAccounts();
            }
        }

        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the edit account dialog
            new EditAccountsDialog().ShowDialog(this);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the about dialog
            new AboutDialog().ShowDialog(this);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show settings dialog
            new SettingsDialog().ShowDialog(this);
        }

        private void MoreBtn_Click(object sender, EventArgs e)
        {
            // Fetch next page of txns
            if (transactionsGridView.CurrentPage.HasNext)
            {   
                transactionsGridView.CurrentPage = transactionsGridView.CurrentPage.NextPage;
                GetTxns(transactionsGridView.CurrentPage);
            }
        }

        private void catagoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EditCategoriesDialog().ShowDialog(this);
        }

        private void debugWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DebugWindow.Show();                
        }

        #endregion

        #region Override Methods

        protected override void OnLoad(EventArgs e)
        {
            transactionsGridView.FillColumns();

            GetOperator();
        }

        #endregion

        #region IOController Implementation

        public Int32 RowsPerPage { get { return Settings.Default.RowsPerPage; } }

        public void ExceptionHandler(Object sender, ThreadExceptionEventArgs e)
        {
            Error(new ErrorMessage(e.Exception));
        }

        public DialogResult Error(ErrorMessage message)
        {
            return MessageBox.Show(this, message.ToString(), Strings.strError, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public DialogResult Confirm(ErrorMessage message)
        {
            return MessageBox.Show(this, message.ToString(), Strings.strConfirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public DialogResult Warning(ErrorMessage message)
        {
            return MessageBox.Show(this, message.ToString(), Strings.strWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public DialogResult Info(ErrorMessage message)
        {
            return MessageBox.Show(this, message.ToString(), Strings.strInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void MessageReceived(String message)
        {
            messageStatusLbl.Text = message;
            messageStatusBar.Increment(-10);
            Application.DoEvents();
        }

        public void MessageSent(String message)
        {
            messageStatusLbl.Text = message;
            messageStatusBar.Increment(10);
            Application.DoEvents();
        }

        public void Debug(MessageTiming timing)
        {
            if(timing != null)
            {
                ((MessageTimings<MessageTiming>)DebugWindow.Messages.DataSource).Insert(0, timing);
            }
        }

        #endregion        
    }
}
