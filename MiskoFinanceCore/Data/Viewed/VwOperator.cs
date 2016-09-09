using System;
using log4net;
using MiskoFinanceCore.Data.Stored;
using MiskoFinanceCore.Enums;
using MiskoPersist.Attributes;
using MiskoPersist.Core;
using MiskoPersist.Data.Viewed;

namespace MiskoFinanceCore.Data.Viewed
{
	public class VwOperator : ViewedData
	{
		private static ILog Log = LogManager.GetLogger(typeof(VwOperator));

		#region Fields


		#endregion

		#region Viewed Properties

		[Viewed]
		public PrimaryKey OperatorId { get; set; }
		[Viewed]
		public String Username { get; set; }
		[Viewed]
		public String Password { get; set; }
		[Viewed]
		public String FirstName { get; set; }
		[Viewed]
		public String LastName { get; set; }
		[Viewed]
		public String Email { get; set; }
		[Viewed]
		public DateTime? Birthday { get; set; }
		[Viewed]
		public Gender Gender { get; set; }
		[Viewed]
		public VwBankAccounts BankAccounts { get; set; }
		[Viewed]
		public VwCategories Categories { get; set; }

		#endregion
		
		#region Properties
		
		public override Boolean IsSet
		{
			get
			{
				return OperatorId.IsSet;
			}
		}
		
		#endregion

		#region Constructors

		public VwOperator()
        {
        }

        public VwOperator(Session session, Persistence persistence) : base(session, persistence)
        {
        }
		
		#endregion

		#region Private Methods



		#endregion

		#region Public Methods	
		
		public override void Fetch(Session session)
		{
			Persistence persistence = Persistence.GetInstance(session);
			persistence.ExecuteQuery("SELECT * FROM VwOperator WHERE OperatorId = ?", OperatorId);
			Set(session, persistence);
			persistence.Close();
			persistence = null;
		}
		
		public override void Fetch(Session session, Boolean deep)
		{
			Fetch(session);
			FetchDeep(session);
		}
		
		public override void FetchDeep(Session session)
		{
			BankAccounts = new VwBankAccounts();
			BankAccounts.FetchByOperator(session, OperatorId);
			Categories = new VwCategories();
			Categories.FetchByComposite(session, OperatorId, Status.Active);
		}

		public Person Update(Session session)
		{
			Person p = new Person();
			p.FetchById(session, OperatorId);
			
			p.Username = Username;
			p.Password = Password;
			p.FirstName = FirstName;
			p.LastName = LastName;
			p.Email = Email;
			p.Gender = Gender;
			p.Birthday = Birthday;
			p.Save(session);

			return p;
		}

		#endregion
	}
}