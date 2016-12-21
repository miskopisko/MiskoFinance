using System;
using log4net;
using MiskoFinanceCore.Enums;
using MiskoFinanceCore.Resources;
using MiskoPersist.Attributes;
using MiskoPersist.Core;
using MiskoPersist.Data.Stored;
using MiskoPersist.Enums;

namespace MiskoFinanceCore.Data.Stored
{
	public class Category : StoredData
    {
        private static ILog Log = LogManager.GetLogger(typeof(Category));

        #region Fields



        #endregion

        #region Stored Properties

        [Stored]
        public PrimaryKey Operator { get; set; }
        [Stored(Length = 128)]
        public String Name { get; set; }
        [Stored]
        public CategoryType CategoryType { get; set; }

        #endregion

        #region Other Properties

        

        #endregion

        #region Constructors

        public Category()
        {
        }

        public Category(Session session, Persistence persistence) : base(session, persistence)
        {
        }

        #endregion

        #region Override Methods

		public override StoredData Create(Session session)
		{
			PreSave(session, UpdateMode.Insert);
			Persistence.ExecuteInsert(session, this, typeof(Category));
			PostSave(session, UpdateMode.Insert);
			return this;
		}

		public override StoredData Store(Session session)
		{
			PreSave(session, UpdateMode.Update);
			Persistence.ExecuteUpdate(session, this, typeof(Category));
			PostSave(session, UpdateMode.Update);
			return this;
		}
        
		public override StoredData Remove(Session session)
		{
			Persistence.ExecuteDelete(session, this, typeof(Category));
			PostSave(session, UpdateMode.Delete);
			return this;
		}

		public override void PreSave(Session session, UpdateMode mode)
		{
			if (String.IsNullOrEmpty(Name))
			{
				session.Error(ErrorLevel.Error, ErrorStrings.errCategoryNameNull);
			}
			if (CategoryType == null || !CategoryType.IsSet)
			{
				session.Error(ErrorLevel.Error, ErrorStrings.errCategoryTypeNull);
			}
		}

		public override void PostSave(Session session, UpdateMode mode)
		{
			// If a category is deleted or inactivated reset all txns that were in that category
			if (mode.Equals(UpdateMode.Delete))
			{
				Txns.RemoveTxnCategory(session, this);
			}
		}

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        

        #endregion
    }
}
