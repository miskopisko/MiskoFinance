using System;
using log4net;
using MiskoFinanceCore.Enums;
using MiskoPersist.Core;
using MiskoPersist.Data.Viewed;

namespace MiskoFinanceCore.Data.Viewed
{
	public class VwCategories : ViewedDataList<VwCategory>
	{
		private static ILog Log = LogManager.GetLogger(typeof(VwCategories));

		#region Fields



		#endregion

		#region Properties

		

		#endregion

		#region Constructors

		

		#endregion

		#region Private Methods

		

		#endregion

		#region Public Methods

		public VwCategories GetByType(CategoryType type, Boolean addBlank = false)
		{
			VwCategories result = new VwCategories();
			
			if (addBlank)
			{
				result.Add(new VwCategory());
			}

			foreach (VwCategory category in this)
			{
				if(category.CategoryId.IsSet && category.CategoryType.Equals(type))
				{
					result.Add(category);
				}
			}

			return result;
		}

		public VwCategories GetByStatus(Status status, Boolean addBlank = false)
		{
			VwCategories result = new VwCategories();
			
			if (addBlank)
			{
				result.Add(new VwCategory());
			}

			foreach (VwCategory category in this)
			{
				if(category.CategoryId > 0 && category.Status.Equals(status))
				{
					result.Add(category);
				}
			}

			return result;
		}

		public void FetchByComposite(Session session, PrimaryKey o, Status status)
		{
			using (Persistence persistence = session.GetPersistence())
			{
				persistence.SetSql("SELECT * FROM VwCategory");
				persistence.SqlWhere(true, "OperatorId = ?", o);
				persistence.SqlWhere(status != null && status.IsSet, "Status = ?", status);
				persistence.ExecuteQuery();
				Set(session, persistence);
			}
		}

		#endregion
	}
}