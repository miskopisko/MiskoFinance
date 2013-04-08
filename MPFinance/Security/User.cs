using System;
using MPersist.Core;
using MPersist.Core.Data;
using MPersist.Core.Attributes;

namespace MPersist.Security
{
    public class User : AbstractViewedData
    {
        private static Logger Log = Logger.GetInstance(typeof(User));

        #region Variable Declarations



        #endregion

        #region Properties

        [Viewed]
        public String Follower { get; set; }
        [Viewed]
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
