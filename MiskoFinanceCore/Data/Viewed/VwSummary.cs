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
		public Money SelectionTotalTransfersIn { get; set; }
		[Viewed]
		public Money SelectionTotalTransfersOut { get; set; }
		[Viewed]
		public Money SelectionTotalOneTimeIn { get; set; }
		[Viewed]
		public Money SelectionTotalOneTimeOut { get; set; }        
		[Viewed]
		public Money SelectionOpeningBalance { get; set; }
		[Viewed]
		public Money SelectionCurrentBalance { get; set; }
		[Viewed]
		public Money AllTimeOpeningBalance { get; set; }
		[Viewed]
		public Money AllTimeCurrentBalance { get; set; }

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
			String sql1 = "SELECT SUM(B.OpeningBalance) OpeningBalance, MAX(B.Nickname) Nickname " +
						  "FROM   Account A, BankAccount B " +
						  "WHERE  A.Id = B.Id ";

			Persistence persistence = Persistence.GetInstance(session);
			persistence.SetSql(sql1);
			persistence.SqlWhere(true, "A.Operator = ?", o);
			persistence.SqlWhere(bankAccount.IsSet, "A.Id = ?", bankAccount);
			persistence.ExecuteQuery();           

			if (!persistence.IsEof)
			{
				AllTimeOpeningBalance = persistence.GetMoney("OpeningBalance");
			}

			persistence.Close();
			persistence = null;

			String sql2 = "SELECT SUM(CASE WHEN C.DrCr = 0 THEN C.Amount ELSE -C.Amount END) ClosingBalance " +
						  "FROM   Account A, BankAccount B, Txn C " +
						  "WHERE  A.Id = B.Id " +
						  "AND    B.Id = C.Account";

			persistence = Persistence.GetInstance(session);
			persistence.SetSql(sql2);
			persistence.SqlWhere(true, "A.Operator = ?", o);
			persistence.SqlWhere(bankAccount.IsSet, "A.Id = ?", bankAccount);
			persistence.ExecuteQuery();

			if (!persistence.IsEof)
			{
				AllTimeCurrentBalance = AllTimeOpeningBalance + persistence.GetMoney("ClosingBalance");
			}

			persistence.Close();
			persistence = null;

			String sql3 = "SELECT SUM(CASE WHEN DrCr = 0 AND Transfer = 0 AND OneTime = 0 THEN Amount ELSE 0 END) SumCredit, " +
						  "       SUM(CASE WHEN DrCr = 1 AND Transfer = 0 AND OneTime = 0 THEN Amount ELSE 0 END) SumDebit, " +
						  "       SUM(CASE WHEN DrCr = 0 AND Transfer = 1 THEN Amount ELSE 0 END) SumTransferIn, " +
						  "       SUM(CASE WHEN DrCr = 1 AND Transfer = 1 THEN Amount ELSE 0 END) SumTransferOut, " +
						  "       SUM(CASE WHEN DrCr = 0 AND OneTime = 1 THEN Amount ELSE 0 END) SumOneTimeIn, " +
						  "       SUM(CASE WHEN DrCr = 1 AND OneTime = 1 THEN Amount ELSE 0 END) SumOneTimeOut " +
						  "FROM   VwTxn";

			persistence = Persistence.GetInstance(session);
			persistence.SetSql(sql3);
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
				SelectionTotalTransfersIn = persistence.GetMoney("SumTransferIn");
				SelectionTotalTransfersOut = persistence.GetMoney("SumTransferOut");
				SelectionTotalOneTimeIn = persistence.GetMoney("SumOneTimeIn");
				SelectionTotalOneTimeOut = persistence.GetMoney("SumOneTimeOut");
			}

			persistence.Close();
			persistence = null;

			String sql4 = "SELECT SUM(DISTINCT B.OpeningBalance) + SUM(CASE WHEN C.DatePosted < ? THEN CASE WHEN C.DrCr = 0 THEN C.Amount ELSE -C.Amount END ELSE 0 END) OpeningBalance, " +
						  "       SUM(DISTINCT B.OpeningBalance) + SUM(CASE WHEN C.DatePosted <= ? THEN CASE WHEN C.DrCr = 0 THEN C.Amount ELSE -C.Amount END ELSE 0 END) ClosingBalance " +
						  "FROM   Account A, BankAccount B, Txn C " +
						  "WHERE  A.Id = B.Id " +
						  "AND    B.Id = C.Account " +
						  "AND    C.DatePosted <= ? ";

			persistence = Persistence.GetInstance(session);
			persistence.SetSql(sql4, fromDate.Value, toDate.Value, toDate.Value);
			persistence.SqlWhere(true, "A.Operator = ?", o);
			persistence.SqlWhere(bankAccount.IsSet, "A.Id = ?", bankAccount);
			persistence.ExecuteQuery();

			if (!persistence.IsEof)
			{
				SelectionOpeningBalance = persistence.GetMoney("OpeningBalance");
				SelectionCurrentBalance = persistence.GetMoney("ClosingBalance");
			}

			persistence.Close();
			persistence = null;
		} 

		#endregion
	}
}
