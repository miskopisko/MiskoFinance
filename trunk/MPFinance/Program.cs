using MPersist.Core;
using MPersist.Core.Enums;
using MPFinance.Core.Enums;
using MPFinance.Forms;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MPFinance.Core.Data.Stored;

namespace MPFinance
{
    static class Program
    {
        //static Session session = new Session(SqlSessionType.MySql, ServiceLocator.GetMysqlConnection("piskuric.ca", "miskop_MPersistenceTest", "miskop_michael", "sarpatt06"));
        //static Session session = new Session(SqlSessionType.Oracle, ServiceLocator.GetOracleConnection("192.168.0.111", 1521, "xe", "MPersist", "MPersist"));
        static Session session = new Session(SqlSessionType.Sqlite, ServiceLocator.GetSqliteConnection(@"..\..\DBA\MPersist_DB.sqlite3"));

        [STAThread]
        static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;

            User user = new User();
            user.fetchByUsername(session, "miskopisko");

            if (!user.IsSet)
            {
                user.Username = "miskopisko";
                user.Password = GetMd5Hash(MD5.Create(), "secret");
                user.Birthday = new DateTime(1982, 05, 15);
                user.Email = "michael@piskuric.ca";
                user.Gender = Gender.Male;
                user.FirstName = "Michael";
                user.LastName = "Piskuric";
                user.IsSet = true;
                user.Save(session);
            }

            Application.Run(new MPFinanceMain(session, user));
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static String GetMd5Hash(MD5 md5Hash, string input)
        {
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
            return sBuilder.ToString();
        }

        // Verify a hash against a string. 
        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input. 
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
