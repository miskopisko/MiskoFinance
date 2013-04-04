using MPersist.Security;
using System;
using System.Data.Common;
using System.Collections.Generic;
using MPersist.Resources.Enums;
using System.Windows.Forms;
using System.Reflection;

namespace MPersist.Core
{
    public sealed class Session
    {
        private static Logger Log = Logger.GetInstance(typeof(Session));

        #region Variable Declarations

        private readonly SessionType sessionType_;
        private readonly DbConnection conn_;
        private Boolean transactionInProgress_ = false;
        private OperatorProfile operator_;
        private List<Persistence> persistencePool_ = new List<Persistence>();

        #endregion

        #region Properties

        public SessionType SessionType
        {
            get { return sessionType_; }
        }

        public DbConnection Connection
        {
            get { return conn_; }
        }

        public Boolean TransactionInProgress
        {
            get { return transactionInProgress_; }
        }

        public OperatorProfile Operator
        {
            get { return operator_; }
            set { operator_ = value; }
        }

        public List<Persistence> PersistencePool
        {
            get { return persistencePool_; }
        }

        #endregion

        public Session(SessionType sessionType, DbConnection connection)
        {
            sessionType_ = sessionType;
            conn_ = connection;
        }

        public void Error(Type clazz, MethodBase method, ErrorLevel errorLevel, String errorMessage)
        {
            String message = clazz.Name + "." + method.Name + Environment.NewLine + errorMessage;

            Log.Error(errorMessage);
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
