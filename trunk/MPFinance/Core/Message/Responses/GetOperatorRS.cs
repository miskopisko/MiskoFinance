using MPersist.Core;
using MPersist.Core.Message.Response;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Data.Viewed;

namespace MPFinance.Core.Message.Responses
{
    public class GetOperatorRS : AbstractResponse
    {
        private static Logger Log = Logger.GetInstance(typeof(GetOperatorRS));

        #region Parameters

        public Operator Operator { get; set; }
        public Accounts Accounts { get; set; }
        public Categories IncomeCategories { get; set; }
        public Categories ExpenseCategories { get; set; }
        public Categories TransferCategories { get; set; }
        public Categories AllCategories { get; set; }
        public VwTxns Txns { get; set; }
        public VwSummary Summary { get; set; }

        #endregion

        public GetOperatorRS()
        {
            Operator = new Operator();
            Accounts = new Accounts();
            IncomeCategories = new Categories();
            ExpenseCategories = new Categories();
            TransferCategories = new Categories();
            AllCategories = new Categories();
            Txns = new VwTxns();
            Summary = new VwSummary();
        }
    }
}
