using System;
using MiskoFinanceCore.Enums;
using MiskoPersist.Attributes;
using MiskoPersist.Core;
using MiskoPersist.Data;
using MiskoPersist.Enums;

namespace MiskoFinanceCore.Data.Stored
{
    public class Operator : AbstractStoredData
    {
        private static Logger Log = Logger.GetInstance(typeof(Operator));

        #region Fields

        

        #endregion

        #region Stored Properties

        [Stored(Length = 128)]
        public String Username { get; set; }
        [Stored(Length = 32)]
        public String Password { get; set; }
        [Stored(Length = 128)]
        public String FirstName { get; set; }
        [Stored(Length = 128)]
        public String LastName { get; set; }
        [Stored(Length = 128)]
        public String Email { get; set; }
        [Stored]
        public DateTime Birthday { get; set; }
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

        #endregion

        #region Override Methods

        public override AbstractStoredData Create(Session session)
        {
            PreSave(session, UpdateMode.Insert);
            Persistence.ExecuteInsert(session, this, typeof(Operator));
            PostSave(session, UpdateMode.Insert);
            return this;
        }

        public override AbstractStoredData Store(Session session)
        {
            PreSave(session, UpdateMode.Update);
            Persistence.ExecuteUpdate(session, this, typeof(Operator));
            PostSave(session, UpdateMode.Update);
            return this;
        }

        public override AbstractStoredData Remove(Session session)
        {
            Persistence.ExecuteDelete(session, this, typeof(Operator));
            PostSave(session, UpdateMode.Delete);
            return this;
        }

        public void PreSave(Session session, UpdateMode mode)
        {
            if (String.IsNullOrEmpty(FirstName))
            {
                session.Error(ErrorLevel.Error, "First name cannot be blank");
            }

            if (String.IsNullOrEmpty(LastName))
            {
                session.Error(ErrorLevel.Error, "Last name cannot be blank");
            }

            if (String.IsNullOrEmpty(Email))
            {
                session.Error(ErrorLevel.Error, "Email cannot be blank");
            }

            if (Gender == null || Gender.IsNotSet)
            {
                session.Error(ErrorLevel.Error, "Gender must be set");
            }

        }

        public void PostSave(Session session, UpdateMode mode)
        {
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

                

        #endregion
    }
}
