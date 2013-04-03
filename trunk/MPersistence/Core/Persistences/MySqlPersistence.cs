using System;
using MPersist.Core;
using System.Reflection;
using MySql.Data.MySqlClient;
using MPersist.Core.Data;

namespace MPersistence.Core.Persistences
{
    class MySqlPersistence : Persistence
    {
        private static Logger Log = Logger.GetInstance(typeof(MySqlPersistence));

        #region Variable Declarations



        #endregion

        #region Properties



        #endregion

        #region Constructors

        public MySqlPersistence(Session session) : base(session)
        {
            command_ = ((MySqlConnection)session_.Connection).CreateCommand();
        }

        #endregion

        #region Private Methods



        #endregion

        #region Public Methods

        protected override String GenerateSelectStatement(Type clazz)
        {
            String result = "";

            if (clazz != null && clazz.IsSubclassOf(typeof(AbstractStoredData)))
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
                    result += (i == 0 ? " WHERE " : "   AND ") + Parameters[i].ParameterName + " = @param_" + i;

                    // Add the parameter to the command
                    ((MySqlCommand)command_).Parameters.AddWithValue("@param_" + i, parameters_[i].Value);
                }
            }

            return result;
        }

        protected override String GenerateUpdateStatement(AbstractStoredData clazz)
        {
            throw new NotImplementedException();
        }

        protected override String GenerateDeleteStatement(AbstractStoredData clazz)
        {
            throw new NotImplementedException();
        }

        protected override String GenerateInsertStatement(AbstractStoredData clazz)
        {
            String result = "";

            if (clazz != null)
            {
                result += "INSERT INTO " + clazz.GetType().Name + " (";

                PropertyInfo[] properties = clazz.GetType().GetProperties();
                for (int i = 0; i < properties.Length; i++)
                {
                    result += properties[i].Name.ToUpper() + (i + 1 < properties.Length ? ", " : "");
                }

                result += ")" + Environment.NewLine + "VALUES (";
                for (int i = 0; i < properties.Length; i++)
                {
                    result += "@" + properties[i].Name.ToLower() + (i + 1 < properties.Length ? ", " : "");

                    if (properties[i].PropertyType.IsSubclassOf(typeof(Enum)) && (Int32)properties[i].GetValue(clazz, null) < 0)
                    {
                        Parameters.AddNew(properties[i].Name, DBNull.Value);
                    }
                    else
                    {
                        Parameters.AddNew(properties[i].Name, properties[i].GetValue(clazz, null));
                    }

                    // Add the parameter to the command
                    ((MySqlCommand)command_).Parameters.AddWithValue("@" + parameters_[i].ParameterName.ToLower(), parameters_[i].Value);
                }

                result += ");" + Environment.NewLine;
                result += "SELECT LAST_INSERT_ID() AS ID;";
            }

            return result;
        }

        #endregion
    }
}
