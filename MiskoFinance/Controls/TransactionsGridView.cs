using System;
using System.Windows.Forms;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Enums;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;
using MiskoPersist.Core;
using MiskoPersist.Data;
using MiskoPersist.Message.Response;
using MiskoPersist.MoneyType;
using MiskoFinance.Forms;
using MiskoFinance.Properties;

namespace MiskoFinance.Controls
{
    public partial class TransactionsGridView : DataGridView
    {
        private static Logger Log = Logger.GetInstance(typeof(TransactionsGridView));

        #region Delegates

        public delegate void TxnUpdatedEventHandler(VwSummary summary);
        public event TxnUpdatedEventHandler TxnUpdated;
        
        public delegate void FetchCompleteEventHandler(VwSummary summary, Page page);
        public event FetchCompleteEventHandler FetchComplete;

        #endregion

        #region Fields

        private readonly DataGridViewTextBoxColumn mDate_ = new DataGridViewTextBoxColumn();
        private readonly DataGridViewTextBoxColumn mDescription_ = new DataGridViewTextBoxColumn();
        private readonly DataGridViewTextBoxColumn mCredit_ = new DataGridViewTextBoxColumn();
        private readonly DataGridViewTextBoxColumn mDebit_ = new DataGridViewTextBoxColumn();
        private readonly DataGridViewCheckBoxColumn mTransfer_ = new DataGridViewCheckBoxColumn();
        private readonly DataGridViewComboBoxColumn mCategory_ = new DataGridViewComboBoxColumn();
        
        private Page mPage_ = new Page();

        #endregion

        #region Properties
        
        public VwTxns Txns
        {
        	get
        	{
        		if(DataSource == null)
        		{
        			DataSource = new VwTxns();
        		}
        		return (VwTxns)DataSource;
        	}
        	set
        	{
        		DataSource = value ?? new VwTxns();
        		if(value == null || ((VwTxns)value).Count == 0)
        		{
        			mPage_ = new Page();
        		}
        	}
        }

        #endregion

        #region Constructor

        public TransactionsGridView()
        {
            InitializeComponent();
            FillColumns();
        }

        #endregion

        #region Override Methods
        
		protected override void OnCellClick(DataGridViewCellEventArgs e)
		{
			base.OnCellClick(e);

        	// Check to make sure the cell clicked is the cell containing the combobox 
        	if(Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && (e.RowIndex != -1))
        	{
	            BeginEdit(true);
    	        ((ComboBox)EditingControl).DroppedDown = true;
    	    }
		}

        protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
        {
            base.OnDataBindingComplete(e);

            foreach (DataGridViewRow row in Rows)
            {
                VwTxn txn = (VwTxn)row.DataBoundItem;

                if (txn.TxnType.Equals(TxnType.Credit))
                {
                    ((DataGridViewComboBoxCell)row.Cells["Category"]).DataSource = MiskoFinanceMain.Instance.Operator.Categories.GetByType(CategoryType.Income, true);
                }
                else if (txn.TxnType.Equals(TxnType.Debit))
                {
                    ((DataGridViewComboBoxCell)row.Cells["Category"]).DataSource = MiskoFinanceMain.Instance.Operator.Categories.GetByType(CategoryType.Expense, true);
                }
                else if (txn.TxnType.Equals(TxnType.TransferIn) || txn.TxnType.Equals(TxnType.TransferOut))
                {
                    ((DataGridViewComboBoxCell)row.Cells["Category"]).DataSource = MiskoFinanceMain.Instance.Operator.Categories.GetByType(CategoryType.Transfer, true);
                }

                ((DataGridViewComboBoxCell)row.Cells["Category"]).Value = txn.Category;
            }
        }

        protected override void OnCurrentCellDirtyStateChanged(EventArgs e)
        {
            base.OnCurrentCellDirtyStateChanged(e);
            
            CommitEdit(DataGridViewDataErrorContexts.Commit);            
        }

