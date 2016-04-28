using System;
using MiskoPersist.Enums;

namespace MiskoFinanceCore.Enums
{
	public class DrCr : MiskoEnum
	{
		#region Fields

		private static readonly DrCr mNULL_ = new DrCr(-1, "", "");
		private static readonly DrCr mCredit_ = new DrCr(0, "CR", "Credit");
		private static readonly DrCr mDebit_ = new DrCr(1, "DR", "Debit");

		private static readonly DrCr[] mElements_ = new[]
		{
			mNULL_, mCredit_, mDebit_
		};

		#endregion

		#region Parameters

		public static DrCr[] Elements { get { return mElements_; } }
		public static DrCr NULL { get { return mNULL_; } }
		public static DrCr Credit { get { return mCredit_; } }
		public static DrCr Debit { get { return mDebit_; } }

		#endregion

		public DrCr()
		{
		}

		public DrCr(Int64 value, String code, String description) : base(value, code, description)
		{
		}

		public int Sign()
		{
			return this == Credit ? 1 : -1;
		}

		public static DrCr GetElement(long index)
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

		public static DrCr GetElement(String descriptionCode)
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
