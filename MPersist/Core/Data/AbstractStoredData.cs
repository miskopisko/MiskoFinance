using System;
using System.Collections;
using System.Reflection;
using MPersist.Core.Attributes;
using MPersist.Core.Enums;
using MPersist.Core.Tools;

namespace MPersist.Core.Data
{
    public abstract class AbstractStoredData : AbstractData
    {
        private static Logger Log = Logger.GetInstance(typeof(AbstractStoredData));

        #region Variable Declarations

        private static Hashtable CACHE_ = new Hashtable();

        #endregion

        #region Stored Properties

        [Stored]
        public Int64 Id { get; set; }
        [Stored]
        public Int64 RowVer { get; set; }

        #endregion

        #region Other Properties

        public bool IsSet { get; set; }
        public bool IsNotSet { get { return !IsSet; } }

        #endregion

        #region Constructors

        public AbstractStoredData()
        {
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

            int i = 0;
        }

        #endregion

        #region Public Methods

        public static AbstractStoredData GetInstanceById(Session session, Type type, Int64 id)
        {
            return GetInstanceById(session, type, id, false);
        }

        public static AbstractStoredData GetInstanceById(Session session, Type type, Int64 id, Boolean deep)
        {
            AbstractStoredData result = (AbstractStoredData)type.Assembly.CreateInstance(type.FullName);

            result.FetchById(session, id, deep);

            return result;
        }        

        public void FetchById(Session session, Int64 id)
        {
            FetchById(session, id, false);
        }

        public void FetchById(Session session, Int64 id, Boolean deep)
        {
            String key = MPCache.GetKey(this, new Object[] { "Id", id });

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
                    MPCache.Put(key, this);
                }
            }
            else
            {
                CopyFromCache(value);
            }
        }

        public void Save(Session session)
        {
            Persistence p = Persistence.GetInstance(session);
            
            if (Id == 0)
            {
                PreSave(session, UpdateMode.Insert);
                Id = p.ExecuteInsert(this);
                PostSave(session, UpdateMode.Insert);

                MPCache.Put(MPCache.GetKey(this, new Object[] { "Id", this.Id }), this);
            }
            else if (Id > 0)
            {
                PreSave(session, UpdateMode.Update);
                RowVer = p.ExecuteUpdate(this);
                PostSave(session, UpdateMode.Update);

                MPCache.Put(MPCache.GetKey(this, new Object[] { "Id", this.Id }), this);
            }
            else if(Id < 0)
            {
                PreSave(session, UpdateMode.Delete);
                p.ExecuteDelete(this);
                PostSave(session, UpdateMode.Delete);

                MPCache.Remove(MPCache.GetKey(this, new Object[] { "Id", this.Id }));
            }

            p.Close();
            p = null;
        }

        #endregion

        #region Abstract Methods

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
