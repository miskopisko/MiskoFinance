using System;
using System.Windows.Forms;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;
using MiskoFinanceCore.Resources;
using MiskoPersist.Core;
using MiskoPersist.Message.Response;
using MiskoPersist.Tools;
using MiskoFinance.Controls;
using MiskoFinance.Forms;

namespace MiskoFinance.Panels
{
    public partial class TransactionsPanel : UserControl
    {
        private static Logger Log = Logger.GetInstance(typeof(TransactionsPanel));
        
        #region Fields
        
		
        
        #endregion
        
        #region Properties
        
        

        #endregion

        public TransactionsPanel()
        {
            InitializeComponent();
            
            mTransactionsGridView_.CellValueChanged += mTransactionsGridView_CellValueChanged;
            mPageCountsLbl_.Text = Utils.ResolveTextParameters(Strings.strPageCounts, new Object[] { 0, 0 });
            mTransactionCountsLbl_.Text = Utils.ResolveTextParameters(Strings.strTransactionCounts, new Object[] { 0, 0 });
        }

        #region Override Methods

        

        #endregion

        #region Event Listenners

		private void mTransactionsGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			UpdateTxnRQ request = new UpdateTxnRQ();
            request.Txn = (VwTxn)((TransactionsGridView)sender).CurrentRow.DataBoundItem;
            request.Operator = MiskoFinanceMain.Instance.Operator.OperatorId;
        	request.Account = MiskoFinanceMain.Instance.SearchPanel.Account.BankAccountId;
        	request.FromDate = MiskoFinanceMain.Instance.SearchPanel.FromDate;
        	request.ToDate = MiskoFinanceMain.Instance.SearchPanel.ToDate;
        	request.Category = MiskoFinanceMain.Instance.SearchPanel.Category.CategoryId;
        	request.Description = MiskoFinanceMain.Instance.SearchPanel.Description;
            ServerConnection.SendRequest(request, UpdateTxnSuccess);
		}     
		
        #endregion

        #region Public Methods
        
        public void Clear()
        {
        	mTransactionsGridView_.DataSource = null;
        }

		public void More()
        {
        	MiskoFinanceMain.Instance.SearchPanel.Search.Enabled = false;
        	MiskoFinanceMain.Instance.SearchPanel.More.Enabled = false;
            GetTxns();
        }

        public void Search()
        {
        	MiskoFinanceMain.Instance.SearchPanel.Search.Enabled = false;
        	MiskoFinanceMain.Instance.SearchPanel.More.Enabled = false;
            mTransactionsGridView_.DataSource = null;
           	GetTxns();
        }
        
        // Fetch all txns as per the search criteria
        public void GetTxns()
        {
        	if(MiskoFinanceMain.Instance.Operator.IsSet)
        	{
	        	GetTxnsRQ request = new GetTxnsRQ();
	            request.Operator = MiskoFinanceMain.Instance.Operator.OperatorId;
	            request.Account = MiskoFinanceMain.Instance.SearchPanel.Account.BankAccountId;
	            request.FromDate = MiskoFinanceMain.Instance.SearchPanel.FromDate;
	            request.ToDate = MiskoFinanceMain.Instance.SearchPanel.ToDate;
	            request.Category = MiskoFinanceMain.Instance.SearchPanel.Category.CategoryId;
	            request.Description = MiskoFinanceMain.Instance.SearchPanel.Description;
	            request.Page =  mTransactionsGridView_.Page.Next;
	            request.Page.RowsPerPage = MiskoFinanceMain.Instance.RowsPerPage;
	            request.Page.IncludeRecordCount = true;
	            ServerConnection.SendRequest(request, GetTxnsSuccess);
        	}
        }

        #endregion

        #region Private Methods
        
        // Callback for UpdateTxn
        private void UpdateTxnSuccess(ResponseMessage response)
        {
        	MiskoFinanceMain.Instance.SummaryPanel.Summary = ((UpdateTxnRS)response).Summary;
        }

        // Callback method for GetTxns
        private void GetTxnsSuccess(ResponseMessage response)
        {
        	mTransactionsGridView_.DataSource.AddRange(((GetTxnsRS)response).Txns);
    		mTransactionsGridView_.DataSource.ResetBindings();
            mTransactionsGridView_.Page = response.Page;
			
			mPageCountsLbl_.Text = Utils.ResolveTextParameters(Strings.strPageCounts, new Object[] { mTransactionsGridView_.Page.PageNo, mTransactionsGridView_.Page.TotalPageCount });
            mTransactionCountsLbl_.Text = Utils.ResolveTextParameters(Strings.strTransactionCounts, new Object[] { mTransactionsGridView_.RowCount, mTransactionsGridView_.Page.TotalRowCount });
			
            MiskoFinanceMain.Instance.SummaryPanel.Summary = ((GetTxnsRS)response).Summary;
            MiskoFinanceMain.Instance.SearchPanel.Search.Enabled = true;
            MiskoFinanceMain.Instance.SearchPanel.More.Enabled = mTransactionsGridView_.Page.HasNext;
        } 

        #endregion
    }
}
