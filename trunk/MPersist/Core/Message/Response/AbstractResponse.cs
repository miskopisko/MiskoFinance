using MPersist.Core.Data;
using MPersist.Core.Debug;
using MPersist.Core.Enums;
using System;

namespace MPersist.Core.Message.Response
{
    public abstract class AbstractResponse
    {
        private static Logger Log = Logger.GetInstance(typeof(AbstractResponse));

        #region Variable Declarations



        #endregion

        #region Properties

        public Boolean HasErrors { get; set; }

        public Boolean HasWarnings { get; set; }

        public Boolean HasConfirmations { get; set; }

        public MessageMode MessageMode { get; set; }

        public Page Page { get; set; }

        public MessageTiming MessageTiming { get; set; }

        #endregion

        #region Constructors

        protected AbstractResponse()
        {
        }

        #endregion
    }
}
