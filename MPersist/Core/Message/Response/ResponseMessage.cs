﻿using System;
using MPersist.Core.Data;
using MPersist.Core.Debug;
using MPersist.Core.Enums;

namespace MPersist.Core.Message.Response
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
        public Boolean HasErrors { get { return Errors != null && Errors.Count > 0; } }        
        public Boolean HasWarnings { get { return Warnings != null && Warnings.Count > 0; } }        
        public Boolean HasConfirmations { get { return Confirmations != null && Confirmations.Count > 0; } }
        public MessageMode MessageMode { get; set; }
        public Page Page { get; set; }
        public MessageTiming MessageTiming { get; set; }

        #endregion

        #region Constructors

        protected ResponseMessage()
        {
        }

        #endregion
    }
}
