using System.Data;

namespace MPersist.Core.Data
{
    public class AbstractViewedData : AbstractData
    {
        private static Logger Log = Logger.GetInstance(typeof(AbstractViewedData));

        #region Variable Declarations



        #endregion

        #region Properties



        #endregion

        #region Constructors

        public AbstractViewedData()
        {
        }

        public AbstractViewedData(Session session, Persistence persistence)
        {
            Set(session, persistence, true);
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        

        #endregion
    }
}
