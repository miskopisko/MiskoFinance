using MPersist.Core;
using MPersist.Core.Data;
using MPersist.Core.Message.Response;
using MPersist.Core.MoneyType;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Data.Viewed;
using MPFinance.Core.Enums;
using MPFinance.Core.Message.Requests;
using System;
using System.Windows.Forms;

namespace MPFinance.Forms.Controls
{
    public partial class TransactionsGridView : DataGridView
    {
        private static Logger Log = Logger.GetInstance(typeof(TransactionsGridView));

        #region Delegates

        public delegate void TxnUpdatedEventHandler();
        public event TxnUpdatedEventHandler TxnUpdated;

        #endregion

        #region Variable Declarations

        private DataGridViewTextBoxColumn Date = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn Description = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn Credit = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn Debit = new DataGridViewTextBoxColumn();
        private DataGridViewCheckBoxColumn Transfer = new DataGridViewCheckBoxColumn();
        private DGVComboBoxColumn Category = new DGVComboBoxColumn();

        private Page mCurrentPage_ = new Page();

        #endregion

        #region Properties

        public Page CurrentPage 
        { 
            get { return mCurrentPage_; }
            set { mCurrentPage_ = value; } 
        }

        #endregion

        public TransactionsGridView()
        {
            AutoGenerateColumns = false;
            InitializeComponent();
        }

        protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
        {
            base.OnDataBindingComplete(e);

            foreach (DataGridViewRow row in Rows)
            {
                VwTxn txn = (VwTxn)row.DataBoundItem;

                if (txn.TxnType.Equals(TxnType.Credit))
                {
                    ((DGVComboBoxCell)row.Cells["Category"]).DataSource = Program.GetIncomeCategories();                    
                }
                else if (txn.TxnType.Equals(TxnType.Debit))
                {
                    ((DGVComboBoxCell)row.Cells["Category"]).DataSource = Program.GetExpenseCategories();
                }
                else if (txn.TxnType.Equals(TxnType.TransferIn) || txn.TxnType.Equals(TxnType.TransferOut))
                {
                    ((DGVComboBoxCell)row.Cells["Category"]).DataSource = Program.GetTransferCategories();
                }

                ((DGVComboBoxCell)row.Cells["Category"]).Value = txn.Category;
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
            if (e.ColumnIndex.Equals(Columns.IndexOf(Transfer)))
            {
                vwTxn.Category = null;               

                if(vwTxn.Transfer)
                {
                    ((DGVComboBoxCell)Rows[e.RowIndex].Cells["Category"]).DataSource = Program.GetTransferCategories();
                }
                else
                {
                    if(vwTxn.TxnType.Equals(TxnType.Credit))
                    {
                        ((DGVComboBoxCell)Rows[e.RowIndex].Cells["Category"]).DataSource = Program.GetIncomeCategories();
                    }
                    else if (vwTxn.TxnType.Equals(TxnType.Debit))
                    {
                        ((DGVComboBoxCell)Rows[e.RowIndex].Cells["Category"]).DataSource = Program.GetExpenseCategories();
                    }
                }

                ((DGVComboBoxCell)Rows[e.RowIndex].Cells["Category"]).Value = null;
            }

            UpdateTxnRQ request = new UpdateTxnRQ();
            request.VwTxn = vwTxn;
            MessageProcessor.SendRequest(request, UpdateTxnSuccess);             
        }

        public void FillColumns()
        {
            if (Columns.Count == 0 && !DesignMode)
            {
                Date.ValueType = typeof(DateTime);
                Date.DataPropertyName = "DatePosted";
                Date.HeaderText = "Txn. Date";
                Date.Name = "Date";
                Date.DefaultCellStyle.Format = "MMM dd yyyy";
                Date.Width = 100;
                Date.ReadOnly = true;

                Description.DataPropertyName = "Description";
                Description.HeaderText = "Description";
                Description.Name = "Description";
                Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
                Description.ReadOnly = true;

                Credit.ValueType = typeof(Money);
                Credit.DataPropertyName = "Credit";
                Credit.HeaderText = "Credit";
                Credit.Name = "Credit";
                Credit.Width = 100;
                Credit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Credit.ReadOnly = true;

                Debit.ValueType = typeof(Money);
                Debit.DataPropertyName = "Debit";
                Debit.HeaderText = "Debit";
                Debit.Name = "Debit";
                Debit.Width = 100;
                Debit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Debit.ReadOnly = true;

                Transfer.ValueType = typeof(bool);
                Transfer.DataPropertyName = "Transfer";
                Transfer.HeaderText = "Transfer";
                Transfer.Name = "Transfer";
                Transfer.Width = 75;
                Transfer.SortMode = DataGridViewColumnSortMode.Automatic;

                Category.ValueType = typeof(Category);
                Category.HeaderText = "Category";
                Category.Name = "Category";
                Category.Width = 150;
                Category.DataPropertyName = "Category";
                Category.DisplayMember = "Name";
                Category.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                Category.SortMode = DataGridViewColumnSortMode.Automatic;
                
                Columns.AddRange(new DataGridViewColumn[] {
                                Date,
                                Description,
                                Credit,
                                Debit,
                                Transfer,
                                Category});
            }
        }

        public void UpdateTxnSuccess(AbstractResponse Response)
        {
            if (TxnUpdated != null)
            {
                TxnUpdated();
            }
        }
    }
}
