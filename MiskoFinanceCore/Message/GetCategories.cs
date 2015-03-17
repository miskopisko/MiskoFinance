using MiskoPersist.Core;
using MiskoPersist.Message;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;

namespace MiskoFinanceCore.Message
{
    public class GetCategories : MessageWrapper
    {
        private static Logger Log = Logger.GetInstance(typeof(GetCategories));

        #region Properties

        public new GetCategoriesRQ Request { get { return (GetCategoriesRQ)base.Request; } }
        public new GetCategoriesRS Response { get { return (GetCategoriesRS)base.Response; } }

        #endregion

        public GetCategories(GetCategoriesRQ request, GetCategoriesRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
            Response.Categories.FetchByComposite(session, Request.Operator, Request.Status);
        }
    }
}