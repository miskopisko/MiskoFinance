using System;
using log4net;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;
using MiskoPersist.Core;
using MiskoPersist.Enums;
using MiskoPersist.Message;
using MiskoPersist.Tools;

namespace MiskoFinanceCore.Message
{
	public class UpdateOperator : MessageWrapper
    {
        private static ILog Log = LogManager.GetLogger(typeof(UpdateOperator));

        #region Properties

        public new UpdateOperatorRQ Request { get { return (UpdateOperatorRQ)base.Request; } }
        public new UpdateOperatorRS Response { get { return (UpdateOperatorRS)base.Response; } }

        #endregion

        public UpdateOperator(UpdateOperatorRQ request, UpdateOperatorRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
            if (!String.IsNullOrEmpty(Request.Password1) && !String.IsNullOrEmpty(Request.Password2) && !Request.Password1.Equals(Request.Password2))
            {
                session.Error(ErrorLevel.Error, "Passwords do not match. Try again");
            }

            // If the OperatorId is not set then we are adding a new operator
            // Check if that operator already exists
            if(Request.Operator == null || !Request.Operator.IsSet)
            {
                VwOperator alreadyExists = VwOperator.GetInstanceByUsername(session, Request.Operator.Username);
                if(alreadyExists != null && alreadyExists.IsSet)
                {
                    session.Error(ErrorLevel.Error, "Username {0} is already taken.", Request.Operator.Username);
                }
                
                // Ask the user of they are sure
            	session.Error(ErrorLevel.Confirmation, "You are about to create a new user {0}. Are you sure?", Request.Operator.Username);
            }

            // Only reset the password of a new password was sent
            if(!String.IsNullOrEmpty(Request.Password1))
            {
            	Request.Operator.Password = PasswordHash.CreateHash(Request.Password1);
            }

            Request.Operator.Update(session);

            Response.Operator = Request.Operator;
        }
    }
}
