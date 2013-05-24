using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Reflection;
using MPersist.Core.Enums;
using MPersist.Core.Resources;

namespace MPersist.Core
{
    public sealed class Session
    {
        private static Logger Log = Logger.GetInstance(typeof(Session));

        #region Variable Declarations

        private readonly DbConnection conn_;
        private Boolean transactionInProgress_ = false;
        private List<Persistence> persistencePool_ = new List<Persistence>();
        private DbTransaction transaction_;
        private ErrorMessages errorMessages_ = new ErrorMessages();
        private ErrorLevel status_ = ErrorLevel.Success;
        private MessageMode messageMode_ = MessageMode.Normal;
        private Int32 rowsPerPage_ = 20;

        #endregion

        #region Properties

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

        public ErrorLevel Status
        {
            get { return status_; }
            set { status_ = value; }
        }

        public MessageMode MessageMode
        {
            get { return messageMode_; }
            set { messageMode_ = value; }
        }

        public Int32 RowPerPage
        {
            get { return rowsPerPage_; }
            set { rowsPerPage_ = value; }
        }

        public ErrorMessages ErrorMessages
        {
            get { return errorMessages_; }
        }

        public Boolean HasErrors
        {
            get { return Contains(ErrorLevel.Error); }
        }

        public Boolean HasWarnings
        {
            get { return Contains(ErrorLevel.Warning); }
        }

        public Boolean HasConfirmations
        {
            get { return Contains(ErrorLevel.Confirmation); }
        }

        public ErrorMessages Errors
        {
            get { return ListOf(ErrorLevel.Error); }
        }

        public ErrorMessages Warnings
        {
            get { return ListOf(ErrorLevel.Warning); }
        }

        public ErrorMessages Confirmations
        {
            get { return ListOf(ErrorLevel.Confirmation); }
        }

        #endregion

        public Session(DbConnection connection)
        {
            conn_ = connection;
        }

        public void BeginTransaction()
        {
            if (transactionInProgress_ || transaction_ != null)
            {
                Error(GetType(), MethodInfo.GetCurrentMethod(), ErrorLevel.Error, ErrorStrings.errTransactionAlreadyInProgress);
            }
            else
            {
                transactionInProgress_ = true;
                transaction_ = conn_.BeginTransaction();
            }
        }

        public void EndTransaction()
        {
            if (TransactionInProgress)
            {
                if (!Status.IsCommitable() || MessageMode.Equals(MessageMode.Trial))
                {
                    Transaction.Rollback();
                }
                else
                {
                    Transaction.Commit();
                }

                transaction_ = null;
                transactionInProgress_ = false;
            }
        }

        public void FlushPersistence()
        {
            if(persistencePool_.Count > 0)
            {
                while(persistencePool_.Count > 0)
                {
                    persistencePool_[persistencePool_.Count - 1].Close();
                }
            }
        }

        public void Error(Type clazz, MethodBase method, ErrorLevel errorLevel, String message)
        {
            Error(clazz, method, errorLevel, message, null);
        }
        
        public void Error(Type clazz, MethodBase method, ErrorLevel errorLevel, String message, Object[] parameters)
        {
            ErrorMessage errorMessage = new ErrorMessage(clazz, method, errorLevel, message, parameters);

            if (errorLevel.Equals(ErrorLevel.Confirmation) && ErrorMessages.Contains(errorMessage) && ErrorMessages[ErrorMessages.IndexOf(errorMessage)].Confirmed)
            {
                return;
            }

            if (Status.Value < errorLevel.Value)
            {
                status_ = errorLevel;
            }

            ErrorMessages.Add(errorMessage);
            Log.Error(errorMessage.Message);
            errorMessage = null;

            if(!errorLevel.Equals(ErrorLevel.Warning))
            {
                throw new MPException(new ErrorMessage(GetType(), MethodInfo.GetCurrentMethod(), ErrorLevel.Error, ErrorStrings.errUnexpectedApplicationErrorShort));
            }
        }

        private Boolean Contains(ErrorLevel level)
        {
            if (level != null && ErrorMessages != null && ErrorMessages.Count > 0)
            {
                foreach (ErrorMessage message in ErrorMessages)
                {
                    if (message.Level.Equals(level))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private ErrorMessages ListOf(ErrorLevel level)
        {
            ErrorMessages list = new ErrorMessages();

            if (level != null && ErrorMessages != null && ErrorMessages.Count > 0)
            {
                foreach (ErrorMessage message in ErrorMessages)
                {
                    if (message.Level.Equals(level))
                    {
                        list.Add(message);
                    }
                }
            }

            return list;
        }
    }
}
