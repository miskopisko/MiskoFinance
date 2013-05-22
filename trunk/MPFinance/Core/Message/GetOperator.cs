using MPersist.Core;
using MPersist.Core.Enums;
using MPersist.Core.Message;
using MPFinance.Core.Data.Stored;
using MPFinance.Core.Enums;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;
using MPFinance.Resources;
using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace MPFinance.Core.Message
{
    public class GetOperator : AbstractMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(GetOperator));

        #region Properties

        public new GetOperatorRQ Request
        {
            get
            {
                return (GetOperatorRQ)base.Request;
            }
        }

        public new GetOperatorRS Response
        {
            get
            {
                return (GetOperatorRS)base.Response;
            }
        }

        #endregion

        public GetOperator(GetOperatorRQ request, GetOperatorRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
            Operator o = new Operator(); 
            o.FetchByUsername(session, Request.Username);

            if (!o.IsSet)
            {
                session.Error(GetType(), MethodInfo.GetCurrentMethod(), ErrorLevel.Confirmation, ConfirmStrings.conConfirmNewUser, new object[]{ Request.Username });

                o.Username = Request.Username;
                o.Password = GenerateHash("secret");
                o.Birthday = new DateTime(1982, 05, 15);
                o.Email = "michael@piskuric.ca";
                o.Gender = Gender.Male;
                o.FirstName = "Michael";
                o.LastName = "Piskuric";
                o.IsSet = true;
                o.Save(session);
            }

            Response.Operator = o;
        }

        private String GenerateHash(String input)
        {
            MD5 md5Hash = MD5.Create();

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
    }
}
