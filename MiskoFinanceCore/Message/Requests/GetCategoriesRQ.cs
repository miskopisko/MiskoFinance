using log4net;
using MiskoFinanceCore.Enums;
using MiskoPersist.Attributes;
using MiskoPersist.Core;
using MiskoPersist.Message.Requests;

namespace MiskoFinanceCore.Message.Requests
{
	public class GetCategoriesRQ : RequestMessage
	{
		private static ILog Log = LogManager.GetLogger(typeof(GetCategoriesRQ));

		#region Parameters

		[Viewed]
		public PrimaryKey Operator { get; set; }

		#endregion
	}
}
