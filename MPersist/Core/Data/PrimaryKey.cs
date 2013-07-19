using System;

namespace MPersist.Core.Data
{
    public class PrimaryKey : IComparable<PrimaryKey>, IComparable<Int64>, IEquatable<PrimaryKey>, IEquatable<Int64>
    {
        private static Logger Log = Logger.GetInstance(typeof(PrimaryKey));

        #region Fields

        private Int64 mValue_;

        #endregion

        #region Properties

        public Int64 Value { get { return mValue_; } set { mValue_ = value; } }
        public Boolean IsSet { get { return mValue_ != 0; } }

        #endregion

        #region Constructors

        public PrimaryKey()
        {
            mValue_ = 0;
        }

        public PrimaryKey(Int64 value)
        {
            mValue_ = value;
        }

        public PrimaryKey(String s)
        {
            if (!String.IsNullOrEmpty(s))
            {
                mValue_ = Convert.ToInt64(s);
            }
            else
            {
                mValue_ = 0;
            }
        }

        #endregion

        #region Operators

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
            if (object.ReferenceEquals(left, null))
            {
                return false;
            }

            return !(left == right);
        }

        public static Boolean operator >(PrimaryKey left, PrimaryKey right)
        {
            if (object.ReferenceEquals(left, null))
            {
                return false;
            }

            return left.CompareTo(right.Value) > 0;
        }

        public static Boolean operator >(PrimaryKey left, Int64 right)
        {
            if (object.ReferenceEquals(left, null))
            {
                return false;
            }

            return left.CompareTo(right) > 0;
        }

        public static Boolean operator <(PrimaryKey left, PrimaryKey right)
        {
            if (object.ReferenceEquals(left, null))
            {
                return false;
            }

            return left.CompareTo(right.Value) < 0;
        }

        public static Boolean operator <(PrimaryKey left, Int64 right)
        {
            if (object.ReferenceEquals(left, null))
            {
                return false;
            }

            return left.CompareTo(right) < 0;
        }

        public static Boolean operator >=(PrimaryKey left, PrimaryKey right)
        {
            if (object.ReferenceEquals(left, null))
            {
                return false;
            }

            return left.CompareTo(right.Value) >= 0;
        }

        public static Boolean operator >=(PrimaryKey left, Int64 right)
        {
            if (object.ReferenceEquals(left, null))
            {
                return false;
            }

            return left.CompareTo(right) >= 0;
        }

        public static Boolean operator <=(PrimaryKey left, PrimaryKey right)
        {
            if (object.ReferenceEquals(left, null))
            {
                return false;
            }

            return left.CompareTo(right.Value) <= 0;
        }

        public static Boolean operator <=(PrimaryKey left, Int64 right)
        {
            if (object.ReferenceEquals(left, null))
            {
                return false;
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
            return mValue_.GetHashCode();
        }

        public override string ToString()
        {
            return mValue_.ToString();
        }

        #endregion

        #region IComparable<PrimaryKey> Members

        public int CompareTo(PrimaryKey other)
        {
            return mValue_.CompareTo(other.Value);
        }

        #endregion

        #region IComparable<long> Members

        public int CompareTo(long other)
        {
            return mValue_.CompareTo(other);
        }

        #endregion

        #region IEquatable<PrimaryKey> Members

        public bool Equals(PrimaryKey other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }

            return mValue_ == other.Value;
        }

        #endregion

        #region IEquatable<long> Members

        public bool Equals(long other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }

            return mValue_ == other;
        }

        #endregion
    }
}
