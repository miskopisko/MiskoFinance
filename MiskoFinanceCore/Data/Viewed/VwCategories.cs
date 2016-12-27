using System;
using log4net;
using MiskoFinanceCore.Enums;
using MiskoPersist.Core;
using MiskoPersist.Data.Viewed;
using MiskoPersist.Enums;

namespace MiskoFinanceCore.Data.Viewed
{
    public class VwCategories : ViewedDataList<VwCategory>
	{
		private static ILog Log = LogManager.GetLogger(typeof(VwCategories));

        #region Fields

        private VwCategories mIncome_;
        private VwCategories mExpense_;
        private VwCategories mTransfer_;
        private VwCategories mOneTime_;

        #endregion

        #region Properties

        public VwCategories Income
        {
            get
            {
                if (mIncome_ == null)
                {
                    mIncome_ = new VwCategories();
                    mIncome_.Add(new VwCategory());

                    foreach (VwCategory category in this)
                    {
                        if (category.CategoryId.IsSet && category.CategoryType.Equals(CategoryType.Income))
                        {
                            mIncome_.Add(category);
                        }
                    }
                }
                return mIncome_;
            }
        }

        public VwCategories Expense
        {
            get
            {
                if (mExpense_ == null)
                {
                    mExpense_ = new VwCategories();
                    mExpense_.Add(new VwCategory());

                    foreach (VwCategory category in this)
                    {
                        if (category.CategoryId.IsSet && category.CategoryType.Equals(CategoryType.Expense))
                        {
                            mExpense_.Add(category);
                        }
                    }
                }
                return mExpense_;
            }
        }

        public VwCategories Transfer
        {
            get
            {
                if (mTransfer_ == null)
                {
                    mTransfer_ = new VwCategories();
                    mTransfer_.Add(new VwCategory());

                    foreach (VwCategory category in this)
                    {
                        if (category.CategoryId.IsSet && category.CategoryType.Equals(CategoryType.Transfer))
                        {
                            mTransfer_.Add(category);
                        }
                    }
                }
                return mTransfer_;
            }
        }

        public VwCategories OneTime
        {
            get
            {
                if (mOneTime_ == null)
                {
                    mOneTime_ = new VwCategories();
                    mOneTime_.Add(new VwCategory());

                    foreach (VwCategory category in this)
                    {
                        if (category.CategoryId.IsSet && category.CategoryType.Equals(CategoryType.OneTime))
                        {
                            mOneTime_.Add(category);
                        }
                    }
                }
                return mOneTime_;
            }
        }

        #endregion

        #region Constructors



        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public VwCategories GetByType(CategoryType type)
		{
            if (type.Equals(CategoryType.Income))
            {
                return Income;
            }
            else if (type.Equals(CategoryType.Expense))
            {
                return Expense;
            }
            else if (type.Equals(CategoryType.Transfer))
            {
                return Transfer;
            }
            else if (type.Equals(CategoryType.OneTime))
            {
                return OneTime;
            }
            return new VwCategories();
        }

		public void FetchByComposite(Session session, PrimaryKey o)
		{
			using (Persistence persistence = session.GetPersistence())
			{
				persistence.SetSql("SELECT * FROM VwCategory");
				persistence.SqlWhere(true, "OperatorId = ?", o);
                persistence.SqlOrderBy("Name", SqlSortDirection.Ascending);
				persistence.ExecuteQuery();
				Set(session, persistence);
			}
		}

		#endregion
	}
}