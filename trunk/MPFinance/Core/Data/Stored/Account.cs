using MPersist.Core;
using MPersist.Core.Attributes;
using MPersist.Core.Data;
using MPersist.Core.Enums;
using MPFinance.Core.Enums;
using MPFinance.Resources;

namespace MPFinance.Core.Data.Stored
{
    public class Account : StoredData
    {
        private static Logger Log = Logger.GetInstance(typeof(Account));

        #region Variable Declarations



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

        public override void PreSave(Session session, UpdateMode mode)
        {
            if (AccountType == null || AccountType.Equals(AccountType.NULL))
            {
                session.Error(ErrorLevel.Error, ErrorStrings.errAccountTypeMandatory);
            }
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        

        #endregion
    }
}
