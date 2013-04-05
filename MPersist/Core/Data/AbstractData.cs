using System;
using System.Reflection;

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
            foreach (PropertyInfo property in GetType().GetProperties())
            {
                if (property.Name.Equals("Id"))
                {
                    property.SetValue(this, p.GetInt(property.Name), null);
                }
                else
                {
                    if (property.PropertyType == typeof(String))
                    {
                        property.SetValue(this, p.GetString(property.Name), null);
                    }
                    else if (property.PropertyType == typeof(Boolean?))
                    {
                        property.SetValue(this, p.GetBoolean(property.Name), null);
                    }
                    else if (property.PropertyType == typeof(Int32?))
                    {
                        property.SetValue(this, p.GetInt(property.Name), null);
                    }
                    else if (property.PropertyType == typeof(Int64?))
                    {
                        property.SetValue(this, p.GetLong(property.Name), null);
                    }
                    else if (property.PropertyType == typeof(Double?))
                    {
                        property.SetValue(this, p.GetDouble(property.Name), null);
                    }
                    else if (property.PropertyType == typeof(DateTime?))
                    {
                        property.SetValue(this, p.GetDate(property.Name), null);
                    }
                    else if (property.PropertyType == typeof(Boolean))
                    {
                        Boolean? value = p.GetBoolean(property.Name);
                        property.SetValue(this, value.HasValue ? value.Value : false, null);
                    }
                    else if (property.PropertyType == typeof(Int32))
                    {
                        Int32? value = p.GetInt(property.Name);
                        property.SetValue(this, value.HasValue ? value.Value : 0, null);
                    }
                    else if (property.PropertyType == typeof(Int64))
                    {
                        Int64? value = p.GetLong(property.Name);
                        property.SetValue(this, value.HasValue ? value.Value : 0, null);
                    }
                    else if (property.PropertyType == typeof(Double))
                    {
                        Double? value = p.GetDouble(property.Name);
                        property.SetValue(this, value.HasValue ? value.Value : 0, null);
                    }
                    else if (property.PropertyType == typeof(DateTime))
                    {
                        DateTime? value = p.GetDate(property.Name);
                        property.SetValue(this, value.HasValue ? value.Value : DateTime.MinValue, null);
                    }
                    else if (property.PropertyType.IsEnum)
                    {
                        Int32? value = p.GetInt(property.Name);

                        if (value.HasValue)
                        {
                            property.SetValue(this, Enum.ToObject(property.PropertyType, p.GetInt(property.Name).Value), null);
                        }
                        else
                        {
                            property.SetValue(this, -1, null);
                        }
                    }
                    else if (property.PropertyType.IsSubclassOf(typeof(AbstractStoredData)))
                    {
                        AbstractStoredData item = null;

                        if (p.GetInt(property.Name) > 0)
                        {
                            item = (AbstractStoredData)property.PropertyType.Assembly.CreateInstance(property.PropertyType.FullName);
                            item.Id = p.GetInt(property.Name).Value;
                        }

                        property.SetValue(this, item, null);
                    }
                    else if (property.PropertyType == typeof(Guid))
                    {
                        property.SetValue(this, new Guid(p.GetString(property.Name)), null);
                    }
                    else if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) && property.PropertyType.GetGenericArguments()[0].IsEnum)
                    {
                        Int32? value = p.GetInt(property.Name);

                        if (value.HasValue)
                        {
                            Enum e = (Enum)Enum.ToObject(property.PropertyType.GetGenericArguments()[0], value.Value);

                            property.SetValue(this, e, null);
                        }
                        else
                        {
                            property.SetValue(this, null, null);
                        }
                    }
                    else if (property.PropertyType.IsGenericType) // Leave this out for now
                    {
                        //Object list = Activator.CreateInstance(property.PropertyType.MakeGenericType(property.PropertyType.GetGenericArguments()));
                        // property.SetValue(this, list, null);
                    }
                }
            }

            return this;
        }

        #endregion
    }
}
