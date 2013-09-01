using System;
using MPersist.Attributes;
using MPersist.Core;
using MPersist.Data;
using MPFinanceCore.Data.Stored;
using MPFinanceCore.Enums;

namespace MPFinanceCore.Data.Viewed
{
    public class VwCategory : AbstractViewedData
    {
        private static Logger Log = Logger.GetInstance(typeof(VwCategory));

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
        [Viewed]
        public Status Status { get; set; }

        #endregion

        #region Other Properties



        #endregion

        #region Constructors

        public VwCategory()
        {
        }

        public VwCategory(Session session, Persistence persistence)
            : base(session, persistence)
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

        public Category Update(Session session)
        {
            Category category = new Category();
            category.FetchById(session, CategoryId);

            category.Operator = OperatorId;
            category.Name = Name;
            category.CategoryType = CategoryType;            
            category.Status = Status;
            category.Save(session);

            return category;
        }

        #endregion
    }
}