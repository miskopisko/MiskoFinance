using System;
using Newtonsoft.Json;
using MiskoPersist.Core;

namespace MiskoPersist.Data
{
	[JsonObjectAttribute(MemberSerialization.OptOut)]
    public class PrimaryKey : AbstractData, IComparable<PrimaryKey>, IComparable<Int64>, IEquatable<PrimaryKey>, IEquatable<Int64>
    {
        private static Logger Log = Logger.GetInstance(typeof(PrimaryKey));

        #region Fields


        #endregion

        #region Properties

		public Int64 Value { get; set; }
        [JsonIgnore]
        public Boolean IsSet { get { return Value != 0; } }
        [JsonIgnore]
        public Boolean IsNotSet { get { return !IsSet; } }

        #endregion

        #region Constructors

        public PrimaryKey()
        {
            Value = 0;
        }

        public PrimaryKey(Int64 value)
        {
            Value = value;
        }

        public PrimaryKey(String s)
        {
            if (!String.IsNullOrEmpty(s))
            {
                Value = Convert.ToInt64(s);
            }
            else
            {
                Value = 0;
            }
        }

        #endregion

        #region Operators

        public static PrimaryKey operator +(PrimaryKey left, Int64 right)
        {
            if (object.ReferenceEquals(left, null)) return new PrimaryKey() + right;
            return new PrimaryKey(left.Value + right);
        }

        public static PrimaryKey operator -(PrimaryKey value)
        {
            return new PrimaryKey(-value.Value);
        }

        public static Boolean operator ==(PrimaryKey left, Int64 right)
        {
            if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null)) return true;
            else if (object.ReferenceEquals(left, null) && !object.ReferenceEquals(right, null)) return false;
            else if (!object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null)) return false;
            return left.Value.Equals(right);
        }

        public static Boolean operator !=(PrimaryKey left, Int64 right)
        {
            return !(left == right);
        }

        public static Boolean operator ==(PrimaryKey left, PrimaryKey right)
        {
            if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null)) return true;
            else if (object.ReferenceEquals(left, null) && !object.ReferenceEquals(right, null)) return false;
            else if (!object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null)) return false;
            return left.Value.Equals(right.Value);
        }

        public static Boolean operator !=(PrimaryKey left, PrimaryKey right)
        {
            return !(left == right);
        }

        public static Boolean operator >(PrimaryKey left, PrimaryKey right)
        {
            if (object.ReferenceEquals(left, null))
            {
                left = new PrimaryKey(0);
            }

            return left.CompareTo(right.Value) > 0;
        }

        public static Boolean operator >(PrimaryKey left, Int64 right)
        {
            if (object.ReferenceEquals(left, null))
            {
                left = new PrimaryKey(0);
            }

            return left.CompareTo(right) > 0;
        }

        public static Boolean operator <(PrimaryKey left, PrimaryKey right)
        {
            if (object.ReferenceEquals(left, null))
            {
                left = new PrimaryKey(0);
            }

            return left.CompareTo(right.Value) < 0;
        }

        public static Boolean operator <(PrimaryKey left, Int64 right)
        {
            if (object.ReferenceEquals(left, null))
            {
                left = new PrimaryKey(0);
            }

            return left.CompareTo(right) < 0;
        }

        public static Boolean operator >=(PrimaryKey left, PrimaryKey right)
        {
            if (object.ReferenceEquals(left, null))
            {
                left = new PrimaryKey(0);
            }

            return left.CompareTo(right.Value) >= 0;
        }

        public static Boolean operator >=(PrimaryKey left, Int64 right)
        {
            if (object.ReferenceEquals(left, null))
            {
                left = new PrimaryKey(0);
            }

            return left.CompareTo(right) >= 0;
        }

        public static Boolean operator <=(PrimaryKey left, PrimaryKey right)
        {
            if (object.ReferenceEquals(left, null))
            {
                left = new PrimaryKey(0);
            }

            return left.CompareTo(right.Value) <= 0;
        }

        public static Boolean operator <=(PrimaryKey left, Int64 right)
        {
            if (object.ReferenceEquals(left, null))
            {
                left = new PrimaryKey(0);
            }

            return left.CompareTo(right) <= 0;
        }

        #endregion

        #region Override Methods

        public override bool Equals(object obj)
        {
            if (obj is PrimaryKey)
            {
                return Equals((PrimaryKey)obj);
            }
            else if (obj is Int64)
            {
                return Equals((Int64)obj);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        #endregion

        #region IComparable<PrimaryKey> Members

        public int CompareTo(PrimaryKey other)
        {
            return Value.CompareTo(other.Value);
        }

        #endregion

        #region IComparable<long> Members

        public int CompareTo(long other)
        {
            return Value.CompareTo(other);
        }

        #endregion

        #region IEquatable<PrimaryKey> Members

        public bool Equals(PrimaryKey other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }

            return Value == other.Value;
        }

        #endregion

        #region IEquatable<long> Members

        public bool Equals(long other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }

            return Value == other;
        }

        #endregion
    }
}
