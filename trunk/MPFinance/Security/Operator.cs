using System;
using MPersist.Core.Data;
using MPersist.Core;
using MPersist.Resources.Enums;

namespace MPFinance.Security
{
    public class Operator : AbstractStoredData
    {
        private static Logger Log = Logger.GetInstance(typeof(Operator));

        #region Variable Declarations



        #endregion

        #region Properties

        public String Username { get; set; }
        public String Password { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public DateTime? Birthday { get; set; }
        public Gender? Gender { get; set; }
        public Int32? Age { get; set; }
        public Operator TeamLead { get; set; }

        #endregion

        #region Constructors

        public Operator()
        {
        }

        public Operator(String username, String password, String name, String email, DateTime? birthday, Gender gender, Int32? age, Operator tl)
        {
            Username = username;
            Password = password;
            Name = name;
            Email = email;
            Birthday = birthday.Value;
            Gender = gender;
            Age = age.Value;
            TeamLead = tl;
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

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
