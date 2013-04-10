using System;
using System.Reflection;
using System.ComponentModel;
using MPersist.Core.Attributes;
using MPersist.Core.Enums;

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

        public AbstractData set(Persistence p)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(GetType(), new Attribute[] { new StoredAttribute() });

            foreach (PropertyDescriptor property in properties)
            {
                if (property.Name.Equals("Id"))
                {
                    property.SetValue(this, p.GetInt(property.Name));
                }
                else
                {
                    if (property.PropertyType == typeof(String))
                    {
                        property.SetValue(this, p.GetString(property.Name));
                    }
                    else if (property.PropertyType == typeof(Boolean?))
                    {
                        property.SetValue(this, p.GetBoolean(property.Name));
                    }
                    else if (property.PropertyType == typeof(Int32?))
                    {
                        property.SetValue(this, p.GetInt(property.Name));
                    }
                    else if (property.PropertyType == typeof(Int64?))
                    {
                        property.SetValue(this, p.GetLong(property.Name));
                    }
                    else if (property.PropertyType == typeof(Double?))
                    {
                        property.SetValue(this, p.GetDouble(property.Name));
                    }
                    else if (property.PropertyType == typeof(DateTime?))
                    {
                        property.SetValue(this, p.GetDate(property.Name));
                    }
                    else if (property.PropertyType == typeof(Boolean))
                    {
                        Boolean? value = p.GetBoolean(property.Name);
                        property.SetValue(this, value.HasValue ? value.Value : false);
                    }
                    else if (property.PropertyType == typeof(Int32))
                    {
                        Int32? value = p.GetInt(property.Name);
                        property.SetValue(this, value.HasValue ? value.Value : 0);
                    }
                    else if (property.PropertyType == typeof(Int64))
                    {
                        Int64? value = p.GetLong(property.Name);
                        property.SetValue(this, value.HasValue ? value.Value : 0);
                    }
                    else if (property.PropertyType == typeof(Double))
                    {
                        Double? value = p.GetDouble(property.Name);
                        property.SetValue(this, value.HasValue ? value.Value : 0);
                    }
                    else if (property.PropertyType == typeof(DateTime))
                    {
                        DateTime? value = p.GetDate(property.Name);
                        property.SetValue(this, value.HasValue ? value.Value : DateTime.MinValue);
                    }
                    else if (property.PropertyType.IsSubclassOf(typeof(AbstractEnum)))
                    {
                        AbstractEnum item = null;

                        if (p.GetLong(property.Name).HasValue)
                        {
                            item = (AbstractEnum)property.PropertyType.InvokeMember("GetElement", BindingFlags.Default | BindingFlags.InvokeMethod, null, null, new object[] { p.GetLong(property.Name) });
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

                        if (p.GetInt(property.Name) > 0)
                        {
                            item = (AbstractStoredData)property.PropertyType.Assembly.CreateInstance(property.PropertyType.FullName);
                            item.Id = p.GetInt(property.Name).Value;
                        }

                        property.SetValue(this, item);
                    }
                    else if (property.PropertyType == typeof(Guid))
                    {
                        property.SetValue(this, new Guid(p.GetString(property.Name)));
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
                }
            }

            return this;
        }

        #endregion
    }
}
