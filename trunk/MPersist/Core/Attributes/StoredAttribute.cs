using System;

namespace MPersist.Core.Attributes
{
    public class StoredAttribute : Attribute
    {
        private static Logger Log = Logger.GetInstance(typeof(StoredAttribute));

        #region Variable Declarations



        #endregion

        #region Properties

        public Boolean PrimaryKey { get; set; }
        public Boolean DtCreated { get; set; }
        public Boolean DTModified { get; set; }
        public Boolean RowVer { get; set; }

        public Boolean UseInSql { get { return !PrimaryKey && !DtCreated && !DTModified && !RowVer; } }

        #endregion

        #region Constructors



        #endregion

        #region Private Methods



        #endregion

        #region Public Methods



        #endregion
    }
}
