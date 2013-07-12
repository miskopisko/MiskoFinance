using MPersist.Core.Attributes;
using MPersist.Core.Enums;
using MPersist.Core.MoneyType;
using System;
using System.ComponentModel;
using System.Reflection;

namespace MPersist.Core.Data
{
    public abstract class AbstractData
    {
        private static Logger Log = Logger.GetInstance(typeof(AbstractData));

        #region Variable Declarations



        #endregion

        #region Properties



        #endregion

        #region Constructors

        public AbstractData()
        {
        }

        public AbstractData(Session session, Persistence persistence)
        {
            Set(session, persistence);
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public AbstractData Set(Session session, Persistence persistence)
        {
            return Set(session, persistence, false);
        }

        public AbstractData Set(Session session, Persistence persistence, bool deep)
        {
            if (persistence.Next())
            {
                PropertyDescriptorCollection properties = null;
                if(this is AbstractStoredData)
                {
                    properties = TypeDescriptor.GetProperties(GetType(), new Attribute[] { new StoredAttribute() });

                    ((AbstractStoredData)this).IsSet = true;
                    ((AbstractStoredData)this).Id = persistence.GetPrimaryKey("Id");
                    ((AbstractStoredData)this).RowVer = persistence.GetInt("RowVer").Value;
                }
                else if(this is AbstractViewedData)
                {
                    properties = TypeDescriptor.GetProperties(GetType(), new Attribute[] { new ViewedAttribute() });
                }

                foreach (PropertyDescriptor property in properties)
                {
                    if (property.PropertyType == typeof(String))
                    {
                        property.SetValue(this, persistence.GetString(property.Name));
                    }
                    else if (property.PropertyType == typeof(Boolean?))
                    {
                        property.SetValue(this, persistence.GetBoolean(property.Name));
                    }
                    else if (property.PropertyType == typeof(Int32?))
                    {
                        property.SetValue(this, persistence.GetInt(property.Name));
                    }
                    else if (property.PropertyType == typeof(Int64?))
                    {
                        property.SetValue(this, persistence.GetLong(property.Name));
                    }
                    else if (property.PropertyType == typeof(Double?))
                    {
                        property.SetValue(this, persistence.GetDouble(property.Name));
                    }
                    else if (property.PropertyType == typeof(DateTime?))
                    {
                        property.SetValue(this, persistence.GetDate(property.Name));
                    }
                    else if (property.PropertyType == typeof(Boolean))
                    {
                        Boolean? value = persistence.GetBoolean(property.Name);
                        property.SetValue(this, value.HasValue ? value.Value : false);
                    }
                    else if (property.PropertyType == typeof(Int32))
                    {
                        Int32? value = persistence.GetInt(property.Name);
                        property.SetValue(this, value.HasValue ? value.Value : 0);
                    }
                    else if (property.PropertyType == typeof(Int64))
                    {
                        Int64? value = persistence.GetLong(property.Name);
                        property.SetValue(this, value.HasValue ? value.Value : 0);
                    }
                    else if (property.PropertyType == typeof(Double))
                    {
                        Double? value = persistence.GetDouble(property.Name);
                        property.SetValue(this, value.HasValue ? value.Value : 0);
                    }
                    else if (property.PropertyType == typeof(DateTime))
                    {
                        DateTime? value = persistence.GetDate(property.Name);
                        property.SetValue(this, value.HasValue ? value.Value : DateTime.MinValue);
                    }
                    else if (property.PropertyType.IsSubclassOf(typeof(AbstractEnum)))
                    {
                        AbstractEnum item = null;

                        if (persistence.GetLong(property.Name).HasValue)
                        {
                            item = (AbstractEnum)property.PropertyType.InvokeMember("GetElement", BindingFlags.Default | BindingFlags.InvokeMethod, null, null, new object[] { persistence.GetLong(property.Name) });
                        }
                        else
                        {
                            item = (AbstractEnum)property.PropertyType.InvokeMember("GetElement", BindingFlags.Default | BindingFlags.InvokeMethod, null, null, new object[] { -1 });
                        }

                        property.SetValue(this, item);
                    }
                    else if (property.PropertyType.IsSubclassOf(typeof(AbstractStoredData)))
                    {
                        AbstractStoredData item = null;

                        if (persistence.GetInt(property.Name) > 0)
                        {
                            item = (AbstractStoredData)property.PropertyType.Assembly.CreateInstance(property.PropertyType.FullName);
                            item.Id = persistence.GetPrimaryKey("Id");
                        }

                        property.SetValue(this, item);
                    }
                    else if (property.PropertyType == typeof(Guid))
                    {
                        property.SetValue(this, new Guid(persistence.GetString(property.Name)));
                    }
                    else if (property.PropertyType == typeof(Money))
                    {
                        property.SetValue(this, persistence.GetMoney(property.Name));
                    }
                    else if (property.PropertyType == typeof(PrimaryKey))
                    {
                        property.SetValue(this, persistence.GetPrimaryKey(property.Name));
                    }
                    else if (property.PropertyType.IsGenericType) // Leave this out for now
                    {
                        //Object list = Activator.CreateInstance(property.PropertyType.MakeGenericType(property.PropertyType.GetGenericArguments()));
                        //property.SetValue(this, list, null);
                    }

                    if (deep)
                    {
                        FetchDeep(session);
                    }
                }
            }

            return this;
        }

        protected void FetchDeep(Session session)
        {
            foreach (PropertyInfo property in GetType().GetProperties())
            {
                if (property.PropertyType.IsSubclassOf(typeof(AbstractStoredData)))
                {
                    AbstractStoredData item = (AbstractStoredData)property.GetValue(this, null);
                    if (item != null && item.Id > 0 && item.IsNotSet)
                    {
                        item.FetchById(session, item.Id, true);
                    }
                }
            }
        }

        #endregion
    }
}
