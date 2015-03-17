using MiskoPersist.Core;
using MiskoPersist.Data;
using MiskoPersist.Message.Request;
using MiskoFinanceCore.Enums;

namespace MiskoFinanceCore.Message.Requests
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
