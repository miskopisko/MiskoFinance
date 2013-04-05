using System;
using MPersist.Core;
using MPersist.Core.Data;

namespace MPersist.Security
{
    public class User : AbstractViewedData
    {
        private static Logger Log = Logger.GetInstance(typeof(User));

        #region Variable Declarations



        #endregion

        #region Properties

        public String Follower { get; set; }
        public String Leader { get; set; }

        #endregion

        #region Constructors

        public User()
        {
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods



        #endregion
    }
}
