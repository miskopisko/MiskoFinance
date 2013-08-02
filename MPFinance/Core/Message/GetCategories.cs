using MPersist.Core;
using MPersist.Core.Message;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;

namespace MPFinance.Core.Message
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
