using System;
using MPersist.Core;
using System.Data.SQLite;
using System.Reflection;
using MPersist.Core.Data;

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
                    result += (i == 0 ? " WHERE " : "   AND ") + Parameters[i].ParameterName + " = ?";

                    // Add the paramter to the command
                    ((SQLiteCommand)command_).Parameters.AddWithValue("@param_" + i, parameters_[i].Value);
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
                    else if (properties[i].Name.Equals("ID",StringComparison.OrdinalIgnoreCase))
                    {
                        Parameters.AddNew(properties[i].Name, DBNull.Value);
                    }
                    else
                    {
                        Parameters.AddNew(properties[i].Name, properties[i].GetValue(clazz, null));
                    }

                    // Add the parameter to the command
                    ((SQLiteCommand)command_).Parameters.AddWithValue("@" + parameters_[i].ParameterName.ToLower(), parameters_[i].Value);
                }

                result += ");" + Environment.NewLine;
                result += "SELECT LAST_INSERT_ROWID() AS ID;";
            }

            return result;
        }

        #endregion
    }
}
