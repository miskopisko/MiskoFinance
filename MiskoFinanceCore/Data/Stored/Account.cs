using log4net;
using MiskoFinanceCore.Enums;
using MiskoFinanceCore.Resources;
using MiskoPersist.Attributes;
using MiskoPersist.Core;
using MiskoPersist.Data.Stored;
using MiskoPersist.Enums;

namespace MiskoFinanceCore.Data.Stored
{
    public class Account : StoredData
    {
        private static ILog Log = LogManager.GetLogger(typeof(Account));

        #region Fields



        #endregion

        #region Stored Properties

        [Stored]
        public PrimaryKey Operator { get; set; }
        [Stored]
        public AccountType AccountType { get; set; }        

        #endregion

        #region Other Properties

        

        #endregion

        #region Constructors

        public Account()
        {
        }

        public Account(Session session, Persistence persistence) : base(session, persistence)
        {
        }

        #endregion

        #region Override Methods

        public override StoredData Create(Session session)
        {
            PreSave(session, UpdateMode.Insert);
            Persistence.ExecuteInsert(session, this, typeof(Account));
            PostSave(session, UpdateMode.Insert);
            return this;
        }

        public override StoredData Store(Session session)
        {
            PreSave(session, UpdateMode.Update);
            Persistence.ExecuteUpdate(session, this, typeof(Account));
            PostSave(session, UpdateMode.Update);
            return this;
        }

        public override StoredData Remove(Session session)
        {
            Persistence.ExecuteDelete(session, this, typeof(Account));
            PostSave(session, UpdateMode.Delete);
            return this;
        }

        public void PreSave(Session session, UpdateMode mode)
        {
            if(Operator.IsNotSet)
            {
                session.Error(ErrorLevel.Error, "Operator is not set");
            }

            if(AccountType == null || AccountType.Equals(AccountType.NULL))
            {
                session.Error(ErrorLevel.Error, ErrorStrings.errAccountTypeMandatory);
            }
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
