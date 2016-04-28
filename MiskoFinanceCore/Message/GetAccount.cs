using System;
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
	public class GetAccount : MessageWrapper
    {
        private static ILog Log = LogManager.GetLogger(typeof(GetAccount));

        #region Properties

        public new GetAccountRQ Request { get { return (GetAccountRQ)base.Request; } }
        public new GetAccountRS Response { get { return (GetAccountRS)base.Response; } }

        #endregion

        public GetAccount(GetAccountRQ request, GetAccountRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
            Response.BankAccount = VwBankAccount.GetInstanceByAccountNo(session, Request.AccountNo);
            
            if(!Response.BankAccount.IsSet)
            {
            	session.Error(ErrorLevel.Error, ErrorStrings.errAccountNotFound, Request.AccountNo);
            }
        }
    }
}
