using System;
using System.Reflection;
using MPersist.Core;
using MPersist.Core.Attributes;
using MPersist.Core.Data;
using MPersist.Core.Enums;
using MPFinance.Core.Enums;
using MPFinance.Resources;

namespace MPFinance.Core.Data.Stored
{
    public class Category : AbstractStoredData
    {
        private static Logger Log = Logger.GetInstance(typeof(Category));

        #region Variable Declarations



        #endregion

        #region Properties

        [Stored]
        public Operator Operator { get; set; }
        [Stored]
        public String Name { get; set; }
        [Stored]
        public CategoryType CategoryType { get; set; }
        [Stored]
        public Status Status { get; set; }

        #endregion

        #region Constructors

        public Category()
        {
        }

        public Category(Session session, Persistence persistence) : base(session, persistence)
        {
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public void Validate(Session session)
        {
            if(String.IsNullOrEmpty(Name))
            {
                session.Error(GetType(), MethodInfo.GetCurrentMethod(), ErrorLevel.Error, ErrorStrings.errCategoryNameBlank);
            }

            if(CategoryType == null || !CategoryType.IsSet)
            {
                session.Error(GetType(), MethodInfo.GetCurrentMethod(), ErrorLevel.Error, ErrorStrings.errCategoryTypeMissing);
            }
        }

        public override string ToString()
        {
            return Name;
        }

        public static Category FetchByComposite(Session session, Operator o, String name, CategoryType categoryType)
        {
            Category result = null;

            Persistence p = Persistence.GetInstance(session);
            p.ExecuteQuery("SELECT * FROM Category WHERE Operator = ? AND Name = ? AND CategoryType = ?", new Object[]{o, name, categoryType});
            if(p.HasNext)
            {
                result = new Category(session, p);
            }
            p.Close();
            p = null;

            return result;
        }

        #endregion
    }
}
