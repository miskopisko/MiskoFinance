using System;
using log4net;
using MiskoPersist.Core;
using MiskoPersist.Data.Viewed;
using MiskoPersist.Enums;

namespace MiskoFinanceCore.Data.Viewed
{
	public class VwTxns : ViewedDataList<VwTxn>
    {
        private static ILog Log = LogManager.GetLogger(typeof(VwTxns));

        #region Fields



        #endregion

        #region Properties

        

        #endregion

        #region Constructors

        

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public void Fetch(Session session, Page page, PrimaryKey op, PrimaryKey account, DateTime? from, DateTime? to, PrimaryKey category, String description)
        {
			using (Persistence persistence = session.GetPersistence())
			{
				persistence.SetSql("SELECT * FROM VwTxn");
				persistence.SqlWhere(op.IsSet, "OperatorId = ?", op);
				persistence.SqlWhere(account.IsSet, "AccountId = ?", account);
				persistence.SqlWhere(from.HasValue, "DatePosted >= ?", from);
				persistence.SqlWhere(to.HasValue, "DatePosted <= ?", to);
				persistence.SqlWhere(category.IsSet, "Category = ?", category);
				persistence.SqlWhere(!String.IsNullOrEmpty(description), "Description LIKE ?", "%" + description + "%");
				persistence.SqlOrderBy("DatePosted", SqlSortDirection.Descending);            
				persistence.ExecuteQuery();
				Set(session, persistence, page);
			}
        } 

        #endregion
    }
}
