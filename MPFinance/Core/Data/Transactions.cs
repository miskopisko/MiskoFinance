using MPersist.Core;
using MPersist.Core.Data;

namespace MPFinance.Core.Data
{
    public class Transactions : AbstractStoredDataList
    {
        private static Logger Log = Logger.GetInstance(typeof(Transactions));

        #region Variable Declarations



        #endregion

        #region Properties



        #endregion

        #region Constructors

        public Transactions()
        {
            BaseType = typeof(Transaction);
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods



        #endregion
    }
}
