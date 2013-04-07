using System;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Reflection;
using MPersist.Core.Data;
using MPersist.Core.Persistences;
using MPersist.Resources.Enums;
using MySql.Data.MySqlClient;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace MPersist.Core
{
    public abstract class Persistence
    {
        #region Variable Declarations

        protected Session session_ = null;
        protected DataTable rs_ = new DataTable();
        protected DbCommand command_ = null;
        
        private DataRow result_;
        private Int32 currentResult_ = 0;
        
        #endregion

        #region Properties

        private Boolean HasNext
        {
            get { return rs_ != null && currentResult_ < rs_.Rows.Count; }
        }

        public Int32 RecordCount
        {
            get { return rs_ != null ? rs_.Rows.Count : 0; }
        }
       
        #endregion

        #region Constructors

        public Persistence(Session session)
        {
            session_ = session;
            command_ = session_.Connection.CreateCommand();
        }

        #endregion

        #region Public Methods

        public static Persistence GetInstance(Session session)
        {
            if(session.SessionType.Equals(SqlSessionType.Oracle))
            {
                return new OraclePersistence(session);
            }
            else if(session.SessionType.Equals(SqlSessionType.MySql))
            {
                return new MySqlPersistence(session);
            }
            else if (session.SessionType.Equals(SqlSessionType.Sqlite))
            {
                return new SqlitePersistence(session);
            }
            else
            {
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
                session_.PersistencePool.Remove(this);
            }
        }

        public bool Next()
        {
            if (HasNext)
            {
                result_ = rs_.Rows[currentResult_];
                currentResult_++;
                return true;
            }

            return false;
        }

        #endregion

        #region Execute Methods

        public bool ExecuteUpdate(AbstractStoredData clazz)
        {
            session_.PersistencePool.Add(this);

            GenerateUpdateStatement(clazz);
            
            try
            {
                return command_.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                Close();
                session_.Error(GetType(), MethodInfo.GetCurrentMethod(), ErrorLevel.Critical, e.Message);
            }

            return false;
        }

        public int ExecuteInsert(AbstractStoredData clazz)
        {
            session_.PersistencePool.Add(this);

            GenerateInsertStatement(clazz);

            try
            {
                if (command_ is MySqlCommand || command_ is SQLiteCommand)
                {
                    return Int32.Parse(command_.ExecuteScalar().ToString());
                }
                else if (command_ is OracleCommand)
                {
                    OracleParameter lastId = new OracleParameter(":LASTID", OracleDbType.Int16, ParameterDirection.Output);
                    ((OracleCommand)command_).Parameters.Add(lastId);

                    command_.ExecuteNonQuery();

                    return ((OracleDecimal)lastId.Value).ToInt32();
                }
            }
            catch (Exception e)
            {
                Close();
                session_.Error(GetType(), MethodInfo.GetCurrentMethod(), ErrorLevel.Critical, e.Message);
            }

            return -1;
        }

        public bool ExecuteDelete(AbstractStoredData clazz)
        {
            session_.PersistencePool.Add(this);

            GenerateDeleteStatement(clazz);

            try
            {
                return command_.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                Close();
                session_.Error(GetType(), MethodInfo.GetCurrentMethod(), ErrorLevel.Critical, e.Message);
            }

            return false;
        }

        public bool ExecuteQuery(String sql)
        {
            return ExecuteQuery(sql, new Object[]{});
        }

        public bool ExecuteQuery(String sql, Object[] values)
        {
            session_.PersistencePool.Add(this);

            command_.CommandText = sql;
            SetParameters(values);

            try
            {
                DbDataAdapter adapter = null;

                if (command_ is OracleCommand)
                {
                    adapter = new OracleDataAdapter((OracleCommand)command_);
                }
                else if (command_ is MySqlCommand)
                {
                    adapter = new MySqlDataAdapter((MySqlCommand)command_);
                }
                else if (command_ is SQLiteCommand)
                {
                    adapter = new SQLiteDataAdapter((SQLiteCommand)command_);
                }

                adapter.Fill(rs_);
            }
            catch (Exception e)
            {
                Close();
                session_.Error(GetType(), MethodInfo.GetCurrentMethod(), ErrorLevel.Critical, e.Message);
            }

            return HasNext;
        }

        #endregion

        #region Abstract Methods

        protected abstract void SetParameters(Object[] value);
        protected abstract void GenerateUpdateStatement(AbstractStoredData clazz);
        protected abstract void GenerateDeleteStatement(AbstractStoredData clazz);
        protected abstract void GenerateInsertStatement(AbstractStoredData clazz);

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
