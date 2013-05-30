using System;
using System.Reflection;
using MPersist.Core.Enums;
using MPersist.Core.Tools;

namespace MPersist.Core
{
    public class ErrorMessage : IComparable
    {
        private static Logger Log = Logger.GetInstance(typeof(ErrorMessage));

        #region Variable Declarations

        private readonly String mClass_;
        private readonly String mMethod_;
        private readonly Object[] mParameters_;
        private Boolean mConfirmed_;
        private ErrorLevel mErrorLevel_;
        private String mErrorMessage_;

        #endregion

        #region Properties

        public String Class
        {
            get
            {
                return mClass_;
            }
        }

        public String Method
        {
            get
            {
                return mMethod_;
            }
        }

        public ErrorLevel Level
        {
            get
            {
                return mErrorLevel_;
            }
        }

        public String Message
        {
            get
            {
                return mErrorMessage_;
            }
        }

        public Boolean Confirmed
        {
            get
            {
                return mErrorLevel_.Equals(ErrorLevel.Confirmation) ? mConfirmed_ : true;
            }
            set
            {
                mConfirmed_ = value;
            }
        }

        #endregion

        #region Constructors

        public ErrorMessage(Type clazz, MethodBase method, ErrorLevel level, String message) : this(clazz, method, level, message, null)
        {
        }

        public ErrorMessage(Type clazz, MethodBase method, ErrorLevel level, String message, Object[] param)
        {
            mClass_ = clazz.Name;
            mMethod_ = method.Name;
            mErrorLevel_ = level;
            mErrorMessage_ = message;
            mParameters_ = param;
        }

        #endregion

        #region Override Methods

        public Int32 CompareTo(Object obj)
        {
            if (obj != null && obj is ErrorMessage)
            {
                return Message.CompareTo(((ErrorMessage)obj).Message);
            }

            return -1;
        }

        public override String ToString()
        {
            return Utils.ResolveTextParameters(mErrorMessage_, mParameters_);
        }

        public override Boolean Equals(Object obj)
        {
            return CompareTo(obj) == 0;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}
