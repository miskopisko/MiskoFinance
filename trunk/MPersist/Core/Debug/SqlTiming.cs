using System;
using System.Data.Common;

namespace MPersist.Core.Debug
{
    public class SqlTiming
    {
        private static Logger Log = Logger.GetInstance(typeof(SqlTiming));

        #region Variable Declarations

        private String SQL_;
        private DbParameterCollection Parameters_;
        private TimeSpan ExecutionTime_;

        #endregion

        #region Properties

        public String SQL { get { return SQL_;} }
        public DbParameterCollection Parameters { get { return Parameters_; } }
        public TimeSpan ExecutionTime { get { return ExecutionTime_; } }
        public Double TotalExecutionTime { get { return Math.Round(ExecutionTime_.TotalSeconds, 4); } }

        public String ParametersString
        {
            get
            {
                String result = "[";

                foreach (DbParameter item in Parameters)
                {
                    result += item.Value.ToString() + ", ";
                }

                if (result.EndsWith(", "))
                {
                    result = result.Substring(0, result.Length - 2);
                }

                return result + "]";
            }
        }

        public String FormattedSql
        {
            get
            {
                String result = SQL;

                foreach (DbParameter item in Parameters)
                {
                    result = result.Replace(item.ParameterName, item.Value.ToString());
                }

                return result;
            }
        }

        #endregion

        #region Constructors

        public SqlTiming(String sql, DbParameterCollection parameters, DateTime start)
        {
            SQL_ = sql;
            Parameters_ = parameters;
            ExecutionTime_ = DateTime.Now.Subtract(start);
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods



        #endregion
    }
}
