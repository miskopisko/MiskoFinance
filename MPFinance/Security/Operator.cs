using System;
using MPersist.Core.Data;
using MPersist.Core;
using MPersist.Resources.Enums;
using MPersist.Core.Attributes;

namespace MPFinance.Security
{
    public class OperatorProfile : AbstractStoredData
    {
        private static Logger Log = Logger.GetInstance(typeof(OperatorProfile));

        #region Variable Declarations



        #endregion

        #region Properties

        [Stored]
        public String Username { get; set; }
        [Stored]
        public String Password { get; set; }
        [Stored]
        public String Name { get; set; }
        [Stored]
        public String Email { get; set; }
        [Stored]
        public DateTime? Birthday { get; set; }
        [Stored]
        public Gender Gender { get; set; }
        [Stored]
        public Int32? Age { get; set; }
        [Stored]
        public OperatorProfile TeamLead { get; set; }

        public bool IsFollower { get{ return TeamLead == null;} }

        #endregion

        #region Constructors

        public OperatorProfile()
        {
        }

        public OperatorProfile(String username, String password, String name, String email, DateTime? birthday, Gender gender, Int32? age, OperatorProfile tl)
        {
            IsSet = true;
            Username = username;
            Password = password;
            Name = name;
            Email = email;
            Birthday = birthday;
            Gender = gender;
            Age = age;
            TeamLead = tl;
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public static OperatorProfile GetInstanceById(Session session, Int32 id)
        {
            return (OperatorProfile)fetchById(session, typeof(OperatorProfile), id, false);
        }

        public static OperatorProfile GetInstanceById(Session session, Int32 id, Boolean deep)
        {
            return (OperatorProfile)fetchById(session, typeof(OperatorProfile), id, deep);
        }

        #endregion
    }
}
