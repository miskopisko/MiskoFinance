using log4net;
using MiskoPersist.Data;

namespace MiskoFinanceCore.Data.Viewed
{
	public class VwOperators : ViewedDataList
	{
		private static ILog Log = LogManager.GetLogger(typeof(VwOperators));

		#region Fields



		#endregion

		#region Properties



		#endregion

		#region Constructors

		public VwOperators() : base(typeof(VwOperator))
		{
		}

		#endregion

		#region Private Methods



		#endregion

		#region Public Methods



		#endregion
	}
}