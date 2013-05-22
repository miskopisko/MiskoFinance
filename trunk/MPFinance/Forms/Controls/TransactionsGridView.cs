using MPersist.Core;
using MPersist.Core.Interfaces;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Data.Viewed;
using MPFinance.Core.Enums;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;
using System;
using System.Windows.Forms;

namespace MPFinance.Forms.Controls
{
    public partial class TransactionsGridView : DataGridView, IDataRequestor
    {
        public delegate void TxnUpdatedEventHandler();
        public event TxnUpdatedEventHandler TxnUpdated;

        private static Logger Log = Logger.GetInstance(typeof(TransactionsGridView));

        private DataGridViewTextBoxColumn Date = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn Description = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn Credit = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn Debit = new DataGridViewTextBoxColumn();
        private DataGridViewComboBoxColumn Category = new DataGridViewComboBoxColumn();
        private DataGridViewCheckBoxColumn Transfer = new DataGridViewCheckBoxColumn();

        public TransactionsGridView()
        {
            AutoGenerateColumns = false;
            InitializeComponent();
        }

        protected override void OnCurrentCellDirtyStateChanged(EventArgs e)
        {
            if (CurrentCell is DataGridViewCheckBoxCell)
            {
                CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

            base.OnCurrentCellDirtyStateChanged(e);
        }

        protected override void OnCellValueChanged(DataGridViewCellEventArgs e)
        {
            VwTxn vwTxn = (VwTxn)Rows[e.RowIndex].DataBoundItem;

            if (vwTxn.TxnType.Equals(TxnType.Credit) || vwTxn.TxnType.Equals(TxnType.TransferIn))
            {
                vwTxn.TxnType = vwTxn.Transfer ? TxnType.TransferIn : TxnType.Credit;
            }
            else if (vwTxn.TxnType.Equals(TxnType.Debit) || vwTxn.TxnType.Equals(TxnType.TransferOut))
            {
                vwTxn.TxnType = vwTxn.Transfer ? TxnType.TransferOut : TxnType.Debit;
            }

            UpdateTxnRQ request = new UpdateTxnRQ();
            request.VwTxn = vwTxn;
            MessageProcessor.SendRequest(request, this); 

            base.OnCellValueChanged(e);
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

                Category.DataPropertyName = "Category";
                Category.HeaderText = "Category";
                Category.Name = "Category";
                Category.Width = 150;

                Columns.AddRange(new DataGridViewColumn[] {
                                Date,
                                Description,
                                Credit,
                                Debit,
                                Transfer,
                                Category});
            }
        }

        public void ResponseRecieved(AbstractResponse response)
        {
            if (!response.HasErrors && response is UpdateTxnRS)
            {
                if (TxnUpdated != null)
                {
                    TxnUpdated();
                }
            }
        }
    }
}
