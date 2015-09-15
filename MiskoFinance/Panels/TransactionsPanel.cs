using System;
using System.Windows.Forms;
using MiskoFinance.Controls;
using MiskoFinance.Forms;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;
using MiskoFinanceCore.Resources;
using MiskoPersist.Core;
using MiskoPersist.Message.Response;
using MiskoPersist.Tools;

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
        	
            mTransactionsGridView_.DataBindingComplete += delegate(object sender, DataGridViewBindingCompleteEventArgs e) {
            	DataGridViewColumn dgvColumn = mTransactionsGridView_.Columns["Description"];
            	mSummaryRow_.ColumnStyles[dgvColumn.Index].Width = dgvColumn.Width;
            };
            
            mTransactionsGridView_.Resize += delegate(object sender, EventArgs e) {
            	DataGridViewColumn dgvColumn = mTransactionsGridView_.Columns["Description"];
            	mSummaryRow_.ColumnStyles[dgvColumn.Index].Width = dgvColumn.Width;
            };
            
            mPageCountLbl_.Text = Utils.ResolveTextParameters(Strings.strPageCounts, new Object[] { 0, 0 });
            mTransactionCountLbl_.Text = Utils.ResolveTextParameters(Strings.strTransactionCounts, new Object[] { 0, 0 });
        }

        #region Override Methods

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			
			DataGridViewColumn dgvColumn = mTransactionsGridView_.Columns["Date"];
            mSummaryRow_.ColumnStyles[dgvColumn.Index].SizeType = SizeType.Absolute;
        	mSummaryRow_.ColumnStyles[dgvColumn.Index].Width = dgvColumn.Width;
        	
        	dgvColumn = mTransactionsGridView_.Columns["Description"];
        	mSummaryRow_.ColumnStyles[dgvColumn.Index].SizeType = SizeType.Absolute;
        	mSummaryRow_.ColumnStyles[dgvColumn.Index].Width = dgvColumn.Width;
        	
        	dgvColumn = mTransactionsGridView_.Columns["Credit"];
        	mSummaryRow_.ColumnStyles[dgvColumn.Index].SizeType = SizeType.Absolute;
        	mSummaryRow_.ColumnStyles[dgvColumn.Index].Width = dgvColumn.Width;
        	
        	dgvColumn = mTransactionsGridView_.Columns["Debit"];
        	mSummaryRow_.ColumnStyles[dgvColumn.Index].SizeType = SizeType.Absolute;
        	mSummaryRow_.ColumnStyles[dgvColumn.Index].Width = dgvColumn.Width;
        	
        	dgvColumn = mTransactionsGridView_.Columns["Transfer"];
        	mSummaryRow_.ColumnStyles[dgvColumn.Index].SizeType = SizeType.Absolute;
        	mSummaryRow_.ColumnStyles[dgvColumn.Index].Width = dgvColumn.Width;
        	
        	dgvColumn = mTransactionsGridView_.Columns["OneTime"];
        	mSummaryRow_.ColumnStyles[dgvColumn.Index].SizeType = SizeType.Absolute;
        	mSummaryRow_.ColumnStyles[dgvColumn.Index].Width = dgvColumn.Width;
        	
        	dgvColumn = mTransactionsGridView_.Columns["Category"];
        	mSummaryRow_.ColumnStyles[dgvColumn.Index].SizeType = SizeType.Absolute;
        	mSummaryRow_.ColumnStyles[dgvColumn.Index].Width = dgvColumn.Width;
		}

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
        
        private void UpdateSummary(VwSummary summary)
        {
        	mCreditTotal_.Value = summary.SelectionTotalCredits;
        	mDebitTotal_.Value = summary.SelectionTotalDebits;
        	mCreditDebitDiff_.Value = summary.SelectionCreditsDebitsDifference;
        	
        	mTotalTransferIn_.Value = summary.SelectionTotalTransfersIn;
        	mTotalTransferOut_.Value = summary.SelectionTotalTransfersOut;
        	mTransferDiff_.Value = summary.SelectionTransfersDifference;
        	
        	mTotalOneTimeIn_.Value = summary.SelectionTotalOneTimeIn;
        	mTotalOneTimeOut_.Value = summary.SelectionTotalOneTimeOut;
        	mOneTimeDiff_.Value = summary.SelectionOneTimeDifference;
        }
        
        // Callback for UpdateTxn
        private void UpdateTxnSuccess(ResponseMessage response)
        {
        	MiskoFinanceMain.Instance.SummaryPanel.Summary = ((UpdateTxnRS)response).Summary;
        	
        	UpdateSummary(((UpdateTxnRS)response).Summary);
        }
		
        // Callback method for GetTxns
        private void GetTxnsSuccess(ResponseMessage response)
        {
        	mTransactionsGridView_.DataSource.AddRange(((GetTxnsRS)response).Txns);
    		mTransactionsGridView_.DataSource.ResetBindings();
            mTransactionsGridView_.Page = response.Page;
			
			mPageCountLbl_.Text = Utils.ResolveTextParameters(Strings.strPageCounts, new Object[] { mTransactionsGridView_.Page.PageNo, mTransactionsGridView_.Page.TotalPageCount });
            mTransactionCountLbl_.Text = Utils.ResolveTextParameters(Strings.strTransactionCounts, new Object[] { mTransactionsGridView_.RowCount, mTransactionsGridView_.Page.TotalRowCount });
			
            MiskoFinanceMain.Instance.SummaryPanel.Summary = ((GetTxnsRS)response).Summary;
            MiskoFinanceMain.Instance.SearchPanel.Search.Enabled = true;
            MiskoFinanceMain.Instance.SearchPanel.More.Enabled = mTransactionsGridView_.Page.HasNext;
            
            UpdateSummary(((GetTxnsRS)response).Summary);
        } 

        #endregion
    }
}
