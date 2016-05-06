using MiskoFinanceWeb.Data.Viewed;
using MiskoPersist.Attributes;
using MiskoPersist.Message.Response;

namespace MiskoFinanceWeb.Message.Responses
{
	public class TestDBConnectionRS : ResponseMessage
	{
		#region Parameters

		[Viewed]
		public VwDatabaseConnections Connections { get; set; }

		#endregion
	}
}

