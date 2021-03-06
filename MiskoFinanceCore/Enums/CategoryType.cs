using System;
using MiskoPersist.Enums;

namespace MiskoFinanceCore.Enums
{
	public class CategoryType : MiskoEnum
    {
        #region Fields

        private static readonly CategoryType mNULL_ = new CategoryType(-1, "", "");
        private static readonly CategoryType mIncome_ = new CategoryType(0, "I", "Income");
        private static readonly CategoryType mExpense_ = new CategoryType(1, "E", "Expense");
        private static readonly CategoryType mTransfer_ = new CategoryType(2, "T", "Transfer");
        private static readonly CategoryType mOneTime_ = new CategoryType(3, "O", "One Time");

        private static readonly CategoryType[] mElements_ = new[]
		{
		    mNULL_, mIncome_, mExpense_, mTransfer_, mOneTime_
		};

        #endregion

        #region Parameters

        public static CategoryType[] Elements { get { return mElements_; } }
        public static CategoryType NULL { get { return mNULL_; } }
        public static CategoryType Income { get { return mIncome_; } }
        public static CategoryType Expense { get { return mExpense_; } }
        public static CategoryType Transfer { get { return mTransfer_; } }
        public static CategoryType OneTime { get { return mOneTime_; } }

        #endregion
        
        #region Constructors

        public CategoryType()
        {
        }

        public CategoryType(Int64 value, String code, String description)
        	: base(value, code, description)
        {
        }
        
        #endregion
    }
}
