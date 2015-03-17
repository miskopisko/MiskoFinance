using System;
using System.Reflection;
using MiskoPersist.Core;
using MiskoPersist.Data;
using MiskoPersist.Enums;
using MiskoPersist.Message;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;

namespace MiskoFinanceCore.Message
{
    public class TestConnection : MessageWrapper
    {
        private static Logger Log = Logger.GetInstance(typeof(TestConnection));

        #region Properties

        public new TestConnectionRQ Request { get { return (TestConnectionRQ)base.Request; } }
        public new TestConnectionRS Response { get { return (TestConnectionRS)base.Response; } }

        #endregion

        #region Constructors

        public TestConnection()
        {
        }

        public TestConnection(TestConnectionRQ request, TestConnectionRS response)
            : base(request, response)
        {
        }

        #endregion

        public override void Execute(Session session)
        {
            Persistence persistence = Persistence.GetInstance(session);

            try
            {
                persistence.ExecuteQuery("SELECT * FROM Operator");
                persistence.Close();
                persistence = null;

                session.Error(ErrorLevel.Info, "Connection successful!");
            }
            catch(Exception)
            {
                persistence.Close();
                persistence = null;

                session.Error(ErrorLevel.Confirmation, "Database not setup correctly. Would you like to set it up now?");

                foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
                {
                    if (type.Namespace == "MiskoFinanceCore.Data.Stored" && type.BaseType.IsAssignableFrom(typeof(AbstractStoredData)))
                    {
                        
                    }
                }
            }
        }
    }
}