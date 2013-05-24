using MPersist.Core;
using MPersist.Core.Attributes;
using MPersist.Core.Data;
using MPFinance.Core.Enums;
using System;
using MPersist.Core.MoneyType;

namespace MPFinance.Core.Data.Stored
{
    public class Txn : AbstractStoredData
    {
        private static Logger Log = Logger.GetInstance(typeof(Txn));

        #region Variable Declarations

       

        #endregion

        #region Properties

        [Stored]
        public Account Account { get; set; }
        [Stored]
        public TxnType TxnType { get; set;}
        [Stored]
        public DateTime DatePosted { get; set; }
        [Stored]
        public Money Amount { get; set; }
        [Stored]
        public String Description { get; set; }
        [Stored]
        public Category Category { get; set; }
        [Stored]
        public String HashCode { get; set; }

        #endregion

        #region Constructors

        public Txn()
        {
        }

        public Txn(Session session, Persistence persistence) : base(session, persistence)
        {
        }


        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public static Txn FetchByHashCode(Session session, String hash)
        {
            Txn result = null;
            Persistence p = Persistence.GetInstance(session);
            p.ExecuteQuery("SELECT * FROM Txn WHERE HashCode = ?", new Object[] { hash });
            if (p.HasNext)
            {
                result = new Txn(session, p);
            }
            p.Close();
            p = null;

            return result;
        }

        #endregion
    }
}
