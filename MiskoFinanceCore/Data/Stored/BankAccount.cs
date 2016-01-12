using System;
using MiskoFinanceCore.Resources;
using MiskoPersist.Attributes;
using MiskoPersist.Core;
using MiskoPersist.Data;
using MiskoPersist.Enums;
using MiskoPersist.MoneyType;

namespace MiskoFinanceCore.Data.Stored
{
	public class BankAccount : Account
    {
        private static Logger Log = Logger.GetInstance(typeof(BankAccount));

        #region Fields



        #endregion

        #region Stored Properties

        [Stored(Length = 128)]
        public String BankNumber { get; set; }
        [Stored(Length = 128)]
        public String AccountNumber { get; set; }
        [Stored(Length = 128)]
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

        public override AbstractStoredData Create(Session session)
        {
            PreSave(session, UpdateMode.Insert);
            base.Create(session);
            Persistence.ExecuteInsert(session, this, typeof(BankAccount));
            PostSave(session, UpdateMode.Insert);
            return this;
        }

        public override AbstractStoredData Store(Session session)
        {
            PreSave(session, UpdateMode.Update);
            base.Store(session);
            Persistence.ExecuteUpdate(session, this, typeof(BankAccount));
            PostSave(session, UpdateMode.Update);
            return this;
        }

        public override AbstractStoredData Remove(Session session)
        {
            base.Remove(session);
            Persistence.ExecuteDelete(session, this, typeof(BankAccount));
            PostSave(session, UpdateMode.Delete);
            return this;
        }
        
        public new void PreSave(Session session, UpdateMode mode)
        {        	
            if (String.IsNullOrEmpty(BankNumber))
            {
                session.Error(ErrorLevel.Error, ErrorStrings.errBankNameMandatory);
            }

            if (String.IsNullOrEmpty(AccountNumber))
            {
                session.Error(ErrorLevel.Error, ErrorStrings.errAccountNumberMandatory);
            }            

            if (String.IsNullOrEmpty(Nickname))
            {
                session.Error(ErrorLevel.Error, ErrorStrings.errNicknameMandatory);
            }

            if (OpeningBalance == null)
            {
                session.Error(ErrorLevel.Error, ErrorStrings.errOpeningBalance);
            }
            
            // Check to see if another bank account already exists
        	if(mode.Equals(UpdateMode.Insert))
        	{
        	   	BankAccount bankAccount = BankAccount.GetInstanceByComposite(session, Operator, AccountNumber);
        	   	
        	   	if(bankAccount.IsSet)
        	   	{
        	   		session.Error(ErrorLevel.Confirmation, "Account {0} already exists. Are you sure you want to create this account?", new Object[] { AccountNumber });
        	   	}
        	}
        }

        public new void PostSave(Session session, UpdateMode mode)
        {
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public static BankAccount GetInstanceByComposite(Session session, PrimaryKey op, String accountNo)
        {
            BankAccount result = new BankAccount();

            String sql = "SELECT * " +
                         "FROM   Account A, BankAccount B " +
                         "WHERE  A.Id = B.Id " +
                         "AND    A.Operator = ? " +
                         "AND    B.AccountNumber = ?";

            Persistence p = Persistence.GetInstance(session);
            p.ExecuteQuery(sql, new Object[] { op, accountNo });
            result.Set(session, p);
            p.Close();
            p = null;

            return result;
        }

        #endregion
    }
}
