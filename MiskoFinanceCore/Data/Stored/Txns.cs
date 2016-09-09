using System;
using log4net;
using MiskoPersist.Core;
using MiskoPersist.Data.Stored;

namespace MiskoFinanceCore.Data.Stored
{
	public class Txns : StoredDataList<Txn>
    {
        private static ILog Log = LogManager.GetLogger(typeof(Txns));

        #region Fields



        #endregion

        #region Properties



        #endregion

        #region Constructors

        

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public static void RemoveTxnCategory(Session session, Category category)
        {
            Persistence.ExecuteUpdate(session, "UPDATE Txn SET Category = ? WHERE Category = ?", null, category);
        }

        public void FetchByAccountAndDate(Session sessiom, PrimaryKey account, DateTime fromDate, DateTime toDate)
        {
            Persistence persistence = Persistence.GetInstance(sessiom);
            persistence.ExecuteQuery("SELECT * FROM Txn WHERE Account = ? AND DatePosted BETWEEN ? AND ?", account, fromDate, toDate);
            Set(sessiom, persistence);
            persistence.Close();
            persistence = null;
        }

        #endregion
    }
}
