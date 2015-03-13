using System;
using MPersist.Attributes;
using MPersist.Core;
using MPersist.Data;
using MPersist.MoneyType;

namespace MPFinanceCore.Data.Viewed
{
    public class VwSummary : AbstractViewedData
    {
        private static Logger Log = Logger.GetInstance(typeof(VwSummary));

        #region Fields



        #endregion
        
        #region Properties
        
        public PrimaryKey Operator { get; set; }
        public PrimaryKey BankAccount { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public PrimaryKey Category { get; set; }
        public String Description { get; set; }
        
        #endregion

        #region Viewed Properties

        [Viewed]
        public Money SelectionTotalCredits { get; set; }
        [Viewed]
        public Money SelectionTotalDebits { get; set; }
        [Viewed]
        public Money SelectionCreditsDebitsDifference { get; set; }
        [Viewed]
        public Money SelectionTotalTransfersIn { get; set; }
        [Viewed]
        public Money SelectionTotalTransfersOut { get; set; }
        [Viewed]
        public Money SelectionTransfersDifference { get; set; }
        [Viewed]
        public Money SelectionOpeningBalance { get; set; }
        [Viewed]
        public Money SelectionCurrentBalance { get; set; }
        [Viewed]
        public Money SelectionBalanceDifference { get; set; }
        [Viewed]
        public Money AllTimeOpeningBalance { get; set; }
        [Viewed]
        public Money AllTimeCurrentBalance { get; set; }
        [Viewed]
        public Money AllTimeBalanceDifference { get; set; }

        #endregion

        #region Constructors

        public VwSummary()
        {
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public void Fetch(Session session)
        {
            String sql1 = "SELECT SUM(B.OpeningBalance) OpeningBalance, MAX(B.Nickname) Nickname " +
                          "FROM   Account A, BankAccount B " +
                          "WHERE  A.Id = B.Id ";

            Persistence p = Persistence.GetInstance(session);
            p.SetSql(sql1);
            p.SqlWhere(true, "A.Operator = ?", new Object[] { Operator });
            p.SqlWhere(BankAccount != null, "A.Id = ?", new Object[] { BankAccount });
            p.ExecuteQuery();           

            if (p.Next())
            {
                AllTimeOpeningBalance = p.GetMoney("OpeningBalance");
            }

            p.Close();
            p = null;

            String sql2 = "SELECT SUM(CASE WHEN C.TxnType IN (0,2) THEN C.Amount ELSE -C.Amount END) ClosingBalance " +
                          "FROM   Account A, BankAccount B, Txn C " +
                          "WHERE  A.Id = B.Id " +
                          "AND    B.Id = C.Account";

            p = Persistence.GetInstance(session);
            p.SetSql(sql2);
            p.SqlWhere(true, "A.Operator = ?", new Object[] { Operator });
            p.SqlWhere(BankAccount != null, "A.Id = ?", new Object[] { BankAccount });
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
            p.SqlWhere(true, "OperatorId = ?", new Object[] { Operator });
            p.SqlWhere(BankAccount != null, "AccountId = ?", new Object[] { BankAccount });
            p.SqlWhere(FromDate.HasValue, "DatePosted >= ?", new Object[] { FromDate });
            p.SqlWhere(ToDate.HasValue, "DatePosted <= ?", new Object[] { ToDate });
            p.SqlWhere(Category != null, "Category = ?", new Object[] { Category });
            p.SqlWhere(!String.IsNullOrEmpty(Description), "Description LIKE ?", new Object[] { "%" + Description + "%" });
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
            p.SetSql(sql4, new Object[]{ FromDate.Value, ToDate.Value, ToDate.Value });
            p.SqlWhere(true, "A.Operator = ?", new Object[] { Operator });
            p.SqlWhere(BankAccount != null, "A.Id = ?", new Object[] { BankAccount });
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
