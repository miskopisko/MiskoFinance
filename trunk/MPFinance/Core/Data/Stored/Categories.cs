using MPersist.Core;
using MPersist.Core.Data;
using System;

namespace MPFinance.Core.Data.Stored
{
    public class Categories : AbstractStoredDataList
    {
        private static Logger Log = Logger.GetInstance(typeof(Categories));

        #region Variable Declarations



        #endregion

        #region Properties



        #endregion

        #region Constructors

        public Categories()
        {
            BaseType = typeof(Category);
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public void FetchByOperator(Session session, Operator o, Page page)
        {
            Persistence p = Persistence.GetInstance(session);
            p.ExecuteQuery("SELECT * FROM Category WHERE Operator = ?", new Object[] { o.Id });
            set(session, p, page);
            p.Close();
            p = null;
        }

        #endregion
    }
}
