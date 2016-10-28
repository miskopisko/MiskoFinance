using System;
using log4net;
using MiskoFinanceCore.Enums;
using MiskoPersist.Core;
using MiskoPersist.Data.Stored;
using MiskoPersist.Enums;
using MiskoPersist.Attributes;

namespace MiskoFinanceCore.Data.Stored
{
	public class Person : Operator
	{
		private static ILog Log = LogManager.GetLogger(typeof(Person));
		
		#region Fields

        

        #endregion

        #region Stored Properties

        [Stored(Length = 128)]
        public String Email { get; set; }
        [Stored]
        public DateTime? Birthday { get; set; }
        [Stored]
        public Gender Gender { get; set; }

        #endregion

        #region Other Properties

        

        #endregion

        #region Constructors

        public Person()
        {
        }

        public Person(Session session, Persistence persistence) : base(session, persistence)
        {
        }

        #endregion

        #region Override Methods

		public override StoredData Create(Session session)
		{
			base.Create(session);
			PreSave(session, UpdateMode.Insert);
			Persistence.ExecuteInsert(session, this, typeof(Person));
			PostSave(session, UpdateMode.Insert);
			return this;
		}

		public override StoredData Store(Session session)
		{
			base.Store(session);
			PreSave(session, UpdateMode.Update);
			Persistence.ExecuteUpdate(session, this, typeof(Person));
			PostSave(session, UpdateMode.Update);
			return this;
		}

		public override StoredData Remove(Session session)
		{
			base.Remove(session);
			Persistence.ExecuteDelete(session, this, typeof(Person));
			PostSave(session, UpdateMode.Delete);
			return this;
		}

		public override void PreSave(Session session, UpdateMode mode)
		{
			base.PreSave(session, mode);
			
			if (String.IsNullOrEmpty(Email))
			{
				session.Error(ErrorLevel.Error, "Email cannot be blank");
			}
			if (Gender == null || !Gender.IsSet)
			{
				session.Error(ErrorLevel.Error, "Gender must be set");
			}
			if (Birthday == null || !Birthday.HasValue || Birthday.Value == DateTime.MinValue)
			{
				session.Error(ErrorLevel.Error, "Birthday must be set");
			}
		}

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

                

        #endregion
	}
}
