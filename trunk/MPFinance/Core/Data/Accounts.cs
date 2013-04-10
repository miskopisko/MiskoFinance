using MPersist.Core;
using MPersist.Core.Data;
using System;

namespace MPFinance.Core.Data
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

        public void fetchByClient(Session session, Client c)
        {
            Persistence p = Persistence.GetInstance(session);
            p.ExecuteQuery("SELECT * FROM Account WHERE Client = ?", new Object[] { c.Id });
            if(p.HasNext)
            {
                set(session, BaseType, p);
            }
            p.Close();
            p = null;
        }

        #endregion
    }
}
