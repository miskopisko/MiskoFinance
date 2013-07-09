using MPersist.Core;
using MPersist.Core.Attributes;
using MPersist.Core.Data;
using MPersist.Core.Enums;
using MPFinance.Core.Enums;
using MPFinance.Resources;
using System;

namespace MPFinance.Core.Data.Stored
{
    public class Category : AbstractStoredData
    {
        private static Logger Log = Logger.GetInstance(typeof(Category));

        #region Variable Declarations



        #endregion

        #region Stored Properties

        [Stored]
        public Operator Operator { get; set; }
        [Stored]
        public String Name { get; set; }
        [Stored]
        public CategoryType CategoryType { get; set; }
        [Stored]
        public Status Status { get; set; }

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

        public Category(Operator op, String name, CategoryType type, Status status)
        {
            Operator = op;
            Name = name;
            CategoryType = type;
            Status = status;
        }

        #endregion

        #region Override Methods

        public override String ToString()
        {
            return Name;
        }

        public override void PreSave(Session session, UpdateMode mode)
        {
            if(String.IsNullOrEmpty(Name))
            {
                session.Error(ErrorLevel.Error, ErrorStrings.errCategoryNameNull);
            }

            if(CategoryType == null || CategoryType.IsNotSet)
            {
                session.Error(ErrorLevel.Error, ErrorStrings.errCategoryTypeNull);
            }

            if(Status == null || Status.IsNotSet)
            {
                session.Error(ErrorLevel.Error, ErrorStrings.errCategoryStatusNull);
            }
        }

        public override void PostSave(Session session, UpdateMode mode)
        {
            // If a category is deleted or inactivated reset all txns that were in that category
            if(mode.Equals(UpdateMode.Delete) || Status.Equals(Status.Inactive))
            {
                Txns.RemoveTxnCategory(session, this);
            }
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public static Category GetInstanceByComposite(Session session, Operator o, String name, CategoryType categoryType)
        {
            Category result = new Category();

            Persistence p = Persistence.GetInstance(session);
            p.ExecuteQuery("SELECT * FROM Category WHERE Operator = ? AND Name = ? AND CategoryType = ?", new Object[] { o, name, categoryType });
            result.Set(session, p);
            p.Close();
            p = null;   

            return result;
        }

        #endregion
    }
}
