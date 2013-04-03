using System;
using System.Data.Common;
using MPersistence.Core.Persistences;
using MPersist.Resources.Enums;

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

        public bool ExecuteSelect(Type clazz)
        {
            session_.PersistencePool.Add(this);

            command_.CommandText = GenerateSelectStatement(clazz);
            AddParameters();
            command_.Prepare();

            try
            {
                rs_ = command_.ExecuteReader();
            }
            catch (Exception e)
            {
                session_.Error(GetType(), ErrorLevel.Critical, e.Message);
            }

            return rs_ != null && rs_.HasRows;
        }

        #region Abstract Methods

        protected abstract String GenerateSelectStatement(Type clazz);
        protected abstract String GenerateUpdateStatement(Type clazz);
        protected abstract String GenerateDeleteStatement(Type clazz);
        protected abstract String GenerateInsertStatement(Type clazz);
        protected abstract void AddParameters();

        #endregion
    }
}
