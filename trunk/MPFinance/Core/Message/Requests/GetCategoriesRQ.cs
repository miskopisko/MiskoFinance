using MPersist.Core;
using MPersist.Core.Message.Request;
using MPFinance.Core.Data.Stored;
using System;
using MPFinance.Core.Enums;

namespace MPFinance.Core.Message.Requests
{
    public class GetCategoriesRQ : AbstractRequest
    {
        private static Logger Log = Logger.GetInstance(typeof(GetCategoriesRQ));

        #region Parameters

        public Operator Operator { get; set; }
        public Status Status { get; set; }

        #endregion

        public GetCategoriesRQ()
        {

        }
    }
}
