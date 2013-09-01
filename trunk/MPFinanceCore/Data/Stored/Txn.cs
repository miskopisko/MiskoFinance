using System;
using MPersist.Attributes;
using MPersist.Core;
using MPersist.Data;
using MPersist.Enums;
using MPersist.MoneyType;
using MPFinanceCore.Enums;

namespace MPFinanceCore.Data.Stored
{
    public class Txn : AbstractStoredData
    {
        private static Logger Log = Logger.GetInstance(typeof(Txn));

        #region Fields

       

        #endregion

        #region Stored Properties

        [Stored]
        public PrimaryKey Account { get; set; }
        [Stored]
        public TxnType TxnType { get; set;}
        [Stored]
        public DateTime DatePosted { get; set; }
        [Stored]
        public Money Amount { get; set; }
        [Stored(Length = 128)]
        public String Description { get; set; }
        [Stored]
        public PrimaryKey Category { get; set; }
        [Stored(Length = 512)]
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

        public override AbstractStoredData Create(Session session)
        {
            PreSave(session, UpdateMode.Insert);
            Persistence.ExecuteInsert(session, this, typeof(Txn));
            PostSave(session, UpdateMode.Insert);
            return this;
        }

        public override AbstractStoredData Store(Session session)
        {
            PreSave(session, UpdateMode.Update);
            Persistence.ExecuteUpdate(session, this, typeof(Txn));
            PostSave(session, UpdateMode.Update);
            return this;
        }

        public override AbstractStoredData Remove(Session session)
        {
            Persistence.ExecuteDelete(session, this, typeof(Txn));
            PostSave(session, UpdateMode.Delete);
            return this;
        }

        public void PreSave(Session session, UpdateMode mode)
        {
        }

        public void PostSave(Session session, UpdateMode mode)
        {
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        

        #endregion
    }
}
