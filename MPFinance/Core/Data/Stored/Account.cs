using System;
using MPersist.Core;
using MPersist.Core.Attributes;
using MPersist.Core.Data;
using MPFinance.Resources.Enums;

namespace MPFinance.Core.Data.Stored
{
    public class Account : AbstractStoredData
    {
        private static Logger Log = Logger.GetInstance(typeof(Account));

        #region Variable Declarations



        #endregion

        #region Properties

        [Stored]
        public User User { get; set; }
        [Stored]
        public AccountType AccountType { get; set; }
        [Stored]
        public String BankNumber { get; set; }
        [Stored]
        public String AccountNumber { get; set; }

        public Transactions Transactions { get; set; }

        #endregion

        #region Constructors



        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public Transactions GetTransactions(Session session)
        {
            Transactions = new Transactions();

            Persistence p = Persistence.GetInstance(session);
            p.ExecuteQuery("SELECT * FROM 'Transaction' WHERE Account = ?", new Object[] { Id });
            if(p.HasNext)
            {
                Transactions.set(session, typeof(Transaction), p);
            }
            p.close();
            p = null;

            return Transactions;
        }

        public static Account GetInstanceByComposite(Session session, User user, AccountType type, String bankNo, String accountNo)
        {
            Account result = new Account();

            String sql = "SELECT * " +
                         "FROM   Account A " + 
                         "WHERE  A.User = ? " +
                         "AND    A.AccountType = ? " +
                         "AND    A.BankNumber = ? " + 
                         "AND    A.AccountNumber = ?";

            Persistence p = Persistence.GetInstance(session);
            p.ExecuteQuery(sql, new Object[] { user.Id, type, bankNo, accountNo });
            result.set(session, p);
            p.close();
            p = null;

            return result;
        }

        #endregion
    }
}
