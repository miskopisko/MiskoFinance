using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using Newtonsoft.Json;
using MiskoPersist.Data;
using MiskoPersist.Enums;
using MiskoPersist.Tools;

namespace MiskoPersist.Core
{
	[JsonObjectAttribute(MemberSerialization.OptOut)]
    public class ErrorMessage : AbstractViewedData
    {
        private static Logger Log = Logger.GetInstance(typeof(ErrorMessage));

        #region Fields

        private String mClass_;
        private String mMethod_;
        private List<String> mParameters_;
        private ErrorLevel mErrorLevel_;
        private String mErrorMessage_;
        private Boolean? mConfirmed_ = false;

        #endregion

        #region Properties

        public String Class { get { return mClass_; } set { mClass_ = value; } }
        public String Method { get { return mMethod_; } set { mMethod_ = value; } }
        public List<String> Parameters { get { return mParameters_; } set { mParameters_ = value; } }
        public ErrorLevel Level { get { return mErrorLevel_; } set { mErrorLevel_ = value; } }
        public String Message { get { return ToString(); } set { mErrorMessage_ = value; } }
        [JsonIgnore]
        public Boolean? Confirmed { get  { return mErrorLevel_.Equals(ErrorLevel.Confirmation) ? mConfirmed_ : null; } set { mConfirmed_ = value; } }

        #endregion

        #region Constructors

        public ErrorMessage()
        {
        }

        public ErrorMessage(Exception e) : this(e.TargetSite.DeclaringType, e.TargetSite, ErrorLevel.Error, e.Message, null)
        {
        }

        public ErrorMessage(Type clazz, MethodBase method, ErrorLevel level, String message) : this(clazz, method, level, message, null)
        {
        }

        public ErrorMessage(Type clazz, MethodBase method, ErrorLevel level, String message, String[] parameters)
        {
            mClass_ = clazz.Name;
            mMethod_ = method.Name;
            mErrorLevel_ = level;
            mErrorMessage_ = message;
            mParameters_ = parameters != null ? new List<String>(parameters) : null;
        }

        #endregion

        #region Override Methods

        public override string ToString()
        {
            return Utils.ResolveTextParameters(mErrorMessage_, mParameters_ != null ? mParameters_.ToArray() : null);
        }

        public override Boolean Equals(Object obj)
        {
            if(obj is ErrorMessage)
            {
                return string.Compare(ToString(), ((ErrorMessage)obj).ToString(), StringComparison.CurrentCulture) == 0;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}
