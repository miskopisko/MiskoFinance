using System;
using System.Collections.Generic;
using System.Reflection;
using MPersist.Core.Attributes;
using MPersist.Core.Enums;
using MPersist.Core.Tools;

namespace MPersist.Core.Data
{
    public class StoredData : Data
    {
        private static Logger Log = Logger.GetInstance(typeof(StoredData));

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

        public StoredData()
        {
            Id = new PrimaryKey();
        }

        public StoredData(Session session, Persistence persistence)
        {
            Set(session, persistence);
        }

        #endregion

        #region Private Methods

        private void CopyFromCache(StoredData source)
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

        private StoredData Create(Session session, Type[] types)
        {
            PreSave(session, UpdateMode.Insert);
            foreach (Type type in types)
            {
                Id = Persistence.ExecuteInsert(session, this, type);
            }
            IsSet = true;
            PostSave(session, UpdateMode.Insert);
            return this;
        }

        private StoredData Store(Session session, Type[] types)
        {
            PreSave(session, UpdateMode.Update);
            foreach (Type type in types)
            {
                RowVer = Persistence.ExecuteUpdate(session, this, type);
            }
            PostSave(session, UpdateMode.Update);
            return this;
        }

        private StoredData Remove(Session session, Type[] types)
        {
            PreSave(session, UpdateMode.Delete);
            foreach (Type type in types)
            {
                Persistence.ExecuteDelete(session, this, type);
            }
            PostSave(session, UpdateMode.Delete);
            return this;
        }

        #endregion

        #region Public Methods

        public static StoredData GetInstanceById(Session session, Type type, Int64 id)
        {
            return GetInstanceById(session, type, new PrimaryKey(id), false);
        }

        public static StoredData GetInstanceById(Session session, Type type, PrimaryKey id)
        {
            return GetInstanceById(session, type, id, false);
        }

        public static StoredData GetInstanceById(Session session, Type type, Int64 id, Boolean deep)
        {
            return GetInstanceById(session, type, new PrimaryKey(id), deep);
        }
        
        public static StoredData GetInstanceById(Session session, Type type, PrimaryKey id, Boolean deep)
        {
            StoredData result = (StoredData)type.Assembly.CreateInstance(type.FullName);

            result.FetchById(session, id, deep);

            return result;
        }

        public void FetchById(Session session, Int64 id)
        {
            FetchById(session, new PrimaryKey(id), false);
        }
        
        public void FetchById(Session session, PrimaryKey id)
        {
            FetchById(session, id, false);
        }

        public void FetchById(Session session, Int64 id, Boolean deep)
        {
            FetchById(session, new PrimaryKey(id), deep);
        }

        public void FetchById(Session session, PrimaryKey id, Boolean deep)
        {
            String key = MPCache.GetKey(GetType(), session.ConnectionName, new Object[] { "Id", id });

            StoredData value = (StoredData)MPCache.Get(key);

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

        public StoredData Save(Session session)
        {
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
            else if (Id < 0) // Delete mode
            {
                Remove(session);
                MPCache.Remove(MPCache.GetKey(GetType(), session.ConnectionName, new Object[] { "Id", this.Id }));
            }            

            return this;
        }

        #endregion

        #region Virtual Methods

        public virtual StoredData Create(Session session)
        {
            List<Type> types = new List<Type>();
            Type currentType = GetType();
            while (!currentType.Equals(typeof(StoredData)))
            {
                types.Add(currentType);
                currentType = currentType.BaseType;
            }
            types.Reverse();
            return Create(session, types.ToArray());
        }        

        public virtual StoredData Store(Session session)
        {
            List<Type> types = new List<Type>();
            Type currentType = GetType();
            while (!currentType.Equals(typeof(StoredData)))
            {
                types.Add(currentType);
                currentType = currentType.BaseType;
            }
            types.Reverse();
            return Store(session, types.ToArray());
        }        

        public virtual StoredData Remove(Session session)
        {
            List<Type> types = new List<Type>();
            Type currentType = GetType();
            while (!currentType.Equals(typeof(StoredData)))
            {
                types.Add(currentType);
                currentType = currentType.BaseType;
            }
            return Remove(session, types.ToArray());
        }        

        public virtual void PreSave(Session session, UpdateMode mode)
        {
        }

        public virtual void PostSave(Session session, UpdateMode mode)
        {
        }

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
