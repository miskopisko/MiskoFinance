using System.Collections.Generic;
using System;
using MPersist.Core.Data;

namespace MPersist.Core
{
    public class Parameters : List<Parameter>
    {
        private static Logger Log = Logger.GetInstance(typeof(Parameters));

        public Parameters()
        {
        }

        #region Public Methods

        public void AddNew(string parameterName, Type type, object value)
        {
            if(type.IsSubclassOf(typeof(Enum)) && (int)value < 0)
            {
                Add(new Parameter(parameterName, DBNull.Value));
            }
            else if (type.IsSubclassOf(typeof(AbstractStoredData)) && value != null)
            {
                Add(new Parameter(parameterName, ((AbstractStoredData)value).Id));
            }
            else if (type.IsSubclassOf(typeof(AbstractStoredData)) && value == null)
            {
                Add(new Parameter(parameterName, DBNull.Value));
            }
            else
            {
                Add(new Parameter(parameterName, value != null ? value : DBNull.Value));
            }
        }

        #endregion
    }
}
