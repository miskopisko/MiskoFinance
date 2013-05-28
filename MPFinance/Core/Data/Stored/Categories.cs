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
            BaseType = typeof(Category);
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public override AbstractStoredDataList<Category> Save(Session session)
        {
            foreach (AbstractStoredData item in this)
            {
                item.Save(session);
            }

            return this;
        }

        public void FetchByOperatorAndType(Session session, Operator o, CategoryType type)
        {
            Persistence p = Persistence.GetInstance(session);
            p.ExecuteQuery("SELECT * FROM Category WHERE Operator = ? AND CategoryType = ?", new Object[] { o, type });
            Set(session, p);
            p.Close();
            p = null;
        }

        #endregion
    }
}
