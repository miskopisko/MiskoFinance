using System;
using System.Collections.Generic;

namespace MPersist.Core.Data
{
    public class AbstractViewedDataList : List<AbstractViewedData>
    {
        private static Logger Log = Logger.GetInstance(typeof(AbstractViewedDataList));

        #region Variable Declarations



        #endregion

        #region Properties

        public Type BaseType { get; set; }

        #endregion

        #region Constructors

        public AbstractViewedDataList()
        {
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public void fetchAll(Session session)
        {
            Persistence persistence = Persistence.GetInstance(session);
            persistence.ExecuteQuery("SELECT * FROM " + BaseType.Name);
            set(session, BaseType, persistence);
            persistence.Close();
            persistence = null;
        }

        public void set(Session session, Type type, Persistence p)
        {
            while (p.Next())
            {
                AbstractViewedData o = (AbstractViewedData)type.Assembly.CreateInstance(type.FullName);

                Add((AbstractViewedData)o.set(p));
            }
        }

        #endregion
    }
}
