using System;
using MPersist.Core;
using MPersist.Core.Attributes;
using MPersist.Core.Data;
using MPersist.Core.MoneyType;
using MPFinance.Core.Enums;

namespace MPFinance.Core.Data.Stored
{
    public class Txn : StoredData
    {
        private static Logger Log = Logger.GetInstance(typeof(Txn));

        #region Variable Declarations

       

        #endregion

        #region Stored Properties

        [Stored]
        public PrimaryKey Account { get; set; }
        [Stored]
        public TxnType TxnType { get; set;}
        [Stored]
        public DateTime DatePosted { get; set; }
        [Stored]
        public Money Amount { get; set; }
        [Stored]
        public String Description { get; set; }
        [Stored]
        public PrimaryKey Category { get; set; }
        [Stored]
        public String HashCode { get; set; }

        #endregion

        #region Other Properties

        

        #endregion        

        #region Constructors

        public Txn()
        {
        }

        public Txn(Session session, Persistence persistence) : base(session, persistence)
        {
        }

        #endregion

        #region Override Methods

        

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        

        #endregion
    }
}
