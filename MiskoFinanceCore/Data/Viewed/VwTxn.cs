using System;
using MiskoPersist.Attributes;
using MiskoPersist.Core;
using MiskoPersist.Data;
using MiskoPersist.MoneyType;
using MiskoFinanceCore.Data.Stored;
using MiskoFinanceCore.Enums;

namespace MiskoFinanceCore.Data.Viewed
{
    public class VwTxn : AbstractViewedData
    {
        private static Logger Log = Logger.GetInstance(typeof(VwTxn));

        #region Fields

        

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

        public Txn Update(Session session)
        {
            Txn txn = new Txn();
            txn.FetchById(session, TxnId);
                
            txn.TxnType = TxnType;
            txn.Category = Category;
            txn.Save(session);

            return txn;
        }

        #endregion
    }
}
