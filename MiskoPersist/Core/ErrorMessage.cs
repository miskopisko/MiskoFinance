using System;
using System.Collections.Generic;
using System.Reflection;
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

        private String mErrorMessage_;
        private Boolean? mConfirmed_ = false;

        #endregion

        #region Properties

		public String Class 
		{
			get;
			set;
		}
		
		public String Method 
		{
			get;
			set;
		}
		
		public List<String> Parameters 
		{
			get;
			set;
		}
		
		public ErrorLevel ErrorLevel 
		{
			get;
			set;
		}
		
        public String Message 
        { 
        	get 
        	{ 
        		return ToString(); 
        	} 
        	set 
        	{ 
        		mErrorMessage_ = value;
        	} 
        }
        
        [JsonIgnore]
        public Boolean? Confirmed 
        { 
        	get  
        	{ 
        		return ErrorLevel.Equals(ErrorLevel.Confirmation) ? mConfirmed_ : null; 
        	} 
        	set
        	{ 
        		mConfirmed_ = value; 
        	} 
        }

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
            Class = clazz.Name;
            Method = method.Name;
            ErrorLevel = level;
            mErrorMessage_ = message;
            Parameters = parameters != null ? new List<String>(parameters) : null;
        }

        #endregion

        #region Override Methods

        public override string ToString()
        {
            return Utils.ResolveTextParameters(mErrorMessage_, Parameters != null ? Parameters.ToArray() : null);
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
