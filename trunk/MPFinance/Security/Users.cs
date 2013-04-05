using System;
using MPersist.Core;
using MPersist.Core.Data;

namespace MPersist.Security
{
    public class Users : AbstractViewedDataList
    {
        private static Logger Log = Logger.GetInstance(typeof(Users));

        #region Variable Declarations



        #endregion

        #region Properties



        #endregion

        #region Constructors

        public Users()
        {
            BaseType = typeof(User);
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods



        #endregion
    }
}
