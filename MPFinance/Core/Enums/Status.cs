using MPersist.Core.Enums;
using System;

namespace MPFinance.Core.Enums
{
    public class Status : AbstractEnum
    {
        #region Variable Declarations

        private static readonly Status mNULL_ = new Status(-1, "", "");
        private static readonly Status mActive_ = new Status(0, "", "Active");
        private static readonly Status mInactive_ = new Status(1, "", "Inactive");

        private static readonly Status[] mElements_ = new[]
		{
		    mNULL_, mActive_, mInactive_
		};

        #endregion

        #region Parameters

        public static Status[] Elements { get { return mElements_; } }
        public static Status NULL { get { return mNULL_; } }
        public static Status Active { get { return mActive_; } }
        public static Status Inactive { get { return mInactive_; } }

        #endregion

        protected Status(Int64 value, String code, String description) : base(value, code, description)
        {
        }

        public static Status GetElement(long index)
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

        public static Status GetElement(String descriptionCode)
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
