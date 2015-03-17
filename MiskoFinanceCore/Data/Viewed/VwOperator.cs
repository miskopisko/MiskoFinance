using System;
using MiskoPersist.Attributes;
using MiskoPersist.Core;
using MiskoPersist.Data;
using MiskoFinanceCore.Data.Stored;
using MiskoFinanceCore.Enums;

namespace MiskoFinanceCore.Data.Viewed
{
    public class VwOperator : AbstractViewedData
    {
        private static Logger Log = Logger.GetInstance(typeof(VwOperator));

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
        public DateTime Birthday { get; set; }
        [Viewed]
        public Gender Gender { get; set; }
        [Viewed]
        public VwBankAccounts BankAccounts { get; set; }
        [Viewed]
        public VwCategories Categories { get; set; }

        #endregion

        #region Constructors

        public VwOperator()
        {
        	BankAccounts = new VwBankAccounts();
        	Categories = new VwCategories();
        }

        public VwOperator(Session session, Persistence persistence)
            : base(session, persistence)
        {
        	BankAccounts = new VwBankAccounts();
        	Categories = new VwCategories();
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public Operator Update(Session session)
        {
            Operator o = new Operator();
            o.FetchById(session, OperatorId);
            
            o.Username = Username;
            o.Password = Password;
            o.FirstName = FirstName;
            o.LastName = LastName;
            o.Email = Email;
            o.Gender = Gender;
            o.Birthday = Birthday;
            o.Save(session);

            return o;
        }

        public static VwOperator GetInstanceByUsername(Session session, String username)
        {
            VwOperator result = new VwOperator();

            Persistence p = Persistence.GetInstance(session);
            p.ExecuteQuery("SELECT * FROM VwOperator WHERE Username = ?", new Object[] { username });
            result.Set(session, p);
            p.Close();
            p = null;

            return result;
        }

        #endregion
    }
}