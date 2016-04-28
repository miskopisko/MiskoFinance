using log4net;
using MiskoPersist.Data;

namespace MiskoFinanceCore.Data.Stored
{
	public class Accounts : StoredDataList
    {
        private static ILog Log = LogManager.GetLogger(typeof(Accounts));

        #region Fields



        #endregion

        #region Properties



        #endregion

        #region Constructors

        public Accounts() : base(typeof(Account))
        {
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        

        #endregion        
    }
}
