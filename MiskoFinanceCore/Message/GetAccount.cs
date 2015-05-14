using System;
using MiskoPersist.Core;
using MiskoPersist.Enums;
using MiskoPersist.Message;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;
using MiskoFinanceCore.Resources;

namespace MiskoFinanceCore.Message
{
    public class GetAccount : MessageWrapper
    {
        private static Logger Log = Logger.GetInstance(typeof(GetAccount));

        #region Properties

        public new GetAccountRQ Request { get { return (GetAccountRQ)base.Request; } }
        public new GetAccountRS Response { get { return (GetAccountRS)base.Response; } }

        #endregion

        public GetAccount(GetAccountRQ request, GetAccountRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
            Response.BankAccount.FetchByAccountNo(session, Request.AccountNo);
            
            if(Response.BankAccount.BankAccountId == null || Response.BankAccount.BankAccountId.IsNotSet)
            {
            	session.Error(ErrorLevel.Error, ErrorStrings.errAccountNotFound, new Object[] { Request.AccountNo });
            }
        }
    }
}
