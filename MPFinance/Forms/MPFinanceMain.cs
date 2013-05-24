using System;
using System.IO;
using System.Windows.Forms;
using MPersist.Core;
using MPersist.Core.Data;
using MPersist.Core.Interfaces;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Data.Viewed;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;
using MPFinance.Core.OFX;
using MPFinance.Resources;

namespace MPFinance.Forms
{
    public partial class MPFinanceMain : Form, IOController
    {   
        private static Logger Log = Logger.GetInstance(typeof(MPFinanceMain));

        public Categories UserCategories { get; set; }

        public MPFinanceMain()
        {
            InitializeComponent();
            transactionsGridView.FillColumns();

            transactionsGridView.TxnUpdated += transactionsGridView_TxnUpdated;

            FromDatePicker.Value = new DateTime(DateTime.Now.Year, 1, 1); // Jan 1 of current year
            ToDatePicker.Value = DateTime.Now;
        }

        #region Local Private Methods

        private void GetTxns(Page page)
        {
            // Feth all txns as per the search criteria
            GetTxnsRQ findTxns = new GetTxnsRQ();
            findTxns.Operator = Program.Operator;
            findTxns.Account = (Account)AccountsList.SelectedNode.Tag;
            findTxns.FromDate = FromDatePicker.Value;
            findTxns.ToDate = ToDatePicker.Value;
            findTxns.Page = page;
            MessageProcessor.SendRequest(findTxns, GetTxnsSuccess);
        }        

        private void GetSummary()
        {
            // Fetch the summary as per the selection criteris
            GetSummaryRQ request = new GetSummaryRQ();
            request.Operator = Program.Operator;
            request.Account = (Account)AccountsList.SelectedNode.Tag;
            request.FromDate = FromDatePicker.Value;
            request.ToDate = ToDatePicker.Value;
            MessageProcessor.SendRequest(request, GetSummarySuccess);   
        }        

        private void GetAccounts()
        {
            // Reload the Accounts tree
            GetAccountsRQ findAccounts = new GetAccountsRQ();
            findAccounts.Operator = Program.Operator;
            MessageProcessor.SendRequest(findAccounts, GetAccountsSuccess);
        }

        private void GetTxnsSuccess(AbstractResponse response)
        {
            if (((GetTxnsRS)response).Page.PageNo.Equals(1))
            {
                transactionsGridView.DataSource = ((GetTxnsRS)response).Txns;
            }
            else
            {
                ((AbstractViewedDataList<VwTxn>)transactionsGridView.DataSource).AddRange(((GetTxnsRS)response).Txns);
                ((AbstractViewedDataList<VwTxn>)transactionsGridView.DataSource).ResetBindings();
            }

            summaryPanel.Update(((GetTxnsRS)response).Summary);
            recordPageCounts.Text = ((GetTxnsRS)response).Page.PageNo + " / " + ((GetTxnsRS)response).Page.TotalPageCount;
            transactionsGridView.CurrentPage = ((GetTxnsRS)response).Page;

            MoreBtn.Enabled = transactionsGridView.CurrentPage.PageNo != transactionsGridView.CurrentPage.TotalPageCount;
        }

        private void GetSummarySuccess(AbstractResponse response)
        {
            summaryPanel.Update(((GetSummaryRS)response).Summary);
        }

        private void GetAccountsSuccess(AbstractResponse response)
        {
            AccountsList.Nodes["Accounts"].Nodes.Clear();

            foreach (Account a in ((GetAccountsRS)response).Accounts)
            {
                AccountsList.Nodes["Accounts"].Nodes.Add(a.Id.ToString(), a.Nickname).Tag = a;
            }

            AccountsList.ExpandAll();
            AccountsList.SelectedNode = AccountsList.Nodes["Accounts"];
        }

        private void GetOperatorSuccess(AbstractResponse response)
        {
            Program.Operator = ((GetOperatorRS)response).Operator;
            headerLbl.Text = Program.Operator.LastName + ", " + Program.Operator.FirstName;

            GetAccountsRQ findAccounts = new GetAccountsRQ();
            findAccounts.Operator = Program.Operator;
            MessageProcessor.SendRequest(findAccounts, GetAccountsSuccess);

            GetCategoriesRQ getCategories = new GetCategoriesRQ();
            getCategories.Operator = Program.Operator;
            MessageProcessor.SendRequest(getCategories, GetCategoriesSuccess);
        }

        private void GetCategoriesSuccess(AbstractResponse response)
        {
            UserCategories = ((GetCategoriesRS)response).Categories;
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
            GetTxns(new Page(1));
        }

        private void txnSearch_Click(object sender, EventArgs e)
        {
            GetTxns(new Page(1));
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
            GetTxns(new Page(transactionsGridView.CurrentPage.PageNo + 1));
        }

        #endregion

        #region Overridden Methods

        protected override void OnLoad(EventArgs e)
        {
            GetOperatorRQ findUser = new GetOperatorRQ();
            findUser.Username = "miskopisko";
            MessageProcessor.SendRequest(findUser, GetOperatorSuccess);
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

        #endregion
    }
}
