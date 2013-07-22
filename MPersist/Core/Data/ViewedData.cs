
namespace MPersist.Core.Data
{
    public class ViewedData : Data
    {
        private static Logger Log = Logger.GetInstance(typeof(ViewedData));

        #region Fields



        #endregion

        #region Properties



        #endregion

        #region Constructors

        public ViewedData()
        {
        }

        public ViewedData(Session session, Persistence persistence)
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
