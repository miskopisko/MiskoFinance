using System;
using System.Reflection;
using System.Xml;
using MPersist.Core;

namespace MPersist.Data
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

        #region Override Methods

        public override string ToString()
        {
            String result = GetType().Name + Environment.NewLine;

            foreach (PropertyInfo property in GetType().GetProperties())
            {
                result += property.Name + ": " + property.GetValue(this, null) + Environment.NewLine;
            }

            return result;
        }

        public override void WriteXml(XmlWriter writer)
        {
            base.WriteXml(writer);
            
            WriteXmlProperties(writer, GetViewedProperties());
        }

        #endregion

        #region Private Methods

        

        #endregion

        #region Public Methods

        

        #endregion
    }
}