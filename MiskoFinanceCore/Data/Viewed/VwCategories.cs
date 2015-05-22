using System;
using MiskoPersist.Core;
using MiskoPersist.Data;
using MiskoFinanceCore.Enums;

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
        
        public VwCategories getAllCategories()
        {
        	if(Count > 0)
        	{
        		VwCategories categories = new VwCategories();
        		categories.Add(new VwCategory());
        		categories.AddRange(this);
        		return categories;
        	}
        	
        	return null;
        }

        public VwCategories GetByType(CategoryType type, bool includeBlank)
        {
            VwCategories result = new VwCategories();
            
            if(includeBlank)
            {
            	result.Add(new VwCategory());
            }

            foreach (VwCategory category in this)
            {
                if (category.CategoryType.Equals(type))
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