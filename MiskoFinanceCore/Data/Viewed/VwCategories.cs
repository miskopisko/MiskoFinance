using System;
using MiskoFinanceCore.Enums;
using MiskoPersist.Core;
using MiskoPersist.Data;

namespace MiskoFinanceCore.Data.Viewed
{
	public class VwCategories : AbstractViewedDataList<VwCategory>
    {
        private static Logger Log = Logger.GetInstance(typeof(VwCategories));

        #region Fields



        #endregion

        #region Properties



        #endregion

        #region Constructors

        public VwCategories()
        {
        }

        #endregion

        #region Private Methods

		

        #endregion

        #region Public Methods

        public VwCategories GetByType(CategoryType type)
        {
            VwCategories result = new VwCategories();

            foreach (VwCategory category in this)
            {
                if (category.CategoryId.IsSet && category.CategoryType.Equals(type))
                {
                    result.Add(category);
                }
            }

            return result;
        }

        public VwCategories GetByStatus(Status status)
        {
            VwCategories result = new VwCategories();

            foreach (VwCategory category in this)
            {
                if (category.CategoryId > 0 && category.Status.Equals(status))
                {
                    result.Add(category);
                }
            }

            return result;
        }

        public void FetchByComposite(Session session, PrimaryKey o, Status status)
        {
            Persistence p = Persistence.GetInstance(session);
            p.SetSql("SELECT * FROM VwCategory");
            p.SqlWhere(true, "OperatorId = ?", new Object[] { o });
            p.SqlWhere(status != null && status.IsSet, "Status = ?", new Object[] { status });
            p.ExecuteQuery();
            Set(session, p);
            p.Close();
            p = null;
        }

        #endregion
    }
}