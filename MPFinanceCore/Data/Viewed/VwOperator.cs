using System;
using MPersist.Attributes;
using MPersist.Core;
using MPersist.Data;
using MPFinanceCore.Data.Stored;
using MPFinanceCore.Enums;

namespace MPFinanceCore.Data.Viewed
{
    public class VwOperator : AbstractViewedData
    {
        private static Logger Log = Logger.GetInstance(typeof(VwOperator));

        #region Event Delegates

        public delegate void BankAccountsChangedHandler();
        public event BankAccountsChangedHandler BankAccountsChanged;

        public delegate void CategoriesChangedHandler();
        public event CategoriesChangedHandler CategoriesChanged;

        #endregion

        #region Fields

        private VwBankAccounts mBankAccounts_ = new VwBankAccounts();
        private VwCategories mCategories_ = new VwCategories();

        #endregion

        #region Viewed Properties

        [Viewed]
        public PrimaryKey OperatorId { get; set; }
        [Viewed]
        public String Username { get; set; }
        [Viewed]
        public String Password { get; set; }
        [Viewed]
        public String FirstName { get; set; }
        [Viewed]
        public String LastName { get; set; }
        [Viewed]
        public String Email { get; set; }
        [Viewed]
        public DateTime Birthday { get; set; }
        [Viewed]
        public Gender Gender { get; set; }

        #endregion

        #region Other Properties

        public VwBankAccounts BankAccounts
        {
            get { return mBankAccounts_; }
            set
            {
                mBankAccounts_ = value;
                if (BankAccountsChanged != null)
                {
                    BankAccountsChanged();
                }
            }
        }

        public VwCategories Categories
        {
            get { return mCategories_; }
            set
            {
                mCategories_ = value;
                if (CategoriesChanged != null)
                {
                    CategoriesChanged();
                }
            }
        }

        #endregion

        #region Constructors

        public VwOperator()
        {
        }

        public VwOperator(Session session, Persistence persistence)
            : base(session, persistence)
        {
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public Operator Update(Session session)
        {
            Operator o = new Operator();
            o.FetchById(session, OperatorId);
            
            o.Username = Username;
            o.Password = Password;
            o.FirstName = FirstName;
            o.LastName = LastName;
            o.Email = Email;
            o.Gender = Gender;
            o.Birthday = Birthday;
            o.Save(session);

            return o;
        }

        public void Refresh()
        {
            if (BankAccountsChanged != null)
            {
                BankAccountsChanged();
            }

            if (CategoriesChanged != null)
            {
                CategoriesChanged();
            }
        }

        public static VwOperator GetInstanceByUsername(Session session, String username)
        {
            VwOperator result = new VwOperator();

            Persistence p = Persistence.GetInstance(session);
            p.ExecuteQuery("SELECT * FROM VwOperator WHERE Username = ?", new Object[] { username });
            result.Set(session, p);
            p.Close();
            p = null;

            return result;
        }

        #endregion
    }
}