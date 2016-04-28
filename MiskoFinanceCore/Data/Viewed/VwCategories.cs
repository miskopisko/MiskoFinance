using System;
using log4net;
using MiskoFinanceCore.Enums;
using MiskoPersist.Core;
using MiskoPersist.Data;

namespace MiskoFinanceCore.Data.Viewed
{
	public class VwCategories : ViewedDataList
	{
		private static ILog Log = LogManager.GetLogger(typeof(VwCategories));

		#region Fields



		#endregion

		#region Properties



		#endregion

		#region Constructors

		public VwCategories() : base(typeof(VwCategory))
		{
		}

		#endregion

		#region Private Methods

		

		#endregion

		#region Public Methods

		public VwCategories GetByType(CategoryType type)
		{
			VwCategories result = new VwCategories();

			foreach (VwCategory category in this)
			{
				if(category.CategoryId.IsSet && category.CategoryType.Equals(type))
				{
					result.Add(category);
				}
			}

			return result;
		}

		public VwCategories GetByStatus(Status status)
		{
			VwCategories result = new VwCategories();

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
			Persistence p = Persistence.GetInstance(session);
			p.SetSql("SELECT * FROM VwCategory");
			p.SqlWhere(true, "OperatorId = ?",  o);
			p.SqlWhere(status != null && status.IsSet, "Status = ?", status);
			p.ExecuteQuery();
			Set(session, p);
			p.Close();
			p = null;
		}

		#endregion
	}
}