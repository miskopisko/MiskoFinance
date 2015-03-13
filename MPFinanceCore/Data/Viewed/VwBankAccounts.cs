using System;
using MPersist.Core;
using MPersist.Data;

namespace MPFinanceCore.Data.Viewed
{
    public class VwBankAccounts : AbstractViewedDataList<VwBankAccount>
    {
        private static Logger Log = Logger.GetInstance(typeof(VwBankAccounts));

        #region Fields



        #endregion

        #region Properties



        #endregion

        #region Constructors

        public VwBankAccounts()
        {
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods
        
        public VwBankAccounts getAllAccounts()
        {
        	VwBankAccounts bankAccounts = new VwBankAccounts();
        	bankAccounts.Add(new VwBankAccount{Nickname="All"});
        	bankAccounts.AddRange(this);
        	return bankAccounts;
        }

        public void FetchByOperator(Session session, PrimaryKey o)
        {
            Persistence p = Persistence.GetInstance(session);
            p.ExecuteQuery("SELECT * FROM VwBankAccount WHERE OperatorId = ?", new Object[] { o });
            Set(session, p);
            p.Close();
            p = null;
        }

        #endregion
    }
}