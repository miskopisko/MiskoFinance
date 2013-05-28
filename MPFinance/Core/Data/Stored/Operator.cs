using MPersist.Core;
using MPersist.Core.Attributes;
using MPersist.Core.Data;
using MPFinance.Core.Enums;
using System;

namespace MPFinance.Core.Data.Stored
{
    public class Operator : AbstractStoredData
    {
        private static Logger Log = Logger.GetInstance(typeof(Operator));

        #region Variable Declarations



        #endregion

        #region Properties

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

        #region Constructors

        public Operator()
        {
        }

        public Operator(String username, String password)
        {
            IsSet = true;
            Username = username;
            Password = password;
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public void FetchByUsername(Session session, String username)
        {
            Persistence p = Persistence.GetInstance(session);
            p.ExecuteQuery("SELECT * FROM Operator WHERE Username = ?", new Object[] { username });
            Set(session, p);
            p.Close();
            p = null;
        }

        public static Operator GetInstanceById(Session session, Int32 id)
        {
            return (Operator)FetchById(session, typeof(Operator), id, false);
        }

        public static Operator GetInstanceById(Session session, Int32 id, Boolean deep)
        {
            return (Operator)FetchById(session, typeof(Operator), id, deep);
        }

        #endregion
    }
}
