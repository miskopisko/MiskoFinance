using System;
using log4net;
using MiskoFinanceCore.Data.Stored;
using MiskoFinanceCore.Enums;
using MiskoPersist.Attributes;
using MiskoPersist.Core;
using MiskoPersist.Data.Viewed;
using MiskoPersist.MoneyType;

namespace MiskoFinanceCore.Data.Viewed
{
	public class VwBankAccount : ViewedData
	{
		private static ILog Log = LogManager.GetLogger(typeof(VwBankAccount));

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

		public override Boolean IsSet
		{
			get
			{
				return BankAccountId.IsSet;
			}
		}

		#endregion

		#region Constructors

		public VwBankAccount()
        {
        }

        public VwBankAccount(Session session, Persistence persistence) : base(session, persistence)
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

            bankAccount.Id = BankAccountId;
			bankAccount.Operator = OperatorId;            
			bankAccount.AccountType = AccountType;
			bankAccount.AccountNumber = AccountNumber;
			bankAccount.BankNumber = BankNumber;
			bankAccount.Nickname = Nickname;
			bankAccount.OpeningBalance = OpeningBalance;
			bankAccount.Save(session);
			
			BankAccountId = bankAccount.Id;
		}

		public static VwBankAccount GetInstanceByAccountNo(Session session, String accountNo)
		{
			using (Persistence persistence = session.GetPersistence())
			{
				persistence.ExecuteQuery("SELECT * FROM VwBankAccount WHERE AccountNumber = ?", accountNo);
				return new VwBankAccount(session, persistence);
			}
		}

		#endregion
	}
}