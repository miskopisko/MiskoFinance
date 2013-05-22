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
            BaseType = typeof(VwTxn);
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public void Fetch(Session session, Int32 PageNo, Int32 NoRows, Operator op, Account account, DateTime? from, DateTime? to)
        {
            Persistence p = Persistence.GetInstance(session);
            p.SetSql("SELECT * FROM VwTxn");
            p.SqlWhere(op != null && op.IsSet, "OperatorId = ?", new Object[]{ op });
            p.SqlWhere(account != null && account.IsSet, "AccountId = ?", new Object[] { account });
            p.SqlWhere(from.HasValue, "DatePosted >= ?", new Object[] { from });
            p.SqlWhere(to.HasValue, "DatePosted <= ?", new Object[] { to });
            p.ExecuteQuery();

            while (p.HasNext)
            {
                Add(new VwTxn(session, p));
            }

            p.Close();
            p = null;
        } 

        #endregion
    }
}
