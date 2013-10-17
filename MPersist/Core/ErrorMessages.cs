using System;
using MPersist.Data;
using MPersist.Enums;

namespace MPersist.Core
{
    public class ErrorMessages : AbstractViewedDataList<ErrorMessage>
    {
        private static Logger Log = Logger.GetInstance(typeof(ErrorMessages));

        #region Fields



        #endregion

        #region Properties

        

        #endregion

        #region Constructors



        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public Boolean Contains(ErrorLevel level)
        {
            if (level != null && Count > 0)
            {
                foreach (ErrorMessage message in this)
                {
                    if (message.Level.Equals(level))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public ErrorMessages ListOf(ErrorLevel level)
        {
            ErrorMessages list = new ErrorMessages();

            if (level != null && Count > 0)
            {
                foreach (ErrorMessage message in this)
                {
                    if (message.Level.Equals(level))
                    {
                        list.Add(message);
                    }
                }
            }

            return list;
        }

        #endregion

        #region XML Serialixation



        #endregion
    }
}
