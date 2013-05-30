using System;
using MPersist.Core;
using MPersist.Core.Attributes;
using MPersist.Core.Data;
using MPersist.Core.Enums;
using MPFinance.Core.Enums;

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

        

        #endregion

        #region Constructors

        public Operator()
        {
        }

        public Operator(Session session, Persistence persistence) : base(session, persistence)
        {
        }

        public Operator(String username, String password)
        {
            IsSet = true;
            Username = username;
            Password = password;
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

        public static Operator FetchByUsername(Session session, String username)
        {
            Operator result = null;

            Persistence p = Persistence.GetInstance(session);
            p.ExecuteQuery("SELECT * FROM Operator WHERE Username = ?", new Object[] { username });
            if(p.HasNext)
            {
                result = new Operator(session, p);
            }
            p.Close();
            p = null;

            return result;
        }

        #endregion
    }
}
