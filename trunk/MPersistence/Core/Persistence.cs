﻿using System;
using System.Data.Common;
using MPersistence.Core.Persistences;
using MPersist.Resources.Enums;
using MPersist.Core.Data;
using MySql.Data.MySqlClient;
using System.Data.OracleClient;
using System.Data.SQLite;
using System.Data;

namespace MPersist.Core
{
    public abstract class Persistence
    {
        #region Variable Declarations

        protected Session session_ = null;
        protected DbDataReader rs_ = null;
        protected DbCommand command_ = null;
        protected String sql_ = "";
        protected Parameters parameters_ = new Parameters();
        
        #endregion

        #region Properties

        public String SQL
        {
            get { return sql_; }
            set { sql_ = value; }
        }

        public Parameters Parameters
        {
            get { return parameters_; }
            set { parameters_ = value; }
        }

        public Boolean HasRows
        {
            get { return rs_ != null && rs_.HasRows; }
        }

        public DbDataReader Results
        {
            get { return rs_; }
        }
       
        #endregion

        public Persistence(Session session)
        {
            session_ = session;
        }

        public static Persistence GetInstance(Session session)
        {
            switch (session.SessionType)
            {
                case MPersist.Resources.Enums.SessionType.Oracle:
                    return new OraclePersistence(session);
                case MPersist.Resources.Enums.SessionType.MySql:
                    return new MySqlPersistence(session);
                case MPersist.Resources.Enums.SessionType.Sqlite:
                    return new SqlitePersistence(session);
                default:
                    return null;
            }
        }

        public void Close()
        {
            try
            {
                Exception e = null;
                try
                {
                    if (rs_ != null)
                    {
                        rs_.Close();
                        rs_ = null;
                    }
                }
                catch (Exception ex)
                {
                    e = ex;
                    rs_ = null;
                }

                try
                {
                    if (command_ != null)
                    {
                        command_.Dispose();
                        command_ = null;
                    }
                }
                catch (Exception ex)
                {
                    if (e == null)
                    {
                        e = ex;
                    }
                    command_ = null;
                }

                if (e != null)
                {
                    throw e;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                sql_ = "";
                parameters_ = new Parameters();
                session_.PersistencePool.Remove(this);
            }
        }

        #region Execute Methods

        public bool ExecuteSelect(Type clazz)
        {
            session_.PersistencePool.Add(this);

            command_.CommandText = GenerateSelectStatement(clazz);
            command_.Prepare();

            try
            {
                rs_ = command_.ExecuteReader();
            }
            catch (Exception e)
            {
                session_.Error(GetType(), ErrorLevel.Critical, e.Message);
            }

            return rs_ != null && rs_.Read();
        }

        public bool ExecuteUpdate(AbstractStoredData clazz)
        {
            session_.PersistencePool.Add(this);

            command_.CommandText = GenerateUpdateStatement(clazz);
            command_.Prepare();

            try
            {
                return command_.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                session_.Error(GetType(), ErrorLevel.Critical, e.Message);
            }

            return false;
        }

        public int ExecuteInsert(AbstractStoredData clazz)
        {
            session_.PersistencePool.Add(this);

            command_.CommandText = GenerateInsertStatement(clazz);
            command_.Prepare();

            try
            {
                if (command_ is MySqlCommand || command_ is SQLiteCommand)
                {
                    return Int32.Parse(command_.ExecuteScalar().ToString());
                }
                else if (command_ is OracleCommand)
                {
                    OracleParameter lastId = new OracleParameter(":LASTID", OracleType.Int32);
                    lastId.Direction = ParameterDirection.Output;
                    ((OracleCommand)command_).Parameters.Add(lastId);

                    command_.ExecuteNonQuery();

                    return (Int32)lastId.Value;
                }
            }
            catch (Exception e)
            {
                session_.Error(GetType(), ErrorLevel.Critical, e.Message);
            }

            return -1;
        }

        public bool ExecuteDelete(AbstractStoredData clazz)
        {
            session_.PersistencePool.Add(this);

            command_.CommandText = GenerateDeleteStatement(clazz);
            command_.Prepare();

            try
            {
                return command_.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                session_.Error(GetType(), ErrorLevel.Critical, e.Message);
            }

            return false;
        }

        public bool ExecuteQuery(String sql)
        {
            session_.PersistencePool.Add(this);

            command_.CommandText = sql;
            command_.Prepare();

            try
            {
                rs_ = command_.ExecuteReader();                
            }
            catch (Exception e)
            {
                session_.Error(GetType(), ErrorLevel.Critical, e.Message);
            }

            return rs_ != null && rs_.Read();
        }

        #endregion

        #region Abstract Methods

        protected abstract String GenerateSelectStatement(Type clazz);
        protected abstract String GenerateUpdateStatement(AbstractStoredData clazz);
        protected abstract String GenerateDeleteStatement(AbstractStoredData clazz);
        protected abstract String GenerateInsertStatement(AbstractStoredData clazz);

        #endregion
    }
}
