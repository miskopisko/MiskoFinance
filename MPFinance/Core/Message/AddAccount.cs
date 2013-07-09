using MPersist.Core;
using MPersist.Core.Enums;
using MPersist.Core.Message;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;
using MPFinance.Resources;
using System;

namespace MPFinance.Core.Message
{
    public class AddAccount : AbstractMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(AddAccount));

        #region Properties

        public new AddAccountRQ Request
        {
            get
            {
                return (AddAccountRQ)base.Request;
            }
        }

        public new AddAccountRS Response
        {
            get
            {
                return (AddAccountRS)base.Response;
            }
        }

        #endregion

        public AddAccount(AddAccountRQ request, AddAccountRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
            Request.Account.Save(session);

            session.Error(ErrorLevel.Confirmation, ConfirmStrings.conCreateNewAccount, new Object[] { Request.Account.AccountNumber });

            Response.NewAccount = Request.Account;
        }
    }
}
