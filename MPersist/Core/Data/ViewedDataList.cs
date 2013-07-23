using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using MPersist.Core.Tools;

namespace MPersist.Core.Data
{
    public class ViewedDataList<ViewedData> : BindingList<ViewedData>
    {
        private static Logger Log = Logger.GetInstance(typeof(ViewedDataList<ViewedData>));

        #region Fields

        private bool mIsSorted_;
        private ListSortDirection mSortDirection_ = ListSortDirection.Ascending;
        private PropertyDescriptor mSortProperty_;

        #endregion

        #region Properties

        

        #endregion

        #region Constructors

        public ViewedDataList()
        {
        }

        public ViewedDataList(IList<ViewedData> list) : base(list)
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
                ConstructorInfo ctor = typeof(ViewedData).GetConstructor(new[] { typeof(Session), typeof(Persistence) });
                Add((ViewedData)ctor.Invoke(new object[] { session, persistence }));
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
            persistence.ExecuteQuery("SELECT * FROM " + typeof(ViewedData).Name);
            Set(session, persistence, new Page());
            persistence.Close();
            persistence = null;
        }

        public void AddRange(ViewedDataList<ViewedData> list)
        {
            foreach (ViewedData item in list)
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

            List<ViewedData> list = Items as List<ViewedData>;
            if (list == null) return;

            list.Sort(Compare);

            mIsSorted_ = true;
            //fire an event that the list has been changed.
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        private int Compare(ViewedData lhs, ViewedData rhs)
        {
            var result = OnComparison(lhs, rhs);
            //invert if descending
            if (mSortDirection_ == ListSortDirection.Descending)
            {
                result = -result;
            }
                
            return result;
        }

        private int OnComparison(ViewedData lhs, ViewedData rhs)
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