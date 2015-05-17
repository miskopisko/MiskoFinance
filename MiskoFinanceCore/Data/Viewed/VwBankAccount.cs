using System;
using MiskoPersist.Attributes;
using MiskoPersist.Core;
using MiskoPersist.Data;
using MiskoPersist.MoneyType;
using MiskoFinanceCore.Data.Stored;
using MiskoFinanceCore.Enums;

namespace MiskoFinanceCore.Data.Viewed
{
    public class VwBankAccount : AbstractViewedData
    {
        private static Logger Log = Logger.GetInstance(typeof(VwBankAccount));

        #region Fields



        #endregion

        #region Viewed Properties

        [Viewed]
        public PrimaryKey OperatorId { get; set; }
        [Viewed]
        public PrimaryKey BankAccountId { get; set; }
        [Viewed]
        public AccountType AccountType { get; set; } 
        [Viewed]
        public String BankNumber { get; set; }
        [Viewed]
        public String AccountNumber { get; set; }
        [Viewed]
        public String Nickname { get; set; }
        [Viewed]
        public Money OpeningBalance { get; set; }

        #endregion

        #region Other Properties



        #endregion

        #region Constructors

        public VwBankAccount()
        {
        }

        public VwBankAccount(Session session, Persistence persistence)
            : base(session, persistence)
        {
        }

        #endregion

        #region Override Methods

        

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public void Update(Session session)
        {
            BankAccount bankAccount = new BankAccount();
            bankAccount.FetchById(session, BankAccountId);

            bankAccount.Operator = OperatorId;            
            bankAccount.AccountType = AccountType;
            bankAccount.AccountNumber = AccountNumber;
            bankAccount.BankNumber = BankNumber;
            bankAccount.Nickname = Nickname;
            bankAccount.OpeningBalance = OpeningBalance;
            bankAccount.Save(session);
            
            BankAccountId = bankAccount.Id;
        }

        public void FetchByAccountNo(Session session, String accountNo)
        {
            Persistence p = Persistence.GetInstance(session);
            p.ExecuteQuery("SELECT * FROM VwBankAccount WHERE AccountNumber = ?", new Object[] { accountNo });
            Set(session, p);
            p.Close();
            p = null;
        }

        #endregion
    }
}