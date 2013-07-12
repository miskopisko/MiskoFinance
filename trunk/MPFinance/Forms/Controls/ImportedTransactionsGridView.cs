using System;
using System.Windows.Forms;
using MPersist.Core;
using MPersist.Core.MoneyType;
using MPFinance.Core.Data.Viewed;
using MPFinance.Core.Enums;

namespace MPFinance.Forms.Controls
{
    public partial class ImportedTransactionsGridView : DataGridView
    {
        private static Logger Log = Logger.GetInstance(typeof(ImportedTransactionsGridView));

        #region Variable Declarations

        private DataGridViewCheckBoxColumn mImport_ = new DataGridViewCheckBoxColumn();
        private DataGridViewTextBoxColumn mDate_ = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn mDescription_ = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn mCredit_ = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn mDebit_ = new DataGridViewTextBoxColumn();
        private DataGridViewCheckBoxColumn mTransfer_ = new DataGridViewCheckBoxColumn();

        private Int32 mSelectableRecords_ = 0;
        private Int32 mSelectedRecords_ = 0;

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
            mSelectableRecords_ = Rows.Count;

            ((CheckBoxHeaderCell)mImport_.HeaderCell).Enabled = mSelectableRecords_ > 0;

            base.OnDataBindingComplete(e);
        }

        protected override void OnCellValueChanged(DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(Columns.IndexOf(mImport_)) && e.RowIndex >= 0)
            {
                mSelectedRecords_ += ((Boolean)Rows[e.RowIndex].Cells[e.ColumnIndex].Value) ? 1 : -1;

                //Change state of the header CheckBox.
                if (mSelectableRecords_ == 0 || mSelectedRecords_ < mSelectableRecords_)
                {
                    ((CheckBoxHeaderCell)mImport_.HeaderCell).Checked = false;
                }
                else if (mSelectedRecords_ == mSelectableRecords_)
                {
                    ((CheckBoxHeaderCell)mImport_.HeaderCell).Checked = true;
                }

                // Repaint the checkboxes
                InvalidateColumn(Columns.IndexOf(mImport_));
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
                mImport_.ValueType = typeof(bool);
                mImport_.DataPropertyName = "Import";
                mImport_.HeaderText = "Import";
                mImport_.Name = "Import";
                mImport_.Width = 75;

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
                
                Columns.AddRange(new DataGridViewColumn[] {
                                mImport_,
                                mDate_,
                                mDescription_,
                                mCredit_,
                                mDebit_,
                                mTransfer_});

                Columns["Import"].HeaderCell = new CheckBoxHeaderCell("Import");
                ((CheckBoxHeaderCell)Columns["Import"].HeaderCell).OnCheckBoxClicked += new CheckBoxHeaderCell.CheckBoxClickedHandler(cbHeader_OnCheckBoxClicked);
                ((CheckBoxHeaderCell)mImport_.HeaderCell).Enabled = false;
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

            mSelectedRecords_ = state ? mSelectableRecords_ : 0;
        }

        #endregion
    }
}
