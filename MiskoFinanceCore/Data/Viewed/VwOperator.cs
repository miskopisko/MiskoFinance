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
			BankAccounts = new VwBankAccounts();
			Categories = new VwCategories();
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
			using (Persistence persistence = session.GetPersistence())
			{
				persistence.ExecuteQuery("SELECT * FROM VwOperator WHERE OperatorId = ?", OperatorId);
				Set(session, persistence);
			}
		}
		
		public override void Fetch(Session session, Boolean deep)
		{
			Fetch(session);
			if (deep)
			{
				FetchDeep(session);
			}
		}
		
		public override void FetchDeep(Session session)
		{
			BankAccounts = new VwBankAccounts();
			BankAccounts.FetchByOperator(session, OperatorId);
			Categories = new VwCategories();
			Categories.FetchByComposite(session, OperatorId);
		}

		public void Update(Session session, String password1, String password2)
		{
			Person p = new Person();
			p.FetchById(session, OperatorId);

            p.Id = OperatorId;
			p.Username = Username;
			p.FirstName = FirstName;
			p.LastName = LastName;
			p.Email = Email;
			p.Gender = Gender;
			p.Birthday = Birthday;

            // Only reset the password of a new password was sent
            if (!String.IsNullOrEmpty(password1) || !String.IsNullOrEmpty(password2))
            {
                p.SetPassword(session, password1, password2);
            }

            p.Save(session);

            OperatorId = p.Id;
		}

		#endregion
	}
}