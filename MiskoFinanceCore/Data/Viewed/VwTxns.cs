using System;
using MiskoPersist.Core;
using MiskoPersist.Data;
using MiskoPersist.Enums;

namespace MiskoFinanceCore.Data.Viewed
{
	public class VwTxns : AbstractViewedDataList<VwTxn>
    {
        private static Logger Log = Logger.GetInstance(typeof(VwTxns));

        #region Fields



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

        public void Fetch(Session session, Page page, PrimaryKey op, PrimaryKey account, DateTime? from, DateTime? to, PrimaryKey category, String description)
        {
            Persistence p = Persistence.GetInstance(session);
            p.SetSql("SELECT * FROM VwTxn");
            p.SqlWhere(op != null && op > 0, "OperatorId = ?", new Object[]{ op });
            p.SqlWhere(account != null && account > 0, "AccountId = ?", new Object[] { account });
            p.SqlWhere(from.HasValue, "DatePosted >= ?", new Object[] { from });
            p.SqlWhere(to.HasValue, "DatePosted <= ?", new Object[] { to });
            p.SqlWhere(category != null && category > 0, "Category = ?", new Object[] { category });
            p.SqlWhere(!String.IsNullOrEmpty(description), "Description LIKE ?", new Object[] { "%" + description + "%" });
            p.SqlOrderBy("DatePosted", SortDirection.Descending);            
            p.ExecuteQuery();
            Set(session, p, page);
            p.Close();
            p = null;
        } 

        #endregion
    }
}
