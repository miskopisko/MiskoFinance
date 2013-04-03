using System;
using System.Reflection;

namespace MPersist.Core.Data
{
    public class AbstractStoredData : AbstractData
    {
        private static Logger Log = Logger.GetInstance(typeof(AbstractStoredData));

        #region Variable Declarations



        #endregion

        #region Properties

        public Int32 Id { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtModified { get; set; }
        public Int32 RowVer { get; set; }

        #endregion

        #region Constructors

        public AbstractStoredData()
        {
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public void set(Persistence p)
        {
            if (p.Results.Read())
            {
                PropertyInfo[] properties = GetType().GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    Int32 ordinal = p.Results.GetOrdinal(property.Name);

                    if (property.Name.Equals("Id"))
                    {
                        property.SetValue(this, p.Results.GetInt32(ordinal), null);
                    }
                    else if(p.Results.IsDBNull(ordinal))
                    {
                        if (property.PropertyType.IsEnum)
                        {
                            property.SetValue(this, -1, null);
                        }
                        else
                        {
                            property.SetValue(this, null, null);
                        }
                    }
                    else
                    {
                        if (property.PropertyType == typeof(String))
                        {
                            property.SetValue(this, p.Results.GetString(ordinal), null);
                        }
                        else if (property.PropertyType == typeof(Boolean?))
                        {
                            property.SetValue(this, p.Results.GetBoolean(ordinal), null);
                        }
                        else if (property.PropertyType == typeof(Int32?))
                        {
                            property.SetValue(this, p.Results.GetInt32(ordinal), null);
                        }                        
                        else if (property.PropertyType == typeof(Int64?))
                        {
                            property.SetValue(this, p.Results.GetInt64(ordinal), null);
                        }
                        else if (property.PropertyType == typeof(Double?))
                        {
                            property.SetValue(this, p.Results.GetDouble(ordinal), null);
                        }
                        else if (property.PropertyType == typeof(DateTime?))
                        {
                            property.SetValue(this, p.Results.GetDateTime(ordinal), null);
                        }
                        else if (property.PropertyType == typeof(Boolean))
                        {
                            Boolean? value = p.Results.GetBoolean(ordinal);
                            property.SetValue(this, value.HasValue ? value.Value : false, null);
                        }
                        else if (property.PropertyType == typeof(Int32))
                        {
                            Int32? value = p.Results.GetInt32(ordinal);
                            property.SetValue(this, value.HasValue ? value.Value : 0, null);
                        }
                        else if (property.PropertyType == typeof(Int64))
                        {
                            Int64? value = p.Results.GetInt64(ordinal);
                            property.SetValue(this, value.HasValue ? value.Value : 0, null);
                        }
                        else if (property.PropertyType == typeof(Double))
                        {
                            Double? value = p.Results.GetDouble(ordinal);
                            property.SetValue(this, value.HasValue ? value.Value : 0, null);
                        }
                        else if (property.PropertyType == typeof(DateTime))
                        {
                            DateTime? value = p.Results.GetDateTime(ordinal);
                            property.SetValue(this, value.HasValue ? value.Value : DateTime.MinValue, null);
                        }
                        else if (property.PropertyType.IsEnum)
                        {
                            property.SetValue(this, Enum.ToObject(property.PropertyType, p.Results.GetInt32(ordinal)), null);
                        }
                        else if (property.PropertyType.IsSubclassOf(typeof(AbstractViewedData)))
                        {
                            //AbstractViewedData item = null;

                            //if (result.GetLong(name).HasValue)
                            //{
                            //    item = (AbstractViewedData)property.PropertyType.Assembly.CreateInstance(property.PropertyType.FullName);
                            //    item.Id = result.GetLong(name).Value;
                            //}

                            //property.SetValue(obj, item, null);
                        }
                        else if (property.PropertyType == typeof(Guid))
                        {
                            Guid? value = p.Results.GetGuid(ordinal);
                            property.SetValue(this, value.HasValue ? value : Guid.Empty, null);
                        }
                        else if (property.PropertyType.IsGenericType) // Leave this out for now
                        {
                            //Object list = Activator.CreateInstance(property.PropertyType.MakeGenericType(property.PropertyType.GetGenericArguments()));
                            //property.SetValue(this, list, null);
                        }
                    }
                }
            }
        }

        #endregion
    }
}
