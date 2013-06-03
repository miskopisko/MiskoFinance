using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace MPersist.Core.Data
{
    public class AbstractViewedDataList<AbstractViewedData> : BindingList<AbstractViewedData>
    {
        private static Logger Log = Logger.GetInstance(typeof(AbstractViewedDataList<AbstractViewedData>));

        #region Variable declarations

        private bool isSorted_;
        private ListSortDirection sortDirection_ = ListSortDirection.Ascending;
        private PropertyDescriptor sortProperty_;

        #endregion

        #region Properties

        

        #endregion

        #region Constructors

        public AbstractViewedDataList()
        {
        }

        public AbstractViewedDataList(IList<AbstractViewedData> list) : base(list)
        {
        }

        #endregion

        #region Public Methods

        public void Set(Session session, Persistence persistence, Page page)
        {
            Int32 noRows = page.PageNo != 0 ? session.RowPerPage : 0;
            Int32 pageNo = page.PageNo != 0 ? page.PageNo : 1;            

            int rowsFetched = 0;
            for (int i = 0; i < (pageNo - 1) * noRows && persistence.HasNext; i++)
            {
                persistence.Next();
                rowsFetched++;
            }

            for (int i = 0; (noRows == 0 || i < noRows) && persistence.HasNext; i++)
            {
                ConstructorInfo ctor = typeof(AbstractViewedData).GetConstructor(new[] { typeof(Session), typeof(Persistence) });
                AbstractViewedData o = (AbstractViewedData)ctor.Invoke(new object[] { session, persistence });
                Add(o);
                rowsFetched++;
            }

            if(page.IncludeRecordCount)
            {
                page.TotalRowCount = persistence.RecordCount;
                page.TotalPageCount = page.PageNo == 0 ? 1 : page.PageCount(session.RowPerPage);
                page.RowsFetchedSoFar = rowsFetched;
                page.PageNo = pageNo;
            }
        }

        public void FetchAll(Session session)
        {
            Persistence persistence = Persistence.GetInstance(session);
            persistence.ExecuteQuery("SELECT * FROM " + typeof(AbstractViewedData).Name);
            Set(session, persistence, new Page());
            persistence.Close();
            persistence = null;
        }

        public void AddRange(AbstractViewedDataList<AbstractViewedData> list)
        {
            foreach (AbstractViewedData item in list)
            {
                Items.Add(item);
            }
        }

        #endregion

        #region Private Methods



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

            List<AbstractViewedData> list = Items as List<AbstractViewedData>;
            if (list == null) return;

            list.Sort(Compare);

            isSorted_ = true;
            //fire an event that the list has been changed.
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        private int Compare(AbstractViewedData lhs, AbstractViewedData rhs)
        {
            var result = OnComparison(lhs, rhs);
            //invert if descending
            if (sortDirection_ == ListSortDirection.Descending)
                result = -result;
            return result;
        }

        private int OnComparison(AbstractViewedData lhs, AbstractViewedData rhs)
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