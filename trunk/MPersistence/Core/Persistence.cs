using System;
using System.Data.Common;
using MPersistence.Core.Persistences;
using MPersist.Resources.Enums;
using MPersist.Core.Data;
using MySql.Data.MySqlClient;
using System.Data.OracleClient;
using System.Data.SQLite;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;

namespace MPersist.Core
{
    public abstract class Persistence
    {
        #region Variable Declarations

        protected Session session_ = null;
        protected DataTable rs_ = new DataTable();
        protected DbCommand command_ = null;
        protected String sql_ = "";
        protected Parameters parameters_ = new Parameters();
        protected DataRow result_;
        protected Int32 currentResult_ = 0;
        
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
            get { return rs_ != null && rs_.Rows.Count > 0; }
        }

        public DataTable Results
        {
            get { return rs_; }
        }

        public Int32 RecordCount
        {
            get { return rs_ != null ? rs_.Rows.Count : 0; }
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

        public void Next()
        {
            if (currentResult_ < rs_.Rows.Count)
            {
                currentResult_ ++;
                result_ = rs_.Rows[currentResult_];
            }
        }        

        #region Execute Methods

        public bool ExecuteSelect(Type clazz)
        {
            return ExecuteResultSetQuery(GenerateSelectStatement(clazz));
        }

        public bool ExecuteUpdate(AbstractStoredData clazz)
        {
            session_.PersistencePool.Add(this);

            command_.CommandText = GenerateUpdateStatement(clazz);
            FillDbParameters();

            try
            {
                return command_.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                session_.Error(GetType(), MethodInfo.GetCurrentMethod(), ErrorLevel.Critical, e.Message);
            }

            return false;
        }

        public int ExecuteInsert(AbstractStoredData clazz)
        {
            session_.PersistencePool.Add(this);

            command_.CommandText = GenerateInsertStatement(clazz);
            FillDbParameters();

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
                session_.Error(GetType(), MethodInfo.GetCurrentMethod(), ErrorLevel.Critical, e.Message);
            }

            return -1;
        }

        public bool ExecuteDelete(AbstractStoredData clazz)
        {
            session_.PersistencePool.Add(this);

            command_.CommandText = GenerateDeleteStatement(clazz);
            FillDbParameters();

            try
            {
                return command_.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                session_.Error(GetType(), MethodInfo.GetCurrentMethod(), ErrorLevel.Critical, e.Message);
            }

            return false;
        }

        public bool ExecuteResultSetQuery(String sql)
        {
            session_.PersistencePool.Add(this);

            command_.CommandText = sql;
            FillDbParameters();

            try
            {
                DbDataAdapter adapter = null;

                if(command_ is OracleCommand)
                {
                    adapter = new OracleDataAdapter((OracleCommand)command_);                    
                }
                else if(command_ is MySqlCommand)
                {
                    adapter = new MySqlDataAdapter((MySqlCommand)command_);
                }
                else if(command_ is SQLiteCommand)
                {
                    adapter = new SQLiteDataAdapter((SQLiteCommand)command_);
                }

                adapter.Fill(rs_);
            }
            catch (Exception e)
            {
                session_.Error(GetType(), MethodInfo.GetCurrentMethod(), ErrorLevel.Critical, e.Message);
            }

            if (HasRows)
            {
                result_ = rs_.Rows[currentResult_];
            }

            return HasRows;
        }

        #endregion

        #region Abstract Methods

        protected abstract void FillDbParameters();
        protected abstract String GenerateSelectStatement(Type clazz);
        protected abstract String GenerateUpdateStatement(AbstractStoredData clazz);
        protected abstract String GenerateDeleteStatement(AbstractStoredData clazz);
        protected abstract String GenerateInsertStatement(AbstractStoredData clazz);

        #endregion

        #region Helpers

        public Boolean? GetBoolean(String key)
        {
            Int32 ordinal = rs_.Columns.IndexOf(key);
            Object o = (Object)result_.ItemArray[ordinal];

            if (o == null)
            {
                return null;
            }
            else if (o is Boolean)
            {
                return (Boolean)o;
            }
            else if (o is Decimal || o is Int32 || o is Int64 || o is Byte || o is uint)
            {
                return Convert.ToInt16(o) == 1;
            }

            return null;
        }

        public String GetString(String key)
        {
            Int32 ordinal = rs_.Columns.IndexOf(key);
            Object o = (Object)result_.ItemArray[ordinal];

            if (o is String)
            {
                return (String)o;
            }
            else if (o is Byte[])
            {
                Byte[] asBytes = (Byte[])o;
                String asValue = "";

                for (int i = 0; i < asBytes.Length; i++)
                {
                    asValue += (Char)asBytes[i];
                }

                return asValue;
            }
            else if (o != null)
            {
                return o.ToString().Trim().Length != 0 ? o.ToString().Trim() : null;
            }

            return null;
        }

        public Int32? GetInt(String key)
        {
            Int32 ordinal = rs_.Columns.IndexOf(key);
            Object o = (Object)result_.ItemArray[ordinal];

            if (o == null)
            {
                return null;
            }
            else if (o is Int32)
            {
                return (Int32)o;
            }
            else if (o is sbyte || o is Byte || o is Int64 || o is Decimal)
            {
                return Convert.ToInt32(o);
            }
            else if (o is String)
            {
                try
                {
                    return Int32.Parse((String)o);
                }
                catch
                {
                }
            }

            return null;
        }

        public Int64? GetLong(String key)
        {
            Int32 ordinal = rs_.Columns.IndexOf(key);
            Object o = (Object)result_.ItemArray[ordinal];

            if (o == null)
            {
                return null;
            }
            else if (o is Int64)
            {
                return (Int64)o;
            }
            else if (o is UInt64)
            {
                return Convert.ToInt64((UInt64)o);
            }
            else if (o is Int32)
            {
                return Convert.ToInt64((Int32)o);
            }
            else if (o is uint)
            {
                return Convert.ToInt64((uint)o);
            }
            else if (o is Decimal)
            {
                return Convert.ToInt64((Decimal)o);
            }
            else if (o is String)
            {
                try
                {
                    return Int64.Parse((String)o);
                }
                catch
                {
                }
            }

            return null;
        }

        public Double? GetDouble(String key)
        {
            Int32 ordinal = rs_.Columns.IndexOf(key);
            Object o = (Object)result_.ItemArray[ordinal];

            if (o == null)
            {
                return null;
            }
            else if (o is Decimal)
            {
                return Decimal.ToDouble((Decimal)o);
            }
            else if (o is String)
            {
                try
                {
                    return Double.Parse((String)o);
                }
                catch
                {
                }
            }

            return null;
        }

        public DateTime? GetDate(String key)
        {
            Int32 ordinal = rs_.Columns.IndexOf(key);
            Object o = (Object)result_.ItemArray[ordinal];

            if (o == null)
            {
                return null;
            }
            else if (o is DateTime)
            {
                return (DateTime)o;
            }

            return null;
        }

        #endregion
    }
}
