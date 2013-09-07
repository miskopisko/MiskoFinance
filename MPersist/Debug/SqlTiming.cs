using System;
using System.Data.Common;
using MPersist.Core;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace MPersist.Debug
{
    public class SqlTiming
    {
        private static Logger Log = Logger.GetInstance(typeof(SqlTiming));

        #region Fields

        private String mSQL_;
        private DbParameterCollection mParameters_;
        private TimeSpan mExecutionTime_;

        #endregion

        #region Properties

        public String SQL { get { return mSQL_;} }

        [JsonIgnore]
        [XmlIgnore]
        public DbParameterCollection Parameters { get { return mParameters_; } }
        public TimeSpan ExecutionTime { get { return mExecutionTime_; } }
        public Double TotalExecutionTime { get { return Math.Round(mExecutionTime_.TotalSeconds, 4); } }

        [JsonIgnore]
        [XmlIgnore]
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

        [JsonIgnore]
        [XmlIgnore]
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

        public SqlTiming()
        {
        }

        public SqlTiming(String sql, DbParameterCollection parameters, DateTime start)
        {
            mSQL_ = sql;
            mParameters_ = parameters;
            mExecutionTime_ = DateTime.Now.Subtract(start);
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods



        #endregion
    }
}
