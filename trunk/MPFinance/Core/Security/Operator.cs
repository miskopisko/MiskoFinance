using System;
using MPersist.Core.Data;
using MPersist.Core;
using MPersist.Core.Attributes;
using MPFinance.Core.Enums;
using MPFinance.Core.Data;

namespace MPFinance.Security
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
        public Client Client { get; set; }

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

        public void fetchByUsername(Session session, String username)
        {
            Persistence p = Persistence.GetInstance(session);
            p.ExecuteQuery("SELECT * FROM Operator WHERE Username = ?", new Object[] { username });
            if (p.Next())
            {
                set(p);
            }
            p.Close();
            p = null;
        }

        public static Operator GetInstanceById(Session session, Int32 id)
        {
            return (Operator)fetchById(session, typeof(Operator), id, false);
        }

        public static Operator GetInstanceById(Session session, Int32 id, Boolean deep)
        {
            return (Operator)fetchById(session, typeof(Operator), id, deep);
        }

        #endregion
    }
}
