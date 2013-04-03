using System;
using MPersist.Core;
using MPersist.Resources.Enums;
using MPersist.Core.Data;

namespace MPersist.Security
{
    public class OperatorProfile : AbstractStoredData
    {
        private static Logger Log = Logger.GetInstance(typeof(OperatorProfile));

        #region Variable Declarations



        #endregion

        #region Properties

        public String Name { get; set; }
        public String Email { get; set; }
        public DateTime? Birthday { get; set; }
        public Gender Gender { get; set; }
        public Int32? Age { get; set; }

        #endregion

        #region Constructors

        public OperatorProfile()
        {
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        public static OperatorProfile GetInstance(Session session, Int32 id)
        {
            OperatorProfile result = new OperatorProfile();

            Persistence p = Persistence.GetInstance(session);
            p.Parameters.AddNew("Id", id);
            //p.Parameters.AddNew("Email", "michael@piskuric.ca");
            p.ExecuteSelect(typeof(OperatorProfile));

            if (p.HasRows)
            {
                result.set(p);
            }

            p.Close();
            p = null;

            return result;
        }

        #endregion
    }
}
