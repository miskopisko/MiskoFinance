using System;
using MPersist.Core;
using MPersist.Core.Attributes;
using MPFinance.Core.Enums;
using MPersist.Core.Data;

namespace MPFinance.Core.Data
{
    public class Client : AbstractStoredData
    {
        private static Logger Log = Logger.GetInstance(typeof(Client));

        #region Variable Declarations



        #endregion

        #region Properties

        [Stored]
        public String FirstName { get; set; }
        [Stored]
        public String LastName { get; set; }
        [Stored]
        public String Email { get; set; }
        [Stored]
        public DateTime? Birthday { get; set; }
        [Stored]
        public Gender Gender { get; set; }

        #endregion

        #region Constructors



        #endregion

        #region Private Methods



        #endregion

        #region Public Methods



        #endregion
    }
}
