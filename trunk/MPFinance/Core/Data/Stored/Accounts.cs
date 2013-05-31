using System;
using MPersist.Core;
using MPersist.Core.Data;

namespace MPFinance.Core.Data.Stored
{
    public class Accounts : AbstractStoredDataList<Account>
    {
        private static Logger Log = Logger.GetInstance(typeof(Accounts));

        #region Variable Declarations



        #endregion

        #region Properties



        #endregion

        #region Constructors

        public Accounts()
        {
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public void FetchByOperator(Session session, Operator op)
        {
            Persistence p = Persistence.GetInstance(session);
            p.ExecuteQuery("SELECT * FROM Account WHERE Operator = ?", new Object[] { op });
            while (p.HasNext)
            {
                Add(new Account(session, p));
            }
            p.Close();
            p = null;
        }

        #endregion        
    }
}
