using log4net;
using MiskoPersist.Core;
using MiskoPersist.Data.Viewed;

namespace MiskoFinanceCore.Data.Viewed
{
	public class VwBankAccounts : ViewedDataList<VwBankAccount>
	{
		private static ILog Log = LogManager.GetLogger(typeof(VwBankAccounts));

		#region Fields



		#endregion

		#region Properties



		#endregion

		#region Constructors

		

		#endregion

		#region Private Methods



		#endregion

		#region Public Methods

		public void FetchByOperator(Session session, PrimaryKey o)
		{
			Persistence persistence = session.GetPersistence();
			persistence.ExecuteQuery("SELECT * FROM VwBankAccount WHERE OperatorId = ?", o);
			Set(session, persistence);
			persistence.Close();
			persistence = null;
		}

		#endregion
	}
}