using System;
using MiskoPersist.Enums;

namespace MiskoFinanceCore.Enums
{
	public class Gender : MiskoEnum
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
        
        #region Constructors

        public Gender()
        {
        }

        public Gender(Int64 value, String code, String description) 
        	: base(value, code, description)
        {
        }
        
        #endregion
    }
}
