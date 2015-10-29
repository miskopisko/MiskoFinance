using MiskoPersist.Core;
using MiskoPersist.Message.Response;
using MiskoPersist.Data;

namespace MiskoFinanceWeb.Message.Responses
{
    public class TestDBConnectionRS : ResponseMessage
    {
        private static Logger Log = Logger.GetInstance(typeof(TestDBConnectionRS));

        #region Parameters

        public DatabaseConnections Connections { get; set; }

        #endregion

        public TestDBConnectionRS()
        {
        }
    }
}

