using log4net;
using MiskoPersist.Data;
using MiskoPersist.Data.Stored;

namespace MiskoFinanceCore.Data.Stored
{
	public class Operators : StoredDataList
    {
        private static ILog Log = LogManager.GetLogger(typeof(Operators));

        #region Fields



        #endregion

        #region Properties



        #endregion

        #region Constructors

        public Operators() : base(typeof(Operator))
        {
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        

        #endregion
    }
}
