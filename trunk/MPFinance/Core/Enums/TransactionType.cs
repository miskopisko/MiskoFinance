using MPersist.Core.Enums;
using System;

namespace MPFinance.Resources.Enums
{
    public class TransactionType : AbstractEnum
    {
        #region Variable Declarations

        private static readonly TransactionType mNULL_ = new TransactionType(-1, "", "");
        private static readonly TransactionType mCredit_ = new TransactionType(0, "CR", "Credit");
        private static readonly TransactionType mDebit_ = new TransactionType(1, "DR", "Debit");

        private static readonly TransactionType[] mElements_ = new[]
		{
		    mNULL_, mCredit_, mDebit_
		};

        #endregion

        #region Parameters

        public static TransactionType[] Elements { get { return mElements_; } }
        public static TransactionType NULL { get { return mNULL_; } }
        public static TransactionType Credit { get { return mCredit_; } }
        public static TransactionType Debit { get { return mDebit_; } }

        #endregion

        protected TransactionType(Int64 value, String code, String description) : base(value, code, description)
        {
        }

        public static TransactionType GetElement(long index)
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

        public static TransactionType GetElement(String descriptionCode)
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
