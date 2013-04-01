using System;
using System.Collections.Generic;
using System.Data.Common;
using MPersistence.Core.Persistences;
using MPersist.Core.Data;
using System.Data;

namespace MPersist.Core
{
    public abstract class Persistence
    {
        #region Variable Declarations

        private Session session_ = null;
        private DbDataReader rs_ = null;
        private DbCommand command_ = null;
        private String sql_ = "";
	    private List<Object> parameters_ = new List<Object>();
        
        #endregion

        #region Properties

        public String SQL
        {
            get { return sql_; }
            set { sql_ = value; }
        }

        public Boolean IsEOF
        {
            get { return rs_ != null && !rs_.IsClosed; }
        }

        public Int32 RecordCount
        {
            get { return rs_ != null ? rs_.RecordsAffected : 0; }
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
                parameters_ = new List<Object>();
                session_.PersistencePool.Remove(this);
            }
        }

        private int ExecuteCommand()
        {
            session_.PersistencePool.Add(this);

            command_.Prepare();
            rs_ = command_.ExecuteReader();

            return command_.ExecuteNonQuery();
        }

        private void perepareParameters()
        {
            //command_.Parameters.Add(new DbParameter());
        }

        #region Abstract Methods

        public abstract void GenerateSelectStatement(Type clazz, Parameters parameters);
        public abstract void GenerateUpdateStatement(Type clazz, Parameters parameters);
        public abstract void GenerateDeleteStatement(Type clazz, Parameters parameters);
        public abstract void GenerateInsertStatement(Type clazz);

        #endregion

    }
}
