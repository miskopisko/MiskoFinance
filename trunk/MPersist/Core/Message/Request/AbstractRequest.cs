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
        private Int32 mPageNo_ = 0;
        private Int32 mNoRows_ = 20;        

        #endregion

        #region Properties

        public MessageMode MessageMode { get { return mMessageMode_; } set { mMessageMode_ = value; } }

        public Int32 PageNo { get { return mPageNo_; } set { mPageNo_ = value; } }

        public Int32 NoRows { get { return mNoRows_; } set { mNoRows_ = value; } }

        public String Command { get { return mCommand_; } set { mCommand_ = value; } }

        #endregion

        #region Constructors

        public AbstractRequest()
        {
        }

        #endregion
    }
}
