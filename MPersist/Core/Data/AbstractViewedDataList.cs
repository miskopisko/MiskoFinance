using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace MPersist.Core.Data
{
    public class AbstractViewedDataList<AbstractViewedData> : BindingList<AbstractViewedData>
    {
        private static Logger Log = Logger.GetInstance(typeof(AbstractViewedDataList<AbstractViewedData>));

        #region Variable declarations

        private readonly Dictionary<Type, PropertyComparer<AbstractViewedData>> comparers;
        private bool isSorted;
        private ListSortDirection listSortDirection;
        private PropertyDescriptor propertyDescriptor;

        #endregion

        #region Properties

        public Type BaseType { get; set; }

        #endregion

        #region Constructors

        public AbstractViewedDataList() : base(new List<AbstractViewedData>())
        {
            this.comparers = new Dictionary<Type, PropertyComparer<AbstractViewedData>>();
        }

        public AbstractViewedDataList(IEnumerable<AbstractViewedData> enumeration): base(new List<AbstractViewedData>(enumeration))
        {
            this.comparers = new Dictionary<Type, PropertyComparer<AbstractViewedData>>();
        }

        #endregion

        #region Public Methods

        public void set(Session session, Persistence persistence, Page page)
        {
            Int32 noRows = page.PageNo != 0 ? session.RowPerPage : 0;
            Int32 pageNo = page.PageNo != 0 ? page.PageNo : 1;
            page.PageNo = pageNo;

            for (int i = 0; i < (pageNo - 1) * noRows && persistence.HasNext; i++)
            {
                persistence.Next();
            }

            for (int i = 0; (noRows == 0 || i < noRows) && persistence.HasNext; i++)
            {
                ConstructorInfo ctor = BaseType.GetConstructor(new[] { typeof(Session), typeof(Persistence) });
                Add((AbstractViewedData)ctor.Invoke(new object[] { session, persistence }));
            }

            if(page.IncludeRecordCount)
            {
                page.TotalRowCount = persistence.RecordCount;
                page.TotalPageCount = page.PageCount(session.RowPerPage);
            }
        }

        public void FetchAll(Session session)
        {
            Persistence persistence = Persistence.GetInstance(session);
            persistence.ExecuteQuery("SELECT * FROM " + BaseType.Name);
            set(session, persistence, new Page());
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
            get { return this.isSorted; }
        }

        protected override PropertyDescriptor SortPropertyCore
        {
            get { return this.propertyDescriptor; }
        }

        protected override ListSortDirection SortDirectionCore
        {
            get { return this.listSortDirection; }
        }

        protected override bool SupportsSearchingCore
        {
            get { return true; }
        }

        protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction)
        {
            List<AbstractViewedData> itemsList = (List<AbstractViewedData>)this.Items;

            Type propertyType = property.PropertyType;
            PropertyComparer<AbstractViewedData> comparer;
            if (!this.comparers.TryGetValue(propertyType, out comparer))
            {
                comparer = new PropertyComparer<AbstractViewedData>(property, direction);
                this.comparers.Add(propertyType, comparer);
            }

            comparer.SetPropertyAndDirection(property, direction);
            itemsList.Sort(comparer);

            this.propertyDescriptor = property;
            this.listSortDirection = direction;
            this.isSorted = true;

            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override void RemoveSortCore()
        {
            this.isSorted = false;
            this.propertyDescriptor = base.SortPropertyCore;
            this.listSortDirection = base.SortDirectionCore;

            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override int FindCore(PropertyDescriptor property, object key)
        {
            int count = this.Count;
            for (int i = 0; i < count; ++i)
            {
                AbstractViewedData element = this[i];
                if (property.GetValue(element).Equals(key))
                {
                    return i;
                }
            }

            return -1;
        }

        #endregion
    }
}