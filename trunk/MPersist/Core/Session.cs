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

        private readonly SqlSessionType sessionType_;
        private readonly DbConnection conn_;
        private Boolean transactionInProgress_ = false;
        private List<Persistence> persistencePool_ = new List<Persistence>();
        private DbTransaction transaction_;
        private bool errorEncountered_ = false;

        #endregion

        #region Properties

        public SqlSessionType SessionType
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

        public List<Persistence> PersistencePool
        {
            get { return persistencePool_; }
        }

        public DbTransaction Transaction
        {
            get { return transaction_; }
        }

        #endregion

        public Session(SqlSessionType sessionType, DbConnection connection)
        {
            sessionType_ = sessionType;
            conn_ = connection;
        }

        public void BeginTransaction()
        {
            if (transactionInProgress_)
            {
                Error(GetType(), MethodInfo.GetCurrentMethod(), ErrorLevel.Critical, "Transaction already in progress.");
            }
            else
            {
                transactionInProgress_ = true;
                transaction_ = conn_.BeginTransaction();
            }
        }

        public void EndTransaction()
        {
            if (transactionInProgress_)
            {
                if (errorEncountered_)
                {
                    transaction_.Rollback();
                }
                else
                {
                    transaction_.Commit();
                }

                transactionInProgress_ = false;
            }
        }

        public void Error(Type clazz, MethodBase method, ErrorLevel errorLevel, String errorMessage)
        {
            String message = clazz.Name + "." + method.Name + Environment.NewLine + errorMessage;

            Log.Error(errorMessage);
            //MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            errorEncountered_ = true;
        }
    }
}
