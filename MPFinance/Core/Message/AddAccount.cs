using System;
using MPersist.Core;
using MPersist.Core.Enums;
using MPersist.Core.Message;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;
using MPFinance.Resources;

namespace MPFinance.Core.Message
{
    public class AddAccount : MessageWrapper
    {
        private static Logger Log = Logger.GetInstance(typeof(AddAccount));

        #region Properties

        public new AddAccountRQ Request { get { return (AddAccountRQ)base.Request; } }
        public new AddAccountRS Response { get { return (AddAccountRS)base.Response; } }

        #endregion

        public AddAccount(AddAccountRQ request, AddAccountRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
            // Confirm with the user first
            session.Error(ErrorLevel.Confirmation, ConfirmStrings.conCreateNewAccount, new Object[] { Request.BankAccount.AccountNumber });

            // Make sure a bank account with that account number does not already exist
            BankAccount alreadyExists = BankAccount.GetInstanceByComposite(session, Request.Operator.OperatorId, Request.BankAccount.AccountNumber);
            if(alreadyExists != null && alreadyExists.IsSet)
            {
                session.Error(ErrorLevel.Error, "A bank account with the number {0} already exists", new Object []{ Request.BankAccount.AccountNumber });
            }

            Request.BankAccount.OperatorId = Request.Operator.OperatorId;
            Request.BankAccount.Update(session);

            Response.NewAccount = Request.BankAccount;
        }
    }
}
