using log4net;
using MiskoFinanceCore.Enums;
using MiskoPersist.Attributes;
using MiskoPersist.Data;
using MiskoPersist.Message.Request;

namespace MiskoFinanceCore.Message.Requests
{
	public class GetCategoriesRQ : RequestMessage
	{
		private static ILog Log = LogManager.GetLogger(typeof(GetCategoriesRQ));

		#region Parameters

		[Viewed]
		public PrimaryKey Operator { get; set; }
		[Viewed]
		public Status Status { get; set; }

		#endregion
	}
}
