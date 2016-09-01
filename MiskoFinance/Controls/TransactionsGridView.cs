using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MiskoFinanceCore.Enums;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;
using MiskoPersist.Core;
using MiskoPersist.Message.Response;
using log4net;
using MiskoFinance.Forms;
using MiskoFinanceCore.Data.Viewed;
using MiskoPersist.Data;
using MiskoPersist.MoneyType;
using MiskoPersist.Data.Viewed;

namespace MiskoFinance.Controls
{
	public partial class TransactionsGridView : DataGridView
	{
		private static ILog Log = LogManager.GetLogger(typeof(TransactionsGridView));

		#region Fields

		private readonly DataGridViewTextBoxColumn mAccount_ = new DataGridViewTextBoxColumn();
		private readonly DataGridViewTextBoxColumn mDate_ = new DataGridViewTextBoxColumn();
		private readonly DataGridViewTextBoxColumn mDescription_ = new DataGridViewTextBoxColumn();
		private readonly DataGridViewTextBoxColumn mCredit_ = new DataGridViewTextBoxColumn();
		private readonly DataGridViewTextBoxColumn mDebit_ = new DataGridViewTextBoxColumn();
		private readonly DataGridViewCheckBoxColumn mTransfer_ = new DataGridViewCheckBoxColumn();
		private readonly DataGridViewCheckBoxColumn mOneTime_ = new DataGridViewCheckBoxColumn();
		private readonly DataGridViewComboBoxColumn mCategory_ = new DataGridViewComboBoxColumn();

		private readonly ContextMenuStrip mContextMenu_ = new TransactionsGridContextMenu();

		#endregion

		#region Properties
		
		public Page Page
		{
			get;
			set;
		}

		public override ContextMenuStrip ContextMenuStrip
		{
			get
			{
				return mContextMenu_;
			}
		}

		#endregion

		#region Constructor

		public TransactionsGridView()
		{
			InitializeComponent();
			AutoGenerateColumns = false;
			FillColumns();
		}

		#endregion

		#region Override Methods

		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			
			MouseEventArgs mouseClick = e as MouseEventArgs;

			if(mouseClick.Button.Equals(MouseButtons.Right))
			{
				mContextMenu_.Show(this, mouseClick.Location);
			}
		}

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
				
