using System;
using MiskoPersist.Message;
using MiskoPersist.Core;
using MiskoFinanceWeb.Message.Requests;
using MiskoFinanceWeb.Message.Responses;

namespace MiskoFinanceWeb.Message
{
    public class TestDBConnection : MessageWrapper
    {
        private static Logger Log = Logger.GetInstance(typeof(TestDBConnection));

        #region Properties

        public new TestDBConnectionRQ Request { get { return (TestDBConnectionRQ)base.Request; } }
        public new TestDBConnectionRS Response  { get { return (TestDBConnectionRS)base.Response; } }

        #endregion

        public TestDBConnection(TestDBConnectionRQ request, TestDBConnectionRS response) : base(request, response)
        {
        }

        public override void Execute(Session session)
        {
            Response.Connections = Request.Connections;
        }
    }
}

