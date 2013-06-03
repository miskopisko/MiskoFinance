using MPersist.Core.Enums;
using System;

namespace MPFinance.Core.Enums
{
    public class Gender : AbstractEnum
    {
        #region Variable Declarations

        private static readonly Gender mNULL_ = new Gender(-1, "", "");
        private static readonly Gender mMale_ = new Gender(0, "M", "Male");
        private static readonly Gender mFemale_ = new Gender(1, "F", "Female");

        private static readonly Gender[] mElements_ = new[]
		{
		    mNULL_, mMale_, mFemale_
		};

        #endregion

        #region Parameters

        public static Gender[] Elements { get { return mElements_; } }
        public static Gender NULL { get { return mNULL_; } }
        public static Gender Male { get { return mMale_; } }
        public static Gender Female { get { return mFemale_; } }

        #endregion

        protected Gender()
        {
        }

        protected Gender(Int64 value, String code, String description) : base(value, code, description)
        {
        }

        public static Gender GetElement(long index)
        {
            for (int i = 0; Elements != null && i < Elements.Length; i++)
            {
                if (Elements[i].Value == index)
                {
                    return Elements[i];
                }
            }

            return null;
        }

        public static Gender GetElement(String descriptionCode)
        {
            for (int i = 0; descriptionCode != null && Elements != null && i < Elements.Length; i++)
            {
                if (Elements[i].Description.ToLower().Equals(descriptionCode.ToLower()) || Elements[i].Code.ToLower().Equals(descriptionCode.ToLower()))
                {
                    return Elements[i];
                }
            }

            return null;
        }
    }
}
