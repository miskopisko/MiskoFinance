using MPersist.Core.Message.Request;
using MPersist.Core.Message.Response;

namespace MPersist.Core.Message
{
    public abstract class AbstractMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(AbstractMessage));

        #region Variable Declarations

        private readonly AbstractRequest mRequest_;
        private readonly AbstractResponse mResponse_;

        #endregion

        #region Properties

        public AbstractRequest Request
        {
            get
            {
                return mRequest_;
            }
        }

        public AbstractResponse Response
        {
            get
            {
                return mResponse_;
            }
        }

        #endregion

        #region Constructors

        protected AbstractMessage(AbstractRequest request, AbstractResponse response)
        {
            mRequest_ = request;
            mResponse_ = response;
        }

        #endregion

        public abstract void Execute(Session session);
    }
}
