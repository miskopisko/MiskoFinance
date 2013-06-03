using MPersist.Core.Message;
using System;

namespace MPersist.Core.Debug
{
    public class MessageTiming
    {
        private static Logger Log = Logger.GetInstance(typeof(MessageTiming));

        #region Variable Declarations

        private DateTime StartTime_ = DateTime.Now;

        #endregion

        #region Properties

        public AbstractMessage Message { get; set; }
        public String MessageName { get { return Message.GetType().Name; } }
        public DateTime StartTime { get { return StartTime_; } }
        public DateTime EndTime { get; set; }
        public SqlTimings<SqlTiming> SqlTimings { get; set; }
        public Double TotalMessageTime { get { return Math.Round(EndTime.Subtract(StartTime).TotalSeconds, 4); } }
        public Double TotalSqlTime { get { return Math.Round(SqlTimings.TotalExecutionTime.TotalSeconds, 4); } }
        public Double PercentSql { get { return Math.Round(TotalSqlTime / TotalMessageTime * 100, 4); } }
        public Int32 TotalSqlCalls { get { return SqlTimings.Count; } }

        #endregion

        #region Constructors

        public MessageTiming()
        {
        }

        public MessageTiming(AbstractMessage message)
        {
            StartTime_ = DateTime.Now;
            Message = message;
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        

        #endregion
    }
}