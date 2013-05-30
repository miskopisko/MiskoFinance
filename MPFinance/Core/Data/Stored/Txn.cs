using System;
using MPersist.Core;
using MPersist.Core.Attributes;
using MPersist.Core.Data;
using MPersist.Core.Enums;
using MPersist.Core.MoneyType;
using MPFinance.Core.Enums;

namespace MPFinance.Core.Data.Stored
{
    public class Txn : AbstractStoredData
    {
        private static Logger Log = Logger.GetInstance(typeof(Txn));

        #region Variable Declarations

       

        #endregion

        #region Stored Properties

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

        #region Other Properties

        

        #endregion        

        #region Constructors

        public Txn()
        {
        }

        public Txn(Session session, Persistence persistence) : base(session, persistence)
        {
        }

        #endregion

        #region Override Methods

        public override void PreSave(Session session, UpdateMode mode)
        {
        }

        public override void PostSave(Session session, UpdateMode mode)
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
