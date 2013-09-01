using System;
using MPersist.Core;
using MPersist.Enums;
using MPersist.Message;
using MPersist.Tools;
using MPFinanceCore.Data.Viewed;
using MPFinanceCore.Message.Requests;
using MPFinanceCore.Message.Responses;

namespace MPFinanceCore.Message
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

            VwOperator alreadyExists = VwOperator.GetInstanceByUsername(session, Request.Operator.Username);
            if (alreadyExists.OperatorId != null && alreadyExists.OperatorId.IsSet)
            {
                session.Error(ErrorLevel.Error, "Username {0} is already taken.", new Object[] { Request.Operator.Username });
            }

            Request.Operator.Password = Utils.GenerateHash(Request.Password1);

            Request.Operator.Update(session);

            Response.Operator = Request.Operator;
        }
    }
}
