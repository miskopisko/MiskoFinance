using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MPersist.Core.Data
{
    public class AbstractViewedDataList<AbstractViewedData> : BindingList<AbstractViewedData>
    {
        private readonly Dictionary<Type, PropertyComparer<AbstractViewedData>> comparers;
        private bool isSorted;
        private ListSortDirection listSortDirection;
        private PropertyDescriptor propertyDescriptor;

        public Type BaseType { get; set;}

        public AbstractViewedDataList() : base(new List<AbstractViewedData>())
        {
            this.comparers = new Dictionary<Type, PropertyComparer<AbstractViewedData>>();
        }

        public AbstractViewedDataList(IEnumerable<AbstractViewedData> enumeration): base(new List<AbstractViewedData>(enumeration))
        {
            this.comparers = new Dictionary<Type, PropertyComparer<AbstractViewedData>>();
        }

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

        public void AddRange(AbstractViewedDataList<AbstractViewedData> list)
        {
            foreach (AbstractViewedData item in list)
            {
                Items.Add(item);
            }
        }
    }
}