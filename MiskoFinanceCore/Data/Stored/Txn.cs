using System;
using log4net;
using MiskoFinanceCore.Enums;
using MiskoPersist.Attributes;
using MiskoPersist.Core;
using MiskoPersist.Data;
using MiskoPersist.Data.Stored;
using MiskoPersist.Enums;
using MiskoPersist.MoneyType;

namespace MiskoFinanceCore.Data.Stored
{
	public class Txn : StoredData
    {
        private static ILog Log = LogManager.GetLogger(typeof(Txn));

        #region Fields

       

        #endregion

        #region Stored Properties

        [Stored]
        public PrimaryKey Account { get; set; }
        [Stored]
        public DrCr DrCr { get; set; }
        [Stored]
        public Boolean Transfer { get; set; }
        [Stored]
        public Boolean OneTime { get; set; }
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

        public override StoredData Create(Session session)
        {
            PreSave(session, UpdateMode.Insert);
            Persistence.ExecuteInsert(session, this, typeof(Txn));
            PostSave(session, UpdateMode.Insert);
            return this;
        }

        public override StoredData Store(Session session)
        {
            PreSave(session, UpdateMode.Update);
            Persistence.ExecuteUpdate(session, this, typeof(Txn));
            PostSave(session, UpdateMode.Update);
            return this;
        }

        public override StoredData Remove(Session session)
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
