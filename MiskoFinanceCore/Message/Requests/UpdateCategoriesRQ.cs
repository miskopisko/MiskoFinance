using log4net;
using MiskoFinanceCore.Data.Viewed;
using MiskoPersist.Attributes;
using MiskoPersist.Message.Requests;

namespace MiskoFinanceCore.Message.Requests
{
	public class UpdateCategoriesRQ : RequestMessage
	{
		private static ILog Log = LogManager.GetLogger(typeof(UpdateCategoriesRQ));

		#region Parameters

		[Viewed]
		public VwCategories Categories { get; set; }

		#endregion
	}
}
