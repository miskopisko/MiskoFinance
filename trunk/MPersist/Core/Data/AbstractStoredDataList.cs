using System.Collections.Generic;
using System;

namespace MPersist.Core.Data
{
    public class AbstractStoredDataList : List<AbstractStoredData>
    {
        private static Logger Log = Logger.GetInstance(typeof(AbstractStoredDataList));

        #region Variable Declarations


        #endregion

        #region Properties

        public Type BaseType { get; set; }

        #endregion

        #region Constructors

        public AbstractStoredDataList()
        {
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public void Save(Session session)
        {
            foreach (AbstractStoredData item in this)
            {
                item.Save(session);
            }
        }

        public void set(Session session, Type type, Persistence p)
        {
            while (p.Next())
            {
                AbstractStoredData o = (AbstractStoredData)type.Assembly.CreateInstance(type.FullName);

                Add((AbstractStoredData)o.set(p));
            }
        }

        public void fetchAll(Session session)
        {
            Persistence persistence = Persistence.GetInstance(session);
            persistence.ExecuteQuery("SELECT * FROM " + BaseType.Name);
            set(session, BaseType, persistence);
            persistence.Close();
            persistence = null;
        }

        #endregion
    }
}
