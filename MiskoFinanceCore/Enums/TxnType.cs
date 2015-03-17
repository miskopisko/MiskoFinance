using System;
using MiskoPersist.Enums;

namespace MiskoFinanceCore.Enums
{
    public class TxnType : AbstractEnum
    {
        #region Fields

        private static readonly TxnType mNULL_ = new TxnType(-1, "", "");
        private static readonly TxnType mCredit_ = new TxnType(0, "CR", "Credit");
        private static readonly TxnType mDebit_ = new TxnType(1, "DR", "Debit");
        private static readonly TxnType mTransferIn_ = new TxnType(2, "T-IN", "Transfer In");
        private static readonly TxnType mTransferOut_ = new TxnType(3, "T-OUT", "Transfer Out");

        private static readonly TxnType[] mElements_ = new[]
		{
		    mNULL_, mCredit_, mDebit_, mTransferIn_, mTransferOut_
		};

        #endregion

        #region Parameters

        public static TxnType[] Elements { get { return mElements_; } }
        public static TxnType NULL { get { return mNULL_; } }
        public static TxnType Credit { get { return mCredit_; } }
        public static TxnType Debit { get { return mDebit_; } }
        public static TxnType TransferIn { get { return mTransferIn_; } }
        public static TxnType TransferOut { get { return mTransferOut_; } }

        #endregion

        protected TxnType()
        {
        }

        protected TxnType(Int64 value, String code, String description) : base(value, code, description)
        {
        }

        public static TxnType GetElement(long index)
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

        public static TxnType GetElement(String descriptionCode)
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
