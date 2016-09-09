using log4net;
using MiskoFinanceCore.Data.Viewed;
using MiskoPersist.Attributes;
using MiskoPersist.Message.Responses;

namespace MiskoFinanceCore.Message.Responses
{
	public class UpdateCategoriesRS : ResponseMessage
	{
		private static ILog Log = LogManager.GetLogger(typeof(UpdateCategoriesRS));

		#region Parameters

		[Viewed]
		public VwCategories Categories { get; set; }

		#endregion
	}
}
