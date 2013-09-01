using System;
using System.Reflection;
using MPersist.Enums;
using MPersist.Tools;

namespace MPersist.Core
{
    public class ErrorMessage : IComparable
    {
        private static Logger Log = Logger.GetInstance(typeof(ErrorMessage));

        #region Fields

        private readonly String mClass_;
        private readonly String mMethod_;
        private readonly Object[] mParameters_;
        private Boolean mConfirmed_;
        private ErrorLevel mErrorLevel_;
        private String mErrorMessage_;

        #endregion

        #region Properties

        public String Class { get { return mClass_; } }
        public String Method { get { return mMethod_; } }
        public ErrorLevel Level { get { return mErrorLevel_; } }
        public String Message { get { return ToString(); } }
        public Boolean Confirmed { get  { return mErrorLevel_.Equals(ErrorLevel.Confirmation) ? mConfirmed_ : true; } set { mConfirmed_ = value; } }

        #endregion

        #region Constructors

        public ErrorMessage(Exception e) : this(e.TargetSite.DeclaringType, e.TargetSite, ErrorLevel.Error, e.Message, null)
        {
        }

        public ErrorMessage(Type clazz, MethodBase method, ErrorLevel level, String message) : this(clazz, method, level, message, null)
        {
        }

        public ErrorMessage(Type clazz, MethodBase method, ErrorLevel level, String message, Object[] parameters)
        {
            mClass_ = clazz.Name;
            mMethod_ = method.Name;
            mErrorLevel_ = level;
            mErrorMessage_ = message;
            mParameters_ = parameters;
        }

        #endregion

        #region Public Methods

        public Int32 CompareTo(Object obj)
        {
            if (obj != null && obj is ErrorMessage)
            {
                return Message.CompareTo(((ErrorMessage)obj).Message);
            }

            return -1;
        }

        #endregion

        #region Override Methods

        public override string ToString()
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
