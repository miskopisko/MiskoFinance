using System;
using System.Windows.Forms;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Enums;
using log4net;

namespace MiskoFinance.Controls
{
	public partial class CategoriesGridView : DataGridView
    {
        private static ILog Log = LogManager.GetLogger(typeof(CategoriesGridView));

        #region Fields
        
		private readonly VwCategories mDataSource_ = new VwCategories();
		
        private readonly DataGridViewTextBoxColumn mCategoryName_ = new DataGridViewTextBoxColumn();
        private readonly DataGridViewComboBoxColumn mStatus_ = new DataGridViewComboBoxColumn();
        private readonly DataGridViewButtonColumn mDelete_ = new DataGridViewButtonColumn();

        #endregion

        #region Properties

		public new VwCategories DataSource
		{
			get
			{
				return mDataSource_;
			}
		}

        #endregion

        #region Constructor

        public CategoriesGridView()
        {
            InitializeComponent();
            AutoGenerateColumns = false;            
            FillColumns();
            
			base.DataSource = mDataSource_;
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

            if(e.RowIndex >= 0 && e.ColumnIndex.Equals(Columns.IndexOf(mDelete_)))
            {
                VwCategory category = GetItemAt(e.RowIndex);

                if(category.CategoryId.IsSet)
                {
                    category.CategoryId = -category.CategoryId;
                }
                else
                {
                	DataSource.Remove(category);
                }
            }
        }
        
        protected override void OnCurrentCellDirtyStateChanged(EventArgs e)
        {
            base.OnCurrentCellDirtyStateChanged(e);
            
            CommitEdit(DataGridViewDataErrorContexts.Commit);            
        }

        protected override void OnCellFormatting(DataGridViewCellFormattingEventArgs e)
        {
            base.OnCellFormatting(e);

            if(e.RowIndex >= 0 && e.RowIndex < DataSource.Count && e.ColumnIndex.Equals(Columns.IndexOf(mDelete_)))
            {
                Rows[e.RowIndex].Cells[e.ColumnIndex].Value = GetItemAt(e.RowIndex).CategoryId >= 0 ? "Delete" : "Undelete";
            }
        } 

        #endregion

        #region Private Methods

        private VwCategory GetItemAt(Int32 row)
        {
            return (VwCategory)Rows[row].DataBoundItem;
        }
		
        private void FillColumns()
        {
        	mCategoryName_.ValueType = typeof(String);
            mCategoryName_.DataPropertyName = "Name";
            mCategoryName_.HeaderText = "Name";
            mCategoryName_.Name = "Name";
            mCategoryName_.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            
            mStatus_.ValueType = typeof(Status);
            mStatus_.CellTemplate = new MiskoEnumComboBoxCell();
            mStatus_.HeaderText = "Status";
            mStatus_.Name = "Status";
            mStatus_.Width = 100;
			mStatus_.DisplayMember = "Description";
            mStatus_.DataPropertyName = "Status";
            mStatus_.DataSource = MiskoFinanceCore.Enums.Status.NonNullElements;
            mStatus_.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            mStatus_.SortMode = DataGridViewColumnSortMode.Automatic;            
            
            mDelete_.ValueType = typeof(String);
            mDelete_.HeaderText = "";
            mDelete_.FlatStyle = FlatStyle.Flat;
            mDelete_.Width = 75;
            mDelete_.SortMode = DataGridViewColumnSortMode.Automatic;
            mDelete_.ReadOnly = false;

            Columns.AddRange(new DataGridViewColumn[] {
                            mCategoryName_,
                            mStatus_,
                            mDelete_});
            
        }

        #endregion

        #region Public Methods

        

        #endregion
    }
    
    
}
