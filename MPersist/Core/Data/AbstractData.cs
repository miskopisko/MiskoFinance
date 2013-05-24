using System;
using System.ComponentModel;
using System.Reflection;
using MPersist.Core.Attributes;
using MPersist.Core.Enums;
using MPersist.Core.MoneyType;

namespace MPersist.Core.Data
{
    public class AbstractData
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

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public AbstractData set(Session session, Persistence persistence)
        {
            return set(session, persistence, false);
        }

        public AbstractData set(Session session, Persistence persistence, bool deep)
        {
            if (persistence.Next())
            {
                PropertyDescriptorCollection properties = null;
                if(this is AbstractStoredData)
                {
                     properties = TypeDescriptor.GetProperties(GetType(), new Attribute[] { new StoredAttribute() });
                }
                else if(this is AbstractViewedData)
                {
                    properties = TypeDescriptor.GetProperties(GetType(), new Attribute[] { new ViewedAttribute() });
                }

                foreach (PropertyDescriptor property in properties)
                {
                    if (property.Name.Equals("Id"))
                    {
                        property.SetValue(this, persistence.GetInt(property.Name));
                    }
                    else
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
                                item.Id = persistence.GetInt(property.Name).Value;
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
                        else if (property.PropertyType.IsGenericType) // Leave this out for now
                        {
                            //Object list = Activator.CreateInstance(property.PropertyType.MakeGenericType(property.PropertyType.GetGenericArguments()));
                            //property.SetValue(this, list, null);
                        }
                    }

                    if (this is AbstractStoredData)
                    {
                        ((AbstractStoredData)this).IsSet = true;
                        if (deep)
                        {
                            ((AbstractStoredData)this).FetchDeep(session);
                        }
                    }
                }
            }

            return this;
        }

        #endregion
    }
}
