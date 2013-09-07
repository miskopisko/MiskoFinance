using System;
using System.Reflection;
using System.Xml.Serialization;
using MPersist.Core;
using MPersist.Tools;
using Newtonsoft.Json;

namespace MPersist.Data
{
    public class AbstractViewedData : AbstractData
    {
        private static Logger Log = Logger.GetInstance(typeof(AbstractViewedData));

        #region Fields



        #endregion

        #region Properties

        [JsonIgnore]
        [XmlIgnore]
        public String JSON { get { return JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented); } }
        [JsonIgnore]
        [XmlIgnore]
        public String XML { get { return Utils.Serialize(this); } }

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

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods



        #endregion
    }
}
