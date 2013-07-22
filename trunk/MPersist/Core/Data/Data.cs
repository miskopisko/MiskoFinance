using System;
using System.Collections.Generic;
using System.Reflection;
using MPersist.Core.Attributes;
using MPersist.Core.Enums;
using MPersist.Core.MoneyType;

namespace MPersist.Core.Data
{
    public class Data
    {
        private static Logger Log = Logger.GetInstance(typeof(Data));

        #region Fields



        #endregion

        #region Properties



        #endregion

        #region Constructors

        public Data()
        {
        }

        public Data(Session session, Persistence persistence)
        {
            Set(session, persistence);
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public Data Set(Session session, Persistence persistence)
        {
            return Set(session, persistence, false);
        }

        public Data Set(Session session, Persistence persistence, bool deep)
        {
            if (persistence.Next())
            {
                List<PropertyInfo> properties = new List<PropertyInfo>();
                if(this is StoredData)
                {
                    Type currentType = GetType();
                    while (!currentType.Equals(typeof(StoredData)))
                    {
                        properties.AddRange(GetStoredProperties(currentType));
                        currentType = currentType.BaseType;
                    }

                    ((StoredData)this).IsSet = true;
                    ((StoredData)this).Id = persistence.GetPrimaryKey("Id");
                    ((StoredData)this).RowVer = persistence.GetInt("RowVer") != null ? persistence.GetInt("RowVer").Value : 0;
                }
                else if(this is ViewedData)
                {
                    Type currentType = GetType();
                    while (!currentType.Equals(typeof(ViewedData)))
                    {
                        properties.AddRange(GetViewedProperties(currentType));
                        currentType = currentType.BaseType;
                    }
                }

                foreach (PropertyInfo property in properties)
                {
                    String columnName = GetColumnName(property);

                    if (property.PropertyType == typeof(String))
                    {
                        property.SetValue(this, persistence.GetString(columnName), null);
                    }
                    else if (property.PropertyType == typeof(Boolean?))
                    {
                        property.SetValue(this, persistence.GetBoolean(columnName), null);
                    }
                    else if (property.PropertyType == typeof(Int32?))
                    {
                        property.SetValue(this, persistence.GetInt(columnName), null);
                    }
                    else if (property.PropertyType == typeof(Int64?))
                    {
                        property.SetValue(this, persistence.GetLong(columnName), null);
                    }
                    else if (property.PropertyType == typeof(Double?))
                    {
                        property.SetValue(this, persistence.GetDouble(columnName), null);
                    }
                    else if (property.PropertyType == typeof(DateTime?))
                    {
                        property.SetValue(this, persistence.GetDate(columnName), null);
                    }
                    else if (property.PropertyType == typeof(Boolean))
                    {
                        Boolean? value = persistence.GetBoolean(columnName);
                        property.SetValue(this, value.HasValue ? value.Value : false, null);
                    }
                    else if (property.PropertyType == typeof(Int32))
                    {
                        Int32? value = persistence.GetInt(columnName);
                        property.SetValue(this, value.HasValue ? value.Value : 0, null);
                    }
                    else if (property.PropertyType == typeof(Int64))
                    {
                        Int64? value = persistence.GetLong(columnName);
                        property.SetValue(this, value.HasValue ? value.Value : 0, null);
                    }
                    else if (property.PropertyType == typeof(Double))
                    {
                        Double? value = persistence.GetDouble(columnName);
                        property.SetValue(this, value.HasValue ? value.Value : 0, null);
                    }
                    else if (property.PropertyType == typeof(DateTime))
                    {
                        DateTime? value = persistence.GetDate(columnName);
                        property.SetValue(this, value.HasValue ? value.Value : DateTime.MinValue, null);
                    }
                    else if (property.PropertyType.IsSubclassOf(typeof(AbstractEnum)))
                    {
                        AbstractEnum item = null;

                        if (persistence.GetLong(columnName).HasValue)
                        {
                            item = (AbstractEnum)property.PropertyType.InvokeMember("GetElement", BindingFlags.Default | BindingFlags.InvokeMethod, null, null, new object[] { persistence.GetLong(columnName) });
                        }
                        else
                        {
                            item = (AbstractEnum)property.PropertyType.InvokeMember("GetElement", BindingFlags.Default | BindingFlags.InvokeMethod, null, null, new object[] { -1 });
                        }

                        property.SetValue(this, item, null);
                    }
                    else if (property.PropertyType.IsSubclassOf(typeof(StoredData)))
                    {
                        StoredData item = null;

                        if (persistence.GetInt(columnName) > 0)
                        {
                            item = (StoredData)property.PropertyType.Assembly.CreateInstance(property.PropertyType.FullName);
                            item.Id = persistence.GetPrimaryKey(columnName);
                        }

                        property.SetValue(this, item, null);
                    }
                    else if (property.PropertyType == typeof(Guid))
                    {
                        property.SetValue(this, new Guid(persistence.GetString(columnName)), null);
                    }
                    else if (property.PropertyType == typeof(Money))
                    {
                        property.SetValue(this, persistence.GetMoney(columnName), null);
                    }
                    else if (property.PropertyType == typeof(PrimaryKey))
                    {
                        property.SetValue(this, persistence.GetPrimaryKey(columnName), null);
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

        public void FetchDeep(Session session)
        {
            foreach (PropertyInfo property in GetType().GetProperties())
            {
                if (property.PropertyType.IsSubclassOf(typeof(StoredData)))
                {
                    StoredData item = (StoredData)property.GetValue(this, null);
                    if (item != null && item.Id > 0 && item.IsNotSet)
                    {
                        item.FetchById(session, item.Id, true);
                    }
                }
            }
        }

        public String GetColumnName(PropertyInfo property)
        {
            foreach (Attribute attribute in property.GetCustomAttributes(false))
            {
                if (attribute is StoredAttribute && ((StoredAttribute)attribute).UseInSql && !String.IsNullOrEmpty(((StoredAttribute)attribute).ColumnName))
                {
                    return ((StoredAttribute)attribute).ColumnName;
                }
            }

            return property.Name;
        }

        public PropertyInfo[] GetStoredProperties(Type type)
        {
            List<PropertyInfo> storedProperties = new List<PropertyInfo>();

            foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                foreach (Attribute attribute in property.GetCustomAttributes(false))
                {
                    if (attribute is StoredAttribute && ((StoredAttribute)attribute).UseInSql)
                    {
                        storedProperties.Add(property);
                        break;
                    }
                }
            }

            return storedProperties.ToArray();
        }

        public PropertyInfo[] GetViewedProperties(Type type)
        {
            List<PropertyInfo> viewedProperties = new List<PropertyInfo>();

            foreach (PropertyInfo property in type.GetProperties())
            {
                foreach (Attribute attribute in property.GetCustomAttributes(false))
                {
                    if (attribute is ViewedAttribute)
                    {
                        viewedProperties.Add(property);
                        break;
                    }
                }
            }

            return viewedProperties.ToArray();
        }

        #endregion
    }
}
