using System;
using System.Windows.Forms;
using MPersist.Core;
using MPersist.Data;
using MPersist.Message.Response;
using MPersist.MoneyType;
using MPFinance.Forms;
using MPFinance.Panels;
using MPFinanceCore.Data.Viewed;
using MPFinanceCore.Enums;
using MPFinanceCore.Message.Requests;
using MPFinanceCore.Message.Responses;

namespace MPFinance.Controls
{
    public partial class TransactionsGridView : DataGridView
    {
        private static Logger Log = Logger.GetInstance(typeof(TransactionsGridView));

        #region Delegates

        public delegate void TxnUpdatedEventHandler(VwSummary summary);
        public event TxnUpdatedEventHandler TxnUpdated;

        #endregion

        #region Fields

        private DataGridViewTextBoxColumn mDate_ = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn mDescription_ = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn mCredit_ = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn mDebit_ = new DataGridViewTextBoxColumn();
        private DataGridViewCheckBoxColumn mTransfer_ = new DataGridViewCheckBoxColumn();
        private DataGridViewComboBoxColumn mCategory_ = new DataGridViewComboBoxColumn();

        private Page mCurrentPage_ = new Page();

        #endregion

        #region Properties

        public Page CurrentPage { get { return mCurrentPage_; } set { mCurrentPage_ = value; } }

        #endregion

        #region Constructor

        public TransactionsGridView()
        {
            AutoGenerateColumns = false;
            InitializeComponent();
        }

        #endregion

        #region Override Methods

        protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
        {
            base.OnDataBindingComplete(e);

            foreach (DataGridViewRow row in Rows)
            {
                VwTxn txn = (VwTxn)row.DataBoundItem;

                if (txn.TxnType.Equals(TxnType.Credit))
                {
                    ((DataGridViewComboBoxCell)row.Cells["Category"]).DataSource = MPFinanceMain.Instance.Operator.Categories.GetByType(CategoryType.Income);
                }
                else if (txn.TxnType.Equals(TxnType.Debit))
                {
                    ((DataGridViewComboBoxCell)row.Cells["Category"]).DataSource = MPFinanceMain.Instance.Operator.Categories.GetByType(CategoryType.Expense);
                }
                else if (txn.TxnType.Equals(TxnType.TransferIn) || txn.TxnType.Equals(TxnType.TransferOut))
                {
                    ((DataGridViewComboBoxCell)row.Cells["Category"]).DataSource = MPFinanceMain.Instance.Operator.Categories.GetByType(CategoryType.Transfer);
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
                    ((DataGridViewComboBoxCell)Rows[e.RowIndex].Cells["Category"]).DataSource = MPFinanceMain.Instance.Operator.Categories.GetByType(CategoryType.Transfer);
                }
                else
                {
                    if(vwTxn.TxnType.Equals(TxnType.Credit))
                    {
                        ((DataGridViewComboBoxCell)Rows[e.RowIndex].Cells["Category"]).DataSource = MPFinanceMain.Instance.Operator.Categories.GetByType(CategoryType.Income);
                    }
                    else if (vwTxn.TxnType.Equals(TxnType.Debit))
                    {
                        ((DataGridViewComboBoxCell)Rows[e.RowIndex].Cells["Category"]).DataSource = MPFinanceMain.Instance.Operator.Categories.GetByType(CategoryType.Expense);
                    }
                }

                ((DataGridViewComboBoxCell)Rows[e.RowIndex].Cells["Category"]).Value = null;
            }

            UpdateTxnRQ request = new UpdateTxnRQ();
            request.Txn = vwTxn;
            request.Operator = MPFinanceMain.Instance.Operator.OperatorId;
            request.BankAccount = MPFinanceMain.Instance.BankAccount.BankAccountId;
            request.FromDate = ((TransactionsPanel)Parent.Parent).FromDate;
            request.ToDate = ((TransactionsPanel)Parent.Parent).ToDate;
            request.Category = ((TransactionsPanel)Parent.Parent).Category.CategoryId;
            request.Description = ((TransactionsPanel)Parent.Parent).Description;
            MessageProcessor.SendRequest(request, UpdateTxnSuccess);             
        }

        #endregion

        #region Public Methods

        public void FillColumns()
        {
            if (Columns.Count == 0 && !DesignMode)
            {
                mDate_.ValueType = typeof(DateTime);
                mDate_.DataPropertyName = "DatePosted";
                mDate_.HeaderText = "Txn. Date";
                mDate_.Name = "Date";
                mDate_.DefaultCellStyle.Format = "MMM dd yyyy";
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

                mCategory_.ValueType = typeof(Int64);
                mCategory_.HeaderText = "Category";
                mCategory_.Name = "Category";
                mCategory_.Width = 150;
                mCategory_.DataPropertyName = "Category";
                mCategory_.ValueMember = "Id";
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
        }

        #endregion

        #region Private Methods

        private void UpdateTxnSuccess(ResponseMessage Response)
        {
            if (TxnUpdated != null)
            {
                TxnUpdated(((UpdateTxnRS)Response).Summary);
            }
        }

        #endregion
    }
}
