using System;
using System.IO;
using System.Windows.Forms;
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
        public Categories ExpenseCategories { get; set; }
        public Categories IncomeCategories { get; set; }
        public Categories TransferCategories { get; set; }

        #endregion

        public MPFinanceMain()
        {
            InitializeComponent();
            
            MessageProcessor.IOController = this;
            MessageProcessor.ConnectionSettings = Program.mConnectionSettings_; // Temporary until user settings can be coded
            MessageProcessor.RowsPerPage = Settings.Default.RowsPerPage;

            transactionsGridView.TxnUpdated += transactionsGridView_TxnUpdated;

            DebugWindow.Show();
        }

        #region Local Private Methods

        // Feth all txns as per the search criteria
        private void GetTxns(Page page)
        {
            MoreBtn.Enabled = false;
            txnSearch.Enabled = false;

            GetTxnsRQ request = new GetTxnsRQ();
            request.Operator = MPFinanceMain.Instance.Operator;
            request.Account = AccountsList.SelectedNode != null ? (Account)AccountsList.SelectedNode.Tag : null;
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
            request.Account = AccountsList.SelectedNode != null ? (Account)AccountsList.SelectedNode.Tag : null;
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
            FillAccountsTree(((GetAccountsRS)response).Accounts);
        }

        // Refresh the accounts tree
        private void FillAccountsTree(Accounts accounts)
        {
            AccountsList.Nodes["Accounts"].Nodes.Clear();

            foreach (Account a in accounts)
            {
                AccountsList.Nodes["Accounts"].Nodes.Add(a.Id.ToString(), a.Nickname).Tag = a;
            }

            AccountsList.ExpandAll();
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
            ExpenseCategories = ((GetCategoriesRS)response).ExpenseCategories;
            IncomeCategories = ((GetCategoriesRS)response).IncomeCategories;
            TransferCategories = ((GetCategoriesRS)response).TransferCategories;
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
            GetOperatorRS Response = response as GetOperatorRS;

            Operator = Response.Operator;
            headerLbl.Text = Operator.LastName + ", " + Operator.FirstName;

            ExpenseCategories = Response.ExpenseCategories;
            IncomeCategories = Response.IncomeCategories;
            TransferCategories = Response.TransferCategories;

            FillAccountsTree(Response.Accounts);

            AllCategoriesCmb.DataSource = Response.AllCategories;

            transactionsGridView.DataSource = Response.Txns;

            summaryPanel.Update(Response.Summary);
            PageCountsLbl.Text = Utils.ResolveTextParameters(Strings.strPageCounts, new Object[] { Response.Page.PageNo, Response.Page.TotalPageCount });
            TransactionCountsLbl.Text = Utils.ResolveTextParameters(Strings.strTransactionCounts, new Object[] { Response.Page.RowsFetchedSoFar, Response.Page.TotalRowCount });

            transactionsGridView.CurrentPage = Response.Page;

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

        private void AccountsView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (Operator != null)
            {
                String accountName = AccountsList.SelectedNode.Tag != null ? " - " + ((Account)AccountsList.SelectedNode.Tag).Nickname : "";
                headerLbl.Text = Operator.LastName + ", " + Operator.FirstName + accountName;
                GetTxns(new Page(1));
            }           
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

            MPCache.Flush();

            // reload the accounts tree
            GetAccounts();

            // Reload the summary section
            GetSummary();
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

            MPCache.Flush();

            GetCategories();
        }

        private void debugWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DebugWindow.Show();                
        }

        #endregion

        #region Overridden Methods

        protected override void OnLoad(EventArgs e)
        {
            transactionsGridView.FillColumns();

            GetOperator();
        }

        #endregion

        #region IOController Implementation Methods

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
