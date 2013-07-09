using MPersist.Core;
using MPersist.Core.Attributes;
using MPersist.Core.Data;
using MPersist.Core.Enums;
using MPFinance.Core.Enums;
using System;

namespace MPFinance.Core.Data.Stored
{
    public class Operator : AbstractStoredData
    {
        private static Logger Log = Logger.GetInstance(typeof(Operator));

        #region Variable Declarations



        #endregion

        #region Stored Properties

        [Stored]
        public String Username { get; set; }
        [Stored]
        public String Password { get; set; }
        [Stored]
        public String FirstName { get; set; }
        [Stored]
        public String LastName { get; set; }
        [Stored]
        public String Email { get; set; }
        [Stored]
        public DateTime? Birthday { get; set; }
        [Stored]
        public Gender Gender { get; set; }

        #endregion

        #region Other Properties

        public BankAccounts BankAccounts { get; set; }
        public Categories Categories { get; set; }

        #endregion

        #region Constructors

        public Operator()
        {
            BankAccounts = new BankAccounts();
            Categories = new Categories();
            Categories.Add(new Category(this, "---", CategoryType.NULL, Status.Active));
        }

        public Operator(Session session, Persistence persistence) : base(session, persistence)
        {
        }

        #endregion

        #region Override Methods

        public override void PreSave(Session session, UpdateMode mode)
        {
        }

        public override void PostSave(Session session, UpdateMode mode)
        {
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public static Operator GetInstanceByUsername(Session session, String username)
        {
            Operator result = new Operator();

            Persistence p = Persistence.GetInstance(session);
            p.ExecuteQuery("SELECT * FROM Operator WHERE Username = ?", new Object[] { username });
            result.Set(session, p);
            p.Close();
            p = null;

            return result;
        }

        #endregion
    }
}
