using System;
using MPersist.Core.Data;
using MPersist.Core.Enums;
using MPersist.Core;

namespace MPFinance.Core.Data.Stored
{
    public class BankAccounts : AbstractStoredDataList<BankAccount>
    {
        private static Logger Log = Logger.GetInstance(typeof(BankAccounts));

        #region Variable Declarations



        #endregion

        #region Stored Properties



        #endregion

        #region Other Properties



        #endregion

        #region Constructors

        public BankAccounts()
        {
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public void FetchByOperator(Session session, Operator op)
        {
            Persistence p = Persistence.GetInstance(session);
            p.ExecuteQuery("SELECT * FROM Account A, BankAccount B WHERE A.Id = B.Id AND A.Operator = ?", new Object[] { op });
            Set(session, p);
            p.Close();
            p = null;
        }

        #endregion
    }
}
