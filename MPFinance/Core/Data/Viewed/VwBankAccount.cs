using System;
using MPersist.Core;
using MPersist.Core.Attributes;
using MPersist.Core.Data;

namespace MPFinance.Core.Data.Viewed
{
    public class VwBankAccount : ViewedData
    {
        private static Logger Log = Logger.GetInstance(typeof(VwBankAccount));

        #region Fields



        #endregion

        #region Viewed Properties



        #endregion

        #region Other Properties



        #endregion

        #region Constructors

        public VwBankAccount()
        {
        }

        public VwBankAccount(Session session, Persistence persistence)
            : base(session, persistence)
        {
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods



        #endregion
    }
}