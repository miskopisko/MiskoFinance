using MPersist.Core;
using MPFinance.Core.Data.Viewed;
using MPFinance.Core.Enums;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MPFinance.Forms.Controls
{
    public partial class ImportedTransactionsGridView : DataGridView
    {
        private static Logger Log = Logger.GetInstance(typeof(ImportedTransactionsGridView));

        public DataGridViewCheckBoxColumn Import = new DataGridViewCheckBoxColumn();
        private DataGridViewTextBoxColumn Date = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn Description = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn Credit = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn Debit = new DataGridViewTextBoxColumn();
        private DataGridViewCheckBoxColumn Transfer = new DataGridViewCheckBoxColumn();

        public ImportedTransactionsGridView()
        {
            AutoGenerateColumns = false;
            InitializeComponent();
        }

        protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in Rows)
            {
                if (((VwTxn)row.DataBoundItem).IsDuplicate)
                {
                    row.DefaultCellStyle.BackColor = Color.Salmon;
                    row.ReadOnly = true;
                }
            }

            base.OnDataBindingComplete(e);
        }     

        public VwTxns GetSelected()
        {
            VwTxns txns = new VwTxns();

            foreach (DataGridViewRow row in Rows)
            {
                if(row.Cells["Import"].Value != null && (bool)row.Cells["Import"].Value == true)
                {
                    VwTxn txn = (VwTxn)row.DataBoundItem;
                    if (row.Cells["Transfer"].Value != null && (bool)row.Cells["Transfer"].Value == true && txn.TxnType.Equals(TxnType.Credit))
                    {
                        txn.TxnType = TxnType.TransferIn;
                    }
                    else if (row.Cells["Transfer"].Value != null && (bool)row.Cells["Transfer"].Value == true && txn.TxnType.Equals(TxnType.Debit))
                    {
                        txn.TxnType = TxnType.TransferOut;
                    }
                    txns.Add(txn);
                }
            }

            return txns;
        }

        public void ToggleSelectAll(Boolean value)
        {
            foreach (DataGridViewRow row in Rows)
            {
                if(!row.ReadOnly)
                {
                    row.Cells[Columns.IndexOf(Import)].Value = value;
                }                
            }
        }

        public void FillColumns()
        {
            if (Columns.Count == 0 && !DesignMode)
            {
                Import.ValueType = typeof(bool);
                Import.DataPropertyName = "Import";
                Import.HeaderText = "Import";
                Import.Name = "Import";
                Import.Width = 75;

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
                
                Columns.AddRange(new DataGridViewColumn[] {
                                Import,
                                Date,
                                Description,
                                Credit,
                                Debit,
                                Transfer});
            }
        }
    }
}
