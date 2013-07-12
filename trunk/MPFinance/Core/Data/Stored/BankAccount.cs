using System;
using MPersist.Core;
using MPersist.Core.Attributes;
using MPersist.Core.Data;
using MPersist.Core.Enums;
using MPersist.Core.MoneyType;
using MPFinance.Core.Enums;
using MPFinance.Resources;

namespace MPFinance.Core.Data.Stored
{
    public class BankAccount : Account
    {
        private static Logger Log = Logger.GetInstance(typeof(BankAccount));

        #region Variable Declarations



        #endregion

        #region Stored Properties

        [Stored]
        public String BankNumber { get; set; }
        [Stored]
        public String AccountNumber { get; set; }
        [Stored]
        public String Nickname { get; set; }
        [Stored]
        public Money OpeningBalance { get; set; }

        #endregion

        #region Other Properties



        #endregion

        #region Constructors

        public BankAccount()
        {
        }

        public BankAccount(Session session, Persistence persistence) : base(session, persistence)
        {
        }

        #endregion

        #region Override Methods

        public override string ToString()
        {
            return Nickname;
        }

        public override void PreSave(Session session, UpdateMode mode)
        {
            base.PreSave(session, mode);

            if (String.IsNullOrEmpty(BankNumber))
            {
                session.Error(ErrorLevel.Error, ErrorStrings.errBankNameMandatory);
            }

            if (String.IsNullOrEmpty(AccountNumber))
            {
                session.Error(ErrorLevel.Error, ErrorStrings.errAccountNumberMandatory);
            }

            if (AccountType == null || AccountType.Equals(AccountType.NULL))
            {
                session.Error(ErrorLevel.Error, ErrorStrings.errAccountTypeMandatory);
            }

            if (String.IsNullOrEmpty(Nickname))
            {
                session.Error(ErrorLevel.Error, ErrorStrings.errNicknameMandatory);
            }

            if (OpeningBalance == null)
            {
                session.Error(ErrorLevel.Error, ErrorStrings.errOpeningBalance);
            }
        }

        public override void PostSave(Session session, UpdateMode mode)
        {
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public static Account GetInstanceByComposite(Session session, PrimaryKey op, AccountType type, String bankNo, String accountNo)
        {
            Account result = new Account();

            String sql = "SELECT * " +
                         "FROM   Account A, BankAccount B " +
                         "WHERE  A.Id = B.Id " +
                         "AND    A.Operator = ? " +
                         "AND    A.AccountType = ? " +
                         "AND    B.BankNumber = ? " +
                         "AND    B.AccountNumber = ?";

            Persistence p = Persistence.GetInstance(session);
            p.ExecuteQuery(sql, new Object[] { op, type, bankNo, accountNo });
            result.Set(session, p);
            p.Close();
            p = null;

            return result;
        }

        #endregion
    }
}
