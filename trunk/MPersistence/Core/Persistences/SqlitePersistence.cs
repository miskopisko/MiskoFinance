using System;
using MPersist.Core;
using System.Data.SQLite;
using System.Reflection;

namespace MPersistence.Core.Persistences
{
    class SqlitePersistence : Persistence
    {
        private static Logger Log = Logger.GetInstance(typeof(SqlitePersistence));

        #region Variable Declarations



        #endregion

        #region Properties



        #endregion

        #region Constructors

        public SqlitePersistence(Session session) : base(session)
        {
            command_ = ((SQLiteConnection)session_.Connection).CreateCommand();
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
                    result += (i == 0 ? " WHERE " : "   AND ") + Parameters[i].ParameterName + " = ?";
                }

                Int32 end = 0;
                Int32 position = 0;

                while ((end = result.IndexOf("?")) > 0) // Replace typical ? marks with @param_ values
                {
                    result = result.Substring(0, end) + ("@param_" + position++) + result.Substring(end + 1);
                    end = -1;
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
                ((SQLiteCommand)command_).Parameters.AddWithValue("@param_" + i, parameters_[i].Value);
            }
        }
    }
}
