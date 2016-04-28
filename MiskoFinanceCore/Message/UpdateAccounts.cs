using log4net;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;
using MiskoFinanceCore.Resources;
using MiskoPersist.Core;
using MiskoPersist.Enums;
using MiskoPersist.Message;

namespace MiskoFinanceCore.Message
{
	public class UpdateAccounts : MessageWrapper
    {
        private static ILog Log = LogManager.GetLogger(typeof(UpdateAccounts));

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

            session.Error(ErrorLevel.Information, WarningStrings.warnAccountUpdateSuccess);
        }
    }
}
