using System;
using MPersist.Core;
using MPersist.Core.Attributes;
using MPersist.Core.Data;
using MPFinance.Resources.Enums;

namespace MPFinance.Core.Data
{
    public class Account : AbstractStoredData
    {
        private static Logger Log = Logger.GetInstance(typeof(Account));

        #region Variable Declarations



        #endregion

        #region Properties

        [Stored]
        public Client Client { get; set; }
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
            Persistence p = Persistence.GetInstance(session);
            p.ExecuteQuery("SELECT * FROM Transaction WHERE Account = ?", new Object[] { Id });
            if(p.HasNext)
            {
                Transactions.set(session, typeof(Transaction), p);
            }
            p.Close();
            p = null;

            return Transactions;
        }

        public static Account GetInstanceByComposite(Session session, Client client, AccountType type, String bankNo, String accountNo)
        {
            Account result = new Account();

            Persistence p = Persistence.GetInstance(session);
            String sql = "SELECT * " +
                         "FROM   Account A " + 
                         "WHERE  A.Client = ? " +
                         "AND    A.AccountType = ? " +
                         "AND    A.BankNumber = ? " + 
                         "AND    A.AccountNumber = ?";

            p.ExecuteQuery(sql, new Object[] { client.Id, type, bankNo, accountNo });
            if(p.Next())
            {
                result.set(p);
            }

            return result;
        }

        #endregion
    }
}
