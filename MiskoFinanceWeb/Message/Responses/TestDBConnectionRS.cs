using MiskoPersist.Message.Response;
using MiskoPersist.Data;

namespace MiskoFinanceWeb.Message.Responses
{
    public class TestDBConnectionRS : ResponseMessage
    {
        #region Parameters

        public DatabaseConnections Connections { get; set; }

        #endregion
    }
}

