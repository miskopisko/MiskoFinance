using System;
using log4net;
using MiskoFinanceCore.Data.Stored;
using MiskoFinanceCore.Enums;
using MiskoPersist.Attributes;
using MiskoPersist.Core;
using MiskoPersist.Data.Viewed;

namespace MiskoFinanceCore.Data.Viewed
{
	public class VwCategory : ViewedData
	{
		private static ILog Log = LogManager.GetLogger(typeof(VwCategory));

		#region Fields



		#endregion

		#region Viewed Properties

		[Viewed]
		public PrimaryKey CategoryId { get; set; }
		[Viewed]
		public PrimaryKey OperatorId { get; set; }        
		[Viewed]
		public String Name { get; set; }
		[Viewed]
		public CategoryType CategoryType { get; set; }

		#endregion

		#region Other Properties



		#endregion

		#region Constructors

		public VwCategory()
        {
        }

        public VwCategory(Session session, Persistence persistence) : base(session, persistence)
        {
        }
		
		#endregion

		#region Override Methods

		public override String ToString()
		{
			return Name;
		}

		#endregion

		#region Private Methods



		#endregion

		#region Public Methods

		public void Update(Session session)
		{
			Category category = new Category();
			category.FetchById(session, CategoryId);

            category.Id = CategoryId;
            category.Operator = OperatorId;
			category.Name = Name;
			category.CategoryType = CategoryType;            
			category.Save(session);

            CategoryId = category.Id;
        }

		#endregion
	}
}