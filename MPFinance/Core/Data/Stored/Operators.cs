using MPersist.Core;
using MPersist.Core.Data;

namespace MPFinance.Core.Data.Stored
{
    public class Operators : AbstractStoredDataList<Operator>
    {
        private static Logger Log = Logger.GetInstance(typeof(Operators));

        #region Variable Declarations



        #endregion

        #region Properties



        #endregion

        #region Constructors

        public Operators()
        {
            BaseType = typeof(Operator);
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public override AbstractStoredDataList<Operator> Save(Session session)
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
