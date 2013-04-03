using System.Collections.Generic;

namespace MPersist.Core
{
    public class Parameters : List<Parameter>
    {
        private static Logger Log = Logger.GetInstance(typeof(Parameters));

        public Parameters()
        {
        }

        #region Public Methods

        public void AddNew(string parameterName, object value)
        {
            Add(new Parameter(parameterName, value));
        }

        #endregion
    }
}
