using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;

namespace MPersistence.Core
{
    public abstract class Persistence
    {
        #region Variable Declarations

        public static readonly int TIMEOUT = 300;

        private Session session_ = null;
        private DbDataReader rs_ = null;
        private DbCommand command_ = null;
        private String sql_ = "";
	    private List<Object> parameters_ = new List<Object>();
        
        private static readonly Int32 SQLType_SQL_ = 0;
	    private static readonly Int32 SQLType_PROCEDURE_ = 1;
	    private static readonly Int32 SQLType_FUNCTION_ = 2;

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

            command_.CommandText = sql_;
            perepareParameters();

            command_.Prepare();

            return command_.ExecuteNonQuery();
        }

        private void perepareParameters()
        {
            //command_.Parameters.Add(new DbParameter());
        }

    }
}
