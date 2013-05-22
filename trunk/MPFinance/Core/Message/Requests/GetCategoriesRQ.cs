using MPersist.Core;
using MPersist.Core.Message.Request;
using MPFinance.Core.Data.Stored;
using System;

namespace MPFinance.Core.Message.Requests
{
    public class GetCategoriesRQ : AbstractRequest
    {
        private static Logger Log = Logger.GetInstance(typeof(GetCategoriesRQ));

        #region Parameters

        public Operator Operator { get; set; }

        #endregion

        public GetCategoriesRQ()
        {

        }
    }
}
