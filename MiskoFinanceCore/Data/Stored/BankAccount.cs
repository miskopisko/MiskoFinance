using System;
using log4net;
using MiskoFinanceCore.Resources;
using MiskoPersist.Attributes;
using MiskoPersist.Core;
using MiskoPersist.Data.Stored;
using MiskoPersist.Enums;
using MiskoPersist.MoneyType;

namespace MiskoFinanceCore.Data.Stored
{
    public class BankAccount : Account
    {
        private static ILog Log = LogManager.GetLogger(typeof(BankAccount));

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

		public override StoredData Create(Session session)
		{
			base.Create(session);
			PreSave(session, UpdateMode.Insert);
			Persistence.ExecuteInsert(session, this, typeof(BankAccount));
			PostSave(session, UpdateMode.Insert);
			return this;
		}

		public override StoredData Store(Session session)
		{
			base.Store(session);
			PreSave(session, UpdateMode.Update);
			Persistence.ExecuteUpdate(session, this, typeof(BankAccount));
			PostSave(session, UpdateMode.Update);
			return this;
		}

		public override StoredData Remove(Session session)
		{
			base.Remove(session);
			Persistence.ExecuteDelete(session, this, typeof(BankAccount));
			PostSave(session, UpdateMode.Delete);
			return this;
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
			if (String.IsNullOrEmpty(Nickname))
			{
				session.Error(ErrorLevel.Error, ErrorStrings.errNicknameMandatory);
			}
			// Check to see if another bank account already exists
			if (mode.Equals(UpdateMode.Insert))
			{
				BankAccount bankAccount = BankAccount.GetInstanceByComposite(session, Operator, AccountNumber);
				if (bankAccount.IsSet)
				{
					session.Error(ErrorLevel.Confirmation, "Account {0} already exists. Are you sure you want to create this account?", AccountNumber);
				}
			}
		}

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public static BankAccount GetInstanceByComposite(Session session, PrimaryKey op, String accountNo)
        {
        	using (Persistence persistence = session.GetPersistence())
			{
				persistence.ExecuteQuery("SELECT * FROM Account A, BankAccount B WHERE A.Id = B.Id AND A.Operator = ? AND B.AccountNumber = ?", op, accountNo);
				return new BankAccount(session, persistence);
			}
        }

        #endregion
    }
}
