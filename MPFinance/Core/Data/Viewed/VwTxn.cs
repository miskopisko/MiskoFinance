using MPersist.Core;
using MPersist.Core.Attributes;
using MPersist.Core.Data;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Enums;
using System;
using System.Security.Cryptography;
using System.Text;

namespace MPFinance.Core.Data.Viewed
{
    public class VwTxn : AbstractViewedData
    {
        private static Logger Log = Logger.GetInstance(typeof(VwTxn));

        #region Variable Declarations

        

        #endregion

        #region Properties

        [Viewed]
        public Int64 TxnId { get; set; }
        [Viewed]
        public Int64 OperatorId { get; set; }
        [Viewed]
        public Int64 AccountId { get; set; }
        [Viewed]
        public DateTime DatePosted { get ; set; }
        [Viewed]
        public String Description { get; set; }
        [Viewed]
        public TxnType TxnType { get; set; }
        [Viewed]
        public Category Category { get; set; }
        [Viewed]
        public Money Debit { get; set; }
        [Viewed]
        public Money Credit { get; set; }
        [Viewed]
        public Boolean Transfer { get; set; }        
        
        public String HashCode { get; set; }
        public Money Amount { get; set; }        
        public Boolean IsDuplicate { get; set; }

        #endregion

        #region Constructors

        public VwTxn()
        {
        }

        public VwTxn(Session session, Persistence persistence)
        {
            set(session, persistence);
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public static VwTxn GetInstanceById(Session session, Int64 Id)
        {
            VwTxn result = new VwTxn();
            Persistence p = Persistence.GetInstance(session);
            p.ExecuteQuery("SELECT * FROM VwTxn WHERE TxnId = ?", new Object[] { Id });
            result.set(session, p);
            p.Close();
            p = null;

            return result;
        }

        public void GenerateHashCode(Account account)
        {
            MD5 md5Hash = MD5.Create();
            String input = account.BankNumber + account.AccountNumber + DatePosted.ToString() + Amount.ToString() + Description;

            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            HashCode = sBuilder.ToString();
        }

        #endregion
    }
}
