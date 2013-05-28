using MPersist.Core;
using MPersist.Core.Message.Request;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Enums;
using System;

namespace MPFinance.Core.Message.Requests
{
    public class UpdateCategoriesRQ : AbstractRequest
    {
        private static Logger Log = Logger.GetInstance(typeof(UpdateCategoriesRQ));

        #region Parameters

        public Categories ExpenseCategories { get; set; }
        public Categories IncomeCategories { get; set; }

        #endregion

        public UpdateCategoriesRQ()
        {

        }
    }
}
