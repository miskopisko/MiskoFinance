using System;
using MPersist.Core;
using System.Reflection;
using System.Data.OracleClient;

namespace MPersistence.Core.Persistences
{
    class OraclePersistence : Persistence
    {
        private static Logger Log = Logger.GetInstance(typeof(OraclePersistence));

        #region Variable Declarations



        #endregion

        #region Properties



        #endregion

        #region Constructors

        public OraclePersistence(Session session) : base(session)
        {
            command_ = ((OracleConnection)session_.Connection).CreateCommand();
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods



        #endregion

        protected override String GenerateSelectStatement(Type clazz)
        {
            String result = "";

            if (clazz != null)
            {
                result += "SELECT ";

                PropertyInfo[] properties = clazz.GetProperties();
                for (int i = 0; i < properties.Length; i++)
                {
                    result += properties[i].Name.ToUpper() + (i + 1 < properties.Length ? ", " : "");
                }

                result += Environment.NewLine;
                result += "  FROM " + clazz.Name;

                for (Int32 i = 0; Parameters != null && i < Parameters.Count; i++)
                {
                    result += Environment.NewLine;
                    result += (i == 0 ? " WHERE " : "   AND ") + Parameters[i].ParameterName + " = :param" + i;
                }
            }

            return result;
        }

        protected override String GenerateUpdateStatement(Type clazz)
        {
            throw new NotImplementedException();
        }

        protected override String GenerateDeleteStatement(Type clazz)
        {
            throw new NotImplementedException();
        }

        protected override String GenerateInsertStatement(Type clazz)
        {
            throw new NotImplementedException();
        }

        protected override void AddParameters()
        {
            for (int i = 0; i < parameters_.Count; i++)
            {
                ((OracleCommand)command_).Parameters.AddWithValue(":param" + i, parameters_[i].Value);
            }
        }
    }
}
