using MPersist.Core;
using MPersist.Data;
using MPersist.Message.Request;
using MPFinanceCore.Enums;

namespace MPFinanceCore.Message.Requests
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
