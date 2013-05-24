using System;
using MPersist.Core;
using MPersist.Core.MoneyType;
using MPFinance.Core.Data.Stored;

namespace MPFinance.Core.Data.Viewed
{
    public class VwSummary
    {
        private static Logger Log = Logger.GetInstance(typeof(VwSummary));

        #region Variable Declarations



        #endregion

        #region Properties

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

        public void Fetch(Session session, Operator op, Account account, DateTime? from, DateTime? to)
        {
            Persistence p = Persistence.GetInstance(session);
            p.SetSql("SELECT SUM(Openingbalance) OpeningBalance FROM Account ");
            p.SqlWhere(true, "Operator = ?", new Object[] { op });
            p.SqlWhere(account != null && account.IsSet, "Id = ?", new Object[] { account });
            p.ExecuteQuery();           

            if (p.Next())
            {
                OpeningBalance = p.GetMoney("OpeningBalance", Money.Zero);
            }

            p.Close();
            p = null;

            String sql = "SELECT SUM(CASE WHEN TxnType = 0 THEN Credit ELSE 0 END) SumCredit, " +
                         "       SUM(CASE WHEN TxnType = 1 THEN Debit ELSE 0 END) SumDebit, " +
                         "       SUM(CASE WHEN TxnType = 2 THEN Credit ELSE 0 END) SumTransferIn, " +
                         "       SUM(CASE WHEN TxnType = 3 THEN Debit ELSE 0 END)  SumTransferOut " +
                         "FROM   VwTxn";

            p = Persistence.GetInstance(session);
            p.SetSql(sql);
            p.SqlWhere(true, "OperatorId = ?", new Object[] { op });
            p.SqlWhere(account != null && account.IsSet, "AccountId = ?", new Object[] { account });
            p.SqlWhere(from.HasValue, "DatePosted >= ?", new Object[] { from });
            p.SqlWhere(to.HasValue, "DatePosted <= ?", new Object[] { to });
            p.ExecuteQuery();

            if (p.Next())
            {
                TotalCredits = p.GetMoney("SumCredit", Money.Zero);
                TotalDebits = p.GetMoney("SumDebit", Money.Zero);
                TotalTransfersIn = p.GetMoney("SumTransferIn", Money.Zero);
                TotalTransfersOut = p.GetMoney("SumTransferOut", Money.Zero);
            }

            p.Close();
            p = null;

            CurrentBalance = OpeningBalance + TotalCredits + TotalTransfersIn - TotalDebits - TotalTransfersOut;

            DifferenceCreditsDebits = TotalCredits - TotalDebits;
            DifferenceTransfers = TotalTransfersIn - TotalTransfersOut;
            DifferenceBalance = CurrentBalance - OpeningBalance;
        } 

        #endregion
    }
}
