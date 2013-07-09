using MPersist.Core.Data;
using MPersist.Core.Enums;
using System;

namespace MPersist.Core.Message.Request
{
    public abstract class AbstractRequest
    {
        private static Logger Log = Logger.GetInstance(typeof(AbstractRequest));

        #region Variable Declarations

        private MessageMode mMessageMode_ = MessageMode.Normal;
        private String mCommand_ = "Execute";
        private Page mPage_ = new Page();

        #endregion

        #region Properties

        public MessageMode MessageMode { get { return mMessageMode_; } set { mMessageMode_ = value; } }

        public String Command { get { return mCommand_; } set { mCommand_ = value; } }

        public Page Page { get { return mPage_; } set { mPage_ = value; } }        

        #endregion

        #region Constructors

        public AbstractRequest()
        {
        }

        #endregion
    }
}
