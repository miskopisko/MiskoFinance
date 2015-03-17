using MiskoPersist.Core;
using MiskoPersist.Enums;
using MiskoPersist.Message;
using MiskoFinanceCore.Data.Stored;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;
using MiskoFinanceCore.Resources;

namespace MiskoFinanceCore.Message
{
    public class GetTxns : MessageWrapper
    {
        private static Logger Log = Logger.GetInstance(typeof(GetTxns));

        #region Properties

        public new GetTxnsRQ Request { get { return (GetTxnsRQ)base.Request; } }
        public new GetTxnsRS Response { get { return (GetTxnsRS)base.Response; } }

        #endregion

        public GetTxns(GetTxnsRQ request, GetTxnsRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
            Response.Txns.Fetch(session, Response.Page, Request.Operator, Request.Account, Request.FromDate, Request.ToDate, Request.Category, Request.Description);
            
            Response.Summary.Operator = Request.Operator;
            Response.Summary.BankAccount = Request.Account;
            Response.Summary.FromDate = Request.FromDate;
            Response.Summary.ToDate = Request.ToDate;
            Response.Summary.Category = Request.Category;
            Response.Summary.Description = Request.Description;            
            Response.Summary.Fetch(session);
            
            if(Response.Txns == null || Response.Txns.Count == 0)
            {
            	session.Error(ErrorLevel.Info, Strings.strNoTxnsFound);
            }
        }
    }
}
