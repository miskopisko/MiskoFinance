using MPersist.Core;
using MPersist.Core.Data;
using System;

namespace MPFinance.Core.Data.Stored
{
    public class Accounts : AbstractStoredDataList
    {
        private static Logger Log = Logger.GetInstance(typeof(Accounts));

        #region Variable Declarations



        #endregion

        #region Properties



        #endregion

        #region Constructors

        public Accounts()
        {
            BaseType = typeof(Account);
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public void fetchByUser(Session session, User user)
        {
            Persistence p = Persistence.GetInstance(session);
            p.ExecuteQuery("SELECT * FROM Account WHERE User = ?", new Object[] { user.Id });
            set(session, BaseType, p);
            p.close();
            p = null;
        }

        #endregion
    }
}
