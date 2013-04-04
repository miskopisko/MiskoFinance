using System;
using MPersist.Core;
using MPersist.Resources.Enums;
using MPersist.Core.Data;

namespace MPersist.Security
{
    public class OperatorProfile : AbstractStoredData
    {
        private static Logger Log = Logger.GetInstance(typeof(OperatorProfile));

        #region Variable Declarations



        #endregion

        #region Properties

        public String Name { get; set; }
        public String Email { get; set; }
        public DateTime? Birthday { get; set; }
        public Gender Gender { get; set; }
        public Int32? Age { get; set; }
        public OperatorProfile TeamLead { get; set; }

        #endregion

        #region Constructors

        public OperatorProfile()
        {
        }

        public OperatorProfile(String name, String email, DateTime? birthday, Gender gender, Int32? age, OperatorProfile tl)
        {
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
