using MPersist.Core;
using MPersist.Core.Data;
using MPersist.Core.Message.Request;
using MPFinance.Core.Enums;

namespace MPFinance.Core.Message.Requests
{
    public class GetCategoriesRQ : RequestMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(GetCategoriesRQ));

        #region Parameters

        public PrimaryKey Operator { get; set; }
        public Status Status { get; set; }

        #endregion

        public GetCategoriesRQ()
        {
        }
    }
}