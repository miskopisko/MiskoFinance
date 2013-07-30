using System;
using MPersist.Core;
using MPersist.Core.Attributes;
using MPersist.Core.Data;

namespace MPFinance.Core.Data.Viewed
{
    public class VwCategory : ViewedData
    {
        private static Logger Log = Logger.GetInstance(typeof(VwCategory));

        #region Fields



        #endregion

        #region Viewed Properties



        #endregion

        #region Other Properties



        #endregion

        #region Constructors

        public VwCategory()
        {
        }

        public VwCategory(Session session, Persistence persistence)
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