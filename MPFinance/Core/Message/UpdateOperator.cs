using MPersist.Core;
using MPersist.Core.Enums;
using MPersist.Core.Message;
using MPersist.Core.Tools;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;

namespace MPFinance.Core.Message
{
    public class UpdateOperator : MessageWrapper
    {
        private static Logger Log = Logger.GetInstance(typeof(UpdateOperator));

        #region Properties

        public new UpdateOperatorRQ Request { get { return (UpdateOperatorRQ)base.Request; } }
        public new UpdateOperatorRS Response { get { return (UpdateOperatorRS)base.Response; } }

        #endregion

        public UpdateOperator(UpdateOperatorRQ request, UpdateOperatorRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
            if (!Request.Password1.Equals(Request.Password2))
            {
                session.Error(ErrorLevel.Error, "Passwords do not match. Try again");
            }

            Request.Operator.Password = Utils.GenerateHash(Request.Password1);

            Request.Operator.Save(session);
        }
    }
}
