using System;
using System.Reflection;
using MPersist.Core;
using MPersist.Core.Attributes;
using MPersist.Core.Data;
using MPersist.Core.Enums;
using MPersist.Core.MoneyType;
using MPFinance.Core.Enums;
using MPFinance.Resources;

namespace MPFinance.Core.Data.Stored
{
    public class Account : AbstractStoredData
    {
        private static Logger Log = Logger.GetInstance(typeof(Account));

        #region Variable Declarations



        #endregion

        #region Stored Properties

        [Stored]
        public Operator Operator { get; set; }
        [Stored]
        public AccountType AccountType { get; set; }
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

        public Account()
        {
        }

        public Account(Session session, Persistence persistence) : base(session, persistence)
        {
        }

        #endregion

        #region Override Methods

        public override string ToString()
        {
            return AccountType.ToString() + " " + AccountNumber;
        }

        public override void PreSave(Session session, UpdateMode mode)
        {
            if (String.IsNullOrEmpty(BankNumber))
            {
                session.Error(GetType(), MethodInfo.GetCurrentMethod(), ErrorLevel.Error, ErrorStrings.errBankNameMandatory);
            }

            if (String.IsNullOrEmpty(AccountNumber))
            {
                session.Error(GetType(), MethodInfo.GetCurrentMethod(), ErrorLevel.Error, ErrorStrings.errAccountNumberMandatory);
            }

            if (AccountType == null || AccountType.Equals(AccountType.NULL))
            {
                session.Error(GetType(), MethodInfo.GetCurrentMethod(), ErrorLevel.Error, ErrorStrings.errAccountTypeMandatory);
            }

            if (String.IsNullOrEmpty(Nickname))
            {
                session.Error(GetType(), MethodInfo.GetCurrentMethod(), ErrorLevel.Error, ErrorStrings.errNicknameMandatory);
            }

            if (OpeningBalance == null)
            {
                session.Error(GetType(), MethodInfo.GetCurrentMethod(), ErrorLevel.Error, ErrorStrings.errOpeningBalance);
            }
        }

        public override void PostSave(Session session, UpdateMode mode)
        {
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public static Account GetInstanceByComposite(Session session, Operator op, AccountType type, String bankNo, String accountNo)
        {
            Account result = new Account();

            String sql = "SELECT * " +
                         "FROM   Account A " + 
                         "WHERE  A.Operator = ? " +
                         "AND    A.AccountType = ? " +
                         "AND    A.BankNumber = ? " + 
                         "AND    A.AccountNumber = ?";

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