using MPersist.Attributes;
using MPersist.Core;
using MPersist.Data;
using MPersist.Enums;
using MPFinanceCore.Enums;
using MPFinanceCore.Resources;

namespace MPFinanceCore.Data.Stored
{
    public class Account : AbstractStoredData
    {
        private static Logger Log = Logger.GetInstance(typeof(Account));

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

        public override AbstractStoredData Create(Session session)
        {
            PreSave(session, UpdateMode.Insert);
            Persistence.ExecuteInsert(session, this, typeof(Account));
            PostSave(session, UpdateMode.Insert);
            return this;
        }

        public override AbstractStoredData Store(Session session)
        {
            PreSave(session, UpdateMode.Update);
            Persistence.ExecuteUpdate(session, this, typeof(Account));
            PostSave(session, UpdateMode.Update);
            return this;
        }

        public override AbstractStoredData Remove(Session session)
        {
            Persistence.ExecuteDelete(session, this, typeof(Account));
            PostSave(session, UpdateMode.Delete);
            return this;
        }

        public void PreSave(Session session, UpdateMode mode)
        {
            if (Operator == null || Operator.IsNotSet)
            {
                session.Error(ErrorLevel.Error, "Operator is not set");
            }

            if (AccountType == null || AccountType.Equals(AccountType.NULL))
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
