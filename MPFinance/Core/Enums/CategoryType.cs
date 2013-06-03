using MPersist.Core.Enums;
using System;

namespace MPFinance.Core.Enums
{
    public class CategoryType : AbstractEnum
    {
        #region Variable Declarations

        private static readonly CategoryType mNULL_ = new CategoryType(-1, "", "");
        private static readonly CategoryType mIncome_ = new CategoryType(0, "I", "Income");
        private static readonly CategoryType mExpense_ = new CategoryType(1, "E", "Expense");
        private static readonly CategoryType mTransfer_ = new CategoryType(2, "T", "Transfer");

        private static readonly CategoryType[] mElements_ = new[]
		{
		    mNULL_, mIncome_, mExpense_, mTransfer_
		};

        #endregion

        #region Parameters

        public static CategoryType[] Elements { get { return mElements_; } }
        public static CategoryType NULL { get { return mNULL_; } }
        public static CategoryType Income { get { return mIncome_; } }
        public static CategoryType Expense { get { return mExpense_; } }
        public static CategoryType Transfer { get { return mTransfer_; } }

        #endregion

        protected CategoryType()
        {
        }

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
