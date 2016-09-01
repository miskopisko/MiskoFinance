using log4net;
using MiskoPersist.Core;
using MiskoPersist.Data.Viewed;

namespace MiskoFinanceCore.Data.Viewed
{
	public class VwBankAccounts : ViewedDataList
	{
		private static ILog Log = LogManager.GetLogger(typeof(VwBankAccounts));

		#region Fields



		#endregion

		#region Properties



		#endregion

		#region Constructors

		public VwBankAccounts() : base(typeof(VwBankAccount))
		{
		}

		#endregion

		#region Private Methods



		#endregion

		#region Public Methods

		public void FetchByOperator(Session session, PrimaryKey o)
		{
			Persistence p = Persistence.GetInstance(session);
			p.ExecuteQuery("SELECT * FROM VwBankAccount WHERE OperatorId = ?", o);
			Set(session, p);
			p.Close();
			p = null;
		}

		#endregion
	}
}