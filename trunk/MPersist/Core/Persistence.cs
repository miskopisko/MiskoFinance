using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using MPersist.Core.Data;
using MPersist.Core.Debug;
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

        protected Session mSession_ = null;
        protected DataTable mRs_ = new DataTable();
        protected DbCommand mCommand_ = null;
        protected String mSql_ = "";
        protected List<Object> mParameters_ = new List<Object>();
        protected DataRow mResult_;
        protected Int32 mCurrentResult_ = 0;
        
        #endregion

        #region Properties

        public Boolean HasNext { get { return mRs_ != null && mCurrentResult_ < mRs_.Rows.Count; } }
        public Int32 RecordCount { get { return mRs_ != null ? mRs_.Rows.Count : 0; } }
       
        #endregion

        #region Constructors

        public Persistence(Session session)
        {
            mSession_ = session;            
            mCommand_ = mSession_.Connection.CreateCommand();
            mCommand_.Transaction = session.Transaction;
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
                session.Error(ErrorLevel.Error, ErrorStrings.errInvalicConnectionType);
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
                    if (mRs_ != null)
                    {
                        mRs_ = null;
                    }
                }
                catch (Exception ex)
                {
                    e = ex;
                    mRs_ = null;
                }

                try
                {
                    if (mCommand_ != null)
                    {
                        mCommand_.Dispose();
                        mCommand_ = null;
                    }
                }
                catch (Exception ex)
                {
                    if (e == null)
                    {
                        e = ex;
                    }
                    mCommand_ = null;
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
                mSession_.PersistencePool.Remove(this);
            }
        }

        public bool Next()
        {
            if (HasNext)
            {
                mResult_ = mRs_.Rows[mCurrentResult_];
                mCurrentResult_++;
                return true;
            }

            return false;
        }

        public void SetSql(String sql)
        {
            mSql_ = sql;
        }

        public void SqlWhere(bool condition, String expression, Object[] value)
        {
            if (condition)
            {
                mSql_ = mSql_ + Environment.NewLine + (!mSql_.Contains("WHERE") ? "WHERE " : "AND ") + expression;
                foreach (Object item in value)
                {
                    mParameters_.Add(item);
                }
            }
        }

        public void SqlOrderBy(String columnName)
        {
            SqlOrderBy(columnName, SortDirection.Ascending);
        }

        public void SqlOrderBy(String columnName, SortDirection sortDirection)
        {
            mSql_ = mSql_ + (!mSql_.Contains("ORDER BY") ? Environment.NewLine + "ORDER BY " : ", ") + columnName + sortDirection.Code;
        }

        #endregion

        #region Execute Methods

        public PrimaryKey ExecuteInsert(AbstractStoredData clazz, Type subType)
        {
            mSession_.PersistencePool.Add(this);

            GenerateInsertStatement(clazz, subType);

            PrimaryKey newId = new PrimaryKey();

            if (mCommand_ is MySqlCommand || mCommand_ is SQLiteCommand)
            {
                DateTime startTime = DateTime.Now;
                newId = new PrimaryKey(mCommand_.ExecuteScalar().ToString());
                mSession_.SqlTimings.Add(new SqlTiming(mCommand_.CommandText, mCommand_.Parameters, startTime));
            }
            else if (mCommand_ is OracleCommand)
            {
                OracleParameter lastId = new OracleParameter();
                lastId.ParameterName = ":LASTID";
                lastId.DbType = DbType.Decimal;
                lastId.Direction = ParameterDirection.Output;
                ((OracleCommand)mCommand_).Parameters.Add(lastId);

                DateTime startTime = DateTime.Now;
                mCommand_.ExecuteNonQuery();
                mSession_.SqlTimings.Add(new SqlTiming(mCommand_.CommandText, mCommand_.Parameters, startTime));

                newId = new PrimaryKey(Convert.ToInt64(lastId.Value));
            }

            return mSession_.MessageMode.Equals(MessageMode.Normal) ? newId : clazz.Id;
        }

        public bool ExecuteUpdate(AbstractStoredData clazz, Type subType)
        {
            mSession_.PersistencePool.Add(this);

            GenerateUpdateStatement(clazz, subType);

            DateTime startTime = DateTime.Now;
            int result = mCommand_.ExecuteNonQuery();
            mSession_.SqlTimings.Add(new SqlTiming(mCommand_.CommandText, mCommand_.Parameters, startTime));

            if(result == 0)
            {
                mSession_.Error(ErrorLevel.Error, ErrorStrings.errLockKeyFailed, new Object[] { clazz.GetType().Name });
            }

            return true;
        }

        public bool ExecuteDelete(AbstractStoredData clazz, Type subType)
        {
            mSession_.PersistencePool.Add(this);

            GenerateDeleteStatement(clazz, subType);

            DateTime startTime = DateTime.Now;
            int result = mCommand_.ExecuteNonQuery();
            mSession_.SqlTimings.Add(new SqlTiming(mCommand_.CommandText, mCommand_.Parameters, startTime));

            if (result == 0)
            {
                mSession_.Error(ErrorLevel.Error, ErrorStrings.errLockKeyFailed, new Object[] { GetType().Name });
            }

            return true;
        }                

        public bool ExecuteQuery()
        {
            if (String.IsNullOrEmpty(mSql_))
            {
                mSession_.Error(ErrorLevel.Error, ErrorStrings.errSqlNotSet);
            }

            return ExecuteQuery(mSql_, mParameters_.ToArray());
        }
        
        public bool ExecuteQuery(String sql)
        {
            return ExecuteQuery(sql, new Object[]{});
        }

        public bool ExecuteQuery(String sql, Object[] values)
        {
            mSession_.PersistencePool.Add(this);

            mCommand_.CommandText = sql;
            SetParameters(values);

            DbDataAdapter adapter = null;

            if (mCommand_ is OracleCommand)
            {
                adapter = new OracleDataAdapter((OracleCommand)mCommand_);
            }
            else if (mCommand_ is MySqlCommand)
            {
                adapter = new MySqlDataAdapter((MySqlCommand)mCommand_);
            }
            else if (mCommand_ is SQLiteCommand)
            {
                adapter = new SQLiteDataAdapter((SQLiteCommand)mCommand_);
            }

            DateTime startTime = DateTime.Now;
            adapter.Fill(mRs_);
            mSession_.SqlTimings.Add(new SqlTiming(mCommand_.CommandText, mCommand_.Parameters, startTime));

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
        protected abstract void GenerateUpdateStatement(AbstractStoredData clazz, Type type);
        protected abstract void GenerateDeleteStatement(AbstractStoredData clazz, Type type);
        protected abstract void GenerateInsertStatement(AbstractStoredData clazz, Type type);

        #endregion

        #region Helpers

        public Boolean? GetBoolean(String key)
        {
            Int32 ordinal = mRs_.Columns.IndexOf(key);
            Object o = (Object)mResult_.ItemArray[ordinal];

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
            Int32 ordinal = mRs_.Columns.IndexOf(key);
            Object o = (Object)mResult_.ItemArray[ordinal];

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

        public PrimaryKey GetPrimaryKey(String key)
        {
            Int64? value = GetLong(key);
            if(value != null && value.HasValue)
            {
                return new PrimaryKey(value.Value);
            }
            else
            {
                return null;
            }            
        }

        public Int32? GetInt(String key)
        {
            Int32 ordinal = mRs_.Columns.IndexOf(key);
            Object o = (Object)mResult_.ItemArray[ordinal];

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
            Int32 ordinal = mRs_.Columns.IndexOf(key);
            Object o = (Object)mResult_.ItemArray[ordinal];

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
            Int32 ordinal = mRs_.Columns.IndexOf(key);
            Object o = (Object)mResult_.ItemArray[ordinal];

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
                Int32 ordinal = mRs_.Columns.IndexOf(key);
                Object o = (Object)mResult_.ItemArray[ordinal];

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
