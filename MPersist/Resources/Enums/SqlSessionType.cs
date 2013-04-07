using System;

namespace MPersist.Resources.Enums
{
    public class SqlSessionType : AbstractEnum
    {
        #region Variable Declarations

        private static readonly SqlSessionType mNULL_ = new SqlSessionType(-1, "", "");
        private static readonly SqlSessionType mMySql_ = new SqlSessionType(0, "", "MySql");
        private static readonly SqlSessionType mSqlite_ = new SqlSessionType(1, "", "Sqlite");
        private static readonly SqlSessionType mOracle_ = new SqlSessionType(2, "", "Oracle");

        private static readonly SqlSessionType[] mElements_ = new[]
		{
		    mNULL_, mMySql_, mSqlite_, mOracle_
		};

        #endregion

        #region Parameters

        public static SqlSessionType[] Elements { get { return mElements_; } }
        public static SqlSessionType NULL { get { return mNULL_; } }
        public static SqlSessionType MySql { get { return mMySql_; } }
        public static SqlSessionType Sqlite { get { return mSqlite_; } }
        public static SqlSessionType Oracle { get { return mOracle_; } }

        #endregion

        protected SqlSessionType(Int64 value, String code, String description)
            : base(value, code, description)
        {
        }

        public static SqlSessionType GetElement(long index)
        {
            for (int i = 0; mElements_ != null && i < mElements_.Length; i++)
            {
                if (mElements_[i].Value == index)
                {
                    return mElements_[i];
                }
            }

            return null;
        }

        public static SqlSessionType GetElement(String descriptionCode)
        {
            for (int i = 0; descriptionCode != null && mElements_ != null && i < mElements_.Length; i++)
            {
                if (mElements_[i].Description.ToLower().Equals(descriptionCode.ToLower()) || mElements_[i].Code.ToLower().Equals(descriptionCode.ToLower()))
                {
                    return mElements_[i];
                }
            }

            return null;
        }
    }
}
