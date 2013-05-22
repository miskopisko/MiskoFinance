using MPersist.Core;
using MPersist.Core.Attributes;
using MPersist.Core.Data;
using MPersist.Resources.Enums;
using System;

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

        #endregion

        #region Constructors



        #endregion

        #region Private Methods



        #endregion

        #region Public Methods



        #endregion
    }
}
