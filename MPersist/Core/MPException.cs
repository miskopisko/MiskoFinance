using System;
using System.Reflection;

namespace MPersist.Core
{
    public class MPException : Exception
    {
        private static Logger Log = Logger.GetInstance(typeof(MPException));

        #region Variable Declarations

        private readonly Type mClass_;
        private readonly MethodBase mMethod_;
        private readonly ErrorMessage mErrorMessage_;

        #endregion

        #region Properties

        public Type Class { get { return mClass_; } }

        public MethodBase Method { get { return mMethod_; } }

        public ErrorMessage ErrorMessage { get { return mErrorMessage_; } }

        #endregion

        public MPException(ErrorMessage message) : base(message != null ? message.ToString() : "")
        {
            mErrorMessage_ = message;
        }

        public MPException(Type clazz, MethodBase method, String message) : this(clazz, method, message, null)
        {
        }

        public MPException(Type clazz, MethodBase method, String message, Exception inner) : base(message, inner)
        {
            mClass_ = clazz;
            mMethod_ = method;
        }
    }
}
