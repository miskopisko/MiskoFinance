using MPersist.Core;
using MPersist.Core.Enums;
using MPersist.Core.Message;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;
using MPFinance.Resources;
using System.Reflection;

namespace MPFinance.Core.Message
{
    public class UpdateAccount : AbstractMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(UpdateAccount));

        #region Properties

        public new UpdateAccountRQ Request
        {
            get
            {
                return (UpdateAccountRQ)base.Request;
            }
        }

        public new UpdateAccountRS Response
        {
            get
            {
                return (UpdateAccountRS)base.Response;
            }
        }

        #endregion

        public UpdateAccount(UpdateAccountRQ request, UpdateAccountRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
            Request.Account.Save(session);

            session.Error(GetType(), MethodInfo.GetCurrentMethod(), ErrorLevel.Info, WarningStrings.warnAccountUpdateSuccess);

            Response.Account = Request.Account;
        }
    }
}
