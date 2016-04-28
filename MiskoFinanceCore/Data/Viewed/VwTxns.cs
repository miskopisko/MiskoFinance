using System;
using log4net;
using MiskoPersist.Core;
using MiskoPersist.Data;
using MiskoPersist.Enums;

namespace MiskoFinanceCore.Data.Viewed
{
	public class VwTxns : ViewedDataList
    {
        private static ILog Log = LogManager.GetLogger(typeof(VwTxns));

        #region Fields



        #endregion

        #region Properties

        

        #endregion

        #region Constructors

        public VwTxns() : base(typeof(VwTxn))
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
            p.SqlWhere(op != null && op.IsSet, "OperatorId = ?",  op);
            p.SqlWhere(account != null && account.IsSet, "AccountId = ?", account);
            p.SqlWhere(from.HasValue, "DatePosted >= ?", from);
            p.SqlWhere(to.HasValue, "DatePosted <= ?", to);
            p.SqlWhere(category != null && category.IsSet, "Category = ?", category);
            p.SqlWhere(!String.IsNullOrEmpty(description), "Description LIKE ?", "%" + description + "%");
            p.SqlOrderBy("DatePosted", SqlSortDirection.Descending);            
            p.ExecuteQuery();
            Set(session, p, page);
            p.Close();
            p = null;
        } 

        #endregion
    }
}
