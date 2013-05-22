using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MPersist.Core.Data
{
    public class AbstractStoredDataList : BindingList<AbstractStoredData>
    {
        private static Logger Log = Logger.GetInstance(typeof(AbstractStoredDataList));

        #region Variable Declarations

        private readonly Dictionary<Type, PropertyComparer<AbstractStoredData>> comparers;
        private bool isSorted;
        private ListSortDirection listSortDirection;
        private PropertyDescriptor propertyDescriptor;

        #endregion

        #region Properties

        public Type BaseType { get; set; }

        #endregion

        #region Constructors

        public AbstractStoredDataList() : base(new BindingList<AbstractStoredData>())
        {
            this.comparers = new Dictionary<Type, PropertyComparer<AbstractStoredData>>();
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public void Save(Session session)
        {
            foreach (AbstractStoredData item in this)
            {
                item.Save(session);
            }
        }

        public void set(Session session, Type type, Persistence p)
        {
            while (p.HasNext)
            {
                AbstractStoredData o = (AbstractStoredData)type.Assembly.CreateInstance(type.FullName);
                Add((AbstractStoredData)o.set(session, p));
            }
        }

        public void FetchAll(Session session)
        {
            Persistence persistence = Persistence.GetInstance(session);
            persistence.ExecuteQuery("SELECT * FROM " + BaseType.Name);
            set(session, BaseType, persistence);
            persistence.Close();
            persistence = null;
        }

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
            List<AbstractStoredData> itemsList = (List<AbstractStoredData>)this.Items;

            Type propertyType = property.PropertyType;
            PropertyComparer<AbstractStoredData> comparer;
            if (!this.comparers.TryGetValue(propertyType, out comparer))
            {
                comparer = new PropertyComparer<AbstractStoredData>(property, direction);
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
                AbstractStoredData element = this[i];
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
