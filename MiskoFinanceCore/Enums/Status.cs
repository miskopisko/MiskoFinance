using System;
using MiskoPersist.Enums;

namespace MiskoFinanceCore.Enums
{
	public class Status : MiskoEnum
    {
        #region Fields

        private static readonly Status mNULL_ = new Status(-1, "", "");
        private static readonly Status mActive_ = new Status(0, "A", "Active");
        private static readonly Status mInactive_ = new Status(1, "I", "Inactive");

        private static readonly Status[] mElements_ = new[]
		{
		    mNULL_, mActive_, mInactive_
		};

        private static readonly Status[] mNonNullElements_ = new[]
		{
		    mActive_, mInactive_
		};

        #endregion

        #region Parameters

        public static Status[] Elements { get { return mElements_; } }
        public static Status[] NonNullElements { get { return mNonNullElements_; } }
        public static Status NULL { get { return mNULL_; } }
        public static Status Active { get { return mActive_; } }
        public static Status Inactive { get { return mInactive_; } }

        #endregion

        #region Constructors

        public Status()
        {
        }

        public Status(Int64 value, String code, String description) : base(value, code, description)
        {
        }

        #endregion

        #region Helpers

        public static Status GetElement(long index)
        {
            for (Int32 i = 0; Elements != null && i < Elements.Length; i++)
            {
                if(Elements[i].Value == index)
                {
                    return Elements[i];
                }
            }

            return null;
        }

        public static Status GetElement(String descriptionCode)
        {
            for (Int32 i = 0; descriptionCode != null && Elements != null && i < Elements.Length; i++)
            {
                if(Elements[i].Description.ToLower().Equals(descriptionCode.ToLower()) || Elements[i].Code.ToLower().Equals(descriptionCode.ToLower()))
                {
                    return Elements[i];
                }
            }

            return null;
        }

        #endregion
    }
}