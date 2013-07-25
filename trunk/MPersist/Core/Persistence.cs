using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
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

        #region Fields

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
            else if (session.Connection is OleDbConnection)
            {
                return new FoxProPersistence(session);
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

        public Boolean Next()
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

        public Boolean ExecuteQuery()
        {
            if (String.IsNullOrEmpty(mSql_))
            {
                mSession_.Error(ErrorLevel.Error, ErrorStrings.errSqlNotSet);
            }

            return ExecuteQuery(mSql_, mParameters_.ToArray());
        }

        public Boolean ExecuteQuery(String sql)
        {
            return ExecuteQuery(sql, new Object[]{});
        }

        public Boolean ExecuteQuery(String sql, Object[] parameters)
        {
            mSession_.PersistencePool.Add(this);

            mSql_ = sql;
            mParameters_ = new List<object>(parameters);

            mCommand_.CommandText = mSql_;
            SetParameters(parameters);

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
            else if (mCommand_ is OleDbCommand)
            {
                adapter = new OleDbDataAdapter((OleDbCommand)mCommand_);
            }

            DateTime startTime = DateTime.Now;
            adapter.Fill(mRs_);
            mSession_.SqlTimings.Add(new SqlTiming(mCommand_.CommandText, mCommand_.Parameters, startTime));

            return HasNext;
        }

        public static Int32 ExecuteUpdate(Session session, String sql)
        {
            return ExecuteUpdate(session, sql, null);
        }

        public static Int32 ExecuteUpdate(Session session, String sql, Object[] parameters)
        {
            Persistence persistence = Persistence.GetInstance(session);
            Int32 result = persistence.ExecuteUpdate(sql, parameters);
            persistence.Close();
            persistence = null;
            return result;
        }

        public static Int64 ExecuteUpdate(Session session, StoredData clazz, Type type)
        {
            Persistence persistence = Persistence.GetInstance(session);
            Int64 result = persistence.ExecuteUpdate(clazz, type);
            persistence.Close();
            persistence = null;
            return result;
        }
        
        public static PrimaryKey ExecuteInsert(Session session, StoredData clazz, Type type)
        {
            Persistence persistence = Persistence.GetInstance(session);
            PrimaryKey result = persistence.ExecuteInsert(clazz, type);
            persistence.Close();
            persistence = null;
            return result;
        }        

        public static Boolean ExecuteDelete(Session session, StoredData clazz, Type type)
        {
            Persistence persistence = Persistence.GetInstance(session);
            bool result = persistence.ExecuteDelete(clazz, type);
            persistence.Close();
            persistence = null;
            return result;
        }

        #endregion

        #region Private Methods

        private PrimaryKey ExecuteInsert(StoredData clazz, Type type)
        {
            mSession_.PersistencePool.Add(this);

            GenerateInsertStatement(clazz, type);

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
            else if (mCommand_ is OleDbCommand)
            {
                // FoxPro INSERT is done on a class by class basis by overriding the Create method
            }

            return mSession_.MessageMode.Equals(MessageMode.Normal) ? newId : clazz.Id;
        }

        private Int64 ExecuteUpdate(StoredData clazz, Type type)
        {
            mSession_.PersistencePool.Add(this);

            GenerateUpdateStatement(clazz, type);

            DateTime startTime = DateTime.Now;
            int result = mCommand_.ExecuteNonQuery();
            mSession_.SqlTimings.Add(new SqlTiming(mCommand_.CommandText, mCommand_.Parameters, startTime));

            if (result == 0)
            {
                mSession_.Error(ErrorLevel.Error, ErrorStrings.errLockKeyFailed, new Object[] { clazz.GetType().Name });
            }

            Int64 newRowVer = clazz.RowVer;
            Persistence persistence = Persistence.GetInstance(mSession_);
            persistence.ExecuteQuery("SELECT ROWVER FROM " + clazz.GetType().Name + " WHERE ID = ?", new Object[] { clazz.Id });
            if (persistence.Next())
            {
                newRowVer = persistence.GetLong("ROWVER").Value;
            }
            persistence.Close();
            persistence = null;

            return newRowVer;
        }

        private Boolean ExecuteDelete(StoredData clazz, Type type)
        {
            mSession_.PersistencePool.Add(this);

            GenerateDeleteStatement(clazz, type);

            DateTime startTime = DateTime.Now;
            int result = mCommand_.ExecuteNonQuery();
            mSession_.SqlTimings.Add(new SqlTiming(mCommand_.CommandText, mCommand_.Parameters, startTime));

            if (result == 0)
            {
                mSession_.Error(ErrorLevel.Error, ErrorStrings.errLockKeyFailed, new Object[] { GetType().Name });
            }

            return true;
        }

        private Int32 ExecuteUpdate(String sql, Object[] parameters)
        {
            mSession_.PersistencePool.Add(this);

            mSql_ = sql;
            mParameters_ = new List<object>(parameters);

            mCommand_.CommandText = mSql_;
            SetParameters(parameters);

            DateTime startTime = DateTime.Now;
            int result = mCommand_.ExecuteNonQuery();
            mSession_.SqlTimings.Add(new SqlTiming(mCommand_.CommandText, mCommand_.Parameters, startTime));

            return result;
        }

        #endregion

        #region Abstract Methods

        protected abstract void SetParameters(Object[] value);
        protected abstract void GenerateUpdateStatement(StoredData clazz, Type type);
        protected abstract void GenerateDeleteStatement(StoredData clazz, Type type);
        protected abstract void GenerateInsertStatement(StoredData clazz, Type type);

        #endregion

        #region Private Helpers

        private Object GetObject(String key)
        {
            Int32 ordinal = mRs_.Columns.IndexOf(key);
            if (ordinal >= 0)
            {
                return (Object)mResult_.ItemArray[ordinal];
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region Public Helpers

        public PrimaryKey GetPrimaryKey(String key)
        {
            Int64? value = GetLong(key);
            if (value != null && value.HasValue)
            {
                return new PrimaryKey(value.Value);
            }
            else
            {
                return null;
            }
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

        public String GetString(String key)
        {
            Object o = GetObject(key);

            if (o is String)
            {
                return ((String)o).Trim();
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
            Object o = GetObject(key);

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
            Object o = GetObject(key);

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
            Object o = GetObject(key);

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
            Object o = GetObject(key);

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

        public Boolean? GetBoolean(String key)
        {
            Object o = GetObject(key);

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

        #endregion
    }
}
