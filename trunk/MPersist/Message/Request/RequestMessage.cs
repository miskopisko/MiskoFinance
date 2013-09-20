using System;
using MPersist.Core;
using MPersist.Data;
using MPersist.Enums;

namespace MPersist.Message.Request
{
    public class RequestMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(RequestMessage));

        #region Fields

        private MessageMode mMessageMode_ = MessageMode.Normal;
        private String mCommand_ = "Execute";
        private String mConnection_ = "Default";
        private Page mPage_ = new Page();

        #endregion

        #region Properties

        public MessageMode MessageMode { get { return mMessageMode_; } set { mMessageMode_ = value; } }
        public String Command { get { return mCommand_; } set { mCommand_ = value; } }
        public String Connection { get { return mConnection_; } set { mConnection_ = value; } }
        public Page Page { get { return mPage_; } set { mPage_ = value; } }

        #endregion

        #region Constructors

        protected RequestMessage()
        {
        }

        #endregion
    }
}
