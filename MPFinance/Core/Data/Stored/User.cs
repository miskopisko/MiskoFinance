using System;
using MPersist.Core.Data;
using MPersist.Core;
using MPersist.Core.Attributes;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Enums;

namespace MPFinance.Core.Data.Stored
{
    public class User : AbstractStoredData
    {
        private static Logger Log = Logger.GetInstance(typeof(User));

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

        public User()
        {
        }

        public User(String username, String password)
        {
            IsSet = true;
            Username = username;
            Password = password;
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public void fetchByUsername(Session session, String username)
        {
            Persistence p = Persistence.GetInstance(session);
            p.ExecuteQuery("SELECT * FROM User WHERE Username = ?", new Object[] { username });
            set(session, p);
            p.close();
            p = null;
        }

        public static User GetInstanceById(Session session, Int32 id)
        {
            return (User)fetchById(session, typeof(User), id, false);
        }

        public static User GetInstanceById(Session session, Int32 id, Boolean deep)
        {
            return (User)fetchById(session, typeof(User), id, deep);
        }

        #endregion
    }
}
