using MiskoPersist.Core;
using MiskoPersist.Enums;
using MiskoPersist.Message;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;
using MiskoFinanceCore.Resources;

namespace MiskoFinanceCore.Message
{
    public class UpdateAccounts : MessageWrapper
    {
        private static Logger Log = Logger.GetInstance(typeof(UpdateAccounts));

        #region Properties

        public new UpdateAccountsRQ Request { get { return (UpdateAccountsRQ)base.Request; } }
        public new UpdateAccountsRS Response  { get { return (UpdateAccountsRS)base.Response; } }

        #endregion

        public UpdateAccounts(UpdateAccountsRQ request, UpdateAccountsRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
            foreach (VwBankAccount bankAccount in Request.BankAccounts)
            {
                bankAccount.Update(session);
            }

            Response.BankAccounts = Request.BankAccounts;

            session.Error(ErrorLevel.Info, WarningStrings.warnAccountUpdateSuccess);
        }
    }
}