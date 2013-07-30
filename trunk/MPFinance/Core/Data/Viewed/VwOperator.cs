using System;
using MPersist.Core;
using MPersist.Core.Attributes;
using MPersist.Core.Data;

namespace MPFinance.Core.Data.Viewed
{
    public class VwOperator : ViewedData
    {
        private static Logger Log = Logger.GetInstance(typeof(VwOperator));

        #region Fields



        #endregion

        #region Viewed Properties



        #endregion

        #region Other Properties



        #endregion

        #region Constructors

        public VwOperator()
        {
        }

        public VwOperator(Session session, Persistence persistence)
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