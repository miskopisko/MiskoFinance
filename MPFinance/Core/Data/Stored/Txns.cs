using MPersist.Core;
using MPersist.Core.Data;

namespace MPFinance.Core.Data.Stored
{
    public class Txns : AbstractStoredDataList
    {
        private static Logger Log = Logger.GetInstance(typeof(Txns));

        #region Variable Declarations



        #endregion

        #region Properties



        #endregion

        #region Constructors

        public Txns()
        {
            BaseType = typeof(Txn);
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods



        #endregion
    }
}
