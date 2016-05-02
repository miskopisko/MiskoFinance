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
	public class GetTxns : MessageWrapper
    {
        private static ILog Log = LogManager.GetLogger(typeof(GetTxns));

        #region Properties

        public new GetTxnsRQ Request { get { return (GetTxnsRQ)base.Request; } }
        public new GetTxnsRS Response { get { return (GetTxnsRS)base.Response; } }

        #endregion

        public GetTxns(GetTxnsRQ request, GetTxnsRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
        	Response.Txns = new VwTxns();
        	Response.Txns.Fetch(session, Request.Page, Request.Operator, Request.Account, Request.FromDate, Request.ToDate, Request.Category, Request.Description);
        	
        	Response.Summary = new VwSummary();
        	Response.Summary.Fetch(session, Request.Operator, Request.Account, Request.FromDate, Request.ToDate, Request.Category, Request.Description);
            
        	Response.Page = Request.Page;
        	
            if(Response.Txns == null || Response.Txns.Count == 0)
            {
            	session.Error(ErrorLevel.Information, ErrorStrings.errNotTxnsFound);
            }           
        }
    }
}
