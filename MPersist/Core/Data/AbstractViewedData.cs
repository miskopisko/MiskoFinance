using System;
using System.Collections.Generic;
using System.Reflection;
using MPersist.Core.Attributes;

namespace MPersist.Core.Data
{
    public abstract class AbstractViewedData : AbstractData
    {
        private static Logger Log = Logger.GetInstance(typeof(AbstractViewedData));

        #region Fields



        #endregion

        #region Properties



        #endregion

        #region Constructors

        public AbstractViewedData()
        {
        }

        public AbstractViewedData(Session session, Persistence persistence)
        {
            Set(session, persistence, true);
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public PropertyInfo[] GetViewedProperties()
        {
            List<PropertyInfo> viewedProperties = new List<PropertyInfo>();

            foreach (PropertyInfo property in GetType().GetProperties())
            {
                foreach (Attribute attribute in property.GetCustomAttributes(false))
                {
                    if (attribute is ViewedAttribute)
                    {
                        viewedProperties.Add(property);
                        break;
                    }
                }
            }

            return viewedProperties.ToArray();
        }

        #endregion
    }
}
