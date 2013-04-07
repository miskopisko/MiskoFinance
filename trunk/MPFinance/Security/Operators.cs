using System;
using MPersist.Core;
using MPersist.Core.Data;
using MPersist.Resources.Enums;

namespace MPFinance.Security
{
    public class Operators : AbstractStoredDataList
    {
        private static Logger Log = Logger.GetInstance(typeof(Operators));

        #region Variable Declarations



        #endregion

        #region Properties



        #endregion

        #region Constructors

        public Operators()
        {
            BaseType = typeof(Operator);
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public void fetchTest(Session session)
        {
            String[] unames = {"miskop", "user"};

            Persistence p = Persistence.GetInstance(session);
            p.ExecuteQuery("SELECT * FROM Operator WHERE Username IN (?)", new Object[] {unames});

            //p.ExecuteQuery("SELECT * FROM Operator WHERE Username LIKE '%?%'", new Object[] { "se" });


            set(session, BaseType, p);
            p.Close();
            p = null;

        }

        #endregion
    }
}
