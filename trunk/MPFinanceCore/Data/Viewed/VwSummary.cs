using System;
using MPersist.Core;
using MPersist.Data;
using MPersist.MoneyType;

namespace MPFinanceCore.Data.Viewed
{
    public class VwSummary
    {
        private static Logger Log = Logger.GetInstance(typeof(VwSummary));

        #region Fields



        #endregion

        #region Properties

        public String BankAccountName { get; set; }

        public Money SelectionTotalCredits { get; set; }
        public Money SelectionTotalDebits { get; set; }
        public Money SelectionCreditsDebitsDifference { get; set; }
        public Money SelectionTotalTransfersIn { get; set; }
        public Money SelectionTotalTransfersOut { get; set; }
        public Money SelectionTransfersDifference { get; set; }
        public Money SelectionOpeningBalance { get; set; }
        public Money SelectionCurrentBalance { get; set; }
        public Money SelectionBalanceDifference { get; set; }
        public Money AllTimeOpeningBalance { get; set; }
        public Money AllTimeCurrentBalance { get; set; }
        public Money AllTimeBalanceDifference { get; set; }

        #endregion

        #region Constructors

        public VwSummary()
        {
            SelectionTotalCredits = Money.ZERO;
            SelectionTotalDebits = Money.ZERO;
            SelectionCreditsDebitsDifference = Money.ZERO;
            SelectionTotalTransfersIn = Money.ZERO;
            SelectionTotalTransfersOut = Money.ZERO;
            SelectionTransfersDifference = Money.ZERO;
            AllTimeOpeningBalance = Money.ZERO;
            AllTimeCurrentBalance = Money.ZERO;
            AllTimeBalanceDifference = Money.ZERO;
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
                AllTimeOpeningBalance = p.GetMoney("OpeningBalance");
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
                AllTimeCurrentBalance = AllTimeOpeningBalance + p.GetMoney("ClosingBalance");
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
                SelectionTotalCredits = p.GetMoney("SumCredit");
                SelectionTotalDebits = p.GetMoney("SumDebit");
                SelectionTotalTransfersIn = p.GetMoney("SumTransferIn");
                SelectionTotalTransfersOut = p.GetMoney("SumTransferOut");
            }

            p.Close();
            p = null;

            String sql4 = "SELECT SUM(DISTINCT B.OpeningBalance) + SUM(CASE WHEN C.DatePosted < ? THEN CASE WHEN C.TxnType IN (0,2) THEN C.Amount ELSE -C.Amount END ELSE 0 END) OpeningBalance, " +
                          "       SUM(DISTINCT B.OpeningBalance) + SUM(CASE WHEN C.DatePosted <= ? THEN CASE WHEN C.TxnType IN (0,2) THEN C.Amount ELSE -C.Amount END ELSE 0 END) ClosingBalance " +
                          "FROM   Account A, BankAccount B, Txn C " +
                          "WHERE  A.Id = B.Id " +
                          "AND    B.Id = C.Account " +
                          "AND    C.DatePosted <= ? ";

            p = Persistence.GetInstance(session);
            p.SetSql(sql4, new Object[]{ from.Value, to.Value, to.Value });
            p.SqlWhere(true, "A.Operator = ?", new Object[] { op });
            p.SqlWhere(account != null && account.IsSet, "A.Id = ?", new Object[] { account });
            p.ExecuteQuery();

            if (p.Next())
            {
                SelectionOpeningBalance = p.GetMoney("OpeningBalance");
                SelectionCurrentBalance = p.GetMoney("ClosingBalance");
            }

            p.Close();
            p = null;

            SelectionCreditsDebitsDifference = SelectionTotalCredits - SelectionTotalDebits;
            SelectionTransfersDifference = SelectionTotalTransfersIn - SelectionTotalTransfersOut;
            SelectionBalanceDifference = SelectionCurrentBalance - SelectionOpeningBalance;
            AllTimeBalanceDifference = AllTimeCurrentBalance - AllTimeOpeningBalance;
        } 

        #endregion
    }
}
