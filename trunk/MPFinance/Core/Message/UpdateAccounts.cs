using MPersist.Core;
using MPersist.Core.Enums;
using MPersist.Core.Message;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;
using MPFinance.Resources;
using System.Reflection;

namespace MPFinance.Core.Message
{
    public class UpdateAccounts : AbstractMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(UpdateAccounts));

        #region Properties

        public new UpdateAccountsRQ Request
        {
            get
            {
                return (UpdateAccountsRQ)base.Request;
            }
        }

        public new UpdateAccountsRS Response
        {
            get
            {
                return (UpdateAccountsRS)base.Response;
            }
        }

        #endregion

        public UpdateAccounts(UpdateAccountsRQ request, UpdateAccountsRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
            Request.Accounts.Save(session);

            session.Error(ErrorLevel.Info, WarningStrings.warnAccountUpdateSuccess);

            Response.Accounts = Request.Accounts;
        }
    }
}
