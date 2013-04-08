using System;

namespace MPersist.Resources.Enums
{
    public class ErrorLevel : AbstractEnum
    {
        #region Variable Declarations

        private static readonly ErrorLevel mNULL_ = new ErrorLevel(-1, "", "");
        private static readonly ErrorLevel mCritical_ = new ErrorLevel(-1, "", "Critical");
        private static readonly ErrorLevel mWarning_ = new ErrorLevel(0, "", "Warning");
        private static readonly ErrorLevel mTechnical_ = new ErrorLevel(1, "", "Technical");
        private static readonly ErrorLevel mTimeout_ = new ErrorLevel(2, "", "Timeout");

        private static readonly ErrorLevel[] mElements_ = new[]
		{
		    mNULL_, mCritical_, mWarning_,mTechnical_, mTimeout_
		};

        #endregion

        #region Parameters

        public static ErrorLevel[] Elements { get { return mElements_; } }
        public static ErrorLevel NULL { get { return mNULL_; } }
        public static ErrorLevel Critical { get { return mCritical_; } }
        public static ErrorLevel Warning { get { return mWarning_; } }
        public static ErrorLevel Technical { get { return mTechnical_; } }
        public static ErrorLevel Timeout { get { return mTimeout_; } }

        #endregion

        protected ErrorLevel(Int64 value, String code, String description) : base(value, code, description)
        {
        }

        public static ErrorLevel GetElement(long index)
        {
            for (int i = 0; mElements_ != null && i < mElements_.Length; i++)
            {
                if (mElements_[i].Value == index)
                {
                    return mElements_[i];
                }
            }

            return null;
        }

        public static ErrorLevel GetElement(String descriptionCode)
        {
            for (int i = 0; descriptionCode != null && mElements_ != null && i < mElements_.Length; i++)
            {
                if (mElements_[i].Description.ToLower().Equals(descriptionCode.ToLower()) || mElements_[i].Code.ToLower().Equals(descriptionCode.ToLower()))
                {
                    return mElements_[i];
                }
            }

            return null;
        }
    }
}
