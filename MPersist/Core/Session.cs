﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Reflection;
using MPersist.Enums;
using MPersist.Message.Request;
using MPersist.Resources;

namespace MPersist.Core
{
    public sealed class Session
    {
        private static Logger Log = Logger.GetInstance(typeof(Session));

        #region Fields

        private readonly DbConnection mConn_;
        private readonly String mConnectionName_;
        private Boolean mTransactionInProgress_ = false;
        private List<Persistence> mPersistencePool_ = new List<Persistence>();
        private DbTransaction mTransaction_;
        private ErrorMessages mErrorMessages_ = new ErrorMessages();
        private ErrorLevel mStatus_ = ErrorLevel.Success;
        private MessageMode mMessageMode_ = MessageMode.Normal;
        private Int32 mRowsPerPage_ = 20;

        #endregion

        #region Properties

        public DbConnection Connection { get { return mConn_; } }
        public String ConnectionName { get { return mConnectionName_; } }
        public Boolean TransactionInProgress { get { return mTransactionInProgress_; } }
        public List<Persistence> PersistencePool { get { return mPersistencePool_; } }
        public DbTransaction Transaction { get { return mTransaction_; } }
        public ErrorLevel Status { get { return mStatus_; } set { mStatus_ = value; } }
        public MessageMode MessageMode { get { return mMessageMode_; } set { mMessageMode_ = value; } }
        public Int32 RowPerPage { get { return mRowsPerPage_; } set { mRowsPerPage_ = value; } }
        public ErrorMessages ErrorMessages { get { return mErrorMessages_; } }

        #endregion

        #region Constructors

        public Session(DbConnection conn, RequestMessage request)
        {
            mConn_ = conn;
            mConnectionName_ = request.Connection;
            mMessageMode_ = request.MessageMode;
            mErrorMessages_.AddRange(request.Confirmations);
            mRowsPerPage_ = request.RowsPerPage;
        }

        #endregion

        #region Public Methods

        public void BeginTransaction()
        {
            if (mTransactionInProgress_)
            {
                Error(ErrorLevel.Error, ErrorStrings.errTransactionAlreadyInProgress);
            }
            else
            {
                mTransactionInProgress_ = true;
                mTransaction_ = mConn_.BeginTransaction();
            }
        }

        public void EndTransaction()
        {
            if (TransactionInProgress)
            {
                if (!Status.IsCommitable || MessageMode.Equals(MessageMode.Trial))
                {
                    mTransaction_.Rollback();
                }
                else
                {
                    mTransaction_.Commit();
                }

                mTransaction_ = null;
                mTransactionInProgress_ = false;
            }
        }

        public void FlushPersistence()
        {
            while (mPersistencePool_.Count > 0)
            {
                mPersistencePool_[mPersistencePool_.Count - 1].Close();
            }
        }

        public void Error(ErrorLevel errorLevel, String message)
        {
            StackFrame stackFrame = new StackFrame(1);
            Error(stackFrame.GetMethod().DeclaringType, stackFrame.GetMethod(), errorLevel, message, null);
        }

        public void Error(ErrorLevel errorLevel, String message, String[] parameters)
        {
            StackFrame stackFrame = new StackFrame(1);
            Error(stackFrame.GetMethod().DeclaringType, stackFrame.GetMethod(), errorLevel, message, parameters);
        }

        private void Error(Type clazz, MethodBase method, ErrorLevel errorLevel, String message, String[] parameters)
        {
            ErrorMessage errorMessage = new ErrorMessage(clazz, method, errorLevel, message, parameters);

            if (errorLevel.Equals(ErrorLevel.Confirmation) && ErrorMessages.Contains(errorMessage) && ErrorMessages[ErrorMessages.IndexOf(errorMessage)].Confirmed.Value)
            {
                return;
            }

            if (Status.Value < errorLevel.Value)
            {
                mStatus_ = errorLevel;
            }

            ErrorMessages.Add(errorMessage);

            if (!errorLevel.Equals(ErrorLevel.Warning) && !errorLevel.Equals(ErrorLevel.Info))
            {
                if (errorLevel.Equals(ErrorLevel.Error))
                {
                    Log.Error(errorMessage.Message);
                }
                throw new MPException("Houston we have a problem!");
            }
        }

        #endregion
    }
}
