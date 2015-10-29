using MiskoPersist.Core;
using MiskoPersist.Message.Request;
using MiskoPersist.Data;

namespace MiskoFinanceWeb.Message.Requests
{
    public class TestDBConnectionRQ : RequestMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(TestDBConnectionRQ));

        #region Parameters

        public DatabaseConnections Connections { get; set; }

        #endregion

        public TestDBConnectionRQ()
        {
        }
    }
}