				((TxnsGridCategoriesComboBoxCell)row.Cells["Category"]).DataSource = MiskoFinanceMain.Instance.Operator.Categories.GetByType(txn.CategoryType);
				((TxnsGridCategoriesComboBoxCell)row.Cells["Category"]).Value = txn.Category;
			}
		}

		protected override void OnCurrentCellDirtyStateChanged(EventArgs e)
		{
			base.OnCurrentCellDirtyStateChanged(e);
			
			CommitEdit(DataGridViewDataErrorContexts.Commit);
			
			// Only one of transfer or one time can be selected
			if(CurrentCell.OwningColumn == mTransfer_ && (Boolean)Rows[CurrentCell.RowIndex].Cells["OneTime"].Value)
			{
				Rows[CurrentCell.RowIndex].Cells["OneTime"].Value = false;
			}
			else if(CurrentCell.OwningColumn == mOneTime_ && (Boolean)Rows[CurrentCell.RowIndex].Cells["Transfer"].Value)
			{
				Rows[CurrentCell.RowIndex].Cells["Transfer"].Value = false;
			}
			
			// If the Transfer or One Time checkbox was changed then change the category
			if(CurrentCell.OwningColumn == mTransfer_ || CurrentCell.OwningColumn == mOneTime_)
			{
				VwTxn txn = (VwTxn)Rows[CurrentCell.RowIndex].DataBoundItem;
				((TxnsGridCategoriesComboBoxCell)Rows[CurrentCell.RowIndex].Cells["Category"]).DataSource = MiskoFinanceMain.Instance.Operator.Categories.GetByType(txn.CategoryType);	
				((TxnsGridCategoriesComboBoxCell)Rows[CurrentCell.RowIndex].Cells["Category"]).Value = null;
			}

			EndEdit();
		}
		
		protected override void OnCellEndEdit(DataGridViewCellEventArgs e)
		{
			base.OnCellEndEdit(e);
			VwTxn txn = (VwTxn)Rows[e.RowIndex].DataBoundItem;
			UpdateTxn(txn);
		}
		
		#endregion

		#region Public Methods

		

		#endregion

		#region Private Methods
		
		private void UpdateTxn(VwTxn txn)
		{
			UpdateTxnRQ request = new UpdateTxnRQ();
			request.Txn = txn;
			request.Operator = MiskoFinanceMain.Instance.Operator.OperatorId;
			request.Account = MiskoFinanceMain.Instance.SearchPanel.Account.BankAccountId;
			request.FromDate = MiskoFinanceMain.Instance.SearchPanel.FromDate;
			request.ToDate = MiskoFinanceMain.Instance.SearchPanel.ToDate;
			request.Category = MiskoFinanceMain.Instance.SearchPanel.Category.CategoryId;
			request.Description = MiskoFinanceMain.Instance.SearchPanel.Description;
			Server.SendRequest(request, UpdateTxnSuccess);
		}
		
		private void UpdateTxnSuccess(ResponseMessage response)
        {
        	UpdateTxnRS rs = response as UpdateTxnRS;
        	if(rs != null)
        	{
        		MiskoFinanceMain.Instance.SummaryPanel.Summary = rs.Summary;
        		MiskoFinanceMain.Instance.TransactionsPanel.Summary = rs.Summary;
        	}
        }
		
		// Add columns to the control
		private void FillColumns()
		{
			mAccount_.DataPropertyName = "Account";
			mAccount_.HeaderText = "Account";
			mAccount_.Name = "Account";
			mAccount_.Width = 100;
			mAccount_.ReadOnly = true;
			Columns.Add(mAccount_);

			mDate_.ValueType = typeof(DateTime);
			mDate_.DataPropertyName = "DatePosted";
			mDate_.HeaderText = "Txn. Date";
			mDate_.Name = "Date";
			mDate_.DefaultCellStyle.Format = "MMM dd, yyyy";
			mDate_.Width = 100;
			mDate_.ReadOnly = true;
			Columns.Add(mDate_);

			mDescription_.DataPropertyName = "Description";
			mDescription_.HeaderText = "Description";
			mDescription_.Name = "Description";
			mDescription_.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			mDescription_.ReadOnly = true;
			Columns.Add(mDescription_);

			mCredit_.ValueType = typeof(Money);
			mCredit_.DataPropertyName = "Credit";
			mCredit_.HeaderText = "Credit";
			mCredit_.Name = "Credit";
			mCredit_.Width = 100;
			mCredit_.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			mCredit_.ReadOnly = true;
			Columns.Add(mCredit_);

			mDebit_.ValueType = typeof(Money);
			mDebit_.DataPropertyName = "Debit";
			mDebit_.HeaderText = "Debit";
			mDebit_.Name = "Debit";
			mDebit_.Width = 100;
			mDebit_.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			mDebit_.ReadOnly = true;
			Columns.Add(mDebit_);

			mTransfer_.ValueType = typeof(Boolean);
			mTransfer_.DataPropertyName = "Transfer";
			mTransfer_.HeaderText = "Transfer";
			mTransfer_.Name = "Transfer";
			mTransfer_.Width = 100;
			mTransfer_.SortMode = DataGridViewColumnSortMode.Automatic;
			Columns.Add(mTransfer_);

			mOneTime_.ValueType = typeof(Boolean);
			mOneTime_.DataPropertyName = "OneTime";
			mOneTime_.HeaderText = "One Time";
			mOneTime_.Name = "OneTime";
			mOneTime_.Width = 100;
			mOneTime_.SortMode = DataGridViewColumnSortMode.Automatic;
			Columns.Add(mOneTime_);

			mCategory_.ValueType = typeof(VwCategory);
			mCategory_.CellTemplate = new TxnsGridCategoriesComboBoxCell();
			mCategory_.HeaderText = "Category";
			mCategory_.Name = "Category";
			mCategory_.Width = 150;
			mCategory_.DataPropertyName = "Category";
			mCategory_.ValueMember = "CategoryId";
			mCategory_.DisplayMember = "Name";
			mCategory_.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
			mCategory_.SortMode = DataGridViewColumnSortMode.Automatic;
			Columns.Add(mCategory_);
		}

		#endregion
	}
	
	partial class TxnsGridCategoriesComboBoxCell : DataGridViewComboBoxCell
	{    	
		public new VwCategories DataSource
		{
			get 
			{ 
				return (VwCategories)base.DataSource;
			}
			set 
			{ 
				VwCategories dataSource = new VwCategories();
				dataSource.Add(new VwCategory());
				dataSource.Concatenate(value);
				base.DataSource = dataSource; 
			}
		}
	}

	partial class TransactionsGridContextMenu : ContextMenuStrip
	{
		#region  Fields

		private readonly ToolStripMenuItem mTransfer_ = new ToolStripMenuItem("Transfer");
		private readonly ToolStripMenuItem mOneTime_ = new ToolStripMenuItem("One Time");

		#endregion

		#region Properties

		private TransactionsGridView TransactionsGrid
		{
			get
			{
				return (TransactionsGridView)SourceControl;
			}
		}

		#endregion

		public TransactionsGridContextMenu()
		{
			mTransfer_.Click += mTransfer_Click;
			Items.Add(mTransfer_);

			mOneTime_.Click += mOneTime_Click;
			Items.Add(mOneTime_);
		}

		protected override void OnItemClicked(ToolStripItemClickedEventArgs e)
		{
			base.OnItemClicked(e);
		}

		protected override void OnOpening(CancelEventArgs e)
		{
			base.OnOpening(e);

			Point clickLocation = TransactionsGrid.PointToClient(Cursor.Position);
			Int32 currentRow = TransactionsGrid.HitTest(clickLocation.X, clickLocation.Y).RowIndex;
			
			e.Cancel = !TransactionsGrid.SelectedRows.Contains(TransactionsGrid.Rows[currentRow]);
		}

		private void mTransfer_Click(Object sender, EventArgs e)
		{
			Point clickLocation = TransactionsGrid.PointToClient(Cursor.Position);
			Int32 currentRow = TransactionsGrid.HitTest(clickLocation.X, clickLocation.Y).RowIndex;

			((VwTxn)TransactionsGrid.Rows[currentRow].DataBoundItem).Transfer = true;
		}

		private void mOneTime_Click(Object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}
