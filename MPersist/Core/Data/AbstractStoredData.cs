using System;
using System.Reflection;
using MPersist.Resources.Enums;

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

            result.fetchById(session, id, deep);

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
            p.ExecuteQuery("SELECT * FROM " + GetType().Name + " WHERE ID = ?", new Object[] { id });

            if (p.Next())
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

        #endregion
    }
}
