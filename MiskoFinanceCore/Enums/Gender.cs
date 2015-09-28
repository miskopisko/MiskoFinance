using System;
using MiskoPersist.Enums;

namespace MiskoFinanceCore.Enums
{
    public class Gender : AbstractEnum
    {
        #region Fields

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

        public Gender()
        {
        }

        public Gender(Int64 value, String code, String description) : base(value, code, description)
        {
        }

        public static Gender GetElement(long index)
        {
            for (Int32 i = 0; Elements != null && i < Elements.Length; i++)
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
            for (Int32 i = 0; descriptionCode != null && Elements != null && i < Elements.Length; i++)
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
