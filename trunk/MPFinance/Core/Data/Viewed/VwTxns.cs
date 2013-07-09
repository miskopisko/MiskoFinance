using MPersist.Core;
using MPersist.Core.Data;
using MPFinance.Core.Data.Stored;
using System;

namespace MPFinance.Core.Data.Viewed
{
    public class VwTxns : AbstractViewedDataList<VwTxn>
    {
        private static Logger Log = Logger.GetInstance(typeof(VwTxns));

        #region Variable Declarations



        #endregion

        #region Properties

        

        #endregion

        #region Constructors

        public VwTxns()
        {
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public void Fetch(Session session, Page page, Operator op, Account account, DateTime? from, DateTime? to, Category category)
        {
            Persistence p = Persistence.GetInstance(session);
            p.SetSql("SELECT * FROM VwTxn");
            p.SqlWhere(op != null && op.IsSet, "OperatorId = ?", new Object[]{ op });
            p.SqlWhere(account != null && account.IsSet, "AccountId = ?", new Object[] { account });
            p.SqlWhere(from.HasValue, "DatePosted >= ?", new Object[] { from });
            p.SqlWhere(to.HasValue, "DatePosted <= ?", new Object[] { to });
            p.SqlWhere(category != null && category.IsSet, "Category = ?", new Object[] { category });
            p.ExecuteQuery();
            Set(session, p, page);
            p.Close();
            p = null;
        } 

        #endregion
    }
}
