using System;
using MiskoPersist.Data.Viewed;

namespace MiskoFinanceWeb.Data.Viewed
{
	public class VwDatabaseConnections : ViewedDataList
	{
		public VwDatabaseConnections()
			: base(typeof(VwDatabaseConnection))
		{
		}
	}
}
