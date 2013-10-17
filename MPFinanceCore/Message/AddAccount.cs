using System;
using MPersist.Core;
using MPersist.Enums;
using MPersist.Message;
using MPFinanceCore.Data.Stored;
using MPFinanceCore.Message.Requests;
using MPFinanceCore.Message.Responses;
using MPFinanceCore.Resources;

namespace MPFinanceCore.Message
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
            if (Request.BankAccount.BankAccountId == null || Request.BankAccount.BankAccountId.IsNotSet)
            {
                // Make sure a bank account with that account number does not already exist
                BankAccount alreadyExists = BankAccount.GetInstanceByComposite(session, Request.BankAccount.OperatorId, Request.BankAccount.AccountNumber);
                if (alreadyExists != null && alreadyExists.IsSet)
                {
                    session.Error(ErrorLevel.Error, "A bank account with the number {0} already exists", new String[] { Request.BankAccount.AccountNumber });
                }

                // Confirm with the user first
                session.Error(ErrorLevel.Confirmation, ConfirmStrings.conCreateNewAccount, new String[] { Request.BankAccount.AccountNumber });
            }

            Request.BankAccount.Update(session);

            Response.NewAccount = Request.BankAccount;
        }
    }
}
