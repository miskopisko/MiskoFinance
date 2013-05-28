using MPersist.Core;
using MPersist.Core.Data;

namespace MPFinance.Core.Data.Stored
{
    public class Txns : AbstractStoredDataList<Txn>
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

        public override AbstractStoredDataList<Txn> Save(Session session)
        {
            foreach (AbstractStoredData item in this)
            {
                item.Save(session);
            }

            return this;
        }

        #endregion
    }
}