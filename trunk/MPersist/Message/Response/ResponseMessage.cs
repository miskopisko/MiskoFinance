using System;
using MPersist.Core;
using MPersist.Data;
using MPersist.Enums;

namespace MPersist.Message.Response
{
    public class ResponseMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(ResponseMessage));

        #region Fields



        #endregion

        #region Properties

        public ErrorMessages Errors { get; set; }
        public ErrorMessages Warnings { get; set; }
        public ErrorMessages Confirmations { get; set; }
        public Boolean HasErrors { get { return Errors != null && Errors.Count > 0; } set { } }
        public Boolean HasWarnings { get { return Warnings != null && Warnings.Count > 0; } set { } }
        public Boolean HasConfirmations { get { return Confirmations != null && Confirmations.Count > 0; } set { } }
        public MessageMode MessageMode { get; set; }
        public Page Page { get; set; }

        #endregion

        #region Constructors

        protected ResponseMessage()
        {
        }

        #endregion
    }
}
