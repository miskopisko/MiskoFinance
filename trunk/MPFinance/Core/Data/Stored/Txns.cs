using MPersist.Core;
using MPersist.Core.Data;
using System;

namespace MPFinance.Core.Data.Stored
{
    public class Txns : AbstractStoredDataList<Txn>
    {
        private static Logger Log = Logger.GetInstance(typeof(Txns));

        #region Variable Declarations



        #endregion

        #region Properties



        #endregion

        #region Constructors

        public Txns()
        {
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public static void RemoveTxnCategory(Session session, Category category)
        {
            Persistence.ExecuteUpdate(session, "UPDATE Txn SET Category = ? WHERE Category = ?", new Object[] { null, category });
        }

        public void FetchByAccountAndDate(Session sessiom, BankAccount account, DateTime fromDate, DateTime toDate)
        {
            Persistence persistence = Persistence.GetInstance(sessiom);
            persistence.ExecuteQuery("SELECT * FROM Txn WHERE Account = ? AND DatePosted BETWEEN ? AND ?", new Object[] { account, fromDate, toDate });
            Set(sessiom, persistence);
            persistence.Close();
            persistence = null;
        }

        #endregion
    }
}
