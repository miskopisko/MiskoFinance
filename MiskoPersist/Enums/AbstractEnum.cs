using System;
using Newtonsoft.Json;

namespace MiskoPersist.Enums
{
    [Serializable]
    [JsonObjectAttribute(MemberSerialization.OptOut)]
    public abstract class AbstractEnum : IComparable
    {
        #region Properties
		
        public Int64 Value { get; set; }
        [JsonIgnore]
        public String Code { get; set; }
        [JsonIgnore]
        public String Description { get; set; }
        [JsonIgnore]
        public bool IsSet { get { return Value != -1; } }
        [JsonIgnore]
        public bool IsNotSet { get { return !IsSet; } }

        #endregion

        #region Constructors

        protected AbstractEnum()
        {
        }

        protected AbstractEnum(Int64 v, String code, String description)
        {
            Value = v;
            Code = code;
            Description = description;
        }

        #endregion

        public override String ToString()
        {
            return Description;
        }

        public bool Equals(String codeOrDesc)
        {
			return codeOrDesc != null && Description.Equals(codeOrDesc) || Code.Equals(codeOrDesc);
        }

        public virtual int CompareTo(object e)
        {
            if (e is AbstractEnum)
            {
                if (e == null || ((AbstractEnum)e).Code == null || ((AbstractEnum)e).Code.Trim().Length == 0)
                {
                    return 1;
                }
				return string.Compare(Code, ((AbstractEnum)e).Code, StringComparison.Ordinal);
            }
            return -1;
        }
    }
}
