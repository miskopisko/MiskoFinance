using System;
using log4net;
using MiskoPersist.Attributes;
using MiskoPersist.Core;
using MiskoPersist.Data;
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

			Persistence p = Persistence.GetInstance(session);
			p.SetSql(sql1);
			p.SqlWhere(true, "A.Operator = ?", o);
			p.SqlWhere(bankAccount != null && bankAccount.IsSet, "A.Id = ?", bankAccount);
			p.ExecuteQuery();           

			if (!p.IsEof)
			{
				AllTimeOpeningBalance = p.GetMoney("OpeningBalance");
			}

			p.Close();
			p = null;

			String sql2 = "SELECT SUM(CASE WHEN C.DrCr = 0 THEN C.Amount ELSE -C.Amount END) ClosingBalance " +
						  "FROM   Account A, BankAccount B, Txn C " +
						  "WHERE  A.Id = B.Id " +
						  "AND    B.Id = C.Account";

			p = Persistence.GetInstance(session);
			p.SetSql(sql2);
			p.SqlWhere(true, "A.Operator = ?", o);
			p.SqlWhere(bankAccount != null && bankAccount.IsSet, "A.Id = ?", bankAccount);
			p.ExecuteQuery();

			if (!p.IsEof)
			{
				AllTimeCurrentBalance = AllTimeOpeningBalance + p.GetMoney("ClosingBalance");
			}

			p.Close();
			p = null;

			String sql3 = "SELECT SUM(CASE WHEN DrCr = 0 AND Transfer = 0 AND OneTime = 0 THEN Amount ELSE 0 END) SumCredit, " +
						  "       SUM(CASE WHEN DrCr = 1 AND Transfer = 0 AND OneTime = 0 THEN Amount ELSE 0 END) SumDebit, " +
						  "       SUM(CASE WHEN DrCr = 0 AND Transfer = 1 THEN Amount ELSE 0 END) SumTransferIn, " +
						  "       SUM(CASE WHEN DrCr = 1 AND Transfer = 1 THEN Amount ELSE 0 END) SumTransferOut, " +
						  "       SUM(CASE WHEN DrCr = 0 AND OneTime = 1 THEN Amount ELSE 0 END) SumOneTimeIn, " +
						  "       SUM(CASE WHEN DrCr = 1 AND OneTime = 1 THEN Amount ELSE 0 END) SumOneTimeOut " +
						  "FROM   VwTxn";

			p = Persistence.GetInstance(session);
			p.SetSql(sql3);
			p.SqlWhere(true, "OperatorId = ?", o);
			p.SqlWhere(bankAccount != null && bankAccount.IsSet, "AccountId = ?", bankAccount);
			p.SqlWhere(fromDate.HasValue, "DatePosted >= ?", fromDate);
			p.SqlWhere(toDate.HasValue, "DatePosted <= ?", toDate);
			p.SqlWhere(category != null && category.IsSet, "Category = ?", category);
			p.SqlWhere(!String.IsNullOrEmpty(description), "Description LIKE ?", "%" + description + "%");
			p.ExecuteQuery();

			if (!p.IsEof)
			{
				SelectionTotalCredits = p.GetMoney("SumCredit");
				SelectionTotalDebits = p.GetMoney("SumDebit");
				SelectionTotalTransfersIn = p.GetMoney("SumTransferIn");
				SelectionTotalTransfersOut = p.GetMoney("SumTransferOut");
				SelectionTotalOneTimeIn = p.GetMoney("SumOneTimeIn");
				SelectionTotalOneTimeOut = p.GetMoney("SumOneTimeOut");
			}

			p.Close();
			p = null;

			String sql4 = "SELECT SUM(DISTINCT B.OpeningBalance) + SUM(CASE WHEN C.DatePosted < ? THEN CASE WHEN C.DrCr = 0 THEN C.Amount ELSE -C.Amount END ELSE 0 END) OpeningBalance, " +
						  "       SUM(DISTINCT B.OpeningBalance) + SUM(CASE WHEN C.DatePosted <= ? THEN CASE WHEN C.DrCr = 0 THEN C.Amount ELSE -C.Amount END ELSE 0 END) ClosingBalance " +
						  "FROM   Account A, BankAccount B, Txn C " +
						  "WHERE  A.Id = B.Id " +
						  "AND    B.Id = C.Account " +
						  "AND    C.DatePosted <= ? ";

			p = Persistence.GetInstance(session);
			p.SetSql(sql4, fromDate.Value, toDate.Value, toDate.Value);
			p.SqlWhere(true, "A.Operator = ?", o);
			p.SqlWhere(bankAccount != null && bankAccount.IsSet, "A.Id = ?", bankAccount);
			p.ExecuteQuery();

			if (!p.IsEof)
			{
				SelectionOpeningBalance = p.GetMoney("OpeningBalance");
				SelectionCurrentBalance = p.GetMoney("ClosingBalance");
			}

			p.Close();
			p = null;
		} 

		#endregion
	}
}
