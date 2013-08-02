using System;
using MPersist.Core;
using MPersist.Core.Data;
using MPersist.Core.MoneyType;

namespace MPFinance.Core.Data.Viewed
{
    public class VwSummary
    {
        private static Logger Log = Logger.GetInstance(typeof(VwSummary));

        #region Fields



        #endregion

        #region Properties

        public String BankAccountName { get; set; }
        public Money TotalCredits { get; set; }
        public Money TotalDebits { get; set; }
        public Money DifferenceCreditsDebits { get; set; }
        public Money TotalTransfersIn { get; set; }
        public Money TotalTransfersOut { get; set; }
        public Money DifferenceTransfers { get; set; }
        public Money OpeningBalance { get; set; }
        public Money CurrentBalance { get; set; }
        public Money DifferenceBalance { get; set; }

        #endregion

        #region Constructors

        public VwSummary()
        {
            TotalCredits = Money.Zero;
            TotalDebits = Money.Zero;
            DifferenceCreditsDebits = Money.Zero;
            TotalTransfersIn = Money.Zero;
            TotalTransfersOut = Money.Zero;
            DifferenceTransfers = Money.Zero;
            OpeningBalance = Money.Zero;
            CurrentBalance = Money.Zero;
            DifferenceBalance = Money.Zero;
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public void Fetch(Session session, PrimaryKey op, PrimaryKey account, DateTime? from, DateTime? to, PrimaryKey category, String description)
        {
            String sql1 = "SELECT SUM(B.OpeningBalance) OpeningBalance, MAX(B.Nickname) Nickname " +
                          "FROM   Account A, BankAccount B " +
                          "WHERE  A.Id = B.Id ";

            Persistence p = Persistence.GetInstance(session);
            p.SetSql(sql1);
            p.SqlWhere(true, "A.Operator = ?", new Object[] { op });
            p.SqlWhere(account != null && account.IsSet, "A.Id = ?", new Object[] { account });
            p.ExecuteQuery();           

            if (p.Next())
            {
                OpeningBalance = p.GetMoney("OpeningBalance");
                BankAccountName = account != null && account.IsSet ? p.GetString("Nickname") : "All";
            }

            p.Close();
            p = null;


            String sql2 = "SELECT SUM(CASE WHEN C.TxnType IN (0,2) THEN C.Amount ELSE -C.Amount END) ClosingBalance " +
                          "FROM   Account A, BankAccount B, Txn C " +
                          "WHERE  A.Id = B.Id " +
                          "AND    B.Id = C.Account";

            p = Persistence.GetInstance(session);
            p.SetSql(sql2);
            p.SqlWhere(true, "A.Operator = ?", new Object[] { op });
            p.SqlWhere(account != null && account.IsSet, "A.Id = ?", new Object[] { account });
            p.ExecuteQuery();

            if (p.Next())
            {
                CurrentBalance = OpeningBalance + p.GetMoney("ClosingBalance");
            }

            p.Close();
            p = null;

            String sql3 = "SELECT SUM(CASE WHEN TxnType = 0 THEN Credit ELSE 0 END) SumCredit, " +
                          "       SUM(CASE WHEN TxnType = 1 THEN Debit ELSE 0 END) SumDebit, " +
                          "       SUM(CASE WHEN TxnType = 2 THEN Credit ELSE 0 END) SumTransferIn, " +
                          "       SUM(CASE WHEN TxnType = 3 THEN Debit ELSE 0 END)  SumTransferOut " +
                          "FROM   VwTxn";

            p = Persistence.GetInstance(session);
            p.SetSql(sql3);
            p.SqlWhere(true, "OperatorId = ?", new Object[] { op });
            p.SqlWhere(account != null && account.IsSet, "AccountId = ?", new Object[] { account });
            p.SqlWhere(from.HasValue, "DatePosted >= ?", new Object[] { from });
            p.SqlWhere(to.HasValue, "DatePosted <= ?", new Object[] { to });
            p.SqlWhere(category != null && category.IsSet, "Category = ?", new Object[] { category });
            p.SqlWhere(!String.IsNullOrEmpty(description), "Description LIKE ?", new Object[] { "%" + description + "%" });
            p.ExecuteQuery();

            if (p.Next())
            {
                TotalCredits = p.GetMoney("SumCredit");
                TotalDebits = p.GetMoney("SumDebit");
                TotalTransfersIn = p.GetMoney("SumTransferIn");
                TotalTransfersOut = p.GetMoney("SumTransferOut");
            }

            p.Close();
            p = null;

            DifferenceCreditsDebits = TotalCredits - TotalDebits;
            DifferenceTransfers = TotalTransfersIn - TotalTransfersOut;
            DifferenceBalance = CurrentBalance - OpeningBalance;
        } 

        #endregion
    }
}
