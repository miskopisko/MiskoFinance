using MPersist.Core;
using MPersist.Core.Data;
using MPFinance.Core.Data.Stored;
using System;

namespace MPFinance.Core.Data.Viewed
{
    public class VwTransactions : AbstractViewedDataList
    {
        private static Logger Log = Logger.GetInstance(typeof(VwTransactions));

        #region Variable Declarations



        #endregion

        #region Properties



        #endregion

        #region Constructors

        public VwTransactions()
        {
            BaseType = typeof(VwTransaction);
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public static VwTransactions fetchAllByAccount(Session session, Account account)
        {
            VwTransactions result = new VwTransactions();

            Persistence p = Persistence.GetInstance(session);
            p.ExecuteQuery("SELECT * FROM VwTransaction WHERE Account = ?", new Object[]{account.Id});
            result.set(session, result.BaseType, p);
            p.close();
            p = null;

            return result;
        }

        #endregion
    }
}
