using System;
using System.Windows.Forms;
using log4net;
using MiskoFinance.Forms;
using MiskoFinance.Properties;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;
using MiskoFinanceCore.Resources;
using MiskoPersist.Core;
using MiskoPersist.Message.Response;
using MiskoPersist.Data.Viewed;

namespace MiskoFinance.Panels
{
	public partial class TransactionsPanel : UserControl
    {
        private static ILog Log = LogManager.GetLogger(typeof(TransactionsPanel));
        
        #region Fields
        
        
        
        #endregion
        
        #region Properties
        
        public VwSummary Summary
        {
        	set
        	{
        		mCreditTotal_.Value = value.SelectionTotalCredits;
	        	mDebitTotal_.Value = value.SelectionTotalDebits;
	        	mCreditDebitDiff_.Value = value.SelectionTotalCredits - value.SelectionTotalDebits;
	        	
	        	mTotalTransferIn_.Value = value.SelectionTotalTransfersIn;
	        	mTotalTransferOut_.Value = value.SelectionTotalTransfersOut;
	        	mTransferDiff_.Value = value.SelectionTotalTransfersIn - value.SelectionTotalTransfersOut;
	        	
	        	mTotalOneTimeIn_.Value = value.SelectionTotalOneTimeIn;
	        	mTotalOneTimeOut_.Value = value.SelectionTotalOneTimeOut;
	        	mOneTimeDiff_.Value = value.SelectionTotalOneTimeIn - value.SelectionTotalOneTimeOut;
        	}
        }

        #endregion

        public TransactionsPanel()
        {
            InitializeComponent();
        	
            mTransactionsGridView_.DataBindingComplete += delegate(Object sender, DataGridViewBindingCompleteEventArgs e) {
            	DataGridViewColumn dgvColumn = mTransactionsGridView_.Columns["Description"];
            	mSummaryRow_.ColumnStyles[dgvColumn.Index].Width = dgvColumn.Width;
            };
            
            mTransactionsGridView_.Resize += delegate(Object sender, EventArgs e) {
            	DataGridViewColumn dgvColumn = mTransactionsGridView_.Columns["Description"];
            	mSummaryRow_.ColumnStyles[dgvColumn.Index].Width = dgvColumn.Width;
            };
            
            mPageCountLbl_.Text = String.Format(Strings.strPageCounts, 0, 0);
            mTransactionCountLbl_.Text = String.Format(Strings.strTransactionCounts, 0, 0);
        }

        #region Override Methods

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			DataGridViewColumn dgvColumn = mTransactionsGridView_.Columns["Account"];
			mSummaryRow_.ColumnStyles[dgvColumn.Index].SizeType = SizeType.Absolute;
			mSummaryRow_.ColumnStyles[dgvColumn.Index].Width = dgvColumn.Width;

			dgvColumn = mTransactionsGridView_.Columns["Date"];
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

		     
		
        #endregion

        #region Public Methods
        
        public void Clear()
        {
        	mTransactionsGridView_.DataSource = null;
        	mTransactionsGridView_.Page = new Page(1, Settings.Default.RowsPerPage, true);
        	Summary = new VwSummary();
        }

		public void More()
        {
            GetTxns();
        }

        public void Search()
        {
        	Clear();
           	GetTxns();
        }
        
        // Fetch all txns as per the search criteria
        public void GetTxns()
        {
        	MiskoFinanceMain.Instance.SearchPanel.Disable();
        		
        	GetTxnsRQ request = new GetTxnsRQ();
            request.Operator = MiskoFinanceMain.Instance.Operator.OperatorId;
            request.Account = MiskoFinanceMain.Instance.SearchPanel.Account.BankAccountId;
            request.FromDate = MiskoFinanceMain.Instance.SearchPanel.FromDate.Date;
            request.ToDate = MiskoFinanceMain.Instance.SearchPanel.ToDate.Date;
            request.Category = MiskoFinanceMain.Instance.SearchPanel.Category.CategoryId;
            request.Description = MiskoFinanceMain.Instance.SearchPanel.Description;
            request.Page = mTransactionsGridView_.Page.Next;            
            Server.SendRequest(request, GetTxnsSuccess, GetTxnsError);
        }

        #endregion

        #region Private Methods
        
        // Callback method for GetTxns
        private void GetTxnsSuccess(ResponseMessage response)
        {
        	GetTxnsRS rs = response as GetTxnsRS;
        	
        	if(rs != null)
        	{
        		VwTxns txns = (VwTxns)mTransactionsGridView_.DataSource ?? new VwTxns();
        		txns.Concatenate(rs.Txns);
        		mTransactionsGridView_.DataSource = txns;
        		mTransactionsGridView_.Page = rs.Page;
	        	
        		MiskoFinanceMain.Instance.SummaryPanel.Summary = rs.Summary;
	            MiskoFinanceMain.Instance.SearchPanel.Enable(mTransactionsGridView_.Page.HasNext);
	            mPageCountLbl_.Text = String.Format(Strings.strPageCounts, mTransactionsGridView_.Page.PageNo, mTransactionsGridView_.Page.TotalPageCount);
        		mTransactionCountLbl_.Text = String.Format(Strings.strTransactionCounts, mTransactionsGridView_.RowCount, mTransactionsGridView_.Page.TotalRowCount);
	            Summary = rs.Summary;
        	}
        } 
        
        private void GetTxnsError(ResponseMessage response)
        {
        	MiskoFinanceMain.Instance.SearchPanel.Enable(true);
        }

        #endregion
    }
}
