using MPersist.Core;
using MPersist.Core.Data;
using MPFinance.Core.Enums;
using System;

namespace MPFinance.Core.Data.Stored
{
    public class Categories : AbstractStoredDataList<Category>
    {
        private static Logger Log = Logger.GetInstance(typeof(Categories));

        #region Variable Declarations



        #endregion

        #region Properties



        #endregion

        #region Constructors

        public Categories()
        {
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public Categories GetByType(CategoryType type)
        {
            Categories result = new Categories();

            foreach (Category category in this)
            {
                if (category.CategoryType.Equals(type))
                {
                    result.Add(category);
                }
            }

            return result;
        }

        public Categories GetByStatus(Status status)
        {
            Categories result = new Categories();

            foreach (Category category in this)
            {
                if (category.Id > 0 && category.Status.Equals(status))
                {
                    result.Add(category);
                }
            }

            return result;
        }

        public void FetchByComposite(Session session, PrimaryKey o, Status status)
        {
            Persistence p = Persistence.GetInstance(session);
            p.SetSql("SELECT * FROM Category");
            p.SqlWhere(true, "Operator = ?", new Object[]{ o }); 
            p.SqlWhere(status != null && status.IsSet, "Status = ?", new Object[]{ status });
            p.ExecuteQuery();
            Set(session, p);
            p.Close();
            p = null;
        }

        #endregion
    }
}
