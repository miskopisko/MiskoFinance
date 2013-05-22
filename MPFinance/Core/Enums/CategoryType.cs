using MPersist.Core.Enums;
using System;

namespace MPersist.Resources.Enums
{
    public class CategoryType : AbstractEnum
    {
        #region Variable Declarations

        private static readonly CategoryType mNULL_ = new CategoryType(-1, "", "");
        private static readonly CategoryType mIncome_ = new CategoryType(0, "", "Income");
        private static readonly CategoryType mExpense_ = new CategoryType(1, "", "Expense");

        private static readonly CategoryType[] mElements_ = new[]
		{
		    mNULL_, mIncome_, mExpense_
		};

        #endregion

        #region Parameters

        public static CategoryType[] Elements { get { return mElements_; } }
        public static CategoryType NULL { get { return mNULL_; } }
        public static CategoryType Income { get { return mIncome_; } }
        public static CategoryType Expense { get { return mExpense_; } }

        #endregion

        protected CategoryType(Int64 value, String code, String description): base(value, code, description)
        {
        }

        public static CategoryType GetElement(long index)
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

        public static CategoryType GetElement(String descriptionCode)
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
