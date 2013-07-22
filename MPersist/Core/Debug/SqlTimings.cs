using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using MPersist.Core.Data;

namespace MPersist.Core.Debug
{
    public class SqlTimings<SqlTiming> : BindingList<SqlTiming>
    {
        private static Logger Log = Logger.GetInstance(typeof(SqlTimings<SqlTiming>));

        #region Fields

        private bool mIsSorted_;
        private ListSortDirection mSortDirection_ = ListSortDirection.Ascending;
        private PropertyDescriptor mSortProperty_;
        private TimeSpan mTotalExecutionTime_ = new TimeSpan();

        #endregion

        #region Properties

        public TimeSpan TotalExecutionTime { get { return mTotalExecutionTime_; } }

        #endregion

        #region Constructors

        public SqlTimings()
        {
        }

        public SqlTimings(IList<SqlTiming> list) : base(list)
        {
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public new void Add(SqlTiming sqlTiming)
        {
            Items.Add(sqlTiming);

            TimeSpan time = (TimeSpan)typeof(SqlTiming).InvokeMember("ExecutionTime", BindingFlags.GetProperty, null, sqlTiming, new Object[] { });

            mTotalExecutionTime_ = mTotalExecutionTime_.Add(time);
        }

        #endregion

        #region Inherited Methods

        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        protected override bool IsSortedCore
        {
            get { return mIsSorted_; }
        }

        protected override ListSortDirection SortDirectionCore
        {
            get { return mSortDirection_; }
        }

        protected override PropertyDescriptor SortPropertyCore
        {
            get { return mSortProperty_; }
        }

        protected override void RemoveSortCore()
        {
            mSortDirection_ = ListSortDirection.Ascending;
            mSortProperty_ = null;
        }

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            mSortProperty_ = prop;
            mSortDirection_ = direction;

            List<StoredData> list = Items as List<StoredData>;
            if (list == null) return;

            list.Sort(Compare);

            mIsSorted_ = true;
            //fire an event that the list has been changed.
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        private int Compare(StoredData lhs, StoredData rhs)
        {
            var result = OnComparison(lhs, rhs);
            //invert if descending
            if (mSortDirection_ == ListSortDirection.Descending)
                result = -result;
            return result;
        }

        private int OnComparison(StoredData lhs, StoredData rhs)
        {
            object lhsValue = lhs == null ? null : mSortProperty_.GetValue(lhs);
            object rhsValue = rhs == null ? null : mSortProperty_.GetValue(rhs);
            if (lhsValue == null)
            {
                return (rhsValue == null) ? 0 : -1; //nulls are equal
            }
            if (rhsValue == null)
            {
                return 1; //first has value, second doesn't
            }
            if (lhsValue is IComparable)
            {
                return ((IComparable)lhsValue).CompareTo(rhsValue);
            }
            if (lhsValue.Equals(rhsValue))
            {
                return 0; //both are the same
            }
            //not comparable, compare ToString
            return lhsValue.ToString().CompareTo(rhsValue.ToString());
        }

        #endregion
    }
}