        protected override void OnCellValueChanged(DataGridViewCellEventArgs e)
        {
            base.OnCellValueChanged(e);
            
            if(e.RowIndex >= 0)
            {            
	            VwTxn vwTxn = (VwTxn)Rows[e.RowIndex].DataBoundItem;
	
	            // Set the transaction type
	            if (vwTxn.TxnType.Equals(TxnType.Credit) || vwTxn.TxnType.Equals(TxnType.TransferIn))
	            {
	                vwTxn.TxnType = vwTxn.Transfer ? TxnType.TransferIn : TxnType.Credit;
	            }
	            else if (vwTxn.TxnType.Equals(TxnType.Debit) || vwTxn.TxnType.Equals(TxnType.TransferOut))
	            {
	                vwTxn.TxnType = vwTxn.Transfer ? TxnType.TransferOut : TxnType.Debit;
	            }
	
	            // If the Transfer checkbox was changed then change the category
	            if (e.ColumnIndex.Equals(Columns.IndexOf(mTransfer_)))
	            {
	                vwTxn.Category = null;               
	
	                if(vwTxn.Transfer)
	                {
	                    ((DataGridViewComboBoxCell)Rows[e.RowIndex].Cells["Category"]).DataSource = MiskoFinanceMain.Instance.Operator.Categories.GetByType(CategoryType.Transfer, true);
	                }
	                else
	                {
	                    if(vwTxn.TxnType.Equals(TxnType.Credit))
	                    {
	                        ((DataGridViewComboBoxCell)Rows[e.RowIndex].Cells["Category"]).DataSource = MiskoFinanceMain.Instance.Operator.Categories.GetByType(CategoryType.Income, true);
	                    }
	                    else if (vwTxn.TxnType.Equals(TxnType.Debit))
	                    {
	                        ((DataGridViewComboBoxCell)Rows[e.RowIndex].Cells["Category"]).DataSource = MiskoFinanceMain.Instance.Operator.Categories.GetByType(CategoryType.Expense, true);
	                    }
	                }
	
	                ((DataGridViewComboBoxCell)Rows[e.RowIndex].Cells["Category"]).Value = null;
	            }
	
	            UpdateTxnRQ request = new UpdateTxnRQ();
	            request.Txn = vwTxn;
	            request.Summary = MiskoFinanceMain.Instance.SummaryPanel.Summary;
	            ServerConnection.SendRequest(request, UpdateTxnSuccess);
            }
        }

        #endregion

        #region Public Methods

        // Fetch all txns as per the search criteria
        public void GetTxns()
        {
        	GetTxnsRQ request = new GetTxnsRQ();
            request.Operator = MiskoFinanceMain.Instance.Operator.OperatorId;
            request.Account = ((VwBankAccount)MiskoFinanceMain.Instance.AccountsList.SelectedItem).BankAccountId;
            request.FromDate = MiskoFinanceMain.Instance.TransactionsPanel.FromDate;
            request.ToDate = MiskoFinanceMain.Instance.TransactionsPanel.ToDate;
            request.Category = MiskoFinanceMain.Instance.TransactionsPanel.Category.CategoryId;
            request.Description = MiskoFinanceMain.Instance.TransactionsPanel.Description;
            request.Page = mPage_.Next;
            request.Page.RowsPerPage = MiskoFinance_IOController_Impl.Instance.RowsPerPage;
            request.Page.IncludeRecordCount = true;
            ServerConnection.SendRequest(request, GetTxnsSuccess);
        }

        #endregion

        #region Private Methods
        
        // Callback method for GetTxns
        private void GetTxnsSuccess(ResponseMessage response)
        {
        	Txns.AddRange(((GetTxnsRS)response).Txns);
    		Txns.ResetBindings();

            mPage_ = response.Page;
            
            if(FetchComplete != null)
            {
            	FetchComplete(((GetTxnsRS)response).Summary, mPage_);
            }
        } 

        // Callback method for UpdateTxns
        private void UpdateTxnSuccess(ResponseMessage response)
        {
            if (TxnUpdated != null)
            {
            	TxnUpdated(((UpdateTxnRS)response).Summary);
            }
        }
        
        // Add columns to the control
        private void FillColumns()
        {
        	Columns.Clear();
        	
            mDate_.ValueType = typeof(DateTime);
            mDate_.DataPropertyName = "DatePosted";
            mDate_.HeaderText = "Txn. Date";
            mDate_.Name = "Date";
            mDate_.DefaultCellStyle.Format = "MMM dd, yyyy";
            mDate_.Width = 100;
            mDate_.ReadOnly = true;

            mDescription_.DataPropertyName = "Description";
            mDescription_.HeaderText = "Description";
            mDescription_.Name = "Description";
            mDescription_.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            mDescription_.ReadOnly = true;

            mCredit_.ValueType = typeof(Money);
            mCredit_.DataPropertyName = "Credit";
            mCredit_.HeaderText = "Credit";
            mCredit_.Name = "Credit";
            mCredit_.Width = 100;
            mCredit_.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            mCredit_.ReadOnly = true;

            mDebit_.ValueType = typeof(Money);
            mDebit_.DataPropertyName = "Debit";
            mDebit_.HeaderText = "Debit";
            mDebit_.Name = "Debit";
            mDebit_.Width = 100;
            mDebit_.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            mDebit_.ReadOnly = true;

            mTransfer_.ValueType = typeof(bool);
            mTransfer_.DataPropertyName = "Transfer";
            mTransfer_.HeaderText = "Transfer";
            mTransfer_.Name = "Transfer";
            mTransfer_.Width = 75;
            mTransfer_.SortMode = DataGridViewColumnSortMode.Automatic;

            mCategory_.ValueType = typeof(VwCategory);
            mCategory_.HeaderText = "Category";
            mCategory_.Name = "Category";
            mCategory_.Width = 150;
            mCategory_.DataPropertyName = "Category";
            mCategory_.ValueMember = "CategoryId";
            mCategory_.DisplayMember = "Name";
            mCategory_.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            mCategory_.SortMode = DataGridViewColumnSortMode.Automatic;
            
            Columns.AddRange(new DataGridViewColumn[] {
                            mDate_,
                            mDescription_,
                            mCredit_,
                            mDebit_,
                            mTransfer_,
                            mCategory_});

        }

        #endregion
    }
}
