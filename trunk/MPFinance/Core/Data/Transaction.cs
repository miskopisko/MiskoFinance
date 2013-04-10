using System;
using MPersist.Core.Attributes;
using MPersist.Core.Data;
using MPersist.Core;
using MPFinance.Resources.Enums;

namespace MPFinance.Core.Data
{
    public class Transaction : AbstractStoredData
    {
        private static Logger Log = Logger.GetInstance(typeof(Transaction));

        #region Variable Declarations



        #endregion

        #region Properties

        [Stored]
        public Account Account { get; set; }
        [Stored]
        public TransactionType Type { get; set;}
        [Stored]
        public DateTime DatePosted { get; set; }
        [Stored]
        public Money Amount { get; set; }
        [Stored]
        public String FITID { get; set; }
        [Stored]
        public String Name { get; set; }
        [Stored]
        public String Memo { get; set; }
        [Stored]
        public String CheckNum { get; set; }

        #endregion

        #region Constructors



        #endregion

        #region Private Methods



        #endregion

        #region Public Methods



        #endregion
    }
}
