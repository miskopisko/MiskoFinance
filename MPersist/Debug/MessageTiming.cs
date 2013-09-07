using System;
using MPersist.Core;
using MPersist.Message;

namespace MPersist.Debug
{
    public class MessageTiming
    {
        private static Logger Log = Logger.GetInstance(typeof(MessageTiming));

        #region Fields

        private DateTime mStartTime_ = DateTime.Now;

        #endregion

        #region Properties

        public String MessageName { get; set; }
        public DateTime StartTime { get { return mStartTime_; } set { mStartTime_ = value; } }
        public DateTime EndTime { get; set; }
        public SqlTimings<SqlTiming> SqlTimings { get; set; }
        public Double TotalMessageTime { get { return Math.Round(EndTime.Subtract(StartTime).TotalSeconds, 4); } set { return; } }
        public Double TotalSqlTime { get { return Math.Round(SqlTimings.TotalExecutionTime.TotalSeconds, 4); } set { return; } }
        public Double PercentSql { get { return Math.Round(TotalSqlTime / TotalMessageTime * 100, 4); } set { return; } }
        public Int32 TotalSqlCalls { get { return SqlTimings.Count; } set { return; } }

        #endregion

        #region Constructors

        public MessageTiming()
        {
        }

        public MessageTiming(MessageWrapper message)
        {
            mStartTime_ = DateTime.Now;
            MessageName = message.GetType().Name;
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        

        #endregion
    }
}
