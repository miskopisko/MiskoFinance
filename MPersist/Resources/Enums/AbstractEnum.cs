using System;

namespace MPersist.Resources.Enums
{
    [Serializable]
    public abstract class AbstractEnum : IComparable
    {
        #region Properties

        public Int64 Value { get; set; }
        public String Code { get; set; }
        public String Description { get; set; }

        public bool IsSet { get { return Value != -1; } }

        #endregion

        #region Constructors

        public AbstractEnum()
        {
        }

        public AbstractEnum(Int64 v, String code, String description)
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
            return codeOrDesc != null ? Description.Equals(codeOrDesc) || Code.Equals(codeOrDesc) : false;
        }

        public int CompareTo(object e)
        {
            if(e is AbstractEnum)
            {
                if (e == null || ((AbstractEnum)e).Code == null || ((AbstractEnum)e).Code.Trim().Length == 0)
                {
                    return 1;
                }
                return Code.CompareTo(((AbstractEnum)e).Code);
            }
            return -1;
        }
    }
}
