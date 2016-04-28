using System;
using log4net;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Enums;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;
using MiskoPersist.Core;
using MiskoPersist.Enums;
using MiskoPersist.Message;
using MiskoPersist.Tools;

namespace MiskoFinanceCore.Message
{
	public class Login : MessageWrapper
    {
        private static ILog Log = LogManager.GetLogger(typeof(Login));

        #region Properties

        public new LoginRQ Request { get { return (LoginRQ)base.Request; } }
        public new LoginRS Response  { get { return (LoginRS)base.Response; } }

        #endregion

        public Login(LoginRQ request, LoginRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
        	if(String.IsNullOrEmpty(Request.Username))
            {
                session.Error(ErrorLevel.Error, "Invalid username.");
            }             
            
            VwOperator o = VwOperator.GetInstanceByUsername(session, Request.Username);

            if(o != null && o.IsSet)
            {
            	if(!PasswordHash.ValidatePassword(Request.Password, o.Password))
            	{
            		session.Error(ErrorLevel.Error, "Invalid username or password. Please try again.");
            	}
                
            	o.BankAccounts = new VwBankAccounts();            	
                o.BankAccounts.FetchByOperator(session, o.OperatorId);
                o.Categories = new VwCategories();
                o.Categories.FetchByComposite(session, o.OperatorId, Status.Active);

                Response.Operator = o;
            }
            else
            {
                session.Error(ErrorLevel.Error, "Invalid username or password. Please try again.");
            }
        }
    }
}
