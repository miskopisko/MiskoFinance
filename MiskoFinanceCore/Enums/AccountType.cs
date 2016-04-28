using System;
using MiskoPersist.Enums;

namespace MiskoFinanceCore.Enums
{
	public class AccountType : MiskoEnum
    {
        #region Fields

        private static readonly AccountType mNULL_ = new AccountType(-1, "", "");
        private static readonly AccountType mChecking_ = new AccountType(0, "CHECKING", "Checking");
        private static readonly AccountType mSavings_ = new AccountType(1, "SAVINGS", "Savings");
        private static readonly AccountType mMoneyMarket_ = new AccountType(2, "MONEYMRKT", "Money Market");
        private static readonly AccountType mLineOfCredit_ = new AccountType(3, "CREDITLINE", "Line of Credit");
        private static readonly AccountType mCreditCard_ = new AccountType(4, "CREDITCARD", "Credit Card");

        private static readonly AccountType[] mElements_ = new[]
		{
		    mNULL_, mChecking_, mSavings_, mMoneyMarket_, mLineOfCredit_, mCreditCard_
		};

        #endregion

        #region Parameters

        public static AccountType[] Elements { get { return mElements_; } }
        public static AccountType NULL { get { return mNULL_; } }
        public static AccountType Checking { get { return mChecking_; } }
        public static AccountType Savings { get { return mSavings_; } }
        public static AccountType MoneyMarket { get { return mMoneyMarket_; } }
        public static AccountType LineOfCredit { get { return mLineOfCredit_; } }
        public static AccountType CreditCard { get { return mCreditCard_; } }

        #endregion

        public AccountType()
        {
        }

        public AccountType(Int64 value, String code, String description) : base(value, code, description)
        {
        }

        public static AccountType GetElement(long index)
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

        public static AccountType GetElement(String descriptionCode)
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
    }
}
