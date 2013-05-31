using System;
using MPersist.Core;
using MPersist.Core.Data;
using MPFinance.Core.Enums;

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

        public void FetchByComposite(Session session, Operator o, CategoryType type, Status status)
        {
            Persistence p = Persistence.GetInstance(session);
            p.SetSql("SELECT * FROM Category");
            p.SqlWhere(true, "Operator = ?", new Object[]{ o }); 
            p.SqlWhere(type != null && type.IsSet, "CategoryType = ?", new Object[]{ type }); 
            p.SqlWhere(status != null && status.IsSet, "Status = ?", new Object[]{ status });
            p.ExecuteQuery();
            Set(session, p);
            p.Close();
            p = null;
        }

        #endregion
    }
}
