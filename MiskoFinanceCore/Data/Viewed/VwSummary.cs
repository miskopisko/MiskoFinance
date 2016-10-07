using System;
using log4net;
using MiskoPersist.Attributes;
using MiskoPersist.Core;
using MiskoPersist.Data.Viewed;
using MiskoPersist.MoneyType;

namespace MiskoFinanceCore.Data.Viewed
{
	public class VwSummary : ViewedData
	{
		private static ILog Log = LogManager.GetLogger(typeof(VwSummary));

		#region Fields



		#endregion
		
		#region Properties
		
		
		
		#endregion

		#region Viewed Properties

		[Viewed]
		public Money SelectionTotalCredits { get; set; }
		[Viewed]
		public Money SelectionTotalDebits { get; set; }
		[Viewed]
		public Money SelectionTotalTransfers { get; set; }
		[Viewed]
		public Money SelectionTotalOneTime { get; set; }        
		[Viewed]
		public Money SelectionOpeningBalance { get; set; }
		[Viewed]
		public Money SelectionClosingBalance { get; set; }
		[Viewed]
		public Money AllTimeOpeningBalance { get; set; }
		[Viewed]
		public Money AllTimeClosingBalance { get; set; }

		#endregion

		#region Constructors

		public VwSummary()
        {
        }

        public VwSummary(Session session, Persistence persistence) : base(session, persistence)
        {
        }

		#endregion
		
		#region Override Methods
		
		
		
		#endregion

		#region Private Methods



		#endregion

		#region Public Methods

		public void Fetch(Session session, PrimaryKey o, PrimaryKey bankAccount, DateTime? fromDate, DateTime? toDate, PrimaryKey category, String description)
		{
			using (Persistence persistence = session.GetPersistence())
			{
				String sql = "SELECT SUM(B.OpeningBalance) OpeningBalance, MAX(B.Nickname) Nickname " +
						     "FROM   Account A, BankAccount B " +
						  	 "WHERE  A.Id = B.Id ";
				
				persistence.SetSql(sql);
				persistence.SqlWhere(true, "A.Operator = ?", o);
				persistence.SqlWhere(bankAccount.IsSet, "A.Id = ?", bankAccount);
				persistence.ExecuteQuery();           

				if (!persistence.IsEof)
				{
					AllTimeOpeningBalance = persistence.GetMoney("OpeningBalance");
				}
			}

			using (Persistence persistence = session.GetPersistence())
			{
				String sql = "SELECT SUM(CASE WHEN C.DrCr = 0 THEN C.Amount ELSE -C.Amount END) ClosingBalance " +
						  	 "FROM   Account A, BankAccount B, Txn C " +
						  	 "WHERE  A.Id = B.Id " +
						  	 "AND    B.Id = C.Account";
				
				persistence.SetSql(sql);
				persistence.SqlWhere(true, "A.Operator = ?", o);
				persistence.SqlWhere(bankAccount.IsSet, "A.Id = ?", bankAccount);
				persistence.ExecuteQuery();
	
				if (!persistence.IsEof)
				{
					AllTimeClosingBalance = AllTimeOpeningBalance + persistence.GetMoney("ClosingBalance");
				}	
			}

			using (Persistence persistence = session.GetPersistence())
			{
				String sql = "SELECT SUM(CASE WHEN DrCr = 0 THEN Amount ELSE 0 END) SumCredit, " +
						  	 "       SUM(CASE WHEN DrCr = 1 THEN Amount ELSE 0 END) SumDebit, " +
						  	 "       SUM(CASE WHEN DrCr = 0 AND Transfer = 1 THEN Amount ELSE 0 END) SumTransferIn, " +
						  	 "       SUM(CASE WHEN DrCr = 1 AND Transfer = 1 THEN Amount ELSE 0 END) SumTransferOut, " +
						  	 "       SUM(CASE WHEN DrCr = 0 AND OneTime = 1 THEN Amount ELSE 0 END) SumOneTimeIn, " +
						  	 "       SUM(CASE WHEN DrCr = 1 AND OneTime = 1 THEN Amount ELSE 0 END) SumOneTimeOut " +
						  	 "FROM   VwTxn";
				
				persistence.SetSql(sql);
				persistence.SqlWhere(true, "OperatorId = ?", o);
				persistence.SqlWhere(bankAccount.IsSet, "AccountId = ?", bankAccount);
				persistence.SqlWhere(fromDate.HasValue, "DatePosted >= ?", fromDate);
				persistence.SqlWhere(toDate.HasValue, "DatePosted <= ?", toDate);
				persistence.SqlWhere(category.IsSet, "Category = ?", category);
				persistence.SqlWhere(!String.IsNullOrEmpty(description), "Description LIKE ?", "%" + description + "%");
				persistence.ExecuteQuery();
	
				if (!persistence.IsEof)
				{
					SelectionTotalCredits = persistence.GetMoney("SumCredit");
					SelectionTotalDebits = persistence.GetMoney("SumDebit");
					SelectionTotalTransfers = persistence.GetMoney("SumTransferIn") - persistence.GetMoney("SumTransferOut");
					SelectionTotalOneTime = persistence.GetMoney("SumOneTimeIn") - persistence.GetMoney("SumOneTimeOut");
				}
			}

			using (Persistence persistence = session.GetPersistence())
			{
				String sql = "SELECT SUM(DISTINCT B.OpeningBalance) + SUM(CASE WHEN C.DatePosted < ? THEN CASE WHEN C.DrCr = 0 THEN C.Amount ELSE -C.Amount END ELSE 0 END) OpeningBalance, " +
						  	 "       SUM(DISTINCT B.OpeningBalance) + SUM(CASE WHEN C.DatePosted <= ? THEN CASE WHEN C.DrCr = 0 THEN C.Amount ELSE -C.Amount END ELSE 0 END) ClosingBalance " +
						  	 "FROM   Account A, BankAccount B, Txn C " +
						  	 "WHERE  A.Id = B.Id " +
						  	 "AND    B.Id = C.Account " +
						  	 "AND    C.DatePosted <= ? ";
				
				persistence.SetSql(sql, fromDate.Value, toDate.Value, toDate.Value);
				persistence.SqlWhere(true, "A.Operator = ?", o);
				persistence.SqlWhere(bankAccount.IsSet, "A.Id = ?", bankAccount);
				persistence.ExecuteQuery();
	
				if (!persistence.IsEof)
				{
					SelectionOpeningBalance = persistence.GetMoney("OpeningBalance");
					SelectionClosingBalance = persistence.GetMoney("ClosingBalance");
				}
			}
		} 

		#endregion
	}
}
