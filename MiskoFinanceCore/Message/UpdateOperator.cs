using System;
using MiskoPersist.Core;
using MiskoPersist.Enums;
using MiskoPersist.Message;
using MiskoPersist.Tools;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;

namespace MiskoFinanceCore.Message
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

            // If the OperatorId is not set then we are adding a new operator
            // Check if that operator already exists
            if (Request.Operator.OperatorId == null || Request.Operator.OperatorId.IsNotSet)
            {
                VwOperator alreadyExists = VwOperator.GetInstanceByUsername(session, Request.Operator.Username);
                if (alreadyExists.OperatorId != null && alreadyExists.OperatorId.IsSet)
                {
                    session.Error(ErrorLevel.Error, "Username {0} is already taken.", new Object[] { Request.Operator.Username });
                }
            }

            // Only reset the password of a new password was sent
            if(!String.IsNullOrEmpty(Request.Password1))
            {
            	Request.Operator.Password = Utils.GenerateHash(Request.Password1);
            }

            Request.Operator.Update(session);

            Response.Operator = Request.Operator;
        }
    }
}
