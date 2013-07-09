using MPersist.Core.Enums;
using System;
using System.Diagnostics;
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

        #region Constructors

        public MPException(ErrorMessage message) : base(message != null ? message.ToString() : "")
        {
            StackFrame stackframe = new StackFrame(1);
            mClass_ = stackframe.GetMethod().DeclaringType;
            mMethod_ = stackframe.GetMethod();
            mErrorMessage_ = message;
        }

        public MPException(String message) : base(message)
        {
            StackFrame stackframe = new StackFrame(1);
            mClass_ = stackframe.GetMethod().DeclaringType;
            mMethod_ = stackframe.GetMethod();
            mErrorMessage_ = new ErrorMessage(mClass_, mMethod_, ErrorLevel.Error, message, null);
        }

        public MPException(String message, Object[] parameters) : base(message)
        {
            StackFrame stackframe = new StackFrame(1);
            mClass_ = stackframe.GetMethod().DeclaringType;
            mMethod_ = stackframe.GetMethod();
            mErrorMessage_ = new ErrorMessage(mClass_, mMethod_, ErrorLevel.Error, message, parameters);
        }

        public MPException(String message, Exception inner) : base(message, inner)
        {
            StackFrame stackframe = new StackFrame(1);
            mClass_ = stackframe.GetMethod().DeclaringType;
            mMethod_ = stackframe.GetMethod();
            mErrorMessage_ = new ErrorMessage(mClass_, mMethod_, ErrorLevel.Error, message, null);
        }

        public MPException(String message, Object[] parameters, Exception inner) : base(message, inner)
        {
            StackFrame stackframe = new StackFrame(1);
            mClass_ = stackframe.GetMethod().DeclaringType;
            mMethod_ = stackframe.GetMethod();
            mErrorMessage_ = new ErrorMessage(mClass_, mMethod_, ErrorLevel.Error, message, parameters);
        }

        #endregion
    }
}
