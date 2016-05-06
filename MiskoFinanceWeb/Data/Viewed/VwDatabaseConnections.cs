using System;
using MiskoPersist.Data;

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
