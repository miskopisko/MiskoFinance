using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Reflection;
using MPersist.Core.Data;
using MPersist.Core.Enums;
using MPersist.Core.MoneyType;
using MPersist.Core.Persistences;
using MPersist.Core.Resources;
using MPersist.Resources.Enums;
using MySql.Data.MySqlClient;
using Oracle.DataAccess.Client;

namespace MPersist.Core
{
    public abstract class Persistence
    {
        private static Logger Log = Logger.GetInstance(typeof(Persistence));

        #region Variable Declarations

        protected Session session_ = null;
        protected DataTable rs_ = new DataTable();
        protected DbCommand command_ = null;
        protected String sql_ = "";
        protected List<Object> parameters_ = new List<Object>();
        
        private DataRow result_;
        private Int32 currentResult_ = 0;
        
        #endregion

        #region Properties

        public String SQL
        {
            get { return sql_; }
        }

        public Boolean HasNext
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
            command_.Transaction = session.Transaction;
        }

        #endregion

        #region Public Methods

        public static Persistence GetInstance(Session session)
        {
            if(session.Connection is OracleConnection)
            {
                return new OraclePersistence(session);
            }
            else if(session.Connection is MySqlConnection)
            {
                return new MySqlPersistence(session);
            }
            else if (session.Connection is SQLiteConnection)
            {
                return new SqlitePersistence(session);
            }
            else
            {
                session.Error(typeof(Persistence), MethodInfo.GetCurrentMethod(), ErrorLevel.Error, ErrorStrings.errInvalicConnectionType);
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

        public void SetSql(String sql)
        {
            sql_ = sql;
        }

        public void SqlWhere(bool condition, String expression, Object[] value)
        {
            if (condition)
            {
                sql_ = sql_ + Environment.NewLine + (!sql_.Contains("WHERE") ? "WHERE " : "AND ") + expression;
                foreach (Object item in value)
                {
                    parameters_.Add(item);
                }
            }
        }

        public void SqlOrderBy(String columnName)
        {
            SqlOrderBy(columnName, SortDirection.Ascending);
        }

        public void SqlOrderBy(String columnName, SortDirection sortDirection)
        {
            sql_ = sql_ + (!sql_.Contains("ORDER BY") ? Environment.NewLine + "ORDER BY " : ", ") + columnName + sortDirection.Code;
        }

        #endregion

        #region Execute Methods

        public Int64 ExecuteUpdate(AbstractStoredData clazz)
        {
            session_.PersistencePool.Add(this);

            GenerateUpdateStatement(clazz);
            
            if(command_.ExecuteNonQuery() == 0)
            {
                session_.Error(GetType(), MethodInfo.GetCurrentMethod(), ErrorLevel.Error, ErrorStrings.errLockKeyFailed, new Object[] { clazz.GetType().Name });
            }

            return clazz.RowVer++;
        }

        public Int64 ExecuteInsert(AbstractStoredData clazz)
        {
            session_.PersistencePool.Add(this);

            GenerateInsertStatement(clazz);

            Int64 newId = 0;

            if (command_ is MySqlCommand || command_ is SQLiteCommand)
            {
                newId = Int64.Parse(command_.ExecuteScalar().ToString());
            }
            else if (command_ is OracleCommand)
            {
                OracleParameter lastId = new OracleParameter();
                lastId.ParameterName = ":LASTID";
                lastId.DbType = DbType.Decimal;
                lastId.Direction = ParameterDirection.Output;
                ((OracleCommand)command_).Parameters.Add(lastId);

                command_.ExecuteNonQuery();

                newId = Convert.ToInt64(lastId.Value);
            }

            return session_.MessageMode.Equals(MessageMode.Normal) ? newId : 0;
        }

        public bool ExecuteDelete(AbstractStoredData clazz)
        {
            session_.PersistencePool.Add(this);

            GenerateDeleteStatement(clazz);

            if (command_.ExecuteNonQuery() == 0)
            {
                session_.Error(GetType(), MethodInfo.GetCurrentMethod(), ErrorLevel.Error, ErrorStrings.errLockKeyFailed, new Object[] { GetType().Name });
            }

            return true;
        }                

        public bool ExecuteQuery()
        {
            if (String.IsNullOrEmpty(sql_))
            {
                session_.Error(GetType(), MethodInfo.GetCurrentMethod(), ErrorLevel.Error, ErrorStrings.errSqlNotSet);
            }

            return ExecuteQuery(sql_, parameters_.ToArray());
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

            return HasNext;
        }

        public static bool ExecuteUpdate(Session session, String sql)
        {
            return ExecuteUpdate(session, sql, null);
        }

        public static bool ExecuteUpdate(Session session, String sql, Object[] values)
        {
            Persistence p = Persistence.GetInstance(session);
            bool result = p.ExecuteQuery(sql, values);
            p.Close();
            p = null;

            return result;
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

            Type t = o.GetType();

            if (o == null)
            {
                return null;
            }
            else if (o is Int16)
            {
                return Convert.ToInt64((Int16)o);
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

        public Money GetMoney(String key)
        {
            Decimal? value = GetDecimal(key);

            if (value.HasValue)
            {
                return new Money(value.Value);
            }

            return null;
        }

        public Money GetMoney(String key, Money defaultValue)
        {
            Decimal? value = GetDecimal(key);

            if (value.HasValue)
            {
                return new Money(value.Value);
            }

            return defaultValue;
        }

        public Decimal? GetDecimal(String key)
        {
            Double? value = GetDouble(key);

            if (value.HasValue)
            {
                return Convert.ToDecimal(value);
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
            else if (o is Double)
            {
                return (Double)o;
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
            try
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
            }
            catch (Exception)
            {
                return null;
            }            

            return null;
        }

        #endregion
    }
}
