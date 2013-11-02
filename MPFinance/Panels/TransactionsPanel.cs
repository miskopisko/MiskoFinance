using System;
using System.Windows.Forms;
using MPersist.Core;
using MPersist.Message.Response;
using MPersist.Tools;
using MPFinance.Forms;
using MPFinanceCore.Data.Viewed;
using MPFinanceCore.Message.Requests;
using MPFinanceCore.Message.Responses;
using MPFinanceCore.Resources;
using MPersist.Data;

namespace MPFinance.Panels
{
    public partial class TransactionsPanel : UserControl
    {
        private static Logger Log = Logger.GetInstance(typeof(TransactionsPanel));

        #region Properties

        public DateTime FromDate { get { return mFromDate_.Value; } }
        public DateTime ToDate { get { return mToDate_.Value; } }
        public VwCategory Category { get { return (VwCategory)mCategory_.SelectedItem != null ? (VwCategory)mCategory_.SelectedItem : new VwCategory(); } }
        public String Description { get { return mDescription_.Text.Trim(); } }

        #endregion

        public TransactionsPanel()
        {
            InitializeComponent();
        }

        #region Override Methods

        protected override void OnLoad(System.EventArgs e)
        {
            mTransactionsGridView_.FillColumns();

            mFromDate_.Value = new DateTime(DateTime.Now.Year, 1, 1);

            mTransactionsGridView_.TxnUpdated += transactionsGridView_TxnUpdated;
            mPageCountsLbl_.Text = Utils.ResolveTextParameters(Strings.strPageCounts, new Object[] { 0, 0 });
            mTransactionCountsLbl_.Text = Utils.ResolveTextParameters(Strings.strTransactionCounts, new Object[] { 0, 0 });
        }

        #endregion

        #region Event Listenners

        // The operators categories have changed; refresh the list
        public void Operator_CategoriesChanged()
        {
            VwCategories categories = new VwCategories();
            categories.Add(new VwCategory { Name = "" });
            categories.AddRange(MPFinanceMain.Instance.Operator.Categories);
            mCategory_.DataSource = categories;
        }

        private void transactionsGridView_TxnUpdated(VwSummary summary)
        {
            MPFinanceMain.Instance.Summary = summary;
        }

        private void mMore__Click(object sender, EventArgs e)
        {
            if (mTransactionsGridView_.CurrentPage.HasNext)
            {
                GetTxns(mTransactionsGridView_.CurrentPage.PageNo + 1);
            }
        }

        private void mSearch__Click(object sender, EventArgs e)
        {
            // Load all txns if Ctrl + Click
            GetTxns((ModifierKeys & Keys.Control) == Keys.Control ? 0 : 1);
        }

        #endregion

        #region Public Methods

        public void Reset()
        {
            mTransactionsGridView_.DataSource = null;

            MPFinanceMain.Instance.Summary = new VwSummary();
            mPageCountsLbl_.Text = Utils.ResolveTextParameters(Strings.strPageCounts, new Object[] { 0, 0 });
            mTransactionCountsLbl_.Text = Utils.ResolveTextParameters(Strings.strTransactionCounts, new Object[] { 0, 0 });

            mTransactionsGridView_.CurrentPage = null;

            mSearch_.Enabled = false;
            mMore_.Enabled = false;
        }

        // Fetch all txns as per the search criteria
        public void GetTxns(Int32 page)
        {
            mTransactionsGridView_.Focus();
            mMore_.Enabled = false;
            mSearch_.Enabled = false;

            // Clear the table if fetching first page
            if(page <= 1)
            {
                mTransactionsGridView_.DataSource = new VwTxns();
            }

            GetTxnsRQ request = new GetTxnsRQ();
            request.Operator = MPFinanceMain.Instance.Operator.OperatorId;
            request.Account = MPFinanceMain.Instance.BankAccount.BankAccountId;
            request.FromDate = mFromDate_.Value;
            request.ToDate = mToDate_.Value;
            request.Category = Category.CategoryId;
            request.Description = mDescription_.Text;
            request.Page = new Page() { PageNo = page, NoRows = MPFinanceMain.Instance.RowsPerPage, IncludeRecordCount = true };
            IOController.SendRequest(request, GetTxnsSuccess);
        }

        #endregion

        #region Private Methods

        // Callback method for GetTxns
        private void GetTxnsSuccess(ResponseMessage response)
        {
            ((VwTxns)mTransactionsGridView_.DataSource).AddRange(((GetTxnsRS)response).Txns);
            ((VwTxns)mTransactionsGridView_.DataSource).ResetBindings();

            MPFinanceMain.Instance.Summary = ((GetTxnsRS)response).Summary;
            mPageCountsLbl_.Text = Utils.ResolveTextParameters(Strings.strPageCounts, new Object[] { response.Page.PageNo, response.Page.TotalPageCount });
            mTransactionCountsLbl_.Text = Utils.ResolveTextParameters(Strings.strTransactionCounts, new Object[] { response.Page.RowsFetchedSoFar, response.Page.TotalRowCount });

            mTransactionsGridView_.CurrentPage = response.Page;

            mSearch_.Enabled = true;
            mMore_.Enabled = mTransactionsGridView_.CurrentPage.HasNext;
        } 

        #endregion
    }
}
