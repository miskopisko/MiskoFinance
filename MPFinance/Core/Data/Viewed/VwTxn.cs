using System;
using MPersist.Core;
using MPersist.Core.Attributes;
using MPersist.Core.Data;
using MPersist.Core.MoneyType;
using MPFinance.Core.Enums;

namespace MPFinance.Core.Data.Viewed
{
    public class VwTxn : ViewedData
    {
        private static Logger Log = Logger.GetInstance(typeof(VwTxn));

        #region Variable Declarations

        

        #endregion

        #region Viewed Properties

        [Viewed]
        public PrimaryKey TxnId { get; set; }
        [Viewed]
        public PrimaryKey OperatorId { get; set; }
        [Viewed]
        public PrimaryKey AccountId { get; set; }
        [Viewed]
        public DateTime DatePosted { get ; set; }
        [Viewed]
        public String Description { get; set; }
        [Viewed]
        public TxnType TxnType { get; set; }
        [Viewed]
        public PrimaryKey Category { get; set; }
        [Viewed]
        public Money Debit { get; set; }
        [Viewed]
        public Money Credit { get; set; }
        [Viewed]
        public Boolean Transfer { get; set; }        

        #endregion

        #region Other Properties

        public Money Amount { get; set; }
        public String HashCode { get; set; }

        #endregion

        #region Constructors

        public VwTxn()
        {
        }

        public VwTxn(Session session, Persistence persistence) : base (session, persistence)
        {
        }

        #endregion

        #region Override Methods

        

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public static VwTxn GetInstanceById(Session session, PrimaryKey Id)
        {
            VwTxn result = new VwTxn();

            Persistence p = Persistence.GetInstance(session);
            p.ExecuteQuery("SELECT * FROM VwTxn WHERE TxnId = ?", new Object[] { Id });
            result.Set(session, p);
            p.Close();
            p = null;

            return result;
        }

        #endregion
    }
}