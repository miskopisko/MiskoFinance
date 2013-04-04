using System;
using System.Reflection;
using MPersist.Resources.Enums;
using System.Data;

namespace MPersist.Core.Data
{
    public class AbstractStoredData : AbstractData
    {
        private static Logger Log = Logger.GetInstance(typeof(AbstractStoredData));

        #region Variable Declarations



        #endregion

        #region Properties

        public Int32 Id { get; set; }

        #endregion

        #region Constructors

        public AbstractStoredData()
        {
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public static AbstractStoredData fetchById(Session session, Type type, Int32 id, Boolean deep)
        {
            AbstractStoredData result = (AbstractStoredData)type.Assembly.CreateInstance(type.FullName);

            Persistence p = Persistence.GetInstance(session);
            p.Parameters.AddNew("Id", typeof(Int32), id);
            p.ExecuteSelect(type);

            if (p.HasRows && p.RecordCount == 1)
            {
                result.set(p);
                if (deep)
                {
                    result.fetchDeep(session);
                }
            }

            p.Close();
            p = null;

            return result;
        }

        public void fetchDeep(Session session)
        {
            foreach (PropertyInfo property in GetType().GetProperties())
            {
                if (property.PropertyType.IsSubclassOf(typeof(AbstractStoredData)))
                {
                    AbstractStoredData item = (AbstractStoredData)property.GetValue(this, null);
                    if (item != null && item.Id > 0)
                    {
                        item.fetchById(session, item.Id, true);
                    }
                }
            }
        }

        public void fetchById(Session session, Int32 id, Boolean deep)
        {
            Persistence p = Persistence.GetInstance(session);
            p.Parameters.AddNew("Id", typeof(Int32), id);
            p.ExecuteSelect(GetType());

            if (p.HasRows && p.RecordCount == 1)
            {
                set(p);
                if (deep)
                {
                    fetchDeep(session);
                }
            }

            p.Close();
            p = null;
        }

        public void Save(Session session)
        {
            Persistence p = Persistence.GetInstance(session);
            
            if (Id == 0)
            {
                preSave(session, UpdateMode.Insert);
                Id = p.ExecuteInsert(this);
                postSave(session, UpdateMode.Insert);
            }
            else if (Id > 0)
            {
                preSave(session, UpdateMode.Update);
                p.ExecuteUpdate(this);
                postSave(session, UpdateMode.Update);
            }

            p.Close();
            p = null;
        }

        public void Delete(Session session)
        {
            if (Id > 0)
            {
                Persistence p = Persistence.GetInstance(session);
                p.ExecuteDelete(this);
                p.Close();
                p = null;
                Id = -1;
            }
            else
            {
                session.Error(GetType(), MethodInfo.GetCurrentMethod(), ErrorLevel.Technical, "Object does not exist. Cannot delete");
            }
        }

        public void preSave(Session session, UpdateMode mode)
        {
            // Save any StoredData objects before storing this object
            foreach (PropertyInfo property in GetType().GetProperties())
            {
                if (property.PropertyType.IsSubclassOf(typeof(AbstractStoredData)))
                {
                    AbstractStoredData item = (AbstractStoredData)property.GetValue(this, null);
                    if (item != null)
                    {
                        item.Save(session);
                    }                    
                }
            }
        }

        public void postSave(Session session, UpdateMode mode)
        {
        }

        public void set(Persistence p)
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
        }

        #endregion
    }
}
