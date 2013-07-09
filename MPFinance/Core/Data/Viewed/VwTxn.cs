using MPersist.Core;
using MPersist.Core.Attributes;
using MPersist.Core.Data;
using MPersist.Core.MoneyType;
using MPersist.Core.Tools;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Enums;
using System;

namespace MPFinance.Core.Data.Viewed
{
    public class VwTxn : AbstractViewedData
    {
        private static Logger Log = Logger.GetInstance(typeof(VwTxn));

        #region Variable Declarations

        

        #endregion

        #region Properties

        [Viewed]
        public Int64 TxnId { get; set; }
        [Viewed]
        public Int64 OperatorId { get; set; }
        [Viewed]
        public Int64 AccountId { get; set; }
        [Viewed]
        public DateTime DatePosted { get ; set; }
        [Viewed]
        public String Description { get; set; }
        [Viewed]
        public TxnType TxnType { get; set; }
        [Viewed]
        public Int64? Category { get; set; }
        [Viewed]
        public Money Debit { get; set; }
        [Viewed]
        public Money Credit { get; set; }
        [Viewed]
        public Boolean Transfer { get; set; }        
        
        public String HashCode { get; set; }
        public Money Amount { get; set; }        
        public Boolean IsDuplicate { get; set; }

        #endregion

        #region Constructors

        public VwTxn()
        {
        }

        public VwTxn(Session session, Persistence persistence) : base (session, persistence)
        {
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public static VwTxn GetInstanceById(Session session, Int64 Id)
        {
            VwTxn result = new VwTxn();

            Persistence p = Persistence.GetInstance(session);
            p.ExecuteQuery("SELECT * FROM VwTxn WHERE TxnId = ?", new Object[] { Id });
            result.Set(session, p);
            p.Close();
            p = null;

            return result;
        }

        public String GenerateHashCode(BankAccount account)
        {
            HashCode = Utils.GenerateHash(account.BankNumber + account.AccountNumber + DatePosted.ToString() + Amount.ToString() + Description);

            return HashCode;
        }

        #endregion
    }
}
