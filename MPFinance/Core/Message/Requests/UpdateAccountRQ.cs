using MPersist.Core;
using MPersist.Core.Message.Request;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Enums;
using System;

namespace MPFinance.Core.Message.Requests
{
    public class UpdateAccountRQ : AbstractRequest
    {
        private static Logger Log = Logger.GetInstance(typeof(UpdateAccountRQ));

        #region Parameters

        public Account Account { get; set; }

        #endregion

        public UpdateAccountRQ()
        {
        }
    }
}
