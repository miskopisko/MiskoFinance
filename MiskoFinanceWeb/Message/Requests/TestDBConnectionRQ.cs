using MiskoPersist.Message.Request;
using MiskoPersist.Data;

namespace MiskoFinanceWeb.Message.Requests
{
    public class TestDBConnectionRQ : RequestMessage
    {
        #region Parameters

        public DatabaseConnections Connections { get; set; }

        #endregion
    }
}

