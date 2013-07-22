using System;
using System.Collections.Generic;
using System.Reflection;
using MPersist.Core.Attributes;
using MPersist.Core.Enums;
using MPersist.Core.Tools;

namespace MPersist.Core.Data
{
    public abstract class AbstractStoredData : AbstractData
    {
        private static Logger Log = Logger.GetInstance(typeof(AbstractStoredData));

        #region Fields

        

        #endregion

        #region Stored Properties

        [Stored(PrimaryKey=true)]
        public PrimaryKey Id { get; set; }
        [Stored(RowVer=true)]
        public Int64 RowVer { get; set; }

        #endregion

        #region Other Properties

        public bool IsSet { get; set; }
        public bool IsNotSet { get { return !IsSet; } }

        #endregion

        #region Constructors

        public AbstractStoredData()
        {
            Id = new PrimaryKey();
        }

        public AbstractStoredData(Session session, Persistence persistence)
        {
            Set(session, persistence);
        }

        #endregion

        #region Private Methods

        private void CopyFromCache(AbstractStoredData source)
        {
            PropertyInfo[] destinationProperties = GetType().GetProperties();
            foreach (PropertyInfo destinationPi in destinationProperties)
            {
                PropertyInfo sourcePi = source.GetType().GetProperty(destinationPi.Name);

                if (destinationPi.GetSetMethod() != null)
                {
                    destinationPi.SetValue(this, sourcePi.GetValue(source, null), null);
                }
            }
        }

        /*private void SaveChildren(Session session)
        {
            // Save any StoredData objects before storing this object
            foreach (PropertyInfo property in GetType().GetProperties())
            {
                if (property.PropertyType.IsSubclassOf(typeof(AbstractStoredData)))
                {
                    AbstractStoredData item = (AbstractStoredData)property.GetValue(this, null);
                    if (item != null && item.IsSet)
                    {
                        item.Save(session);
                    }
                }
            }
        }

        private void Insert(Session session)
        {
            Persistence p = Persistence.GetInstance(session);
            Id = p.ExecuteInsert(this);
            p.Close();
            p = null;
        }

        private void Update(Session session)
        {
            Persistence p = Persistence.GetInstance(session);
            RowVer = p.ExecuteUpdate(this);
            p.Close();
            p = null;
        }

        private void Delete(Session session)
        {
            Persistence p = Persistence.GetInstance(session);
            p.ExecuteDelete(this);
            p.Close();
            p = null;
        }*/

        #endregion

        #region Public Methods

        public static PropertyInfo[] GetStoredProperties(Type type)
        {
            List<PropertyInfo> storedProperties = new List<PropertyInfo>();

            foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                foreach (Attribute attribute in property.GetCustomAttributes(false))
                {
                    if(attribute is StoredAttribute && ((StoredAttribute)attribute).UseInSql)
                    {
                        storedProperties.Add(property);
                        break;
                    }
                }
            }

            return storedProperties.ToArray();
        }

        public static AbstractStoredData GetInstanceById(Session session, Type type, Int64 id)
        {
            return GetInstanceById(session, type, new PrimaryKey(id), false);
        }

        public static AbstractStoredData GetInstanceById(Session session, Type type, PrimaryKey id)
        {
            return GetInstanceById(session, type, id, false);
        }

        public static AbstractStoredData GetInstanceById(Session session, Type type, Int64 id, Boolean deep)
        {
            return GetInstanceById(session, type, new PrimaryKey(id), deep);
        }
        
        public static AbstractStoredData GetInstanceById(Session session, Type type, PrimaryKey id, Boolean deep)
        {
            AbstractStoredData result = (AbstractStoredData)type.Assembly.CreateInstance(type.FullName);

            result.FetchById(session, id, deep);

            return result;
        }

        public void FetchById(Session session, PrimaryKey id)
        {
            FetchById(session, id, false);
        }

        public void FetchById(Session session, PrimaryKey id, Boolean deep)
        {
            String key = MPCache.GetKey(GetType(), session.ConnectionName, new Object[] { "Id", id });

            AbstractStoredData value = (AbstractStoredData)MPCache.Get(key);

            if (value == null)
            {
                Persistence p = Persistence.GetInstance(session);
                p.ExecuteQuery("SELECT * FROM " + GetType().Name + " WHERE ID = ?", new Object[] { id });
                Set(session, p, deep);
                p.Close();
                p = null;

                if (IsSet)
                {
                    if (deep)
                    {
                        FetchDeep(session);
                    }

                    MPCache.Put(key, this);
                }
            }
            else
            {
                CopyFromCache(value);
            }
        }

        public AbstractStoredData Save(Session session)
        {
            //SaveChildren(session);
            
            if (Id == 0)    // Insert mode
            {
                Create(session);

                MPCache.Put(MPCache.GetKey(GetType(), session.ConnectionName, new Object[] { "Id", this.Id }), this);
            }
            else if (Id > 0)    // Update mode
            {
                Store(session);

                MPCache.Put(MPCache.GetKey(GetType(), session.ConnectionName, new Object[] { "Id", this.Id }), this);
            }
            else if(Id < 0) // Delete mode
            {
                Remove(session);

                MPCache.Remove(MPCache.GetKey(GetType(), session.ConnectionName, new Object[] { "Id", this.Id }));
            }

            return this;
        }

        #endregion

        #region Abstract Methods

        public abstract AbstractStoredData Create(Session session);

        public abstract AbstractStoredData Store(Session session);

        public abstract AbstractStoredData Remove(Session session);

        public abstract void PreSave(Session session, UpdateMode mode);

        public abstract void PostSave(Session session, UpdateMode mode);

        #endregion

        public override string ToString()
        {
            String result = GetType().Name + Environment.NewLine;

            foreach (PropertyInfo property in GetType().GetProperties())
            {
                result += property.Name + ": " + property.GetValue(this, null) + Environment.NewLine;
            }

            return result;
        }
    }
}
