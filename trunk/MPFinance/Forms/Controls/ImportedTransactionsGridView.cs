using System;
using System.Drawing;
using System.Windows.Forms;
using MPersist.Core;
using MPFinance.Core.Data.Viewed;
using MPFinance.Core.Enums;

namespace MPFinance.Forms.Controls
{
    public partial class ImportedTransactionsGridView : DataGridView
    {
        private static Logger Log = Logger.GetInstance(typeof(ImportedTransactionsGridView));

        #region Variable Declarations

        private DataGridViewCheckBoxColumn Import = new DataGridViewCheckBoxColumn();
        private DataGridViewTextBoxColumn Date = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn Description = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn Credit = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn Debit = new DataGridViewTextBoxColumn();
        private DataGridViewCheckBoxColumn Transfer = new DataGridViewCheckBoxColumn();

        private Int32 SelectableRecords = 0;
        private Int32 SelectedRecords = 0;

        #endregion

        #region Constructors

        public ImportedTransactionsGridView()
        {
            AutoGenerateColumns = false;
            InitializeComponent();
        }

        #endregion

        #region Overridden Local Methods

        protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
        {
            SelectableRecords = Rows.Count;

            foreach (DataGridViewRow row in Rows)
            {
                if (((VwTxn)row.DataBoundItem).IsDuplicate)
                {
                    row.DefaultCellStyle.BackColor = Color.Salmon;
                    row.ReadOnly = true;
                    SelectableRecords--;
                }
            }

            base.OnDataBindingComplete(e);
        }

        protected override void OnCellValueChanged(DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(Columns.IndexOf(Import)) && e.RowIndex >= 0)
            {
                SelectedRecords += ((Boolean)Rows[e.RowIndex].Cells[e.ColumnIndex].Value) ? 1 : -1;

                //Change state of the header CheckBox.
                if (SelectableRecords == 0 || SelectedRecords < SelectableRecords)
                {
                    ((CheckBoxHeaderCell)Import.HeaderCell).Checked = false;
                }
                else if (SelectedRecords == SelectableRecords)
                {
                    ((CheckBoxHeaderCell)Import.HeaderCell).Checked = true;
                }

                // Repaint the checkboxes
                InvalidateColumn(Columns.IndexOf(Import));
            }

            base.OnCellValueChanged(e);
        }

        protected override void OnCurrentCellDirtyStateChanged(EventArgs e)
        {
            if (CurrentCell is DataGridViewCheckBoxCell)
            {
                CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

            base.OnCurrentCellDirtyStateChanged(e);
        }

        #endregion

        #region Public Methods

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

                Columns["Import"].HeaderCell = new CheckBoxHeaderCell("Import");
                ((CheckBoxHeaderCell)Columns["Import"].HeaderCell).OnCheckBoxClicked += new CheckBoxHeaderCell.CheckBoxClickedHandler(cbHeader_OnCheckBoxClicked);
            }
        }

        #endregion

        #region Event Listenners

        private void cbHeader_OnCheckBoxClicked(bool state)
        {
            ((CheckBoxHeaderCell)Columns["Import"].HeaderCell).Checked = state;

            for (int i = 0; i < RowCount; i++)
            {
                if (!Rows[i].ReadOnly)
                {
                    EndEdit();
                    Rows[i].Cells["Import"].Value = state;
                }
            }

            SelectedRecords = state ? SelectableRecords : 0;
        }

        #endregion
    }
}
