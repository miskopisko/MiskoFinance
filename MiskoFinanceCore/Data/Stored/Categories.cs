using log4net;
using MiskoPersist.Data;
using MiskoPersist.Data.Stored;

namespace MiskoFinanceCore.Data.Stored
{
	public class Categories : StoredDataList
    {
        private static ILog Log = LogManager.GetLogger(typeof(Categories));

        #region Fields



        #endregion

        #region Properties



        #endregion

        #region Constructors

        public Categories() : base(typeof(Category))
        {
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        

        #endregion
    }
}
