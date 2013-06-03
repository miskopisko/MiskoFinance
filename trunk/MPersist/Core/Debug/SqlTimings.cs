using MPersist.Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace MPersist.Core.Debug
{
    public class SqlTimings<SqlTiming> : BindingList<SqlTiming>
    {
        private static Logger Log = Logger.GetInstance(typeof(SqlTimings<SqlTiming>));

        #region Variable Declarations

        private bool isSorted_;
        private ListSortDirection sortDirection_ = ListSortDirection.Ascending;
        private PropertyDescriptor sortProperty_;
        private TimeSpan TotalExecutionTime_ = new TimeSpan();

        #endregion

        #region Properties

        public TimeSpan TotalExecutionTime { get { return TotalExecutionTime_; } }

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

            TotalExecutionTime_ = TotalExecutionTime_.Add(time);
        }

        #endregion

        #region Inherited Methods

        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        protected override bool IsSortedCore
        {
            get { return isSorted_; }
        }

        protected override ListSortDirection SortDirectionCore
        {
            get { return sortDirection_; }
        }

        protected override PropertyDescriptor SortPropertyCore
        {
            get { return sortProperty_; }
        }

        protected override void RemoveSortCore()
        {
            sortDirection_ = ListSortDirection.Ascending;
            sortProperty_ = null;
        }

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            sortProperty_ = prop;
            sortDirection_ = direction;

            List<AbstractStoredData> list = Items as List<AbstractStoredData>;
            if (list == null) return;

            list.Sort(Compare);

            isSorted_ = true;
            //fire an event that the list has been changed.
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        private int Compare(AbstractStoredData lhs, AbstractStoredData rhs)
        {
            var result = OnComparison(lhs, rhs);
            //invert if descending
            if (sortDirection_ == ListSortDirection.Descending)
                result = -result;
            return result;
        }

        private int OnComparison(AbstractStoredData lhs, AbstractStoredData rhs)
        {
            object lhsValue = lhs == null ? null : sortProperty_.GetValue(lhs);
            object rhsValue = rhs == null ? null : sortProperty_.GetValue(rhs);
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
